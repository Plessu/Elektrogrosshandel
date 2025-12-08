using Elektrogrosshandel.Hardware;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_ProductCatalogManufacturers
    {
        //Menu Items
        private static List<Markup> menuProductCatalog = new List<Markup>
        {
                new Markup("[#c0c0c0]  1. Produktkategorien[/]"),
                new Markup("[bold #c0c0c0]  2. Hersteller[/]"),
                new Markup("[#c0c0c0]  3. Back to MainMenu[/]")
        };

        private static Layout ProductManufacturer()
        {
            Layout mainMenu = new Layout("Shop Menu")
                .SplitColumns(
                    new Layout("Menu").Size(35),
                    new Layout("Hersteller"));

            mainMenu["Menu"].Update(PanelMenu().Expand());
            mainMenu["Hersteller"].Update(PanelManfacturers().Expand());

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

        private static Panel PanelManfacturers()
        {
            List<Markup> manufacturersItems = new List<Markup>();
            List<string> manufacturers = new List<string>();
            manufacturers = ComputerHardware.GetAllManufacturers();
            manufacturersItems.Add(new Markup("[italic #00afff]Please select an manufacturer or change Menu (1 - 3).[/]"));
            manufacturersItems.Add(new Markup("\n[bold blue]Hersteller:[/]"));
            
            foreach (string manufacturer in manufacturers)
            {
                manufacturersItems.Add(new Markup($"[#c0c0c0] - {manufacturer}[/]"));
            }

            //Create Panel for Display area
            Panel panelDisplay = new Panel(
                Align.Left(new Rows(manufacturersItems), VerticalAlignment.Top));
            panelDisplay.Width = 90;
            panelDisplay.Border(BoxBorder.Rounded);
            panelDisplay.Header("[bold #af8700 on black]Product Manufacturers[/]");
            panelDisplay.HeaderAlignment(Justify.Left);
            panelDisplay.Padding = new Padding(1, 1, 1, 1);
            panelDisplay.Expand();
            return panelDisplay;
        }
        public static Layout ShowProductCatalog()
        {
            Layout shopCategorieLayout = ProductManufacturer();
            return shopCategorieLayout;
        }
        public static int MaxMenuItems()
        {
            int maxMenuItems = menuProductCatalog.Count();
            return maxMenuItems;
        }
    }
}
