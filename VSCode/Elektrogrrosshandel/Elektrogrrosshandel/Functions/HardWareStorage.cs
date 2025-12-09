using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Elektrogrosshandel.Hardware;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Elektrogrosshandel.Functions
{
    internal static class HardWareStorage
    {
        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
                ContractResolver = new DefaultContractResolver
                {
                    DefaultMembersSearchFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
                },
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public static void SaveAllDevices(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Pfad ist ungültig.", nameof(filePath));

            var settings = GetSerializerSettings();

            // Serialisiere alle Geräte (polymorph)
            string json = JsonConvert.SerializeObject(ComputerHardware.Devices, settings);

            // Sicherstellen, dass Zielverzeichnis existiert
            var dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(filePath, json);
        }

        public static List<ComputerHardware> LoadAllDevices(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Pfad ist ungültig.", nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException("Die Datei wurde nicht gefunden.", filePath);

            var settings = GetSerializerSettings();

            string json = File.ReadAllText(filePath);
            var deserialized = JsonConvert.DeserializeObject<List<ComputerHardware>>(json, settings)
                               ?? new List<ComputerHardware>();

            // Alte Listen zurücksetzen
            ComputerHardware.Devices.Clear();
            ComputerHardware.Cases.Clear();
            ComputerHardware.Motherboards.Clear();
            ComputerHardware.PowerSupplies.Clear();
            ComputerHardware.Processors.Clear();
            ComputerHardware.GraphicsCards.Clear();
            ComputerHardware.RAMs.Clear();
            ComputerHardware.StorageDevices.Clear();
            ComputerHardware.CoolingSystems.Clear();
            ComputerHardware.Peripherals.Clear();
            ComputerHardware.Displays.Clear();
            ComputerHardware.Softwares.Clear();
            ComputerHardware.Manufacturers.Clear();

            // Wiederherstellen und in die passenden kategorischen Listen eintragen
            foreach (var device in deserialized)
            {
                switch (device)
                {
                    case Case c:
                        ComputerHardware.AddCase(c);
                        break;
                    case Motherboard m:
                        ComputerHardware.AddMotherboard(m);
                        break;
                    case PowerSupply p:
                        ComputerHardware.AddPowerSupply(p);
                        break;
                    case Processor pr:
                        ComputerHardware.AddProcessor(pr);
                        break;
                    case GraphicsCard g:
                        ComputerHardware.AddGraphicsCard(g);
                        break;
                    case Ram r:
                        ComputerHardware.AddRAM(r);
                        break;
                    case StorageDevice s:
                        ComputerHardware.AddStorageDevice(s);
                        break;
                    case CoolingSystem cs:
                        ComputerHardware.AddCoolingSystem(cs);
                        break;
                    case Peripheral per:
                        ComputerHardware.AddPeripheral(per);
                        break;
                    case Display d:
                        ComputerHardware.AddDisplay(d);
                        break;
                    case Software sw:
                        ComputerHardware.AddSoftware(sw);
                        break;
                    default:
                        // Fallback: falls ein unbekannter Subtyp vorhanden ist, in Devices aufnehmen
                        ComputerHardware.Devices.Add(device);
                        break;
                }
            }

            // Herstellerliste neu aufbauen
            foreach (var dev in ComputerHardware.Devices)
            {
                // Zugriff auf private Property ArticelManufacturer erfolgt via Reflection, da Property intern/privat ist.
                var prop = dev.GetType().GetProperty("ArticelManufacturer", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (prop != null)
                {
                    var m = prop.GetValue(dev) as string;
                    if (!string.IsNullOrEmpty(m) && !ComputerHardware.Manufacturers.Contains(m))
                    {
                        ComputerHardware.Manufacturers.Add(m);
                    }
                }
            }

            return ComputerHardware.Devices;
        }
    }
}
