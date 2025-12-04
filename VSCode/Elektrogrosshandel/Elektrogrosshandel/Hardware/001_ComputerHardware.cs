using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel.Hardware
{
    internal class ComputerHardware
    {
        internal int ArticalID { get; set; }

        internal static readonly string ArticelParentGroup = "Computer Hardware";
        internal static readonly int ArticelParentGroupID = 1001;

        internal static List<Case> Cases = new List<Case>();
        internal static List<Motherboard> Motherboards = new List<Motherboard>();
        internal static List<PowerSupply> PowerSupplies = new List<PowerSupply>();
        internal static List<Processor> Processors = new List<Processor>();
        internal static List<GraphicsCard> GraphicsCards = new List<GraphicsCard>();
        internal static List<Ram> Rams = new List<Ram>();
        internal static List<StorageDevice> StorageDevices = new List<StorageDevice>();
        internal static List<CoolingSystem> CoolingSystems = new List<CoolingSystem>();
        internal static List<Peripheral> Peripherals = new List<Peripheral>();
        internal static List<Display> Displays = new List<Display>();
        internal static List<Software> Softwares = new List<Software>();

        internal static List<ComputerHardware> Devices = new List<ComputerHardware>(0);
        internal static List<string> Manufacturers = new List<string>();

        public ComputerHardware()
        {
            Devices.Add(this);
        }
        public static void AddCase(Case Case)
        {
            Cases.Add(Case);
        }
        public static void AddGraphicsCard(GraphicsCard graphicCard)
        {
            GraphicsCards.Add(graphicCard);
        }
        public static void AddMotherboard(Motherboard motherboard)
        {
            Motherboards.Add(motherboard);
        }

        public static void AddPowerSupply(PowerSupply powerSupply)
        {
            PowerSupplies.Add(powerSupply);
        }

        public static void AddProcessor(Processor processor)
        {
            Processors.Add(processor);
        }

        public static void AddRam(Ram ram)
        {
            Rams.Add(ram);
        }

        public static void AddStorageDevice(StorageDevice storageDevice)
        {
            StorageDevices.Add(storageDevice);
        }

        public static void AddCoolingSystem(CoolingSystem coolingSystem)
        {
            CoolingSystems.Add(coolingSystem);
        }

        public static void AddPeripheral(Peripheral peripheral)
        {
            Peripherals.Add(peripheral);
        }

        public static void AddDisplay(Display display)
        {
            Displays.Add(display);
        }

        public static void AddSoftware(Software software)
        {
            Softwares.Add(software);
        }

        public static ComputerHardware GetArticelByID(int articelID)
        {
            ComputerHardware hardware = new ComputerHardware();

            foreach (ComputerHardware device in Devices)
            {
                if (device.ArticalID == articelID)
                    hardware = device;
                return hardware;
            }
            return null;
        }
    }
}
