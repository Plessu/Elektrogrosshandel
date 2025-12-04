using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*
Pseudocode / Plan (detailliert):

- Datei: 400_Processor.cs
- Namespace: Elektrogrrosshandel.Hardware
- Klasse: Processor (internal, erbt von ComputerHardware)
- Private Eigenschaften (Articel ...):
  - ArticelID, ArticelName, ArticelManufacturer, ArticelModel, ArticelYearOfProduction,
    ArticelManufactrerID, ArticelColors, ArticelStock, ArticelMinStock, ArticelPrice,
    ArticelWeight, ArticelDimesnions, ArticelDescription
  - CoreCount, ThreadCount, BaseClockMHz, BoostClockMHz, TDPWatts, Socket,
    IntegratedGraphics, LithographyNm, CacheMB, PowerConsumptionWatts
- Statische Gruppendaten:
  - ArticelGroupName = "Processor"
  - ArticelGroupID = 400
  - ArticelGroupDescription
  - ArticelIDs List<int>
- Konstruktor:
  - private Processor(...) setzt alle Felder
  - ruft ComputerHardware.AddProcessor(this)
- Fabrikmethode:
  - public static Processor CreateProcessor(...)
  - Validierung: durchlaufe ComputerHardware.Processors und werfe ArgumentException,
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
    internal class Processor : ComputerHardware
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

        private int CoreCount { get; set; }
        private int ThreadCount { get; set; }
        private int BaseClockMHz { get; set; }
        private int BoostClockMHz { get; set; }
        private int TDPWatts { get; set; }
        private string Socket { get; set; }
        private bool IntegratedGraphics { get; set; }
        private int LithographyNm { get; set; }
        private int CacheMB { get; set; }
        private int PowerConsumptionWatts { get; set; }

        private static string ArticelGroupName = "Processor";
        private static int ArticelGroupID = 400;
        private string ArticelGroupDescription = "This category includes central processing units (CPUs) with various core counts, clock rates and socket types.";

        private static List<int> ArticelIDs = new List<int>();

        private Processor(int articelID, string articelName, string articelManufacturer, string articelModel,
                          int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                          int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                          string articelDescription,
                          int coreCount, int threadCount, int baseClockMHz, int boostClockMHz, int tdpWatts,
                          string socket, bool integratedGraphics, int lithographyNm, int cacheMB, int powerConsumptionWatts) : base()
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

            CoreCount = coreCount;
            ThreadCount = threadCount;
            BaseClockMHz = baseClockMHz;
            BoostClockMHz = boostClockMHz;
            TDPWatts = tdpWatts;
            Socket = socket;
            IntegratedGraphics = integratedGraphics;
            LithographyNm = lithographyNm;
            CacheMB = cacheMB;
            PowerConsumptionWatts = powerConsumptionWatts;

            ComputerHardware.AddProcessor(this);
        }

        public static Processor CreateProcessor(string articelName, string articelManufacturer, string articelModel,
                                                int articelYearOfProduction, int articelManufactrerID,
                                                string[] articelColors, int articelStock, int articelMinStock,
                                                double articelPrice, int articelWeight, int[] articelDimesnions,
                                                string articelDescription,
                                                int coreCount, int threadCount, int baseClockMHz, int boostClockMHz, int tdpWatts,
                                                string socket, bool integratedGraphics, int lithographyNm, int cacheMB, int powerConsumptionWatts)
        {
            foreach (var item in ComputerHardware.Processors)
            {
                if (item.ArticelModel == articelModel && item.ArticelManufactrerID == articelManufactrerID)
                {
                    throw new ArgumentException("Processor with the same model and manufacturer ID already exists.");
                }
            }

            int articelID = CreateArticelID();

            return new Processor(articelID, articelName, articelManufacturer, articelModel,
                                 articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                                 articelMinStock, articelPrice, articelWeight, articelDimesnions,
                                 articelDescription,
                                 coreCount, threadCount, baseClockMHz, boostClockMHz, tdpWatts,
                                 socket, integratedGraphics, lithographyNm, cacheMB, powerConsumptionWatts);
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