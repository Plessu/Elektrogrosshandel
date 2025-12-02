using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    //Main Menu dispalyed via Spectre.Console NuGet Plugin
    internal class GUI_MainMenu
    {
        //Layout
        private static Layout MainMenu()
        {
            //Variables
            //Menu Items
            List<Markup> menuItems = new List<Markup>
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
                new Markup("[yellow]10. Massages[/]"),
                new Markup("[yellow]11. Impressum[/]"),
                new Markup("[yellow]12. Exit[/]")
            };

            int choice;

            //Create Layout and structure
            Layout mainMenu = new Layout("MainMenu")
                .SplitRows(
                new Layout("MainMenuHeader"),
                new Layout("MainMenuBody")
                    .SplitColumns(
                    new Layout("MainMenuBodyMenu"),
                    new Layout("MainMenuBodyDisplay")));

            //Change size of structure
            mainMenu["MainMenuHeader"].Size(3);
            mainMenu["MainMenuBody"].Size(20);

            //Create Panel for menu items
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItems), VerticalAlignment.Top));
            panelMenu.Header(" [bold #00ffff]Main Menu[/] :abacus: "); // <-- geschlossenes Tag
            panelMenu.HeaderAlignment(Justify.Left);
            
            mainMenu["MainMenuBodyMenu"].Update(
                new Panel(panelMenu).Expand());

            return mainMenu;
        }

        //Methode to get user input for menu choice with validation
        static internal int GetMenuChoice()
        {
            int choice;
            while (true)
            {
                AnsiConsole.Markup("[bold yellow]Please enter your choice (1-7): [/]");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 7)
                {
                    break; // Valid input, exit the loop
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Invalid input. Please enter a number between 1 and 7.[/]");
                }
            }
            return choice;
        }

        //Methode to access and print Layout MainMenu
        static internal void PrintMainMenu()
        {
            AnsiConsole.Write(MainMenu());
        }
    }
}
