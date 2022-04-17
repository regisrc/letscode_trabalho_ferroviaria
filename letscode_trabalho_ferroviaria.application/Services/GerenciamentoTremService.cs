using letscode_trabalho_ferroviaria.domain.Entities;
using letscode_trabalho_ferroviaria.insfrastructure.Repositories;

namespace letscode_trabalho_ferroviaria.application.Services
{
    public class GerenciamentoTremService
    {
        private readonly FuncionarioService _funcionarioService;
        private readonly TremService _tremService;
        private readonly GerenciamentoTremRepository _gerenciamentoTremRepository;

        public GerenciamentoTremService(FuncionarioService funcionarioService, TremService tremService, GerenciamentoTremRepository gerenciamentoTremRepository)
        {
            _funcionarioService = funcionarioService;
            _tremService = tremService;
            _gerenciamentoTremRepository = gerenciamentoTremRepository;
        }

        public void Add()
        {
            var horarios = GetAll();

            Console.WriteLine("Digite a data/hora de chegada");
            var chegada = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a data/hora de saida");
            var saida = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite o nome do trem");
            var trem = _tremService.GetByName(Console.ReadLine());

            Console.WriteLine("Digite o nome do funcionário");
            var funcionario = _funcionarioService.GetByName(Console.ReadLine());

            horarios.Add(
                new GerenciamentoTremEntity(chegada, saida, trem, funcionario));

            _gerenciamentoTremRepository.Add(horarios);

            Console.WriteLine("Horário cadastrado com sucesso");
        }

        public List<GerenciamentoTremEntity> GetAll() => _gerenciamentoTremRepository.GetAll();

        public void PrintAll() => GetAll().ForEach(
            x => { 
                Console.WriteLine($"Id: {x.Id}"); 
                Console.WriteLine($"Chegada: {x.Chegada}"); 
                Console.WriteLine($"Saida: {x.Saida}"); 
                Console.WriteLine($"Nome trem: {x.Trem.Name}"); 
                Console.WriteLine($"Nome funcionário: {x.FuncionarioAtendimento.Name}\n"); });

        public void Update()
        {
            var horarios = GetAll();

            Console.WriteLine("Digite o id do horário");
            var id = Guid.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nova data/hora de chegada");
            var chegada = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a nova data/hora de saida");
            var saida = Convert.ToDateTime(Console.ReadLine());

            var horario = horarios.Find(x => x.Id == id);

            horario.Chegada = chegada;
            horario.Saida = saida;

            _gerenciamentoTremRepository.Add(horarios);

            Console.WriteLine("Registro atualizado com sucesso");
        }
    }
}
