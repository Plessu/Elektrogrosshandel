using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Elektrogrosshandel.User;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_SCM_CurrentShoppingCart
    {

        private static List<Markup> menuShoppingCartManagerItems = new List<Markup>
            {
                new Markup("[bold yellow]1.[/] [bold]View ShoppingCart[/]"),
                new Markup("[yellow]2.[/] Save Current ShoppingCart"),
                new Markup("[yellow]3.[/] View Saved ShoppingCarts"),
                new Markup("[yellow]4.[/] Delete Saved ShoppingCart"),
                new Markup("\n[yellow]5.[/] Back to Account Menu")
            };

        private static Layout CurrentCart()
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
            accountShoppingCartManager["Display"].Update(DisplayInformation());

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

        private static Panel DisplayInformation()
        {
            List<Markup> infoLines = new List<Markup>(0);

            infoLines = Bucket.GetArticelsInBucket(Account.GetActiveBucket(Program.ActiveUser));

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

        public static Layout ShowSCM_CurrentCart()
        {
            return CurrentCart();
        }

        public static int MaxMenuItems()
        {
            return menuShoppingCartManagerItems.Count();
        }
    }
}
