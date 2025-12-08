using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;

namespace Elektrogrosshandel.Functions.ShopFunctions
{
    internal class ShopProductCategories
    {
        public ShopProductCategories(string UserInput) 
        { 
            switch (UserInput)
            {
                case "Case":

                    AnsiConsole.MarkupLine("[bold green]Case category selected.[/]");
                    Thread.Sleep(200);

                    GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(UserInput));
                    break;
            }
        }
    }
}
