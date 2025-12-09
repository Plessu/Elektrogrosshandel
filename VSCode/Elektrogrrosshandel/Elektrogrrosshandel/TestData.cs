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

            HardWareStorage.SaveAllDevices("Articel.Json");
            HardWareStorage.LoadAllDevices("Articel.Json");
        }
    }
}
