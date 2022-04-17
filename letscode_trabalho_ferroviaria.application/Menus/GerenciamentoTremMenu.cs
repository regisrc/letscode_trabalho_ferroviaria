using letscode_trabalho_ferroviaria.application.Services;
using letscode_trabalho_ferroviaria.crosscutting.Extensions;
using letscode_trabalho_ferroviaria.insfrastructure.Repositories;

namespace letscode_trabalho_ferroviaria.application.Menus
{
    public class GerenciamentoTremMenu
    {
        private readonly GerenciamentoTremService _gerenciamentoTremService;

        public GerenciamentoTremMenu()
        {
            var tremRepository = new TremRepository();
            var tremService = new TremService(tremRepository);

            var funcionarioRepository = new FuncionarioRepository();
            var funcionarioService = new FuncionarioService(funcionarioRepository);

            var gerenciamentoTremRepository = new GerenciamentoTremRepository();
            _gerenciamentoTremService = new GerenciamentoTremService(funcionarioService, tremService, gerenciamentoTremRepository);
        }

        public void Menu()
        {
            Console.WriteLine("Escolha um dos Menus!\n");

            while (true)
            {
                Console.WriteLine("1. Menu Gerenciamento Trem - Adicionar");
                Console.WriteLine("2. Menu Gerenciamento Trem - Atualizar");
                Console.WriteLine("3. Menu Gerenciamento Trem - Ver todos");
                Console.WriteLine("0. Voltar para o menu principal");
                Console.Write("Opção: ");
                switch (Console.Read())
                {
                    case '1':
                        ConsoleExtension.ConsoleMenuChoose();
                        _gerenciamentoTremService.Add();
                        break;
                    case '2':
                        ConsoleExtension.ConsoleMenuChoose();
                        _gerenciamentoTremService.Update();
                        break;
                    case '3':
                        ConsoleExtension.ConsoleMenuChoose();
                        _gerenciamentoTremService.PrintAll();
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
