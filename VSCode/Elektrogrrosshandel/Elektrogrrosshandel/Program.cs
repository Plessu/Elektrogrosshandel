using Spectre.Console;
using Elektrogrosshandel.Hardware;
using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Functions;
    

namespace Elektrogrosshandel
{
    internal class Program
    {
        
        public static Account ActiveUser = new Account();
        static void Main(string[] args)
        {
            TestData.InitializeTestData();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            LogIn.LogingIn();
        }

        public static void SetActiveUser(Account account)
        {
            ActiveUser = account;
        }

    }
}
