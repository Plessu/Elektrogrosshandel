// """

/* 
Plan / Pseudocode (ausführlich):
1. Namespace und Usings analog zur vorhandenen Klasse `GraphicCard` anlegen.
2. Klasse `PowerSupply` internal deklarieren und von `ComputerHardware` erben.
3. Private Eigenschaften anlegen:
   - ArticelID (int)
   - ArticelName (string)
   - ArticelManufacturer (string)
   - ArticelModel (string)
   - ArticelYearOfProduction (int)
   - ArticelManufactrerID (int)
   - ArticelColors (string[])
   - ArticelStock (int)
   - ArticelMinStock (int)
   - ArticelPrice (double)
   - ArticelWeight (int)
   - ArticelDimesnions (int[])
   - ArticelDescription (string)
   - Wattage (int)  // spezifisch für Netzteile
4. Statische Felder für Gruppenname, GroupID (300), Gruppenbeschreibung und eine Liste für bereits vergebene ArticelIDs.
5. Privaten Konstruktor implementieren, der alle Felder setzt und `ComputerHardware.AddPowerSupply(this)` aufruft.
6. Öffentliche statische Factory-Methode `CreatePowerSupply` implementieren:
   - Prüft auf vorhandene Einträge in `ComputerHardware.PowerSupplies` mit gleicher `ArticelModel` und `ArticelManufactrerID` und wirft bei Duplikat.
   - Erzeugt eine neue ArticelID über `CreateArticelID`.
   - Gibt eine neue `PowerSupply`-Instanz zurück.
7. Statische Hilfsmethode `CreateArticelID` implementieren:
   - Erzeugt eine eindeutige ID aus `ComputerHardware.ArticelParentGroupID`, `ArticelGroupID` und einer vierstelligen Zufallsnummer.
   - Stellt sicher, dass die ID noch nicht in der lokalen Liste ist, fügt sie hinzu und gibt sie zurück.
8. Stil, Benennung und Fehlerbehandlung analog zur vorhandenen `GraphicCard`-Klasse halten.
*/

namespace Elektrogrosshandel.Hardware
{
    internal class PowerSupply : ComputerHardware
    {
        private int Wattage { get; set; }

        private static string ArticelGroupName = "Power Supply";
        private static int ArticelGroupID = 300;
        private string ArticelGroupDescription = "This category contains computer power supplies of various wattages and efficiencies.";

        private static List<Int64> ArticelIDs = new List<Int64>();

        public PowerSupply(string articelName, string articelManufacturer, string articelModel,
                            int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                            int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                            string articelDescription, int wattage) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {

            this.Wattage = wattage;
            ComputerHardware.AddPowerSupply(this);
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