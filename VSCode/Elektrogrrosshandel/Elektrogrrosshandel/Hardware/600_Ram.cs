// Pseudocode / Plan (ausführlich):
// 1. Namespace und using-Deklarationen analog zur vorhandenen Grafik-Karten-Klasse erstellen.
// 2. Interne Klasse `Ram` erstellen, die von `ComputerHardware` erbt.
// 3. Private Eigenschaften definieren, die dem Stil von `GraphicCard` entsprechen:
//    - Allgemeine Artikelfelder: ArticelID, ArticelName, ArticelManufacturer, ArticelModel, ArticelYearOfProduction,
//      ArticelManufactrerID, ArticelColors, ArticelStock, ArticelMinStock, ArticelPrice, ArticelWeight,
//      ArticelDimesnions, ArticelDescription
//    - RAM-spezifische Felder: RamCapacity (MB), RamFrequency (MHz), RamType (z.B. "DDR4"), RamModules (Anzahl), RamECC (bool)
//    - Gruppenfelder: ArticelGroupName (static), ArticelGroupID (static), ArticelGroupDescription
//    - Statische List<int> ArticelIDs zum Verwalten bereits vergebener IDs.
// 4. Privaten Konstruktor implementieren, der alle Felder setzt und `ComputerHardware.AddRam(this)` aufruft.
// 5. Statische Fabrikmethode `CreateRam(...)` implementieren:
//    - Vor dem Erzeugen prüfen, ob bereits ein RAM mit gleichem Modell und Hersteller-ID existiert (ComputerHardware.Rams).
//    - Neue Artikel-ID mit `CreateArticelID()` erzeugen.
//    - Instanz zurückgeben.
// 6. Statische Hilfsmethode `CreateArticelID()` analog zur GraphicCard-Klasse implementieren:
//    - Zufällige vierstellige Zahl (1..9999) erzeugen, sicherstellen, dass sie noch nicht in ArticelIDs ist.
//    - ID zusammensetzen: ComputerHardware.ArticelParentGroupID + ArticelGroupID + vierstellige Zahl (D4).
//    - Als int parsen und zurückgeben.
// 7. Stil-/Namenskonventionen und typos aus dem Beispiel übernehmen (z.B. "ArticelDimesnions") damit Klasse zum vorhandenen Code passt.

// Implementierung:
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

        private static List<int> ArticelIDs = new List<int>();

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
                    ArticelIDs.Add(iD);
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