// """

using Elektrogrosshandel.Functions;


namespace Elektrogrosshandel
{
    internal class Program
    {

        public static Account ActiveUser = new Account();
        static void Main(string[] args)
        {
            TestData.InitializeTestData();

            if (File.Exists("HardWareStorage.json"))
            {
                HardWareStorage.LoadAllDevices("HardWareStorage.json");
            }
            else
            {
                HardWareStorage.SaveAllDevices("HardWareStorage.json");
            }

            if (File.Exists("AccountsStorage.json"))
            {
                AccountStorage.LoadAllAccounts("AccountsStorage.json");
            }
            else
            {
                AccountStorage.SaveAllAccounts("AccountsStorage.json");
            }

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            LogIn.LogingIn();
        }

        public static void SetActiveUser(Account account)
        {
            ActiveUser = account;
        }

    }
}
