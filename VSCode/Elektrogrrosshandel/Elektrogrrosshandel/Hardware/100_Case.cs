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
        private string CaseFormFactor { get; set; }
        private int CaseFanSlots { get; set; }
        private string FrontPanelPorts { get; set; }

        private static string ArticelGroupName = "Case";
        private static int ArticelGroupID = 400;
        private string ArticelGroupDescription = "This category includes all kinds of computer cases, ranging from compact enclosures to full-tower designs for gaming and workstation builds.";

        private static List<int> ArticelIDs = new List<int>();

        private Case(int articelID, string articelName, string articelManufacturer, string articelModel,
                            int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                            int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                            string articelDescription, string caseFormFactor, int caseFanSlots, string frontPanelPorts) : base()
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

            this.CaseFormFactor = caseFormFactor;
            this.CaseFanSlots = caseFanSlots;
            this.FrontPanelPorts = frontPanelPorts;

            ComputerHardware.AddCase(this);
        }
        public static Case CreateCase(string articelName, string articelManufacturer, string articelModel,
                                                    int articelYearOfProduction, int articelManufactrerID, 
                                                    string[] articelColors, int articelStock, int articelMinStock, 
                                                    double articelPrice, int articelWeight, int[] articelDimesnions,
                                                    string articelDescription, string caseFormFactor, int caseFanSlots, string frontPanelPorts)
        {
            foreach (var item in ComputerHardware.Cases)
            {
                if (item.ArticelModel == articelModel && item.ArticelManufactrerID == articelManufactrerID)
                {
                    throw new ArgumentException("Case with the same model and manufacturer ID already exists.");
                }
            }

            int articelID = CreateArticelID();

            return new Case(articelID, articelName, articelManufacturer, articelModel,
                                    articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                                    articelMinStock, articelPrice, articelWeight, articelDimesnions,
                                    articelDescription, caseFormFactor, caseFanSlots, frontPanelPorts);
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