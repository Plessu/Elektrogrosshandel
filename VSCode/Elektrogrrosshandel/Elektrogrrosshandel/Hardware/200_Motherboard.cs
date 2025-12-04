using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Elektrogrrosshandel.Hardware
{
    internal class Motherboard : ComputerHardware
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
        private string Socket { get; set; }
        private string RamType { get; set; }
        private string FormFactor { get; set; }
        private string PCIeVersion { get; set; }
        private string[] StorageInterfaces { get; set; }

        private static string ArticelGroupName = "Motherboard";
        private static int ArticelGroupID = 200;
        private string ArticelGroupDescription = "This category includes all kinds of Motherrboards for computers, ranging from entry-level to high-end models designed for gaming and professional use.";

        private static List<int> ArticelIDs = new List<int>();

        private Motherboard(int articelID, string articelName, string articelManufacturer, string articelModel,
                            int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                            int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                            string articelDescription, string Socket, string RamType, string FormFactor,
                            string[] StorageInterfaces, string pCIeVersion) : base()
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
            
            this.Socket = Socket;
            this.RamType = RamType;
            this.FormFactor = FormFactor;
            this.StorageInterfaces = StorageInterfaces;
            this.PCIeVersion = pCIeVersion;

            ComputerHardware.AddMotherboard(this);
        }
        public static Motherboard CreateMotherboard(string articelName, string articelManufacturer,
                            string articelModel, int articelYearOfProduction, int articelManufactrerID, 
                            string[] articelColors, int articelStock, int articelMinStock, double articelPrice, 
                            int articelWeight, int[] articelDimesnions, string articelDescription, 
                            string Socket, string RamType, string FormFactor, string[] StorageInterfaces, string pCIeVersion)
        {
            foreach (Motherboard item in ComputerHardware.Motherboards)
            {
                if (item.ArticelModel == articelModel && item.ArticelManufactrerID == articelManufactrerID)
                {
                    throw new ArgumentException("Motherboard with the same model and manufacturer ID already exists.");
                }
            }

            int articelID = CreateArticelID();

            return new Motherboard(articelID, articelName, articelManufacturer, articelModel,
                                    articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                                    articelMinStock, articelPrice, articelWeight, articelDimesnions,
                                    articelDescription, Socket, RamType, FormFactor, StorageInterfaces, pCIeVersion);
        }

        private static int CreateArticelID()
        {
            string articelID;
            int iD;
            Random random = new Random();
            do
            {
                iD = random.Next(1, 9999);
                if (!ArticelIDs.Contains(iD))
                {
                    break;
                }
            } while (true);

            articelID = ComputerHardware.ArticelParentGroupID + ArticelGroupID.ToString() + iD.ToString("D4");
            iD = int.Parse(articelID);
            ArticelIDs.Add(iD);

            return iD;
        }
    }
}
