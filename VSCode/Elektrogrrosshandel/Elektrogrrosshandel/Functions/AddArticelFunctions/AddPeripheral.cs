using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Hardware;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Elektrogrosshandel.Functions.AddArticelFunctions
{
    internal class AddPeripheral
    {
        private static List<string> addItemsBase = new List<string>
        {
                "Bitte geben Sie den Namen des Peripheriegeräts ein",
                "Bitte geben Sie einen Hersteller ein",
                "Bitte geben Sie ein Modell ein",
                "Bitte geben Sie ein Produktionsjahr ein",
                "Bitte geben Sie eine Hersteller ID ein",
                "Bitte geben Sie verfügbare Farben ein (Komma getrennt, max 3)",
                "Bitte geben Sie den Lagerbestand ein",
                "Bitte geben Sie den Mindestlagerbestand ein",
                "Bitte geben Sie den Preis ein",
                "Bitte geben Sie das Gewicht ein (in Gramm)",
                "Bitte geben Sie die Abmessungen ein (Länge,Breite,Höhe in cm, Komma getrennt)",
                "Bitte geben Sie den Link zur Artikelbeschreibung ein",
        };

        private static List<string> addItemsPeripheral = new List<string>
        {
                "Bitte geben Sie den Peripherie-Typ ein (z.B. Maus, Tastatur, Headset)",
                "Bitte geben Sie den Schnittstellentyp ein (z.B. USB, Bluetooth)",
                "Ist das Gerät kabellos? (ja/nein)",
                "Bitte geben Sie die Akkulaufzeit in Stunden ein (falls relevant, sonst 0)",
                "Bitte geben Sie die Anzahl der Tasten ein (falls nicht relevant, 0)",
                "Bitte geben Sie die DPI ein (falls Maus, sonst 0)",
                "Bitte geben Sie den Schaltertyp ein (z.B. Cherry MX Red) oder 'keiner'",
                "Unterstützt RGB? (ja/nein)",
                "Bitte geben Sie Konnektivitätsoptionen ein (Komma getrennt, z.B. USB,Bluetooth)",
        };

        private static List<string> GetAddPeripheralItems()
        {
            List<string> combinedList = new List<string>(addItemsBase);
            combinedList.AddRange(addItemsPeripheral);
            return combinedList;
        }

        public static void AddPeripheralMenu()
        {
            List<string> items = GetAddPeripheralItems();

            string name = UserInput.GetStringInput(items[0]);
            string manufacturer = UserInput.GetStringInput(items[1]);
            string model = UserInput.GetStringInput(items[2]);

            GUI_Display.DisplayWindow(GUI_AdminMenuMenuAddArticel.ShowAdminMenu());

            int year;
            do
            {
                string yearStr = UserInput.GetStringInput(items[3]);
                if (int.TryParse(yearStr, out year)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie ein gültiges Produktionsjahr ein (nur Zahlen).[/]");
            } while (true);

            int manufacturerID;
            do
            {
                string mId = UserInput.GetStringInput(items[4]);
                if (mId.All(char.IsDigit))
                {
                    manufacturerID = int.Parse(mId);
                    break;
                }
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie eine gültige Hersteller ID ein (nur Zahlen).[/]");
            } while (true);

            string colorsRaw = UserInput.GetStringInput(items[5]);
            colorsRaw = colorsRaw.Replace(" ", "");
            string[] colors = colorsRaw.Split(',');

            do
            {
                if (colors.Length > 3)
                {
                    AnsiConsole.MarkupLine("[red]Sie haben mehr als 3 Farben eingegeben. Bitte geben Sie maximal 3 Farben ein (Komma getrennt).[/]");
                    colorsRaw = UserInput.GetStringInput(items[5]);
                    colorsRaw = colorsRaw.Replace(" ", "");
                    colors = colorsRaw.Split(',');
                }
                else break;
            } while (true);

            AnsiConsole.MarkupLine($"[green]Eingegebene Farben:[/] {string.Join(", ", colors)}");

            int stock;
            do
            {
                string stockStr = UserInput.GetStringInput(items[6]);
                if (int.TryParse(stockStr, out stock)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie einen gültigen Lagerbestand ein (nur Zahlen).[/]");
            } while (true);

            int minStock;
            do
            {
                string minStockStr = UserInput.GetStringInput(items[7]);
                if (int.TryParse(minStockStr, out minStock)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie einen gültigen Mindestlagerbestand ein (nur Zahlen).[/]");
            } while (true);

            double price;
            do
            {
                string priceStr = UserInput.GetStringInput(items[8]);
                if (double.TryParse(priceStr, out price)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie einen gültigen Preis ein (nur Zahlen).[/]");
            } while (true);

            int weight;
            do
            {
                string weightStr = UserInput.GetStringInput(items[9]);
                if (int.TryParse(weightStr, out weight)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie ein gültiges Gewicht ein (nur Zahlen).[/]");
            } while (true);

            int length, width, height;
            int[] dimensions;
            do
            {
                string dims = UserInput.GetStringInput(items[10]);
                dims = dims.Replace(" ", "");
                string[] parts = dims.Split(',');
                if (parts.Length == 3 &&
                    int.TryParse(parts[0], out length) &&
                    int.TryParse(parts[1], out width) &&
                    int.TryParse(parts[2], out height))
                {
                    dimensions = new int[] { length, width, height };
                    break;
                }
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Abmessungen im Format Länge,Breite,Höhe ein (nur Zahlen).[/]");
            } while (true);

            string description = UserInput.GetStringInput(items[11]);

            // Peripheral spezifisch
            string peripheralType = UserInput.GetStringInput(items[12]);
            string interfaceType = UserInput.GetStringInput(items[13]);

            bool wireless;
            do
            {
                string s = UserInput.GetStringInput(items[14]).Trim().ToLowerInvariant();
                if (s == "ja" || s == "j" || s == "true" || s == "t") { wireless = true; break; }
                else if (s == "nein" || s == "n" || s == "false" || s == "f") { wireless = false; break; }
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte antworten Sie mit 'ja' oder 'nein'.[/]");
            } while (true);

            int battery;
            do
            {
                string s = UserInput.GetStringInput(items[15]);
                if (int.TryParse(s, out battery)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Akkulaufzeit in Stunden ein (nur Zahlen).[/]");
            } while (true);

            int buttons;
            do
            {
                string s = UserInput.GetStringInput(items[16]);
                if (int.TryParse(s, out buttons)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Anzahl der Tasten ein (nur Zahlen).[/]");
            } while (true);

            int dpi;
            do
            {
                string s = UserInput.GetStringInput(items[17]);
                if (int.TryParse(s, out dpi)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die DPI ein (nur Zahlen).[/]");
            } while (true);

            string keySwitchType = UserInput.GetStringInput(items[18]);

            bool rgb;
            do
            {
                string s = UserInput.GetStringInput(items[19]).Trim().ToLowerInvariant();
                if (s == "ja" || s == "j" || s == "true" || s == "t") { rgb = true; break; }
                else if (s == "nein" || s == "n" || s == "false" || s == "f") { rgb = false; break; }
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte antworten Sie mit 'ja' oder 'nein'.[/]");
            } while (true);

            string connectivityRaw = UserInput.GetStringInput(items[20]);
            connectivityRaw = connectivityRaw.Replace(" ", "");
            string[] connectivityOptions = string.IsNullOrWhiteSpace(connectivityRaw) ? new string[0] : connectivityRaw.Split(',');

            Peripheral newPeripheral = new Peripheral(
                name,
                manufacturer,
                model,
                year,
                manufacturerID,
                colors,
                stock,
                minStock,
                price,
                weight,
                dimensions,
                description,
                peripheralType,
                interfaceType,
                wireless,
                battery,
                buttons,
                dpi,
                keySwitchType,
                rgb,
                connectivityOptions
            );

            AnsiConsole.MarkupLine("[green]Das Peripheriegerät wurde erfolgreich hinzugefügt![/]");
            AnsiConsole.MarkupLine("[blue]Sie werden zum Hauptmenü zurückgeleitet...[/]");
            Thread.Sleep(500);
            MainMenu.ShowMainMenu();
        }
    }
}