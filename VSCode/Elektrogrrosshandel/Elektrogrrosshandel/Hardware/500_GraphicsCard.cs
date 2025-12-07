using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*
Pseudocode / Plan (detailliert):

- Datei: 500_GraphicsCard.cs
- Namespace: Elektrogrrosshandel.Hardware
- Klasse: GraphicsCard (internal, erbt von ComputerHardware)
- Private Eigenschaften (Articel ...):
  - ArticelID, ArticelName, ArticelManufacturer, ArticelModel, ArticelYearOfProduction,
    ArticelManufactrerID, ArticelColors, ArticelStock, ArticelMinStock, ArticelPrice,
    ArticelWeight, ArticelDimesnions, ArticelDescription
  - VRAM_GB, MemoryType, CoreClockMHz, BoostClockMHz, TDPWatts, PCIeVersion, Outputs, Chipset, CudaCores
- Statische Gruppendaten:
  - ArticelGroupName = "Graphics Card"
  - ArticelGroupID = 500
  - ArticelGroupDescription
  - ArticelIDs List<int>
- Konstruktor:
  - private GraphicsCard(...) setzt Felder und ruft ComputerHardware.AddGraphicsCard(this)
- Fabrikmethode:
  - public static GraphicsCard CreateGraphicsCard(...)
  - Validierung gegen ComputerHardware.GraphicsCards
  - Erzeuge ArticelID via CreateArticelID()
  - Rückgabe neuer Instanz
- CreateArticelID:
  - random 1..9999, prüfe gegen ArticelIDs, baue ID-String mit ComputerHardware.ArticelParentGroupID + ArticelGroupID + D4, parse int, speichern, return
*/

namespace Elektrogrosshandel.Hardware
{
    internal class GraphicsCard : ComputerHardware
    {
        private int VRAM_GB { get; set; }
        private string MemoryType { get; set; }
        private int CoreClockMHz { get; set; }
        private int BoostClockMHz { get; set; }
        private int TDPWatts { get; set; }
        private string PCIeVersion { get; set; }
        private string[] Outputs { get; set; }
        private int PowerConsumptionWatts { get; set; }




        private static string ArticelGroupName = "Graphics Card";
        private static int ArticelGroupID = 500;
        private string ArticelGroupDescription = "This category includes discrete graphics cards with various memory sizes, clock rates and output configurations.";

        private static List<int> ArticelIDs = new List<int>();

        public GraphicsCard(string articelName, string articelManufacturer, string articelModel,
                              int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                              int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                              string articelDescription,
                              int vramGB, string memoryType, int coreClockMHz, int boostClockMHz, int tdpWatts,
                              string pcieVersion, string[] outputs, int powerConsumptionWatts) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {

            VRAM_GB = vramGB;
            MemoryType = memoryType;
            CoreClockMHz = coreClockMHz;
            BoostClockMHz = boostClockMHz;
            TDPWatts = tdpWatts;
            PCIeVersion = pcieVersion;
            Outputs = outputs;
            PowerConsumptionWatts = powerConsumptionWatts;

            ComputerHardware.AddGraphicsCard(this);

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