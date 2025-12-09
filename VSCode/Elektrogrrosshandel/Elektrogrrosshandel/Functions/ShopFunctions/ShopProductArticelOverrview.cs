// """

using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.User;
using Spectre.Console;

namespace Elektrogrosshandel.Functions.ShopFunctions
{
    internal class ShopProductArticelOverrview
    {
        public static void ShowArticelOverview(string articelID)
        {
            bool success = false;
            string userinput;
            int quantity;

            GUI_Display.DisplayWindow(GUI_ProductCatalogArticelOverview.ShowArticelOverview(articelID));

            userinput = Functions.UserInput.GetStringInput("Möchten Sie den Artikel hinzufügen \"add,Quantity\" oder \"back\" um in den Produktkatalog zurückzukehren.");

            if (userinput.ToLower().StartsWith("add"))
            {
                userinput = userinput.ToLower().Replace("add,", "");
                userinput = userinput.Trim();

                if (success = int.TryParse(userinput, out quantity))
                {
                    if (quantity <= 0)
                    {
                        AnsiConsole.MarkupLine("[red]Die Menge muss größer als 0 sein. Bitte versuchen Sie es erneut.[/]");
                        Thread.Sleep(200);

                        ShowArticelOverview(articelID);
                        return;
                    }
                    success = Bucket.AddArticelToBucket(Account.GetActiveBucket(Program.ActiveUser), Int64.Parse(articelID), quantity);

                    if (success)
                    {
                        AnsiConsole.MarkupLine("[green]Der Artikel wurde erfolgreich zum Warenkorb hinzugefügt![/]");
                        AnsiConsole.MarkupLine("[blue]Sie kehren nun zum Produktkatalog zurück.[/]");
                        ProductCatalog.ShowProductCatalog(1);
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]Beim Hinzufügen des Artikels zum Warenkorb ist ein Fehler aufgetreten. Bitte versuchen Sie es erneut.[/]");
                        ShowArticelOverview(articelID);
                    }
                }
            }
            else if (userinput.ToLower() == "back")
            {
                ProductCatalog.ShowProductCatalog(1);
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte versuchen Sie es erneut.[/]");
                ShowArticelOverview(articelID);
            }
        }
    }
}
