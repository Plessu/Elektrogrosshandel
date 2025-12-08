using System;
using System.Collections.Generic;
using System.Text;
using Elektrogrosshandel.User;
using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Spectre.Console;
using System.Globalization;
namespace Elektrogrosshandel.Functions
{
    internal class AdminMenu
    {




        static public void ShowAdminMenu()
        {
            MenuSelection(1);
        }

        private static void MenuSelection(int UserChoice)
        {
            switch (UserChoice)
            {
                case 1:

                    string userinput;

                    GUI_Display.DisplayWindow(GUI_AdminMenuMenuAddArticel.ShowAdminMenu());
                    AnsiConsole.MarkupLine("[bold green]Add Artikel selected.[/]");
                    
                    userinput = UserInput.GetStringInput("Geben Sie \"add\" ein oder wecheln Sie in ein anderes Menü (1 - 3)");

                    if (userinput.ToLower() == "add")
                    {
                        
                    }
                    else
                    {
                        int newchoice;
                        bool isNumeric = int.TryParse(userinput, out newchoice);

                        if (isNumeric && newchoice >= 1 && newchoice <= 3)
                        {
                            MenuSelection(newchoice);
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[bold red]Ungültige Eingabe. Zurück zum Admin-Menü.[/]");
                            ShowAdminMenu();
                        }
                    }

                    break;
                case 2:
                    AnsiConsole.MarkupLine("[bold green]Remove Artikel selected.[/]");
                    break;
                case 5:
                    AccountMenu.ShowAccountMenu();
                    break;
            }
        }
    }
}
