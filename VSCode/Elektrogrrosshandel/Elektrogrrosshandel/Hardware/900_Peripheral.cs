using System;
using System.Collections.Generic;
using System.Text;

/*
Pseudocode / Plan (detailliert):

- Datei: 900_Peripheral.cs
- Namespace: Elektrogrrosshandel.Hardware
- Klasse: Peripheral (internal, erbt von ComputerHardware)

- Statische Gruppendaten:
  - ArticelGroupName = "Peripheral"
  - ArticelGroupID = 900
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

- Private Eigenschaften (Peripheral-spezifisch):
  - PeripheralType : string (z.B. "Mouse","Keyboard","Headset")
  - InterfaceType : string (z.B. "USB","Bluetooth","RF")
  - Wireless : bool
  - BatteryLifeHours : int
  - ButtonsCount : int
  - DPI : int (für Mäuse)
  - KeySwitchType : string (für Tastaturen)
  - RGB : bool
  - ConnectivityOptions : string[]

- Konstruktor:
  - private Peripheral(int articelID, string articelName, string articelManufacturer, string articelModel,
                      int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                      int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                      string articelDescription,
                      string peripheralType, string interfaceType, bool wireless, int batteryLifeHours,
                      int buttonsCount, int dpi, string keySwitchType, bool rgb, string[] connectivityOptions)
  - setzt alle Felder
  - ruft ComputerHardware.AddPeripheral(this)

- Fabrikmethode:
  - public static Peripheral CreatePeripheral(...) mit passenden Parametern
  - Validierung: durchlaufe ComputerHardware.Peripherals und werfe ArgumentException,
    wenn ArticelModel und ArticelManufactrerID bereits existieren
  - Erzeuge ArticelID via CreateArticelID()
  - Erzeuge neues Peripheral-Objekt und return

- CreateArticelID:
  - Random iD zwischen 1..9999 generieren, prüfe gegen ArticelIDs, solange bis frei
  - articelID string zusammensetzen: ComputerHardware.ArticelParentGroupID + ArticelGroupID + iD.ToString("D4")
  - parse zu int, in ArticelIDs speichern, return int
*/

namespace Elektrogrosshandel.Hardware
{
    internal class Peripheral : ComputerHardware
    {
        private string PeripheralType { get; set; }
        private string InterfaceType { get; set; }
        private bool Wireless { get; set; }
        private int BatteryLifeHours { get; set; }
        private int ButtonsCount { get; set; }
        private int DPI { get; set; }
        private string KeySwitchType { get; set; }
        private bool RGB { get; set; }
        private string[] ConnectivityOptions { get; set; }

        private static string ArticelGroupName = "Peripheral";
        private static int ArticelGroupID = 900;
        private string ArticelGroupDescription = "Peripherals such as mice, keyboards, headsets and other input/output devices.";

        private static List<int> ArticelIDs = new List<int>();

        private Peripheral(string articelName, string articelManufacturer, string articelModel,
                           int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                           int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                           string articelDescription,
                           string peripheralType, string interfaceType, bool wireless, int batteryLifeHours,
                           int buttonsCount, int dpi, string keySwitchType, bool rgb, string[] connectivityOptions) : base()
        {

            PeripheralType = peripheralType;
            InterfaceType = interfaceType;
            Wireless = wireless;
            BatteryLifeHours = batteryLifeHours;
            ButtonsCount = buttonsCount;
            DPI = dpi;
            KeySwitchType = keySwitchType;
            RGB = rgb;
            ConnectivityOptions = connectivityOptions;

            ComputerHardware.AddPeripheral(this);
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