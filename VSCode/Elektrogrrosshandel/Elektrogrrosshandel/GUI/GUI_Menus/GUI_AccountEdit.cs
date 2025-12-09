// """

using Spectre.Console;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountEdit
    {
        private static List<Markup> menuItems = new List<Markup>
        {
            new Markup("[yellow]1.[/] Account Info"),
            new Markup("[yellow]2.[/] Orders"),
            new Markup("[yellow]3.[/] [bold white]Edit Account[/]"),
            new Markup("[yellow]4.[/] Back to Main Menu")
        };

        private static Layout AccountEditMenu()
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
            List<Markup> infoLines = new List<Markup>(0);

            infoLines.Add(new Markup("[#c0c0c0]To edit your account information, please enter the option you want to change.[/]"));
            infoLines.Add(new Markup("[#c0c0c0]For security reasons, some changes may require you to re-enter your password.[/]"));
            infoLines.Add(new Markup("[#c0c0c0]Make sure to save your changes before exiting the menu.[/]"));
            infoLines.Add(new Markup("[#c0c0c0]Follofwing Options can be selcted:[/]"));
            infoLines.Add(new Markup("[yellow]1.[/] FirstName, 2. LastName, 3. Email , 4. PhoneNumber"));

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

        public static Layout ShowAccountEditMenu()
        {
            return AccountEditMenu();
        }

        public static int MaxMenuItems()
        {
            return menuItems.Count();
        }
    }
}
