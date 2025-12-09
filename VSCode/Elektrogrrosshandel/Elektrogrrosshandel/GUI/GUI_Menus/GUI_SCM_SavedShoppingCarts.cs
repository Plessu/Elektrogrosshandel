// """

using Spectre.Console;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_SCM_SavedShoppingCarts
    {
        private static List<Markup> menuShoppingCartManagerItems = new List<Markup>
            {
                new Markup("[yellow]1.[/]View ShoppingCart"),
                new Markup("[yellow]2.[/] Save Current ShoppingCart"),
                new Markup("[bold yellow]3.[/]  [bold]View Saved ShoppingCarts[/]"),
                new Markup("[yellow]4.[/] Delete Saved ShoppingCart"),
                new Markup("\n[yellow]5.[/] Back to Account Menu")
            };

        private static Layout ShoppingCartManager()
        {
            Layout accountShoppingCartManager = new Layout("AccountMenu")
                        .SplitColumns(
                            new Layout("MenuShoppingCartManager"),
                            new Layout("Display"));

            accountShoppingCartManager["MenuShoppingCartManager"].Size(40);
            accountShoppingCartManager["Display"].Size(80);

            accountShoppingCartManager["MenuShoppingCartManager"].Update(MenuShoppingCartManager());
            accountShoppingCartManager["Display"].Update(DisplaySavedCarts());

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

        private static Panel DisplaySavedCarts()
        {
            List<Markup> infoLines = new List<Markup>(0);

            infoLines = Account.GetSafedBuckets(Program.ActiveUser);

            var infoPanel = new Panel(new Rows(infoLines))
            {
                Header = new PanelHeader("[bold #af8700 on black]Saved Shopping Carts[/]", Justify.Center),
                Height = 15,
                Width = 85,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };
            return infoPanel;
        }

        public static Layout ShowSavedCarts()
        {
            return ShoppingCartManager();
        }

        public static int MaxMenuItems()
        {
            return menuShoppingCartManagerItems.Count();
        }
    }
}

