using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Functions.ShopFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class ProductCatalog
    {
        public static void ShowProductCatalog(int i) 
        { 
            MenuSelection(i);
        }

        private static void MenuSelection(int UserChoice)
        {
            bool validMenuOption = false;

            switch (UserChoice)
            {
                case 1:

                    string userInputCategorie;
                    validMenuOption = false;

                    GUI_Display.DisplayWindow(GUI_ProductCatalogCategories.ShowProductCatalog());

                    userInputCategorie = UserInput.GetStringInput("Geben Sie den Namen der Kategorie ein, die Sie anzeigen möchten oder 1 - 3:");

                    if (validMenuOption = (int.TryParse(userInputCategorie, out int choice)))
                    {
                        if (choice >= 1 && choice <= GUI_ProductCatalogCategories.MaxMenuItems())
                        {
                            MenuSelection(choice);
                            break;
                        }
                    }

                    else
                    {
                        ShopProductCategories.ShowShopProductCategories(userInputCategorie);
                        break;
                    }
                    break;

                case 2:

                    string userInputManufacturer = "";

                    validMenuOption = false;

                    GUI_Display.DisplayWindow(GUI_ProductCatalogManufacturers.ShowProductCatalog());

                    userInputManufacturer = UserInput.GetStringInput("Geben Sie den Namen des Herstellers ein, die Sie anzeigen möchten oder 1 - 3:");

                    if (validMenuOption = (int.TryParse(userInputManufacturer, out choice)))
                    {
                        if (choice >= 1 && choice <= GUI_ProductCatalogCategories.MaxMenuItems())
                        {
                            MenuSelection(choice);
                            break;
                        }
                    }

                    else
                    {
                        ShopProductManufacturer.ShopManufacturers(userInputManufacturer);
                        break;
                    }
                    break;

                case 3:

                    MainMenu.ShowMainMenu();
                    break;
            }
        }
    }
}
