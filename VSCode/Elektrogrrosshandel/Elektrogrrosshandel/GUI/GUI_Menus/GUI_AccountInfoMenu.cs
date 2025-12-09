// """

using System.Linq;
using Spectre.Console;
using Spectre.Console.Rendering;
using Elektrogrosshandel.Functions;
using Elektrogrosshandel;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountInfoMenu
    {
        private static List<Markup> menuItems = new List<Markup>
        {
            new Markup("[yellow]1.[/] [bold white]Account Info[/]"),
            new Markup("[yellow]2.[/] Orders"),
            new Markup("[yellow]3.[/] Edit Account"),
            new Markup("[yellow]4.[/] Back to Main Menu")
        };

        private static Layout AccountInfoMenu()
        {
            Layout accountMenu = new Layout("AccountMenu")
                        .SplitColumns(
                            new Layout("Menu"),
                            new Layout("Display"));

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
            // Erzeuge die Anzeige-Liste zur Laufzeit aus den aktuellen Daten (Program.ActiveUser)
            var infoLines = AccountEdit.BuildAccountInformationForGui(Program.ActiveUser) ?? new List<Markup>();

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
