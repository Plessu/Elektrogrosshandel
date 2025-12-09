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

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            LogIn.LogingIn();
        }

        public static void SetActiveUser(Account account)
        {
            ActiveUser = account;
        }

    }
}
