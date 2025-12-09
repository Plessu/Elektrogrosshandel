// """

using Spectre.Console;

namespace Elektrogrosshandel.Hardware
{
    internal class ComputerHardware
    {
        private Int64 ArticelID { get; set; }
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
        public ComputerHardware(Int64 articelID, string articelName, string articelManufacturer, string articelModel,
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

        public static ComputerHardware GetArticelByID(Int64 articelID)
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

        public static List<Markup> GetArticelbyManufacturer(string manufacturer)
        {
            List<Markup> list = new List<Markup>();
            List<ComputerHardware> hardwareByManufacturer = new List<ComputerHardware>();

            foreach (ComputerHardware device in Devices)
            {
                if (device.ArticelManufacturer == manufacturer)
                {
                    hardwareByManufacturer.Add(device);
                }
            }

            foreach (ComputerHardware device in hardwareByManufacturer)
            {
                list.Add(new Markup($"[bold yellow]ArtikelID:[/] {device.ArticelID} [bold yellow]Artikelname:[/] {device.ArticelName} [bold yellow]Artikelmodel:[/] {device.ArticelModel}"));
            }

            return list;
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

        public static double GetArticelPriceByID(Int64 articelID)
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
            Markup articelInfo = new Markup($"\n[bold yellow]ArtikelID:[/] {Articel.ArticelID} [bold yellow]Artikelname:[/] {Articel.ArticelName} \n[bold yellow]Hersteller:[/] {Articel.ArticelManufacturer} [bold yellow]Modell:[/] {Articel.ArticelModel} [bold yellow]Preis:[/] {Articel.ArticelPrice}");

            return articelInfo;
        }

        public static List<Markup> GetArticelInfoByID(Int64 articelID)
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

        public static void TestData()
        {
            // --- Cases (5) ---
            new Case("N300", "CoolerMaster", "N300", 2021, 101, new string[] { "Black" }, 15, 2, 79.99, 7000, new int[] { 210, 450, 500 }, "Mid-Tower Gehäuse mit guter Luftkühlung", "ATX", 3, "USB3,Audio");
            new Case("H510", "NZXT", "H510", 2020, 102, new string[] { "White", "Black" }, 10, 1, 89.90, 6800, new int[] { 210, 428, 440 }, "Kompaktes, elegantes Midi-Tower Gehäuse", "ATX", 2, "USB3.1,USB2,Audio");
            new Case("Meshify C", "Fractal", "MeshifyC", 2019, 103, new string[] { "Black" }, 8, 1, 99.50, 7200, new int[] { 230, 395, 440 }, "Hohe Airflow und modernes Design", "ATX", 4, "USB3,Audio");
            new Case("ARGUS", "Phanteks", "ARGUS", 2022, 104, new string[] { "Black", "Grey" }, 12, 2, 109.00, 7500, new int[] { 235, 480, 520 }, "RGB-ready Full-Tower", "E-ATX", 5, "USB3.2,Audio");
            new Case("Prime Mini", "Lian Li", "PrimeMini", 2023, 105, new string[] { "Silver" }, 6, 1, 139.99, 4700, new int[] { 200, 350, 300 }, "Kompaktes ITX-Gehäuse aus Aluminium", "Mini-ITX", 2, "USB-C,USB3");

            // --- Motherboards (5) ---
            new Motherboard("ROG Strix Z690", "ASUS", "Z690-STRIX", 2022, 201, new string[] { "Black" }, 7, 1, 359.99, 1200, new int[] { 305, 244, 30 }, "Gaming-Mainboard für Intel 12. Gen", "LGA1700", "DDR5", "ATX", new string[] { "M.2", "SATA" }, "PCIe5.0");
            new Motherboard("B650M AORUS", "Gigabyte", "B650M-A", 2023, 202, new string[] { "Black" }, 9, 1, 189.90, 900, new int[] { 244, 244, 25 }, "AM5 Micro-ATX Board mit PCIe4.0", "AM5", "DDR5", "Micro-ATX", new string[] { "M.2", "SATA" }, "PCIe4.0");
            new Motherboard("Tomahawk", "MSI", "MAG-TOMAHAWK", 2021, 203, new string[] { "Black" }, 11, 2, 159.99, 1000, new int[] { 305, 244, 30 }, "Solides B550 Mainboard für Ryzen", "AM4", "DDR4", "ATX", new string[] { "M.2", "SATA" }, "PCIe4.0");
            new Motherboard("Z790 AORUS", "Gigabyte", "Z790-A", 2023, 204, new string[] { "Black" }, 5, 1, 289.99, 1250, new int[] { 305, 244, 30 }, "High-End Board für Intel 13./14. Gen", "LGA1700", "DDR5", "ATX", new string[] { "M.2", "U.2", "SATA" }, "PCIe5.0");
            new Motherboard("PRIME B560", "ASUS", "B560-PRIME", 2021, 205, new string[] { "Black" }, 14, 2, 119.00, 980, new int[] { 305, 244, 28 }, "Preiswertes B560-Board mit guter Ausstattung", "LGA1200", "DDR4", "ATX", new string[] { "M.2", "SATA" }, "PCIe4.0");

            // --- PowerSupplies (5) ---
            new PowerSupply("RM750x", "Corsair", "RM750x", 2020, 301, new string[] { "Black" }, 20, 3, 124.99, 1600, new int[] { 150, 140, 86 }, "750W, fully modular, 80+ Gold", 750);
            new PowerSupply("Focus GX-850", "Seasonic", "GX-850", 2021, 302, new string[] { "Black" }, 10, 2, 159.90, 1800, new int[] { 150, 160, 86 }, "850W, 80+ Gold, kompakt", 850);
            new PowerSupply("Toughpower SFX", "Thermaltake", "SFX-600", 2022, 303, new string[] { "Black" }, 6, 1, 119.00, 900, new int[] { 125, 100, 63 }, "SFX 600W für kleine Systeme", 600);
            new PowerSupply("Straight Power", "be quiet!", "SP-1200W", 2023, 304, new string[] { "Black" }, 4, 1, 249.99, 2400, new int[] { 180, 200, 86 }, "1200W High-End PSU, 80+ Platinum", 1200);
            new PowerSupply("ECO 650", "EVGA", "ECO650", 2019, 305, new string[] { "Black" }, 12, 2, 69.90, 1400, new int[] { 150, 140, 86 }, "Preiswerte 650W PSU, 80+ Bronze", 650);

            // --- Processors (5) ---
            new Processor("Ryzen 9 7950X", "AMD", "7950X", 2022, 401, new string[] { "Silver" }, 5, 1, 699.00, 200, new int[] { 45, 45, 10 }, "16-Core High-End CPU", 16, 32, 4500, 5100, 170, "AM5", false, 5, 64, 170);
            new Processor("Core i9-14900K", "Intel", "14900K", 2024, 402, new string[] { "Silver" }, 4, 1, 749.99, 210, new int[] { 45, 45, 10 }, "High-End Desktop CPU mit vielen Kernen", 24, 32, 3400, 5800, 125, "LGA1700", true, 10, 36, 125);
            new Processor("Ryzen 5 7600", "AMD", "7600", 2022, 403, new string[] { "Silver" }, 10, 2, 229.99, 95, new int[] { 45, 45, 8 }, "Gutes Preis-Leistungs-Verhältnis", 6, 12, 3700, 4600, 65, "AM4", false, 5, 32, 65);
            new Processor("Core i5-13400F", "Intel", "13400F", 2023, 404, new string[] { "Silver" }, 18, 3, 189.90, 120, new int[] { 45, 45, 8 }, "Solide Mittelklasse-CPU ohne iGPU", 10, 16, 2600, 4600, 65, "LGA1700", false, 10, 20, 65);
            new Processor("Ryzen Threadripper Pro", "AMD", "WRX80-CPU", 2021, 405, new string[] { "Black" }, 2, 1, 3999.00, 400, new int[] { 60, 60, 15 }, "Workstation-CPU für hohe Thread-Last", 32, 64, 3200, 4300, 280, "sTRX4", false, 7, 256, 280);

            // --- GraphicsCards (5) ---
            new GraphicsCard("RTX 4090", "NVIDIA", "RTX4090", 2022, 501, new string[] { "Black" }, 3, 1, 1999.00, 2200, new int[] { 200, 400, 60 }, "Flaggschiff GPU für 4K Gaming", 24, "GDDR6X", 2235, 2520, 450, "PCIe4.0", new string[] { "HDMI", "DP" }, 450);
            new GraphicsCard("RX 7900 XTX", "AMD", "7900XTX", 2022, 502, new string[] { "Silver" }, 5, 1, 999.99, 1800, new int[] { 200, 350, 55 }, "High-End GPU von AMD", 24, "GDDR6", 2100, 2500, 300, "PCIe4.0", new string[] { "DP", "HDMI" }, 350);
            new GraphicsCard("RTX 4070 Ti", "NVIDIA", "4070Ti", 2023, 503, new string[] { "Black" }, 8, 2, 799.00, 1200, new int[] { 170, 300, 45 }, "Gute Leistung für 1440p-Gaming", 12, "GDDR6X", 2310, 2625, 285, "PCIe4.0", new string[] { "DP", "HDMI" }, 285);
            new GraphicsCard("RX 7600", "AMD", "7600", 2023, 504, new string[] { "Black" }, 14, 2, 259.90, 900, new int[] { 150, 250, 40 }, "Budget-orientierte Karte für 1080p", 8, "GDDR6", 2000, 2400, 135, "PCIe4.0", new string[] { "HDMI", "DP" }, 150);
            new GraphicsCard("GTX 1650", "NVIDIA", "1650", 2019, 505, new string[] { "Black" }, 20, 3, 149.90, 700, new int[] { 145, 200, 40 }, "Einsteiger-GPU mit niedrigem Verbrauch", 4, "GDDR5", 1485, 1665, 75, "PCIe3.0", new string[] { "HDMI", "DVI" }, 75);

            // --- RAMs (5) ---
            new Ram("Vengeance RGB", "Corsair", "VengeanceRGB32", 2021, 601, new string[] { "Black" }, 25, 5, 159.90, 120, new int[] { 135, 35, 7 }, "32GB (2x16) DDR4-3200 RGB Kit", 32768, 3200, "DDR4", 2, false);
            new Ram("Trident Z5", "G.Skill", "TridentZ5-32", 2022, 602, new string[] { "Black" }, 12, 2, 199.99, 130, new int[] { 135, 35, 8 }, "32GB DDR5-6000 high speed", 32768, 6000, "DDR5", 2, false);
            new Ram("Ripjaws V", "G.Skill", "RipjawsV16", 2019, 603, new string[] { "Black" }, 30, 5, 74.90, 70, new int[] { 135, 35, 7 }, "16GB DDR4-2666 Kit", 16384, 2666, "DDR4", 2, false);
            new Ram("Ballistix", "Crucial", "Ballistix16", 2020, 604, new string[] { "Black" }, 18, 3, 89.90, 80, new int[] { 135, 35, 7 }, "16GB DDR4-3200 low latency", 16384, 3200, "DDR4", 2, false);
            new Ram("Professional ECC", "Kingston", "ECC32", 2021, 605, new string[] { "Green" }, 6, 1, 329.90, 140, new int[] { 135, 35, 8 }, "32GB ECC RAM für Workstations", 32768, 3200, "DDR4ECC", 1, true);

            // --- CoolingSystems (5) ---
            new CoolingSystem("Hyper 212", "CoolerMaster", "Hyper212", 2018, 801, new string[] { "Black" }, 40, 5, 34.90, 800, new int[] { 120, 100, 65 }, "Traditioneller CPU-Luftkühler", 2000, false, 150, new string[] { "AM4", "LGA1200" });
            new CoolingSystem("H100i RGB", "Corsair", "H100i", 2020, 802, new string[] { "Black" }, 10, 2, 129.90, 1100, new int[] { 277, 120, 30 }, "240mm AiO Flüssigkeitskühler", 2400, true, 250, new string[] { "AM4", "LGA1700" });
            new CoolingSystem("Kraken X73", "NZXT", "X73", 2021, 803, new string[] { "Black" }, 8, 1, 189.99, 1400, new int[] { 394, 120, 30 }, "360mm AiO mit RGB", 2200, true, 300, new string[] { "AM4", "LGA1700" });
            new CoolingSystem("Noctua NH-D15", "Noctua", "NH-D15", 2019, 804, new string[] { "Beige" }, 7, 1, 99.90, 1250, new int[] { 160, 150, 150 }, "Top Luftkühler für hohe Lasten", 1500, false, 220, new string[] { "AM4", "LGA1200", "LGA1700" });
            new CoolingSystem("ARCTIC Liquid Freezer II", "ARCTIC", "LiqFreezer2", 2022, 805, new string[] { "Black" }, 9, 2, 119.90, 1300, new int[] { 277, 120, 30 }, "Effizientes AiO mit Pumpenintegr.", 2100, true, 280, new string[] { "AM4", "AM5", "LGA1700" });

            // --- Peripherals (5) ---
            new Peripheral("Kone Pro", "ROCCAT", "KonePro", 2021, 901, new string[] { "Black" }, 30, 5, 79.99, 120, new int[] { 120, 70, 40 }, "Gamingmaus mit hoher DPI", "Mouse", "USB", false, 0, 5, 16000, "", true, new string[] { "USB" });
            new Peripheral("K70 RGB", "Corsair", "K70", 2020, 902, new string[] { "Black" }, 20, 3, 129.90, 900, new int[] { 440, 150, 40 }, "Mechanische Gaming-Tastatur", "Keyboard", "USB", false, 0, 0, 0, "CherryMX", true, new string[] { "USB" });
            new Peripheral("Arctis 7", "SteelSeries", "Arctis7", 2019, 903, new string[] { "Black" }, 15, 2, 149.90, 350, new int[] { 200, 180, 90 }, "Kabelloses Gaming-Headset", "Headset", "Wireless", true, 24, 2, 0, "", true, new string[] { "USB", "Wireless" });
            new Peripheral("Webcam C920", "Logitech", "C920", 2018, 904, new string[] { "Black" }, 25, 3, 69.90, 100, new int[] { 60, 40, 30 }, "Full HD Webcam für Streaming", "Webcam", "USB", false, 0, 0, 0, "", false, new string[] { "USB" });
            new Peripheral("PodMic", "Rode", "PodMic", 2020, 905, new string[] { "Black" }, 12, 1, 99.00, 850, new int[] { 180, 120, 120 }, "Dynamisches Studio-Mikrofon", "Microphone", "XLR", false, 0, 0, 0, "", false, new string[] { "XLR" });

            // --- Displays (5) ---
            new Display("U2723QE", "Dell", "U2723QE", 2022, 925, new string[] { "Black" }, 9, 1, 499.00, 6000, new int[] { 614, 180, 60 }, "27\" 4K IPS Monitor für Office/Photo", "3840x2160", 60, "IPS", 27.0, true, new string[] { "HDMI", "DP", "USB-C" }, "None", false, false, 400, "16:9");
            new Display("Odyssey G7", "Samsung", "G7", 2021, 926, new string[] { "Black" }, 6, 1, 699.99, 8500, new int[] { 720, 310, 300 }, "32\" QHD 240Hz Curved Gaming-Monitor", "2560x1440", 240, "VA", 32.0, true, new string[] { "HDMI", "DP" }, "G-Sync", true, false, 600, "16:9");
            new Display("Pro Display XDR", "Apple", "XDR", 2019, 927, new string[] { "Silver" }, 2, 1, 4999.00, 12000, new int[] { 640, 420, 150 }, "Professioneller 6K Monitor für Farbworkflows", "6016x3384", 60, "IPS", 32.0, true, new string[] { "Thunderbolt 3" }, "None", false, false, 1000, "16:9");
            new Display("UltraSharp 27", "Dell", "U2722D", 2023, 928, new string[] { "Black" }, 11, 2, 349.90, 5600, new int[] { 614, 180, 60 }, "27\" QHD Monitor mit guter Farbdarstellung", "2560x1440", 75, "IPS", 27.0, false, new string[] { "HDMI", "DP", "USB-C" }, "FreeSync", false, false, 350, "16:9");
            new Display("VA Curved 24", "AOC", "CU24G2", 2020, 929, new string[] { "Black" }, 18, 3, 179.90, 4200, new int[] { 540, 240, 200 }, "24\" 144Hz Curved Monitor für Gamer", "1920x1080", 144, "VA", 24.0, false, new string[] { "HDMI", "DP" }, "FreeSync", true, false, 300, "16:9");

            // --- Softwares (5) ---
            new Software("Office 365", "Microsoft", "Office365", 2023, 951, new string[] { "Box" }, 999, 0, 99.99, 0, new int[] { 0, 0, 0 }, "Office Suite Subscription", "Windows");
            new Software("Windows 11 Pro", "Microsoft", "Win11Pro", 2021, 952, new string[] { "Box" }, 500, 0, 199.99, 0, new int[] { 0, 0, 0 }, "Betriebssystem für Business", "Windows");
            new Software("Adobe Photoshop", "Adobe", "PS2024", 2024, 953, new string[] { "Box" }, 200, 0, 23.99, 0, new int[] { 0, 0, 0 }, "Professionelle Bildbearbeitung (Subscription)", "Windows");
            new Software("Visual Studio 2022", "Microsoft", "VS2022", 2022, 954, new string[] { "Box" }, 150, 0, 0.00, 0, new int[] { 0, 0, 0 }, "IDE für Entwickler (Community/Pro/Enterprise)", "Windows");
            new Software("Ubuntu Desktop", "Canonical", "Ubuntu24.04", 2024, 955, new string[] { "Box" }, 1000, 0, 0.00, 0, new int[] { 0, 0, 0 }, "Kostenloses Linux-Desktop OS", "Linux");
        }
    }
}

