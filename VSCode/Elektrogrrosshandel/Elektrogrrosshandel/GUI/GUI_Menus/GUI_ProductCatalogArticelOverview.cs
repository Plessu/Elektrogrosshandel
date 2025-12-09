// """

using Elektrogrosshandel.Hardware;
using Spectre.Console;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_ProductCatalogArticelOverview
    {
        private static string ArticelID = "";
        //Menu Items
        private static Layout ArticelInfo()
        {
            Layout mainMenu = new Layout("Artikel Information");

            mainMenu["Artikel Information"].Update(PanelArtikelInfo().Expand());

            return mainMenu;
        }

        //Layout

        private static Panel PanelArtikelInfo()
        {
            List<Markup> articelInfo = new List<Markup>();
            articelInfo = ComputerHardware.GetArticelInfoByID(Int64.Parse(ArticelID));

            if (articelInfo.Count == 0)
            {
                articelInfo.Add(new Markup("[italic red]Artikel nicht gefunden.[/]"));
            }

            Panel articelDetails = new Panel(
                Align.Left(new Rows(articelInfo), VerticalAlignment.Top));
            articelDetails.Border(BoxBorder.Rounded);
            articelDetails.BorderColor(Color.DarkGoldenrod);
            articelDetails.Header("[bold #af8700 on black]Artikel Details[/]");
            articelDetails.HeaderAlignment(Justify.Left);
            articelDetails.Padding = new Padding(1, 1, 1, 1);
            articelDetails.Height = articelInfo.Count + 4;
            articelDetails.Expand();

            return articelDetails;
        }
        public static Layout ShowArticelOverview(string articelID)
        {
            ArticelID = articelID;
            Layout manufacturerSelected = ArticelInfo();
            return manufacturerSelected;
        }
    }
}
