// """

// Implementierung:
namespace Elektrogrosshandel.Hardware
{
    internal class Ram : ComputerHardware
    {
        // RAM-spezifische Eigenschaften
        private int RamCapacity { get; set; } // in MB
        private int RamFrequency { get; set; } // in MHz
        private string RamType { get; set; } // z.B. "DDR4", "DDR5"
        private int RamModules { get; set; } // Anzahl der Module im Kit
        private bool RamECC { get; set; } // Fehlerkorrektur vorhanden

        private static string ArticelGroupName = "RAM";
        private static int ArticelGroupID = 600;
        private string ArticelGroupDescription = "Diese Kategorie enthält Arbeitsspeicher (RAM) für Computer in verschiedenen Kapazitäten, Frequenzen und Typen (z. B. DDR4, DDR5).";

        private static List<Int64> ArticelIDs = new List<Int64>();

        public Ram(string articelName, string articelManufacturer, string articelModel,
                    int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                    int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                    string articelDescription,
                    int ramCapacity, int ramFrequency, string ramType, int ramModules, bool ramEcc) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {

            RamCapacity = ramCapacity;
            RamFrequency = ramFrequency;
            RamType = ramType;
            RamModules = ramModules;
            RamECC = ramEcc;

            ComputerHardware.AddRAM(this);
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
                    ArticelIDs.Add(iD);
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