// """

namespace Elektrogrosshandel.Hardware
{
    internal class Motherboard : ComputerHardware
    {
        private string Socket { get; set; }
        private string RamType { get; set; }
        private string FormFactor { get; set; }
        private string PCIeVersion { get; set; }
        private string[] StorageInterfaces { get; set; }

        private static string ArticelGroupName = "Motherboard";
        private static int ArticelGroupID = 200;
        private string ArticelGroupDescription = "This category includes all kinds of Motherrboards for computers, ranging from entry-level to high-end models designed for gaming and professional use.";

        private static List<Int64> ArticelIDs = new List<Int64>();

        public Motherboard(string articelName, string articelManufacturer, string articelModel,
                            int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                            int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                            string articelDescription, string Socket, string RamType, string FormFactor,
                            string[] StorageInterfaces, string pCIeVersion) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {

            this.Socket = Socket;
            this.RamType = RamType;
            this.FormFactor = FormFactor;
            this.StorageInterfaces = StorageInterfaces;
            this.PCIeVersion = pCIeVersion;

            ComputerHardware.AddMotherboard(this);
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
