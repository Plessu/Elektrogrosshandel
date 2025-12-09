// """

using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Hardware;
using Spectre.Console;

namespace Elektrogrosshandel.Functions.AddArticelFunctions
{

    internal class AddCase
    {
        // Plan (Pseudocode):
        // 1. Entferne die Verwendung von Spectre.Console.Markup in dieser Datei.
        // 2. Ersetze die beiden Listen vom Typ List<Markup> durch List<string>.
        // 3. Bewahre die gleichen Texte der Markup-Einträge, aber als einfache Strings (inkl. eckiger Klammern).
        // 4. Passe die Hilfsmethode GetAddCaseItems so an, dass sie List<string> zurückgibt.
        // 5. Den Rest der Klasse unverändert lassen, damit nachfolgender Code weiterhin funktioniert.
        // 6. Formatierung und Sichtbarkeit so belassen, wie im bestehenden Projekt.

        private static List<string> addItemsBase = new List<string>
        {
                "Bitte geben Sie den Namen des Cases ein",
                "Bitte geben Sie einen Hersteller ein",
                "Bitte geben Sie ein Modell ein",
                "Bitte geben Sie ein Produktionsjahr ein",
                "Bitte geben Sie eine Hersteller ID ein",
                "Bitte geben Sie verfügbare Farben ein (Komma getrennt, max 3)",
                "Bitte geben Sie den Lagerbestand ein",
                "Bitte geben Sie den Mindestlagerbestand ein",
                "Bitte geben Sie den Preis ein",
                "Bitte geben Sie das Gewicht ein (in Gramm)",
                "Bitte geben Sie die Abmessungen ein (Länge,Breite,Höhe in cm, Komma getrennt)[/]",
                "Bitte geben Sie den Link zur Artikelbeschreibung ein",
        };

        private static List<string> addItemsCase = new List<string>
        {
                "Bitte geben Sie den Formfaktor des Gehäuses ein",
                "Bitte geben Sie die Anzahl der Lüfterplätze ein",
                "Bitte geben Sie die Frontanschlüsse ein",
        };

        private static List<string> GetAddCaseItems()
        {
            List<string> combinedList = new List<string>(addItemsBase);
            combinedList.AddRange(addItemsCase);
            return combinedList;
        }

        public static void AddCaseMenu()
        {
            List<string> addCaseItems = GetAddCaseItems();
            string articlename;
            string articlemanufacturer;
            string articlemodel;
            string productionyear;
            int productionyearInt;
            string manufacturerID;
            int manufacturerIDInt;
            string availablecolors;
            string[] colorsArray;
            string stock;
            int stockInt;
            string minstock;
            int minstockInt;
            string price;
            double priceDouble;
            string weight;
            int weightInt;
            string dimensions;
            int length;
            int width;
            int height;
            int[] dimensionsArray;
            string articledescription;
            string caseformfactor;
            string casefanNumber;
            int casefanNumberInt;
            string casefrontports;

            articlename = UserInput.GetStringInput(addCaseItems[0]);
            articlemanufacturer = UserInput.GetStringInput(addCaseItems[1]);
            articlemodel = UserInput.GetStringInput(addCaseItems[2]);

            GUI_Display.DisplayWindow(GUI_AdminMenuMenuAddArticel.ShowAdminMenu());

            do
            {
                productionyear = UserInput.GetStringInput(addCaseItems[3]);

                if (int.TryParse(productionyear, out productionyearInt))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie ein gültiges Produktionsjahr ein (nur Zahlen).[/]");
                }
            } while (true);

            do
            {
                manufacturerID = UserInput.GetStringInput(addCaseItems[4]);

                if (manufacturerID.All(char.IsDigit))
                {
                    manufacturerIDInt = int.Parse(manufacturerID);
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie eine gültige Hersteller ID ein (nur Zahlen).[/]");
                }
            } while (true);

            availablecolors = UserInput.GetStringInput(addCaseItems[5]);
            availablecolors = availablecolors.Replace(" ", "");
            colorsArray = availablecolors.Split(',');

            do
            {
                if (colorsArray.Length > 3)
                {
                    AnsiConsole.MarkupLine("[red]Sie haben mehr als 3 Farben eingegeben. Bitte geben Sie maximal 3 Farben ein (Komma getrennt).[/]");
                    availablecolors = UserInput.GetStringInput(addCaseItems[5]);
                    availablecolors = availablecolors.Replace(" ", "");
                    colorsArray = availablecolors.Split(',');
                }
                else
                {
                    break;
                }
            } while (true);

            AnsiConsole.MarkupLine($"[green]Eingegebene Farben:[/] {string.Join(", ", colorsArray)}");

            do
            {
                stock = UserInput.GetStringInput(addCaseItems[6]);
                if (int.TryParse(stock, out stockInt))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie einen gültigen Lagerbestand ein (nur Zahlen).[/]");
                }
            } while (true);

            do
            {
                minstock = UserInput.GetStringInput(addCaseItems[7]);
                if (int.TryParse(minstock, out minstockInt))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie einen gültigen Mindestlagerbestand ein (nur Zahlen).[/]");
                }
            } while (true);

            do
            {
                price = UserInput.GetStringInput(addCaseItems[8]);
                if (double.TryParse(price, out priceDouble))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie einen gültigen Preis ein (nur Zahlen).[/]");
                }
            } while (true);

            do
            {
                weight = UserInput.GetStringInput(addCaseItems[9]);
                if (int.TryParse(weight, out weightInt))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie ein gültiges Gewicht ein (nur Zahlen).[/]");
                }
            } while (true);

            do
            {
                dimensions = UserInput.GetStringInput(addCaseItems[10]);
                dimensions = dimensions.Replace(" ", "");
                string[] dims = dimensions.Split(',');
                if (dims.Length == 3 &&
                    int.TryParse(dims[0], out length) &&
                    int.TryParse(dims[1], out width) &&
                    int.TryParse(dims[2], out height))
                {
                    dimensionsArray = new int[] { length, width, height };
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie die Abmessungen im Format Länge,Breite,Höhe ein (nur Zahlen, Komma getrennt).[/]");
                }
            } while (true);

            articledescription = UserInput.GetStringInput(addCaseItems[11]);
            caseformfactor = UserInput.GetStringInput(addCaseItems[12]);

            do
            {
                casefanNumber = UserInput.GetStringInput(addCaseItems[13]);
                if (int.TryParse(casefanNumber, out casefanNumberInt))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte geben Sie eine gültige Anzahl der Lüfterplätze ein (nur Zahlen).[/]");
                }
            } while (true);

            casefrontports = UserInput.GetStringInput(addCaseItems[14]);

            Case newCase = new Case(
                articlename,
                articlemanufacturer,
                articlemodel,
                productionyearInt,
                manufacturerIDInt,
                colorsArray,
                stockInt,
                minstockInt,
                priceDouble,
                weightInt,
                dimensionsArray,
                articledescription,
                caseformfactor,
                casefanNumberInt,
                casefrontports
            );

            AnsiConsole.MarkupLine("[green]Das Gehäuse wurde erfolgreich hinzugefügt![/]");
            AnsiConsole.MarkupLine("[blue]Sie werden zum Hauptmenü zurückgeleitet...[/]");
            Thread.Sleep(500);

            MainMenu.ShowMainMenu();
        }

    }
}
