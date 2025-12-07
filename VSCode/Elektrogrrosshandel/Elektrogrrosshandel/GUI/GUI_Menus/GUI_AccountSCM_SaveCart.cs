using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Elektrogrosshandel.User;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountSCM_SaveCart
    {
        private static List<Markup> menuItems = new List<Markup>
        {
            new Markup("[yellow]1.[/] Account Info"),
            new Markup("[yellow]2.[/] [bold white]ShopingCart Manager[/]"),
            new Markup("[yellow]3.[/] Orders"),
            new Markup("[yellow]4.[/] Edit Account"),
            new Markup("[yellow]5.[/] Back to Main Menu")
        };

        private static Layout AccountSaveCart()
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
            accountShoppingCartManager["Display"].Update(DisplaySaveCart());

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
                new Markup("[bold yellow]3.[/] [bold]Save Current ShoppingCart[/]"),
                new Markup("[yellow]5.[/] Delete Saved ShoppingCart"),
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

        private static Panel DisplaySaveCart()
        {
            Markup infoText = new Markup("[bold yellow]Save Current ShoppingCart[/]\n\n" +
                "To save your current shopping cart, please follow these steps:\n\n" +
                "1. Review the items in your shopping cart to ensure everything is correct.\n\n" +
                "2. Choose a name for your saved cart that will help you identify it later.\n\n" +
                "3. Confirm the save action by selecting the appropriate option.\n\n" +
                "Once saved, you can access your saved shopping carts from the 'View Saved ShoppingCarts' menu option.");

            var infoPanel = new Panel(infoText)
            {
                Header = new PanelHeader("[bold #af8700 on black]Save Current Cart[/]", Justify.Center),
                Height = 15,
                Width = 85,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return infoPanel;
        }

        public static Layout ShowSaveCart()
        {
            return AccountSaveCart();
        }

        public static int MaxMenuItems()
        {
            return menuItems.Count();
        }
    }
}

