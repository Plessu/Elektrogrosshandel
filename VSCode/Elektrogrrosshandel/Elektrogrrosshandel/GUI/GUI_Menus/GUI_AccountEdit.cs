using Spectre.Console;
using Elektrogrosshandel.Functions;
using Elektrogrosshandel;

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
            // Zeige statt der Account-Details eine Liste von editierbaren Optionen
            // oder den Hinweis, dass der Nutzer 1-4 im Menü wählen kann.
            List<Markup> infoLines = new List<Markup>
            {
                new Markup("[#c0c0c0]Wählen Sie eine Option zum Bearbeiten Ihres Accounts oder nutzen Sie das Menü (1-4).[/]"),
                new Markup(""),
                new Markup("[yellow]Editierbare Felder:[/]"),
                new Markup("  [green]firstname[/]  - Vorname ändern"),
                new Markup("  [green]lastname[/]   - Nachname ändern"),
                new Markup("  [green]email[/]      - E‑Mail Adresse ändern"),
                new Markup("  [green]phonenumber[/]- Telefonnummer ändern"),
                new Markup("  [green]firmname[/]   - Firmenname ändern (leer = löschen)"),
                new Markup("  [green]username[/]   - Benutzername ändern"),
                new Markup("  [green]password[/]   - Passwort ändern"),
                new Markup("  [green]serialcode[/] - Seriencode / Rolle ändern"),
                new Markup(""),
                new Markup("[#c0c0c0]Tipp: Geben Sie eine der obenstehenden Eigenschaften ein oder wählen Sie das Menü (1-4).[/]")
            };

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
