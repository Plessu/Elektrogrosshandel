using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Elektrogrosshandel.User;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountSCM_DeleteShoppingCart
    {
        private static List<Markup> menuItems = new List<Markup>
        {
            new Markup("[yellow]1.[/] Account Info"),
            new Markup("[yellow]2.[/] [bold white]ShopingCart Manager[/]"),
            new Markup("[yellow]3.[/] Orders"),
            new Markup("[yellow]4.[/] Edit Account"),
            new Markup("[yellow]5.[/] Back to Main Menu")
        };

        private static Layout AccountDeleteCart()
        {
            Console.BufferHeight = 3000;
            Console.BufferWidth = 250;
            Console.WindowHeight = 19;
            Console.WindowWidth = 120;

            Layout accountShoppingCartManager = new Layout("AccountMenu")
                        .SplitColumns(
                            new Layout("Menu"),
                            new Layout("MenuShoppingCartManager"),
                            new Layout("Display"));

            accountShoppingCartManager["AccountMenu"].Size(18);
            accountShoppingCartManager["Menu"].Size(35);
            accountShoppingCartManager["MenuShoppingCartManager"].Size(30);
            accountShoppingCartManager["Display"].Size(55);

            accountShoppingCartManager["Menu"].Update(Menu());
            accountShoppingCartManager["Display"].Update(DisplayDeleteCart());

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

        private static Panel MenuShoppingCartManager()
        {
            List<Markup> menuShoppingCartManagerItems = new List<Markup>
            {
                new Markup("[yellow]1.[/] View ShoppingCart"),
                new Markup("[yellow]2.[/] View Saved ShoppingCarts"),
                new Markup("[yellow]3.[/] Save Current ShoppingCart"),
                new Markup("[bold yellow]5.[/] [bold]Delete Saved ShoppingCart[/]"),
                new Markup("\n[yellow]6.[/] Back to Account Menu")
            };
            var menuShoppingCartManagerPanel = new Panel(new Rows(menuShoppingCartManagerItems))
            {
                Header = new PanelHeader("[bold #af8700 on black]ShopingCart Menu[/]", Justify.Center),
                Height = 15,
                Width = 30,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return menuShoppingCartManagerPanel;
        }

        private static Panel DisplayDeleteCart()
        {
            Markup infoText = new Markup("[bold yellow]Delete Saved ShoppingCart[/]\n\n" +
                "Here you can delete your saved shopping carts. Please select the cart you wish to delete from your list of saved carts. " +
                "Be cautious, as this action cannot be undone. Confirm your selection to permanently remove the cart from your account.");

            var infoPanel = new Panel(infoText)
            {
                Header = new PanelHeader("[bold #af8700 on black]Delete Cart[/]", Justify.Center),
                Height = 15,
                Width = 85,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return infoPanel;
        }

        public static Layout ShowDeleteCart()
        {
            return AccountDeleteCart();
        }

        public static int MaxMenuItems()
        {
            return menuItems.Count();
        }
    }
}

