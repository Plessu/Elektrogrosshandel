// Pseudocode / Plan (deutsch, detailliert):
// 1. Neue Klasse `Case` erstellen, basierend auf der vorhandenen `GraphicCard`-Datei.
// 2. Alle Vorkommen von "GraphicCard" durch "Case" ersetzen:
//    - Klassennamen, Konstruktorname, Factory-Methode, statische Listen- und Methodenaufrufe zu `ComputerHardware`.
// 3. Alle Felder, Eigenschaften und Methodenbezeichner beibehalten (Articel...-Namen bleiben unverändert).
// 4. Statische Gruppennamen anpassen: ArticelGroupName auf "Case" setzen.
// 5. Factory-Methode `CreateCase` implementieren, die Duplikate prüft:
//    - Durchlaufe `ComputerHardware.Cases` und prüfe auf gleiches Model + Hersteller-ID.
//    - Falls gefunden, ArgumentException werfen.
//    - Ansonsten `CreateArticelID()` aufrufen und neuen `Case` erstellen.
// 6. Privaten Konstruktor anlegen, der die Felder setzt und `ComputerHardware.AddCase(this)` aufruft.
// 7. `CreateArticelID()` übernehmen und anpassen (bei Bedarf unverändert lassen).
// 8. Usings, Namespace und Sichtbarkeit analog zur Vorlage übernehmen.
// 9. Datei als `Elektrogrrosshandel\Hardware\Case.cs` speichern.
//
// Hinweis: Diese Implementierung ist 1:1 an die Vorlage angelehnt; nur Bezeichner und Texte auf "Case" geändert.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

        private static List<int> ArticelIDs = new List<int>();

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