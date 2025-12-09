// """

namespace Elektrogrosshandel.Hardware
{
    internal class Case : ComputerHardware
    {
        private string CaseFormFactor { get; set; }
        private int CaseFanSlots { get; set; }
        private string FrontPanelPorts { get; set; }

        private static string ArticelGroupName = "Case";
        private static int ArticelGroupID = 400;
        private string ArticelGroupDescription = "This category includes all kinds of computer cases, ranging from compact enclosures to full-tower designs for gaming and workstation builds.";

        private static List<Int64> ArticelIDs = new List<Int64>();

        public Case(string articelName, string articelManufacturer, string articelModel,
                            int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                            int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                            string articelDescription, string caseFormFactor, int caseFanSlots, string frontPanelPorts) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {
            this.CaseFormFactor = caseFormFactor;
            this.CaseFanSlots = caseFanSlots;
            this.FrontPanelPorts = frontPanelPorts;

            ComputerHardware.AddCase(this);
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

            articelID = ComputerHardware.ArticelParentGroupID + ArticelGroupID.ToString() + iD.ToString();
            iD = Int64.Parse(articelID);
            ArticelIDs.Add(iD);

            return iD;
        }
    }
}