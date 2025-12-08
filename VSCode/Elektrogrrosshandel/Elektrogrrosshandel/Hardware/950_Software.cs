using System;
using System.Collections.Generic;
using System.Text;

/*
Pseudocode / Plan (detailliert) - DEUTSCH:

- Datei: 950_Software.cs
- Namespace: Elektrogrrosshandel.Hardware
- Klasse: Software (internal, erbt von ComputerHardware)

- Statische Gruppendaten:
  - ArticelGroupName = "Software"
  - ArticelGroupID = 950
  - ArticelGroupDescription (kurz)
  - ArticelIDs List<int> für bereits vergebene IDs

- Private Eigenschaften (Articel...):
  - ArticelID : int
  - ArticelName : string
  - ArticelPublisher : string
  - ArticelVersion : string
  - ArticelYearOfRelease : int
  - ArticelPublisherID : int
  - ArticelSupportedOS : string[]
  - ArticelLicenseType : string
  - ArticelIsSubscription : bool
  - ArticelLanguages : string[]
  - ArticelStock : int
  - ArticelMinStock : int
  - ArticelPrice : double
  - ArticelDescription : string

- Konstruktor:
  - private Software(int articelID, string articelName, string articelPublisher, string articelVersion,
                    int articelYearOfRelease, int articelPublisherID, string[] articelSupportedOS,
                    string articelLicenseType, bool articelIsSubscription, string[] articelLanguages,
                    int articelStock, int articelMinStock, double articelPrice, string articelDescription)
  - setzt alle Felder
  - ruft ComputerHardware.AddSoftware(this)

- Fabrikmethode:
  - public static Software CreateSoftware(...) mit passenden Parametern
  - Validierung: durchlaufe ComputerHardware.Softwares und werfe ArgumentException,
    wenn ArticelVersion und ArticelPublisherID bereits existieren (duplikat vermeiden)
  - Erzeuge ArticelID via CreateArticelID()
  - Erzeuge neues Software-Objekt und return

- CreateArticelID:
  - Random iD zwischen 1..9999 generieren, prüfe gegen ArticelIDs, solange bis frei
  - articelID string zusammensetzen: ComputerHardware.ArticelParentGroupID + ArticelGroupID + iD.ToString("D4")
  - parse zu int, in ArticelIDs speichern, return int
*/

namespace Elektrogrosshandel.Hardware
{
    internal class Software : ComputerHardware
    {
        private string OperatingSystem { get; set; }
        private static string ArticelGroupName = "Software";
        private static int ArticelGroupID = 950;
        private string ArticelGroupDescription = "Softwareprodukte, Lizenzen und digitale Güter.";

        private static List<Int64> ArticelIDs = new List<Int64>();

        public Software(string articelName, string articelManufacturer, string articelModel,
                        int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                        int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                        string articelDescription,string operatingSystem) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {

            OperatingSystem = operatingSystem;

            ComputerHardware.AddSoftware(this);
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