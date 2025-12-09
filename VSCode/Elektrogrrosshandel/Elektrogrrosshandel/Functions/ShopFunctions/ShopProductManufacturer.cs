// """

using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Spectre.Console;

namespace Elektrogrosshandel.Functions.ShopFunctions
{
    internal class ShopProductManufacturer
    {
        public static void ShopManufacturers(string UserInput)
        {
            int choice;
            string userInput;

            AnsiConsole.MarkupLine($"[bold green]{UserInput} manufacturer selected.[/]");
            Thread.Sleep(200);

            GUI_Display.DisplayWindow(GUI_ProductCatalogManufacturerSelected.ShowManufacturerSelected(UserInput));
            AnsiConsole.MarkupLine($"");

            userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

            if (int.TryParse(userInput, out choice))
            {
                if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                {
                    ProductCatalog.ShowProductCatalog(choice);
                }
            }
            else
            {
                ShopProductArticelOverrview.ShowArticelOverview(userInput);
            }
        }
    }
}
