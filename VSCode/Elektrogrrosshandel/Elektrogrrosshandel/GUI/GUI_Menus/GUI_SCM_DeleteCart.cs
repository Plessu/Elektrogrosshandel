using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Elektrogrosshandel.User;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_SCM_DeleteShoppingCart
    {

        private static List<Markup> menuShoppingCartManagerItems = new List<Markup>
            {
                new Markup("[yellow]1.[/] View ShoppingCart"),
                new Markup("[yellow]2.[/] Save Current ShoppingCart"),
                new Markup("[yellow]3.[/] View Saved ShoppingCarts"),
                new Markup("[bold yellow]4.[/] [bold]Delete Saved ShoppingCart[/]"),
                new Markup("\n[yellow]5.[/] Back to Account Menu")
            };

        private static Layout DeleteCart()
        {
            Console.BufferHeight = 3000;
            Console.BufferWidth = 250;
            Console.WindowHeight = 19;
            Console.WindowWidth = 120;

            Layout accountShoppingCartManager = new Layout("AccountMenu")
                        .SplitColumns(
                            new Layout("MenuShoppingCartManager"),
                            new Layout("Display"));

            accountShoppingCartManager["AccountMenu"].Size(18);
            accountShoppingCartManager["MenuShoppingCartManager"].Size(40);
            accountShoppingCartManager["Display"].Size(80);

            accountShoppingCartManager["MenuShoppingCartManager"].Update(MenuShoppingCartManager());
            accountShoppingCartManager["Display"].Update(DisplayDeleteCart());

            return accountShoppingCartManager;
        }

        private static Panel MenuShoppingCartManager()
        {

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
            return DeleteCart();
        }

        public static int MaxMenuItems()
        {
            return menuShoppingCartManagerItems.Count();
        }
    }
}

