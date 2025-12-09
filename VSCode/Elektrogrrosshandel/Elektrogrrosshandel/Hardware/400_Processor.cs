// """

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

namespace Elektrogrosshandel.Hardware
{
    internal class Processor : ComputerHardware
    {
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

        private static List<Int64> ArticelIDs = new List<Int64>();

        public Processor(string articelName, string articelManufacturer, string articelModel,
                          int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                          int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                          string articelDescription,
                          int coreCount, int threadCount, int baseClockMHz, int boostClockMHz, int tdpWatts,
                          string socket, bool integratedGraphics, int lithographyNm, int cacheMB, int powerConsumptionWatts) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {

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