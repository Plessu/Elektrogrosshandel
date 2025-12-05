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
        private int ArticelID { get; set; }
        private string ArticelName { get; set; }
        private string ArticelPublisher { get; set; }
        private string ArticelVersion { get; set; }
        private int ArticelYearOfRelease { get; set; }
        private int ArticelPublisherID { get; set; }
        private string[] ArticelSupportedOS { get; set; }
        private string ArticelLicenseType { get; set; }
        private bool ArticelIsSubscription { get; set; }
        private string[] ArticelLanguages { get; set; }
        private int ArticelStock { get; set; }
        private int ArticelMinStock { get; set; }
        private double ArticelPrice { get; set; }
        private string ArticelDescription { get; set; }

        private static string ArticelGroupName = "Software";
        private static int ArticelGroupID = 950;
        private string ArticelGroupDescription = "Softwareprodukte, Lizenzen und digitale Güter.";

        private static List<int> ArticelIDs = new List<int>();

        private Software(int articelID, string articelName, string articelPublisher, string articelVersion,
                         int articelYearOfRelease, int articelPublisherID, string[] articelSupportedOS,
                         string articelLicenseType, bool articelIsSubscription, string[] articelLanguages,
                         int articelStock, int articelMinStock, double articelPrice, string articelDescription) : base()
        {
            ArticelID = articelID;
            ArticelName = articelName;
            ArticelPublisher = articelPublisher;
            ArticelVersion = articelVersion;
            ArticelYearOfRelease = articelYearOfRelease;
            ArticelPublisherID = articelPublisherID;
            ArticelSupportedOS = articelSupportedOS;
            ArticelLicenseType = articelLicenseType;
            ArticelIsSubscription = articelIsSubscription;
            ArticelLanguages = articelLanguages;
            ArticelStock = articelStock;
            ArticelMinStock = articelMinStock;
            ArticelPrice = articelPrice;
            ArticelDescription = articelDescription;

            ComputerHardware.AddSoftware(this);
        }

        public static Software CreateSoftware(string articelName, string articelPublisher, string articelVersion,
                                              int articelYearOfRelease, int articelPublisherID, string[] articelSupportedOS,
                                              string articelLicenseType, bool articelIsSubscription, string[] articelLanguages,
                                              int articelStock, int articelMinStock, double articelPrice, string articelDescription)
        {
            foreach (var item in ComputerHardware.Softwares)
            {
                if (item.ArticelVersion == articelVersion && item.ArticelPublisherID == articelPublisherID)
                {
                    throw new ArgumentException("Software mit derselben Version und Publisher-ID existiert bereits.");
                }
            }

            int articelID = CreateArticelID();

            return new Software(articelID, articelName, articelPublisher, articelVersion,
                                articelYearOfRelease, articelPublisherID, articelSupportedOS,
                                articelLicenseType, articelIsSubscription, articelLanguages,
                                articelStock, articelMinStock, articelPrice, articelDescription);
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