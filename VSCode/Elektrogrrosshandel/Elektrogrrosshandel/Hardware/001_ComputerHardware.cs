using Spectre.Console;
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
        public ComputerHardware(int articelID, string articelName, string articelManufacturer, string articelModel,
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

        public static string GetArticelName(ComputerHardware articel)
        {
            string name = "";
            foreach (ComputerHardware device in Devices)
            {
                if (device.ArticelID == articel.ArticelID)
                    name = device.ArticelName;
            }
            return name;
        }

        public static List<ComputerHardware> GetArticelbyManufacturer(string manufacturer)
        {
            List<ComputerHardware> hardwareByManufacturer = new List<ComputerHardware>();

            foreach (ComputerHardware device in Devices)
            {
                if (device.ArticelManufacturer == manufacturer)
                {
                    hardwareByManufacturer.Add(device);
                }
            }

            return hardwareByManufacturer;
        }

        public static List<string> GetAllManufacturers()
        {
            List<string> manufacturers = new List<string>();
            foreach (ComputerHardware device in Devices)
            {
                if (!manufacturers.Contains(device.ArticelManufacturer))
                {
                    manufacturers.Add(device.ArticelManufacturer);
                }
            }


            return manufacturers;
        }

        public static double GetArticelPriceByHardware(ComputerHardware articel)
        {
            double price = 0;
            foreach (ComputerHardware device in Devices)
            {
                if (device.ArticelID == articel.ArticelID)
                    price = device.ArticelPrice;
            }
            return price;
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

        public static Markup GetArticelInfoByArticel(ComputerHardware Articel)
        {
            Markup articelInfo = new Markup($"[bold yellow]ArtikelID:[/] {Articel.ArticelID} [bold yellow]Artikelname:[/] {Articel.ArticelName} [bold yellow]Hersteller:[/] {Articel.ArticelManufacturer} [bold yellow]Modell:[/] {Articel.ArticelModel} [bold yellow]Preis:[/] {Articel.ArticelPrice}");
            
            return articelInfo;
        }

        public static List<Markup> GetArticelInfoByID(int articelID)
        {
            List<Markup> articelInfo = new List<Markup>();

            foreach (ComputerHardware device in Devices)
            {
                if (device.ArticelID == articelID)
                {
                    articelInfo.Add(new Markup($"[bold yellow]ArtikelID:[/] {device.ArticelID}"));
                    articelInfo.Add(new Markup($"[bold yellow]Artikelname:[/] {device.ArticelName}"));
                    articelInfo.Add(new Markup($"[bold yellow]Hersteller:[/] {device.ArticelManufacturer}"));
                    articelInfo.Add(new Markup($"[bold yellow]Model:[/] {device.ArticelModel}"));
                    articelInfo.Add(new Markup($"[bold yellow]Farben:[/] {string.Join(", ", device.ArticelColors)}"));
                    articelInfo.Add(new Markup($"[bold yellow]HerstellerID:[/] {device.ArticelManufactrerID}"));
                    articelInfo.Add(new Markup($"[bold yellow]Produktionsjahr:[/] {device.ArticelYearOfProduction}"));
                    articelInfo.Add(new Markup($"[bold yellow]Modell:[/] {device.ArticelModel}"));
                    articelInfo.Add(new Markup($"[bold yellow]Beschreibung:[/] {device.ArticelDescription}"));
                    articelInfo.Add(new Markup($"[bold yellow]Preis:[/] {device.ArticelPrice}"));

                    return articelInfo;
                }
            }

            return articelInfo;
        }

        public static List<ComputerHardware> GetAllComputerHardwares()
        {
            return Devices;
        }

        public static List<Case> GetAllCases()
        {
            return Cases;
        }

        public static List<Motherboard> GetAllMotherboards()
        {
            return Motherboards;
        }

        public static List<PowerSupply> GetAllPowerSupplies()
        {
            return PowerSupplies;
        }

        public static List<Processor> GetAllProcessors()
        {
            return Processors;
        }
        public static List<GraphicsCard> GetAllGraphicsCards()
        {
            return GraphicsCards;
        }

        public static List<Ram> GetAllRAMs()
        {
            return RAMs;
        }

        public static List<StorageDevice> GetAllStorageDevices()
        {
            return StorageDevices;
        }

        public static List<CoolingSystem> GetAllCoolingSystems()
        {
            return CoolingSystems;
        }

        public static List<Peripheral> GetAllPeripherals()
        {
            return Peripherals;
        }

        public static List<Display> GetAllDisplays()
        {
            return Displays;
        }

        public static List<Software> GetAllSoftwares()
        {
            return Softwares;
        }

    }
}
