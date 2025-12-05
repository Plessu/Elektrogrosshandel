using Spectre.Console;
using Elektrogrosshandel.Hardware;
using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Functions;
    

namespace Elektrogrosshandel
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
