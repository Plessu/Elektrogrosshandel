using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*
Pseudocode / Plan (detailliert):

- Datei: 800_CoolingSystem.cs
- Namespace: Elektrogrrosshandel.Hardware
- Klasse: CoolingSystem (internal, erbt von ComputerHardware)
- Private Eigenschaften (Articel ...):
  - ArticelID, ArticelName, ArticelManufacturer, ArticelModel, ArticelYearOfProduction,
    ArticelManufactrerID, ArticelColors, ArticelStock, ArticelMinStock, ArticelPrice,
    ArticelWeight, ArticelDimesnions, ArticelDescription
  - FanCount, FanSpeedRPM, RadiatorSizeMM, LiquidCooled, TDPRatingWatts, NoiseLevelDB,
    CompatibilitySockets, Material, RGB, PumpSpeedRPM
- Statische Gruppendaten:
  - ArticelGroupName = "CoolingSystem"
  - ArticelGroupID = 800
  - ArticelGroupDescription
  - ArticelIDs List<int>
- Konstruktor:
  - private CoolingSystem(...) setzt alle Felder
  - ruft ComputerHardware.AddCoolingSystem(this)
- Fabrikmethode:
  - public static CoolingSystem CreateCoolingSystem(...)
  - Validierung: durchlaufe ComputerHardware.CoolingSystems und werfe ArgumentException,
    wenn ArticelModel und ArticelManufactrerID bereits existieren
  - Erzeuge ArticelID via CreateArticelID()
  - Rückgabe neuer Instanz
- CreateArticelID:
  - Erzeuge zufällige Zahl 1..9999, prüfe gegen ArticelIDs, baue ID-String:
    ComputerHardware.ArticelParentGroupID + ArticelGroupID + D4
  - Parse int, speichere in ArticelIDs, return int
*/

namespace Elektrogrrosshandel.Hardware
{
    internal class CoolingSystem : ComputerHardware
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


        private int FanSpeedRPM { get; set; }
        private bool LiquidCooled { get; set; }
        private int TDPRatingWatts { get; set; }
        private string[] CompatibilitySockets { get; set; }

        private static string ArticelGroupName = "CoolingSystem";
        private static int ArticelGroupID = 800;
        private string ArticelGroupDescription = "This category includes air and liquid cooling solutions for CPUs and other components.";

        private static List<int> ArticelIDs = new List<int>();

        private CoolingSystem(int articelID, string articelName, string articelManufacturer, string articelModel,
                              int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                              int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                              string articelDescription,
                              int fanSpeedRPM,bool liquidCooled, int tdpRatingWatts, string[] compatibilitySockets) : base()
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

            FanSpeedRPM = fanSpeedRPM;
            LiquidCooled = liquidCooled;
            TDPRatingWatts = tdpRatingWatts;
            CompatibilitySockets = compatibilitySockets;

            ComputerHardware.AddCoolingSystem(this);
        }

        public static CoolingSystem CreateCoolingSystem(string articelName, string articelManufacturer, string articelModel,
                                                        int articelYearOfProduction, int articelManufactrerID,
                                                        string[] articelColors, int articelStock, int articelMinStock,
                                                        double articelPrice, int articelWeight, int[] articelDimesnions,
                                                        string articelDescription,
                                                        int fanCount, int fanSpeedRPM, int radiatorSizeMM, bool liquidCooled, int tdpRatingWatts,
                                                        double noiseLevelDB, string[] compatibilitySockets, string material, bool rgb, int pumpSpeedRPM)
        {
            foreach (var item in ComputerHardware.CoolingSystems)
            {
                if (item.ArticelModel == articelModel && item.ArticelManufactrerID == articelManufactrerID)
                {
                    throw new ArgumentException("CoolingSystem with the same model and manufacturer ID already exists.");
                }
            }

            int articelID = CreateArticelID();

            return new CoolingSystem(articelID, articelName, articelManufacturer, articelModel,
                                     articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                                     articelMinStock, articelPrice, articelWeight, articelDimesnions,
                                     articelDescription,
                                     fanSpeedRPM, liquidCooled, tdpRatingWatts, compatibilitySockets);
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