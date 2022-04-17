using letscode_trabalho_ferroviaria.application.Services;
using letscode_trabalho_ferroviaria.crosscutting.Extensions;
using letscode_trabalho_ferroviaria.insfrastructure.Repositories;

namespace letscode_trabalho_ferroviaria.application.Menus
{
    public class TremMenu
    {
        private readonly TremService _tremService;

        public TremMenu()
        {
            var tremRepository = new TremRepository();
            _tremService = new TremService(tremRepository);
        }

        public void Menu()
        {
            Console.WriteLine("Escolha um dos Menus!\n");

            while (true)
            {
                Console.WriteLine("1. Menu Trem - Adicionar");
                Console.WriteLine("2. Menu Trem - Atualizar");
                Console.WriteLine("3. Menu Trem - Ver todos");
                Console.WriteLine("0. Voltar para o menu principal");
                Console.Write("Opção: ");
                switch (Console.Read())
                {
                    case '1':
                        ConsoleExtension.ConsoleMenuChoose();
                        _tremService.Add();
                        break;
                    case '2':
                        ConsoleExtension.ConsoleMenuChoose();
                        _tremService.Update();
                        break;
                    case '3':
                        ConsoleExtension.ConsoleMenuChoose();
                        _tremService.PrintAll();
                        break;
                    case '0':
                        return;
                    default:
                        ConsoleExtension.ConsoleMenuChoose();
                        Console.WriteLine("Opção Inválida, Tente novamente.....");
                        break;
                }
            }
        }
    }
}
