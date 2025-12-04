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
            LogIn.LogingIn();
        }

    }
}
