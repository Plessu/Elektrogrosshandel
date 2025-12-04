using Spectre.Console;
using Elektrogrrosshandel.Hardware;
using Elektrogrrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Functions;
    

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
