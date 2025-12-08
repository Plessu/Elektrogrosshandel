using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Hardware;
using Elektrogrosshandel.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Elektrogrosshandel.User;

namespace Elektrogrosshandel.Functions.ShopFunctions
{
    internal class ShopProductArticelOverrview
    {
        public static void ShowArticelOverview(string articelID)
        {
            string userinput;
            int quantity;

            GUI_Display.DisplayWindow(GUI_ProductCatalogArticelOverview.ShowArticelOverview(articelID));

            userinput = Functions.UserInput.GetStringInput("Möchten Sie den Artikel hinzufügen \"add + Quantity\" oder \"back\" um in den Produktkatalog zurückzukehren.");

            if (userinput.ToLower().StartsWith("add"))
            {
                userinput = userinput.ToLower().Replace("add ", "");
                userinput = userinput.Replace("+", "");
                userinput = userinput.Trim();

                if (int.TryParse(articelID, out quantity) && quantity > 0)
                {
                    bool success = false;
                    
                    success = Bucket.AddArticelToBucket(Account.GetActiveBucket(Program.ActiveUser), int.Parse(articelID), quantity);

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
                GUI_ProductCatalog.ShowProductCatalog();
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Ungültige Eingabe. Bitte versuchen Sie es erneut.[/]");
                ShowArticelOverview(UserInput);
            }
        }
    }
}
