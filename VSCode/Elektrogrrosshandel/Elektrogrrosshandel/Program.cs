using Spectre.Console;

namespace Elektrogrrosshandel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI_MainMenu.PrintMainMenu();
            GUI_MainMenu.GetMenuChoice();
        }
    }
}
