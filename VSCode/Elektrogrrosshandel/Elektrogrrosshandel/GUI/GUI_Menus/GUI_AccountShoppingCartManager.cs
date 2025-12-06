using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountShoppingCartManager
    {
        private static List<Markup> menuItems = new List<Markup>
        {
            new Markup("[yellow]1.[/] Account Info"),
            new Markup("[yellow]2.[/] [bold white]ShopingCart Manager[/]"),
            new Markup("[yellow]3.[/] Orders"),
            new Markup("[yellow]4.[/] Edit Account"),
            new Markup("[yellow]5.[/] Back to Main Menu")
        };

        private static Layout AccountShoppingCartManager()
        {
            Console.BufferHeight = 3000;
            Console.BufferWidth = 250;
            Console.WindowHeight = 19;
            Console.WindowWidth = 120;

            Layout accountShoppingCartManager = new Layout("AccountMenu")
                        .SplitColumns(
                            new Layout("Menu"),
                            new Layout("Display"));

            accountShoppingCartManager["AccountMenu"].Size(18);
            accountShoppingCartManager["Menu"].Size(35);
            accountShoppingCartManager["Display"].Size(85);

            accountShoppingCartManager["Menu"].Update(Menu());
            accountShoppingCartManager["Display"].Update(DisplayInformation());

            return accountShoppingCartManager;
        }

        private static Panel Menu()
        {
            var menuPanel = new Panel(new Rows(menuItems))
            {
                Header = new PanelHeader("[bold #af8700 on black]Account Menu[/]", Justify.Center),
                Height = 15,
                Width = 35,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return menuPanel;
        }

        private static Panel DisplayInformation()
        {
            List<Markup> infoLines = new List<Markup>(0);

            infoLines = Account.GetAccountInformationList(Program.ActiveUser);

            var infoPanel = new Panel(new Rows(infoLines))
            {
                Header = new PanelHeader("[bold #af8700 on black]Information[/]", Justify.Center),
                Height = 15,
                Width = 85,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return infoPanel;
        }

        public static Layout ShowAccountInfoMenu()
        {
            return AccountShoppingCartManager();
        }

        public static int MaxMenuItems()
        {
            return menuItems.Count();
        }
    }
}
