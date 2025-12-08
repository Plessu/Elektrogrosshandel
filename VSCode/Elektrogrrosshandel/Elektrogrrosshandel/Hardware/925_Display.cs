using System;
using System.Collections.Generic;
using System.Text;

/*
Pseudocode / Plan (detailliert) - DEUTSCH:

- Datei: 925_Display.cs
- Namespace: Elektrogrrosshandel.Hardware
- Klasse: Display (internal, erbt von ComputerHardware)

- Statische Gruppendaten:
  - ArticelGroupName = "Display"
  - ArticelGroupID = 925
  - ArticelGroupDescription (kurz)
  - ArticelIDs List<int> für bereits vergebene IDs

- Private Eigenschaften (Articel...):
  - ArticelID : int
  - ArticelName : string
  - ArticelManufacturer : string
  - ArticelModel : string
  - ArticelYearOfProduction : int
  - ArticelManufactrerID : int
  - ArticelColors : string[]
  - ArticelStock : int
  - ArticelMinStock : int
  - ArticelPrice : double
  - ArticelWeight : int
  - ArticelDimesnions : int[]
  - ArticelDescription : string

- Private Eigenschaften (Display-spezifisch):
  - Resolution : string (z.B. "1920x1080")
  - RefreshRate : int (Hz)
  - PanelType : string (z.B. "IPS","VA","TN","OLED")
  - SizeInInches : double
  - HDR : bool
  - Ports : string[] (z.B. "HDMI","DisplayPort","USB-C")
  - AdaptiveSync : string (z.B. "G-Sync","FreeSync","None")
  - Curved : bool
  - Touch : bool
  - BrightnessNits : int
  - AspectRatio : string

- Konstruktor:
  - private Display(int articelID, string articelName, string articelManufacturer, string articelModel,
                    int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                    int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                    string articelDescription,
                    string resolution, int refreshRate, string panelType, double sizeInInches, bool hdr,
                    string[] ports, string adaptiveSync, bool curved, bool touch, int brightnessNits, string aspectRatio)
  - setzt alle Felder
  - ruft ComputerHardware.AddDisplay(this)

- Fabrikmethode:
  - public static Display CreateDisplay(...) mit passenden Parametern
  - Validierung: durchlaufe ComputerHardware.Displays und werfe ArgumentException,
    wenn ArticelModel und ArticelManufactrerID bereits existieren
  - Erzeuge ArticelID via CreateArticelID()
  - Erzeuge neues Display-Objekt und return

- CreateArticelID:
  - Random iD zwischen 1..9999 generieren, prüfe gegen ArticelIDs, solange bis frei
  - articelID string zusammensetzen: ComputerHardware.ArticelParentGroupID + ArticelGroupID + iD.ToString("D4")
  - parse zu int, in ArticelIDs speichern, return int
*/

namespace Elektrogrosshandel.Hardware
{
    internal class Display : ComputerHardware
    {
        private string Resolution { get; set; }
        private int RefreshRate { get; set; }
        private string PanelType { get; set; }
        private double SizeInInches { get; set; }
        private bool HDR { get; set; }
        private string[] Ports { get; set; }
        private string AdaptiveSync { get; set; }
        private bool Curved { get; set; }
        private bool Touch { get; set; }
        private int BrightnessNits { get; set; }
        private string AspectRatio { get; set; }

        private static string ArticelGroupName = "Display";
        private static int ArticelGroupID = 925;
        private string ArticelGroupDescription = "Monitors and displays including TVs and professional panels.";

        private static List<int> ArticelIDs = new List<int>();

        public Display(string articelName, string articelManufacturer, string articelModel,
                        int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                        int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                        string articelDescription,
                        string resolution, int refreshRate, string panelType, double sizeInInches, bool hdr,
                        string[] ports, string adaptiveSync, bool curved, bool touch, int brightnessNits, string aspectRatio) : base(CreateArticelID(), articelName, articelManufacturer, articelModel,
                            articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                            articelMinStock, articelPrice, articelWeight, articelDimesnions,
                            articelDescription)
        {

            Resolution = resolution;
            RefreshRate = refreshRate;
            PanelType = panelType;
            SizeInInches = sizeInInches;
            HDR = hdr;
            Ports = ports;
            AdaptiveSync = adaptiveSync;
            Curved = curved;
            Touch = touch;
            BrightnessNits = brightnessNits;
            AspectRatio = aspectRatio;

            ComputerHardware.AddDisplay(this);
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