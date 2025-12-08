using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Elektrogrosshandel.User;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AdminMenuMenuAddArticel
    {

        private static List<Markup> adminMenuItems = new List<Markup>
            {
                new Markup("[bold yellow]1.[/] [bold]Add Artikel[/]"),
                new Markup("[yellow]2.[/] Remove Artikel"),
                new Markup("\n[yellow]5.[/] Back to Account Menu")
            };

        private static Layout AdminMenu()
        {
            Layout accountShoppingCartManager = new Layout("AdminMenu")
                        .SplitColumns(
                            new Layout("MenuAdmin"),
                            new Layout("Display"));

            accountShoppingCartManager["MenuAdmin"].Size(35);
            accountShoppingCartManager["Display"].Size(80);

            accountShoppingCartManager["MenuShoppingCartManager"].Update(MenuAdmin());
            accountShoppingCartManager["Display"].Update(DisplayInformation());

            return accountShoppingCartManager;
        }


        private static Panel MenuAdmin()
        {

            var menuShoppingCartManagerPanel = new Panel(new Rows(adminMenuItems))
            {
                Header = new PanelHeader("[bold #af8700 on black]Admin Menu[/]", Justify.Center),
                Height = 15,
                Width = 30,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return menuShoppingCartManagerPanel;
        }

        private static Panel DisplayInformation()
        {
            List<Markup> infoLines = new List<Markup>(0);

            infoLines.Add(new Markup("[bold yellow]Admin Menu to add or remove Artikels.[/]"));
            infoLines.Add(new Markup("Select an option from the menu to proceed."));

            var infoPanel = new Panel(new Rows(infoLines))
            {
                Header = new PanelHeader("[bold #af8700 on black]Current Cart Manager[/]", Justify.Left),
                Height = 15,
                Width = 85,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return infoPanel;
        }

        public static Layout ShowAdminMenu()
        {
            return AdminMenu();
        }

        public static int MaxMenuItems()
        {
            return adminMenuItems.Count();
        }
    }
}
