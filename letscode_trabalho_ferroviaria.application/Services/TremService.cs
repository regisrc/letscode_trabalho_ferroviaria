using letscode_trabalho_ferroviaria.domain.Entities;
using letscode_trabalho_ferroviaria.insfrastructure.Repositories;

namespace letscode_trabalho_ferroviaria.application.Services
{
    public class TremService
    {
        private readonly TremRepository _tremRepository;

        public TremService(TremRepository tremRepository)
        {
            _tremRepository = tremRepository;
        }

        public void Add()
        {
            Console.WriteLine("Digite o nome do trem");
            var nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome não é válido");
                return;
            }

            var entity = new TremEntity() { Name = nome };

            var trem = _tremRepository.GetLinkedList();

            if (trem == null) trem = entity;
            else
            {
                var previous = GetPrevious(trem);
                previous.Previous = entity;
            }

            _tremRepository.AddLinkedList(trem);
        }

        public TremEntity GetPrevious(TremEntity trem)
        {
            while (trem?.Previous != null)
            {
                trem = trem.Previous;
            }
            return trem;
        }

        public void Update()
        {
            Console.WriteLine("Digite o nome do trem");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite o novo nome do trem");
            var novoNome = Console.ReadLine();

            if (string.IsNullOrEmpty(novoNome))
            {
                Console.WriteLine("Nome não é válido");

                return;
            }

            var trem = _tremRepository.GetLinkedList();

            if (trem == null)
            {
                Console.WriteLine("Não existem trens cadastrados!\n");

                return;
            }

            var tremList = new List<TremEntity>();

            do
            {
                tremList.Add(trem);
                trem = trem.Previous;
            } while (trem != null);

            var tremAchado = tremList.Find(x => x.Name == nome);

            if (tremAchado != null) tremAchado.Name = novoNome;

            tremList.ForEach(x => x.Previous = null);

            var firstTrem = tremList.FirstOrDefault();

            foreach (var item in tremList.Where(x => x.Id != firstTrem?.Id))
            {
                var previous = GetPrevious(firstTrem);
                previous.Previous = item;
            }

            _tremRepository.AddLinkedList(firstTrem);
        }

        public void PrintAll()
        {
            var tempList = new List<TremEntity>();
            var temp = _tremRepository.GetLinkedList();

            if (temp == null)
            {
                Console.WriteLine("Não existem trens cadastrados!\n");

                return;
            }

            while (temp != null)
            {
                tempList.Add(temp);
                temp = temp.Previous;
            };
            tempList.ForEach(
                x =>
                {
                    Console.WriteLine($"Id: {x.Id}");
                    Console.WriteLine($"Nome: {x.Name}\n");
                });
        }

        public TremEntity GetByName(string name)
        {
            var tempVagao = _tremRepository.GetLinkedList();
            while (tempVagao != null && tempVagao.Name != name)
            {
                tempVagao = tempVagao.Previous;
            }
            return tempVagao;
        }
    }
}
