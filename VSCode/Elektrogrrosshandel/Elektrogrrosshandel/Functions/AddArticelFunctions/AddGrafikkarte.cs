// """

using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Hardware;
using Spectre.Console;

namespace Elektrogrosshandel.Functions.AddArticelFunctions
{
    internal class AddGrafikkarte
    {
        private static List<string> addItemsBase = new List<string>
        {
                "Bitte geben Sie den Namen der Grafikkarte ein",
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

        private static List<string> addItemsGPU = new List<string>
        {
                "Bitte geben Sie den VRAM in GB ein",
                "Bitte geben Sie den Speichertyp ein (z.B. GDDR6)",
                "Bitte geben Sie den Core Clock in MHz ein",
                "Bitte geben Sie den Boost Clock in MHz ein",
                "Bitte geben Sie den TDP in Watt ein",
                "Bitte geben Sie die PCIe Version ein (z.B. PCIe 4.0)",
                "Bitte geben Sie die Ausgänge ein (Komma getrennt, z.B. HDMI,DisplayPort)",
                "Bitte geben Sie den Stromverbrauch in Watt ein",
        };

        private static List<string> GetAddGPUItems()
        {
            List<string> combinedList = new List<string>(addItemsBase);
            combinedList.AddRange(addItemsGPU);
            return combinedList;
        }

        public static void AddGrafikkarteMenu()
        {
            List<string> items = GetAddGPUItems();

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

            // GPU specific
            int vram;
            do
            {
                string vramStr = UserInput.GetStringInput(items[12]);
                if (int.TryParse(vramStr, out vram)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie den VRAM in GB als Zahl ein.[/]");
            } while (true);

            string memoryType = UserInput.GetStringInput(items[13]);

            int coreClock;
            do
            {
                string coreClockStr = UserInput.GetStringInput(items[14]);
                if (int.TryParse(coreClockStr, out coreClock)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie den Core Clock in MHz als Zahl ein.[/]");
            } while (true);

            int boostClock;
            do
            {
                string boostClockStr = UserInput.GetStringInput(items[15]);
                if (int.TryParse(boostClockStr, out boostClock)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie den Boost Clock in MHz als Zahl ein.[/]");
            } while (true);

            int tdp;
            do
            {
                string tdpStr = UserInput.GetStringInput(items[16]);
                if (int.TryParse(tdpStr, out tdp)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie den TDP in Watt als Zahl ein.[/]");
            } while (true);

            string pcieVersion = UserInput.GetStringInput(items[17]);

            string outputsRaw = UserInput.GetStringInput(items[18]);
            outputsRaw = outputsRaw.Replace(" ", "");
            string[] outputs = outputsRaw.Split(',');

            int power;
            do
            {
                string powerStr = UserInput.GetStringInput(items[19]);
                if (int.TryParse(powerStr, out power)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie den Stromverbrauch in Watt als Zahl ein.[/]");
            } while (true);

            // Konstruktor in GraphicsCard erwartet die Parameter in dieser Reihenfolge
            GraphicsCard newGpu = new GraphicsCard(
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
                vram,
                memoryType,
                coreClock,
                boostClock,
                tdp,
                pcieVersion,
                outputs,
                power
            );
            HardWareStorage.SaveAllDevices("hardware_storage.json");
            AnsiConsole.MarkupLine("[green]Die Grafikkarte wurde erfolgreich hinzugefügt![/]");
            AnsiConsole.MarkupLine("[blue]Sie werden zum Hauptmenü zurückgeleitet...[/]");
            Thread.Sleep(500);
            MainMenu.ShowMainMenu();
        }
    }
}
