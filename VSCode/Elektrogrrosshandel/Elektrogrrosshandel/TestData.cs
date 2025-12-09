// """

using Elektrogrosshandel.Functions;

namespace Elektrogrosshandel
{
    internal class TestData
    {
        public static void InitializeTestData()
        {
            Account.TestData();
            Hardware.ComputerHardware.TestData();

            AccountStorage.SaveAllAccounts("Accounts.Json");
            AccountStorage.LoadAllAccounts("Accounts.Json");

            HardWareStorage.SaveAllDevices("Articel.Json");
            HardWareStorage.LoadAllDevices("Articel.Json");
        }
    }
}
