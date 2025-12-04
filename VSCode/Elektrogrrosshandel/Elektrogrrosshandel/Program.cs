using Spectre.Console;

namespace Elektrogrrosshandel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 3000;
            Console.BufferWidth = 250;
            Console.WindowHeight = 23;
            Console.WindowWidth = 120;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MainMenu();
        }
        static void MainMenu()
        {
            GUI_Display.MainWindow(GUI_MainMenu.ShowMainMenu());
            MenuSelection(GetUserInput.Choice(GUI_MainMenu.MaxMenuItems()));
        }   
        static void MenuSelection(int UserChoice)
        {
            switch (UserChoice)
            {
                case 1:
                    AnsiConsole.MarkupLine("[bold green]News selected.[/]");
                    break;
            }
        }
    }
}
