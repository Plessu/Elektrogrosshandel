using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel
{
    internal class TestData
    {
        public static void InitializeTestData()
        {
            Account.TestData();
            Hardware.ComputerHardware.TestData();
        }
    }
}
