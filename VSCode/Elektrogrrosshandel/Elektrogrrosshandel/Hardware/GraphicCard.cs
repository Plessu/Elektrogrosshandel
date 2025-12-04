using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Elektrogrrosshandel.Hardware
{
    internal class GraphicCard : ComputerHardware
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
        private int ArticelEnergyConsumption { get; set; }

        private static string ArticelGroupName = "Graphic Card";
        private static int ArticelGroupID = 400;
        private string ArticelGroupDescription = "This category includes all kinds of graphic cards for computers, ranging from entry-level to high-end models designed for gaming and professional use.";

        private static List<int> ArticelIDs = new List<int>();

        private GraphicCard(int articelID, string articelName, string articelManufacturer, string articelModel,
                            int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                            int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                            string articelDescription, int articelEnergyConsumption) : base()
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
            ArticelEnergyConsumption = articelEnergyConsumption;
            ComputerHardware.AddGraphicCard(this);
        }
        public static GraphicCard CreateMotherboard(string articelName, string articelManufacturer, string articelModel,
                                                    int articelYearOfProduction, int articelManufactrerID, 
                                                    string[] articelColors, int articelStock, int articelMinStock, 
                                                    double articelPrice, int articelWeight, int[] articelDimesnions,
                                                    string articelDescription, int articelEnergyConsumption)
        {
            foreach (var item in ComputerHardware.GraphicCards)
            {
                if (item.ArticelModel == articelModel && item.ArticelManufactrerID == articelManufactrerID)
                {
                    throw new ArgumentException("Graphic Card with the same model and manufacturer ID already exists.");
                }
            }

            int articelID = CreateArticelID();

            return new GraphicCard(articelID, articelName, articelManufacturer, articelModel,
                                    articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                                    articelMinStock, articelPrice, articelWeight, articelDimesnions,
                                    articelDescription, articelEnergyConsumption);
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


            return iD;
        }
    }
}
