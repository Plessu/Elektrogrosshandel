using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*
Pseudocode / Plan (detailliert):

- Datei und Namespace:
  - Datei: 700_StorageDevice.cs
  - Namespace: Elektrogrrosshandel.Hardware

- Klasse:
  - Name: StorageDevices (internal, erbt von ComputerHardware)
  - Privater Konstruktor, statische Fabrikmethode zur Erstellung

- Felder / Eigenschaften (private, wie in Vorlage):
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
  - StorageCapacityGB : int
  - StorageType : string (z.B. "SSD", "HDD")
  - StorageInterface : string (z.B. "SATA", "NVMe")
  - ReadSpeedMBs : int
  - WriteSpeedMBs : int
  - FormFactor : string (z.B. "2.5\"", "M.2")

- Statische Gruppendaten:
  - ArticelGroupName, ArticelGroupID (z.B. 700), ArticelGroupDescription
  - ArticelIDs Liste zur eindeutigen ID-Generierung

- Konstruktor:
  - Privater Konstruktor nimmt alle Felder entgegen
  - Setzt die Felder und ruft ComputerHardware.AddStorageDevice(this)

- Fabrikmethode:
  - Name: CreateStorageDevice
  - Validierung: Prüfe, ob in ComputerHardware.StorageDevices bereits ein Gerät mit gleichem Model und Hersteller-ID existiert; falls ja, throw ArgumentException
  - Erzeuge neues ArticelID mit CreateArticelID()
  - Rückgabe einer neuen Instanz via privatem Konstruktor

- CreateArticelID:
  - Generiere zufällige 1..9999 Zahl, prüfe gegen ArticelIDs
  - Baue ID-String: ComputerHardware.ArticelParentGroupID + ArticelGroupID + Zahl im Format D4
  - Parse zu int, in Liste speichern und zurückgeben

- Konsistenz:
  - Stil, Namenskonventionen und Schreibweise an GraphicCard.cs anlehnen (inkl. Schreibfehler 'Articel' bewusst übernehmen)
  - Methoden- und Feldnamen analog benennen, sodass Integration mit ComputerHardware erwartet werden kann

Ende Pseudocode
*/

namespace Elektrogrosshandel.Hardware
{
    internal class StorageDevice : ComputerHardware
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

        private int StorageCapacityGB { get; set; }
        private string StorageType { get; set; }
        private string StorageInterface { get; set; }
        private int ReadSpeedMBs { get; set; }
        private int WriteSpeedMBs { get; set; }
        private string FormFactor { get; set; }

        private static string ArticelGroupName = "Storage Device";
        private static int ArticelGroupID = 700;
        private string ArticelGroupDescription = "This category includes storage devices such as HDDs and SSDs with various interfaces and form factors.";

        private static List<int> ArticelIDs = new List<int>();

        private StorageDevice(int articelID, string articelName, string articelManufacturer, string articelModel,
                               int articelYearOfProduction, int articelManufactrerID, string[] articelColors, int articelStock,
                               int articelMinStock, double articelPrice, int articelWeight, int[] articelDimesnions,
                               string articelDescription,
                               int storageCapacityGB, string storageType, string storageInterface,
                               int readSpeedMBs, int writeSpeedMBs, string formFactor) : base()
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

            StorageCapacityGB = storageCapacityGB;
            StorageType = storageType;
            StorageInterface = storageInterface;
            ReadSpeedMBs = readSpeedMBs;
            WriteSpeedMBs = writeSpeedMBs;
            FormFactor = formFactor;

            ComputerHardware.AddStorageDevice(this);
        }

        public static StorageDevice CreateStorageDevice(string articelName, string articelManufacturer, string articelModel,
                                                         int articelYearOfProduction, int articelManufactrerID,
                                                         string[] articelColors, int articelStock, int articelMinStock,
                                                         double articelPrice, int articelWeight, int[] articelDimesnions,
                                                         string articelDescription,
                                                         int storageCapacityGB, string storageType, string storageInterface,
                                                         int readSpeedMBs, int writeSpeedMBs, string formFactor)
        {
            foreach (var item in ComputerHardware.StorageDevices)
            {
                if (item.ArticelModel == articelModel && item.ArticelManufactrerID == articelManufactrerID)
                {
                    throw new ArgumentException("Storage device with the same model and manufacturer ID already exists.");
                }
            }

            int articelID = CreateArticelID();

            return new StorageDevice(articelID, articelName, articelManufacturer, articelModel,
                                      articelYearOfProduction, articelManufactrerID, articelColors, articelStock,
                                      articelMinStock, articelPrice, articelWeight, articelDimesnions,
                                      articelDescription,
                                      storageCapacityGB, storageType, storageInterface,
                                      readSpeedMBs, writeSpeedMBs, formFactor);
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