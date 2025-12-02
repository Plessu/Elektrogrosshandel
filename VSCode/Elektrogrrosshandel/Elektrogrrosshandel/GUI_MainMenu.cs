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
            List<Markup> menuItems = new List<Markup>
            {
                new Markup("[yellow]1. View Products[/]"),
                new Markup("[yellow]2. View Orders[/]"),
                new Markup("[yellow]3. Manage Inventory[/]"),
                new Markup("[yellow]4. Customer Management[/]"),
                new Markup("[yellow]5. Reports[/]"),
                new Markup("[yellow]6. Settings[/]"),
                new Markup("[yellow]7. Exit[/]")
            };

            int choice;

            //Create structure of Layout
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

            //Fill structure
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItems), VerticalAlignment.Top));
            panelMenu.Header("[bold #00ffff]Main Menu[/]" + Emoji.Known.DownArrow); // <-- geschlossenes Tag
            panelMenu.HeaderAlignment(Justify.Left);
            



            mainMenu["MainMenuBodyMenu"].Update(
                new Panel(panelMenu).Expand());



          

            return mainMenu;
        }

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
