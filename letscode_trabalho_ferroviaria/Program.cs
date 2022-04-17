using letscode_trabalho_ferroviaria.application.Menus;
using letscode_trabalho_ferroviaria.crosscutting.Extensions;

var funcionarioMenu = new FuncionarioMenu();
var tremMenu = new TremMenu();
var gerenciamentoTremMenu = new GerenciamentoTremMenu();

Console.Title = "Projeto Ferroviário";
Console.WriteLine("Escolha um dos Menus!\n");

while (true)
{
    Console.WriteLine("1. Menu Funcionario");
    Console.WriteLine("2. Menu Trem");
    Console.WriteLine("3. Menu Gerenciamento Trem");
    Console.WriteLine("0. Sair");
    Console.Write("Opção: ");
    switch (Console.Read())
    {
        case '1':
            ConsoleExtension.ConsoleMenuChoose();
            funcionarioMenu.Menu();
            break;
        case '2':
            ConsoleExtension.ConsoleMenuChoose();
            tremMenu.Menu();
            break;
        case '3':
            ConsoleExtension.ConsoleMenuChoose();
            gerenciamentoTremMenu.Menu();
            break;
        case '0':
            Environment.Exit(0);
            break;
        default:
            ConsoleExtension.ConsoleMenuChoose();
            break;
    }
}