using Elektrogrosshandel;
using Elektrogrosshandel.User;
using Elektrogrosshandel.Hardware;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountOrders
    {
        private static List<Markup> menuItems = new List<Markup>
        {
            new Markup("[yellow]1.[/] Account Info"),
            new Markup("[yellow]3.[/] [bold white]Orders[/]"),
            new Markup("[yellow]4.[/] Edit Account"),
            new Markup("[yellow]5.[/] Back to Main Menu")
        };

        private static Layout AccountOrders()
        {
            Layout accountMenu = new Layout("AccountMenu")
                        .SplitColumns(
                            new Layout("Menu"),
                            new Layout("Display"));

            accountMenu["Menu"].Size(35);
            accountMenu["Display"].Size(85);

            accountMenu["Menu"].Update(Menu());
            accountMenu["Display"].Update(DisplayOrders());

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

        private static Panel DisplayOrders()
        {
            List<Order> accountOrders = new List<Order>(0);
            List<Markup> orderLines = new List<Markup>(0);

            accountOrders = Account.GetAccountOrders(Program.ActiveUser);

            foreach (Order order in accountOrders)
            {
                orderLines.Add(Order.GetOrdersInfo(order));
            }

            var orderPanel = new Panel(new Rows(orderLines))
            {
                Header = new PanelHeader("[bold #af8700 on black]Orders[/]", Justify.Center),
                Height = 15,
                Width = 35,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };

            return orderPanel;
        }

        public static Layout ShowAccountOrders()
        {
            return AccountOrders();
        }

        public static int MaxMenuItems()
        {
            return menuItems.Count();
        }
    }
}
