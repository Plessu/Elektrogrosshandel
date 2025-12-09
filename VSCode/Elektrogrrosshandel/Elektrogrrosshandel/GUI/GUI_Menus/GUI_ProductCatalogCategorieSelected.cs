// """

using Spectre.Console;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_ProductCatalogCategorieSelected
    {
        private static string Category = "";
        //Menu Items
        private static List<Markup> menuProductCatalog = new List<Markup>
        {
                new Markup("[bold #c0c0c0]  1. Produktkategorien[/]"),
                new Markup("[#c0c0c0]  2. Hersteller[/]"),
                new Markup("[#c0c0c0]  \n3. Back to MainMenu[/]")
        };

        private static Layout ProductCategoriesSelected(List<Markup> ItemsInCategorie)
        {
            Layout mainMenu = new Layout("Shop Menu")
                .SplitColumns(
                    new Layout("Menu").Size(35),
                    new Layout("Kategorien"));

            mainMenu["Menu"].Update(PanelMenu().Expand());
            mainMenu["Kategorien"].Update(PanelCategoriesSelected(ItemsInCategorie).Expand());

            return mainMenu;
        }

        //Layout
        private static Panel PanelMenu()
        {
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuProductCatalog), VerticalAlignment.Top));
            panelMenu.Height = 5;
            panelMenu.Width = 30;
            panelMenu.Border(BoxBorder.Rounded);
            panelMenu.BorderColor(Color.DarkGoldenrod);
            panelMenu.Header("[bold #af8700 on black]Shop[/]");
            panelMenu.HeaderAlignment(Justify.Left);

            return panelMenu;
        }

        private static Panel PanelCategoriesSelected(List<Markup> ItemsInCategorie)
        {

            //Create Panel for Display area
            Panel panelDisplay = new Panel(
                Align.Left(new Rows(ItemsInCategorie), VerticalAlignment.Top));
            panelDisplay.Width = 90;
            panelDisplay.Border(BoxBorder.Rounded);
            panelDisplay.Header("[bold #af8700 on black]Product Categories[/]");
            panelDisplay.HeaderAlignment(Justify.Left);
            panelDisplay.Padding = new Padding(1, 1, 1, 1);
            panelDisplay.Expand();
            return panelDisplay;
        }
        public static Layout ShowCategorieSelected(List<Markup> ItemsInCategorie)
        {

            Layout manufacturerSelected = ProductCategoriesSelected(ItemsInCategorie);
            return manufacturerSelected;
        }
        public static int MaxMenuItems()
        {
            int maxMenuItems = menuProductCatalog.Count();
            return maxMenuItems;
        }
    }
}
