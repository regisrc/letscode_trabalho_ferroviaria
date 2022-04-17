using letscode_trabalho_ferroviaria.application.Dtos;
using letscode_trabalho_ferroviaria.domain.Entities;
using letscode_trabalho_ferroviaria.insfrastructure.Repositories;

namespace letscode_trabalho_ferroviaria.application.Services
{
    public class FuncionarioService
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public FuncionarioService(FuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public void Add()
        {
            var funcionarios = GetAll();

            Console.WriteLine("Digite o nome do funcionário");
            var nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome não é válido");
                return;
            }

            var funcionario = new FuncionarioDto(nome);

            if (funcionarios.Any(x => x.Name == funcionario.Name))
            {
                Console.WriteLine("Funcionário já cadastrado");

                return;
            }

            funcionarios.Add(
                funcionario.FromDtoToEntity(funcionario));

            _funcionarioRepository.Add(funcionarios);

            Console.WriteLine("Funcionário cadastrado com sucesso");
        }

        public List<FuncionarioEntity> GetAll() => _funcionarioRepository.GetAll();

        public FuncionarioEntity GetByName(string name) => _funcionarioRepository.GetAll().Find(x => x.Name == name);

        public void PrintAll() => GetAll().ForEach(
            x =>
            {
                Console.WriteLine($"Id: {x.Id}");
                Console.WriteLine($"Nome: {x.Name}\n");
            });

        public void Update()
        {
            var funcionarios = GetAll();

            Console.WriteLine("Digite o nome do funcionário");
            var nome = Console.ReadLine();

            if (!funcionarios.Any(x => x.Name == nome))
            {
                Console.WriteLine("Funcionário não encontrado");
                return;
            }

            Console.WriteLine("Digite o novo nome do funcionário: ");
            var novoNome = Convert.ToString(Console.ReadLine());

            if (string.IsNullOrEmpty(novoNome))
            {
                Console.WriteLine("Nome não é válido");
                return;
            }

            if (funcionarios.Any(x => x.Name == novoNome))
            {
                Console.WriteLine("Funcionário já está cadastrado");
                return;
            }

            foreach (var item in funcionarios.Where(x => x.Name == nome))
            {
                item.Name = novoNome;
            }

            _funcionarioRepository.Add(funcionarios);

            Console.WriteLine("Registro atualizado com sucesso");
        }
    }
}
