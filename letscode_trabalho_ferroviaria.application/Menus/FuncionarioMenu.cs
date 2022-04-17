using letscode_trabalho_ferroviaria.application.Services;
using letscode_trabalho_ferroviaria.crosscutting.Extensions;
using letscode_trabalho_ferroviaria.insfrastructure.Repositories;

namespace letscode_trabalho_ferroviaria.application.Menus
{
    public class FuncionarioMenu
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioMenu()
        {
            var funcionarioRepository = new FuncionarioRepository();
            _funcionarioService = new FuncionarioService(funcionarioRepository);
        }

        public void Menu()
        {
            Console.WriteLine("Escolha um dos Menus!\n");

            while (true)
            {
                Console.WriteLine("1. Menu Funcionario - Adicionar");
                Console.WriteLine("2. Menu Funcionario - Atualizar");
                Console.WriteLine("3. Menu Funcionario - Ver todos");
                Console.WriteLine("0. Voltar para o menu principal");
                Console.Write("Opção: ");
                switch (Console.Read())
                {
                    case '1':
                        ConsoleExtension.ConsoleMenuChoose();
                        _funcionarioService.Add();
                        break;
                    case '2':
                        ConsoleExtension.ConsoleMenuChoose();
                        _funcionarioService.Update();
                        break;
                    case '3':
                        ConsoleExtension.ConsoleMenuChoose();
                        _funcionarioService.PrintAll();
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
