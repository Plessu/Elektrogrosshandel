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
    internal class AddDisplay
    {
        private static List<string> addItemsBase = new List<string>
        {
                "Bitte geben Sie den Namen des Displays ein",
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

        private static List<string> addItemsDisplay = new List<string>
        {
                "Bitte geben Sie die Auflösung ein (z.B. 1920x1080)",
                "Bitte geben Sie die Bildwiederholfrequenz in Hz ein (z.B. 144)",
                "Bitte geben Sie den Panel-Typ ein (z.B. IPS, VA, TN)",
                "Bitte geben Sie die Größe in Zoll ein (z.B. 27.0)",
                "Unterstützt HDR? (ja/nein)",
                "Bitte geben Sie die Anschlüsse ein (Komma getrennt, z.B. HDMI,DisplayPort)",
                "Bitte geben Sie Adaptive-Sync (z.B. FreeSync, G-Sync oder 'keine') ein",
                "Ist das Display gebogen? (ja/nein)",
                "Ist das Display Touch-fähig? (ja/nein)",
                "Bitte geben Sie die Helligkeit in nits ein (z.B. 300)",
                "Bitte geben Sie das Seitenverhältnis ein (z.B. 16:9)",
        };

        private static List<string> GetAddDisplayItems()
        {
            List<string> combinedList = new List<string>(addItemsBase);
            combinedList.AddRange(addItemsDisplay);
            return combinedList;
        }

        public static void AddDisplayMenu()
        {
            List<string> items = GetAddDisplayItems();

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

            // Display spezifisch
            string resolution = UserInput.GetStringInput(items[12]);

            int refreshRate;
            do
            {
                string s = UserInput.GetStringInput(items[13]);
                if (int.TryParse(s, out refreshRate)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Bildwiederholfrequenz in Hz ein (nur Zahlen).[/]");
            } while (true);

            string panelType = UserInput.GetStringInput(items[14]);

            double sizeInInches;
            do
            {
                string s = UserInput.GetStringInput(items[15]);
                if (double.TryParse(s, out sizeInInches)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Größe in Zoll ein (z.B. 27.0).[/]");
            } while (true);

            bool hdr;
            do
            {
                string s = UserInput.GetStringInput(items[16]).Trim().ToLowerInvariant();
                if (s == "ja" || s == "j" || s == "true" || s == "t")
                {
                    hdr = true; break;
                }
                else if (s == "nein" || s == "n" || s == "false" || s == "f")
                {
                    hdr = false; break;
                }
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte antworten Sie mit 'ja' oder 'nein'.[/]");
            } while (true);

            string portsRaw = UserInput.GetStringInput(items[17]);
            portsRaw = portsRaw.Replace(" ", "");
            string[] ports = portsRaw.Split(',');

            string adaptiveSync = UserInput.GetStringInput(items[18]);

            bool curved;
            do
            {
                string s = UserInput.GetStringInput(items[19]).Trim().ToLowerInvariant();
                if (s == "ja" || s == "j" || s == "true" || s == "t")
                {
                    curved = true; break;
                }
                else if (s == "nein" || s == "n" || s == "false" || s == "f")
                {
                    curved = false; break;
                }
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte antworten Sie mit 'ja' oder 'nein'.[/]");
            } while (true);

            bool touch;
            do
            {
                string s = UserInput.GetStringInput(items[20]).Trim().ToLowerInvariant();
                if (s == "ja" || s == "j" || s == "true" || s == "t")
                {
                    touch = true; break;
                }
                else if (s == "nein" || s == "n" || s == "false" || s == "f")
                {
                    touch = false; break;
                }
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte antworten Sie mit 'ja' oder 'nein'.[/]");
            } while (true);

            int brightness;
            do
            {
                string s = UserInput.GetStringInput(items[21]);
                if (int.TryParse(s, out brightness)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Helligkeit in nits ein (nur Zahlen).[/]");
            } while (true);

            string aspectRatio = UserInput.GetStringInput(items[22]);

            Display newDisplay = new Display(
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
                resolution,
                refreshRate,
                panelType,
                sizeInInches,
                hdr,
                ports,
                adaptiveSync,
                curved,
                touch,
                brightness,
                aspectRatio
            );

            AnsiConsole.MarkupLine("[green]Das Display wurde erfolgreich hinzugefügt![/]");
            AnsiConsole.MarkupLine("[blue]Sie werden zum Hauptmenü zurückgeleitet...[/]");
            Thread.Sleep(500);
            MainMenu.ShowMainMenu();
        }
    }
}