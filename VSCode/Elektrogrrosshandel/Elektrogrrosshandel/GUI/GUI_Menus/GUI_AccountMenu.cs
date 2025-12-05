using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountMenu
    {
        private static List<Markup> menuItems = new List<Markup>
        {
            new Markup("[yellow]1.[/] [bold white]Account Info[/]"),
            new Markup("[yellow]2.[/] ShopingCart Manager"),
            new Markup("[yellow]3.[/] Orders"),
            new Markup("[yellow]4.[/] Edit Account"),
            new Markup("[yellow]4.[/] Back to Main Menu")
        };

        private static void AccountMenu()
        {
            Layout accountMenu = new Layout("AccountMenu")
                        .SplitRows(
                            new Layout("Menu"),
                            new Layout("Display"));

            accountMenu["Menu"].Size = 10;

        }

        private static Panel Menu()
        {
            var menuPanel = new Panel(new Rows(menuItems))
            {
                Header = new PanelHeader("[bold #af8700 on black]Account Menu", Justify.Center),
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return menuPanel;
        }

        private static Panel DisplayInformation()
        {
            var infoPanel = new Panel(new Markup("[#c0c0c0]Select an option from the Account Menu to manage your account settings, view orders, or edit your personal information.[/]"))
            {
                Header = new PanelHeader("[bold #af8700 on black]Information", Justify.Center),
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return infoPanel;
        }
        public static string ShowAccountMenu()
        {

        }
    }
}
