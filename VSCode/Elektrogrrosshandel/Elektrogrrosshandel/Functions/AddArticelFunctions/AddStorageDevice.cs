// """

using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Hardware;
using Spectre.Console;

namespace Elektrogrosshandel.Functions.AddArticelFunctions
{
    internal class AddStorageDevice
    {
        private static List<string> addItemsBase = new List<string>
        {
                "Bitte geben Sie den Namen des Speichermediums ein",
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

        private static List<string> addItemsStorage = new List<string>
        {
                "Bitte geben Sie die Kapazität in GB ein (z.B. 512)",
                "Bitte geben Sie den Speichertyp ein (z.B. SSD, HDD)",
                "Bitte geben Sie das Speicherinterface ein (z.B. SATA, NVMe)",
                "Bitte geben Sie die Lesegeschwindigkeit in MB/s ein",
                "Bitte geben Sie die Schreibgeschwindigkeit in MB/s ein",
                "Bitte geben Sie das Formfaktor ein (z.B. 2.5, M.2)",
        };

        private static List<string> GetAddStorageItems()
        {
            List<string> combinedList = new List<string>(addItemsBase);
            combinedList.AddRange(addItemsStorage);
            return combinedList;
        }

        public static void AddStorageMenu()
        {
            List<string> items = GetAddStorageItems();

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

            // Storage spezifisch
            int capacity;
            do
            {
                string s = UserInput.GetStringInput(items[12]);
                if (int.TryParse(s, out capacity)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Kapazität in GB ein (nur Zahlen).[/]");
            } while (true);

            string storageType = UserInput.GetStringInput(items[13]);
            string storageInterface = UserInput.GetStringInput(items[14]);

            int readSpeed;
            do
            {
                string s = UserInput.GetStringInput(items[15]);
                if (int.TryParse(s, out readSpeed)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Lesegeschwindigkeit in MB/s ein (nur Zahlen).[/]");
            } while (true);

            int writeSpeed;
            do
            {
                string s = UserInput.GetStringInput(items[16]);
                if (int.TryParse(s, out writeSpeed)) break;
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Schreibgeschwindigkeit in MB/s ein (nur Zahlen).[/]");
            } while (true);

            string formFactor = UserInput.GetStringInput(items[17]);

            StorageDevice newStorage = new StorageDevice(
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
                capacity,
                storageType,
                storageInterface,
                readSpeed,
                writeSpeed,
                formFactor
            );
            HardWareStorage.SaveAllDevices("hardware_storage.json");
            AnsiConsole.MarkupLine("[green]Das Speichermedium wurde erfolgreich hinzugefügt![/]");
            AnsiConsole.MarkupLine("[blue]Sie werden zum Hauptmenü zurückgeleitet...[/]");
            Thread.Sleep(500);
            MainMenu.ShowMainMenu();
        }
    }
}
