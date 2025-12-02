using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    //Main Menu dispalyed via Spectre.Console NuGet Plugin
    internal class GUI_MainMenu
    {
        //Menu Items
        private static List<Markup> menuItems = new List<Markup>
            {
                new Markup("[yellow] 1. News[/]"),
                new Markup("[yellow] 2. View Product Catalog[/]"),
                new Markup("[yellow] 3. Discount Promotion[/]"),
                new Markup("[yellow] 4. Shoping Cart[/]"),
                new Markup("[yellow] 5. PC Builder[/]"),
                new Markup("[yellow] 6. Rack Builder[/]"),
                new Markup("[yellow] 7. Cabinet Builder[/]"),
                new Markup("[yellow] 8. Account[/]"),
                new Markup("[yellow] 9. Customer Support[/]"),
                new Markup("[yellow]10. Messages[/]"),
                new Markup("[yellow]11. Impressum[/]"),
                new Markup("[yellow]12. Exit[/]")
            };


        //Layout
        internal static Panel MainMenu()
        {
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItems), VerticalAlignment.Top));
            panelMenu.Header("[bold #00afff]Main Menu[/] :downwards_button:");
            panelMenu.HeaderAlignment(Justify.Left);

            return panelMenu;
        }
        internal static Panel MainDisplay()
        {
            //Create Panel for Display area
            Panel panelDisplay = new Panel(
                new Markup("[italic #00afff]Please select an option from the menu.[/]"));

            panelDisplay.Header("[bold #00afff]Display Area[/] :computer:");
            panelDisplay.HeaderAlignment(Justify.Left);
            return panelDisplay;
        }
    }
}
