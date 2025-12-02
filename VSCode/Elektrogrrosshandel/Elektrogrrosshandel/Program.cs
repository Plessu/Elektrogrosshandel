using Spectre.Console;

namespace Elektrogrrosshandel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MainMenu();
        }
        static void MainMenu()
        {
            GUI_Display.MainWindow(GUI_MainMenu.MainMenu(), GUI_MainMenu.MainDisplay());
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
