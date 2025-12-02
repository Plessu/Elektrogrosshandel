using Spectre.Console;

namespace Elektrogrrosshandel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            GUI_MainMenu.PrintMainMenu();
            GUI_MainMenu.GetMenuChoice();
        }
    }
}
