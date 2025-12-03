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
                new Markup("[bold #af8700 on black]Shop[/]"),
                new Markup("[bold #af8700 on black]---------------------------[/]"),
                new Markup("[#c0c0c0]  1. Product Catalog[/]"),
                new Markup("[#c0c0c0]  2. Discount Promotion[/]"),
                new Markup("[#c0c0c0]  3. PC Builder[/]"),
                new Markup("[#c0c0c0]  4. Rack Builder[/]"),
                new Markup("[#c0c0c0]  5. Cabinet Builder[/]"),
                new Markup("[bold #af8700 on black]Account[/]"),
                new Markup("[bold #af8700 on black]---------------------------[/]"),
                new Markup("[#c0c0c0]  6. Shoping Cart[/]"),
                new Markup("[#c0c0c0]  7. Orders[/]"),
                new Markup("[#c0c0c0]  8. Messages[/]"),
                new Markup("[#c0c0c0]  9. User[/]"),
                new Markup("[bold #af8700 on black]Public Area[/]"),
                new Markup("[bold #af8700 on black]---------------------------[/]"),
                new Markup("[#c0c0c0] 10. Customer Support[/]"),
                new Markup("[#c0c0c0] 11. News[/]"),
                new Markup("[#c0c0c0] 12. Impressum[/]")
            };



        //Layout
        internal static Panel MainMenu()
        {
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItems), VerticalAlignment.Top));
            panelMenu.HeaderAlignment(Justify.Left);
            

            return panelMenu;
        }
        internal static Panel MainDisplay()
        {
            //Create Panel for Display area
            Panel panelDisplay = new Panel(
                new Markup("[italic #00afff]Please select an option from the menu.[/]"));
            panelDisplay.HeaderAlignment(Justify.Left);
            return panelDisplay;
        }
        public static int MaxMenuItems()
        {
            return 12;
        }
    }
}
