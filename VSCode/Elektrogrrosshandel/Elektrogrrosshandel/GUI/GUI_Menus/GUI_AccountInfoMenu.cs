using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Elektrogrosshandel;
using Elektrogrosshandel.User;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountInfoMenu
    {
        private static List<Markup> menuItems = new List<Markup>
        {
            new Markup("[yellow]1.[/] [bold white]Account Info[/]"),
            new Markup("[yellow]2.[/] ShopingCart Manager"),
            new Markup("[yellow]3.[/] Orders"),
            new Markup("[yellow]4.[/] Edit Account"),
            new Markup("[yellow]5.[/] Back to Main Menu")
        };

        private static Layout AccountInfoMenu()
        {
            Console.BufferHeight = 3000;
            Console.BufferWidth = 250;
            Console.WindowHeight = 18;
            Console.WindowWidth = 120;

            Layout accountMenu = new Layout("AccountMenu")
                        .SplitColumns(
                            new Layout("Menu"),
                            new Layout("Display"));

            accountMenu["AccountMenu"].Size(15);
            accountMenu["Menu"].Size(35);
            accountMenu["Display"].Size(85);

            accountMenu["Menu"].Update(Menu());
            accountMenu["Display"].Update(DisplayInformation());

            return accountMenu;
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
            return AccountInfoMenu();
        }

        public static int MaxMenuItems()
        {
            return menuItems.Count();
        }
    }
}
