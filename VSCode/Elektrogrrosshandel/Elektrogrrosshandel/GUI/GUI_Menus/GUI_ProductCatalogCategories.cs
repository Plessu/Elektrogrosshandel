using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_ProductCatalogCategories
    {
        //Menu Items
        private static List<Markup> menuProductCatalog = new List<Markup>
        {
                new Markup("[bold #c0c0c0]  1. Produktkategorien[/]"),
                new Markup("[#c0c0c0]  2. Hersteller[/]"),
                new Markup("[#c0c0c0]  3. Back to MainMenu[/]")
        };

        private static Layout ProductCategorie()
        {
            Layout mainMenu = new Layout("Shop Menu")
                .SplitColumns(
                    new Layout("Menu").Size(35),
                    new Layout("Kategorien"));

            mainMenu["Menu"].Update(PanelMenu().Expand());
            mainMenu["Kategorien"].Update(PanelCategories().Expand());

            return mainMenu;
        }

        //Layout
        private static Panel PanelMenu()
        {
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuProductCatalog), VerticalAlignment.Top));
            panelMenu.Height = 5;
            panelMenu.Width = 30;
            panelMenu.Border(BoxBorder.Rounded);
            panelMenu.BorderColor(Color.DarkGoldenrod);
            panelMenu.Header("[bold #af8700 on black]Shop[/]");
            panelMenu.HeaderAlignment(Justify.Left);

            return panelMenu;
        }

        private static Panel PanelCategories()
        {
            string[] addOptions = new string[]
            {
                        "Case",
                        "Mainboard",
                        "CPU",
                        "RAM",
                        "GPU",
                        "PSU",
                        "Storage",
                        "Cooling",
                        "Peripherie",
                        "Display",
                        "Software"
            };

            List<Markup> categoryItems = new List<Markup>();
            categoryItems.Add(new Markup("[italic #00afff]Please select an categorie or change Menu (1 - 3).[/]"));
            categoryItems.Add(new Markup("\n[bold #c0c0c0] Produktkategorien:[/]"));
            foreach (string category in addOptions)
            {
                categoryItems.Add(new Markup($"[#c0c0c0] - {category}[/]"));
            }

            //Create Panel for Display area
            Panel panelDisplay = new Panel(
                Align.Left(new Rows(categoryItems), VerticalAlignment.Top));
            panelDisplay.Width = 90;
            panelDisplay.Border(BoxBorder.Rounded);
            panelDisplay.Header("[bold #af8700 on black]Product Categories[/]");
            panelDisplay.HeaderAlignment(Justify.Left);
            panelDisplay.Padding = new Padding(1, 1, 1, 1);
            panelDisplay.Expand();
            return panelDisplay;
        }
        public static Layout ShowProductCatalog()
        {
            Layout shopCategorieLayout = ProductCategorie();
            return shopCategorieLayout;
        }
        public static int MaxMenuItems()
        {
            int maxMenuItems = menuProductCatalog.Count();
            return maxMenuItems;
        }
    }
}
