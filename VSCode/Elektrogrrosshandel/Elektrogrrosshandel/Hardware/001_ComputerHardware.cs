using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Hardware
{
    internal class ComputerHardware
    {
        private int ArticelID { get; set; }
        private string ArticelName { get; set; }
        private string ArticelManufacturer { get; set; }
        private string ArticelModel { get; set; }
        private int ArticelYearOfProduction { get; set; }
        private int ArticelManufactrerID { get; set; }
        private string[] ArticelColors { get; set; }
        private int ArticelStock { get; set; }
        private int ArticelMinStock { get; set; }
        private double ArticelPrice { get; set; }
        private int ArticelWeight { get; set; }
        private int[] ArticelDimesnions { get; set; }
        private string ArticelDescription { get; set; }

        internal static readonly string ArticelParentGroup = "Computer Hardware";
        internal static readonly int ArticelParentGroupID = 1001;

        internal static List<Case> Cases = new List<Case>();
        internal static List<Motherboard> Motherboards = new List<Motherboard>();
        internal static List<PowerSupply> PowerSupplies = new List<PowerSupply>();
        internal static List<Processor> Processors = new List<Processor>();
        internal static List<GraphicsCard> GraphicsCards = new List<GraphicsCard>();
        internal static List<Ram> RAMs = new List<Ram>();
        internal static List<StorageDevice> StorageDevices = new List<StorageDevice>();
        internal static List<CoolingSystem> CoolingSystems = new List<CoolingSystem>();
        internal static List<Peripheral> Peripherals = new List<Peripheral>();
        internal static List<Display> Displays = new List<Display>();
        internal static List<Software> Softwares = new List<Software>();

        internal static List<ComputerHardware> Devices = new List<ComputerHardware>(0);
        internal static List<string> Manufacturers = new List<string>();

        public ComputerHardware()
        {
        }
        public  ComputerHardware(int articelID, string articelName, string articelManufacturer, string articelModel,
                            int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                            int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                            string articelDescription)
        {
            ArticelID = articelID;
            ArticelName = articelName;
            ArticelManufacturer = articelManufacturer;
            ArticelModel = articelModel;
            ArticelYearOfProduction = articelYearOfProduction;
            ArticelManufactrerID = articelManufactrerID;
            ArticelColors = articelColors;
            ArticelStock = articelStock;
            ArticelMinStock = articelMinStock;
            ArticelPrice = articelPrice;
            ArticelWeight = articelWeight;
            ArticelDimesnions = articelDimesnions;
            ArticelDescription = articelDescription;
        }
        public static void AddCase(Case Case)
        {
            Devices.Add(Case);
            Cases.Add(Case);
        }
        public static void AddGraphicsCard(GraphicsCard graphicCard)
        {
            Devices.Add(graphicCard);
            GraphicsCards.Add(graphicCard);
        }
        public static void AddMotherboard(Motherboard motherboard)
        {
            Devices.Add(motherboard);
            Motherboards.Add(motherboard);
        }

        public static void AddPowerSupply(PowerSupply powerSupply)
        {
            Devices.Add(powerSupply);
            PowerSupplies.Add(powerSupply);
        }

        public static void AddProcessor(Processor processor)
        {
            Devices.Add(processor);
            Processors.Add(processor);
        }

        public static void AddRAM(Ram ram)
        {
            Devices.Add(ram);
            RAMs.Add(ram);
        }

        public static void AddStorageDevice(StorageDevice storageDevice)
        {
            Devices.Add(storageDevice);
            StorageDevices.Add(storageDevice);
        }

        public static void AddCoolingSystem(CoolingSystem coolingSystem)
        {
            Devices.Add(coolingSystem);
            CoolingSystems.Add(coolingSystem);
        }

        public static void AddPeripheral(Peripheral peripheral)
        {
            Devices.Add(peripheral);
            Peripherals.Add(peripheral);
        }

        public static void AddDisplay(Display display)
        {
            Devices.Add(display);
            Displays.Add(display);
        }

        public static void AddSoftware(Software software)
        {
            Devices.Add(software);
            Softwares.Add(software);
        }

        public static ComputerHardware GetArticelByID(int articelID)
        {
            ComputerHardware hardware = new ComputerHardware();

            foreach (ComputerHardware device in Devices)
            {
                if (device.ArticelID == articelID)
                    hardware = device;
                return hardware;
            }
            return null;
        }

        public static double GetArticelPriceByID(int articelID)
        {
            double price = 0;
            foreach (ComputerHardware device in Devices)
            {
                if (device.ArticelID == articelID)
                    price = device.ArticelPrice;
            }
            return price;
        }
    }
}
