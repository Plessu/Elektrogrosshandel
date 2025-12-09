// """

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

namespace Elektrogrosshandel.Hardware
{
    internal class CoolingSystem : ComputerHardware
    {
        private int FanSpeedRPM { get; set; }
        private bool LiquidCooled { get; set; }
        private int TDPRatingWatts { get; set; }
        private string[] CompatibilitySockets { get; set; }

        private static string ArticelGroupName = "CoolingSystem";
        private static int ArticelGroupID = 800;
        private string ArticelGroupDescription = "This category includes air and liquid cooling solutions for CPUs and other components.";

        private static List<Int64> ArticelIDs = new List<Int64>();

        public CoolingSystem(string articelName, string articelManufacturer, string articelModel,
                              int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                              int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                              string articelDescription,
                              int fanSpeedRPM, bool liquidCooled, int tdpRatingWatts, string[] compatibilitySockets) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {

            FanSpeedRPM = fanSpeedRPM;
            LiquidCooled = liquidCooled;
            TDPRatingWatts = tdpRatingWatts;
            CompatibilitySockets = compatibilitySockets;

            ComputerHardware.AddCoolingSystem(this);
        }

        private static Int64 CreateArticelID()
        {
            string articelID;
            Int64 iD;
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
            iD = Int64.Parse(articelID);
            ArticelIDs.Add(iD);

            return iD;
        }
    }
}