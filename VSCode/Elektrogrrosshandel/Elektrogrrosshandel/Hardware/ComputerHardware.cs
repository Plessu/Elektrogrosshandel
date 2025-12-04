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
        internal static List<GraphicCard> GraphicCards = new List<GraphicCard>();
        internal static List<RAM> RAMs = new List<RAM>();
        internal static List<StorageDevice> StorageDevices = new List<StorageDevice>();
        internal static List<CoolingSystem> CoolingSystems = new List<CoolingSystem>();
        internal static List<Peripheral> ComputerPeripherals = new List<ComputerPeripheral>();
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
        public static void AddGraphicCard(GraphicCard graphicCard)
        {
            GraphicCards.Add(graphicCard);
        }
        public static void AddMotherboard(Motherboard motherboard)
        {
            Motherboards.Add(motherboard);
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
