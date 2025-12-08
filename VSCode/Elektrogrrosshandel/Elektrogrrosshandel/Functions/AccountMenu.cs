using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class AccountMenu
    {
        public static void ShowAccountMenu()
        {
            AccountMenuSelector(1);
        }

        private static void AccountMenuSelector(int choice)
        {
            switch (choice)
            {
                case 1:

                    AnsiConsole.MarkupLine("[bold green]User selected.[/]");
                    Thread.Sleep(500);

                    GUI_Display.DisplayWindow(GUI_AccountInfoMenu.ShowAccountInfoMenu());

                    AnsiConsole.MarkupLine("\n[bold yellow]What would you like to do next? ( 1 - 5 )[/]");
                    AccountMenuSelector(UserInput.MenuChoice(5));
                    

                    break;

                case 2:



                    break;

                case 5:

                    MainMenu.ShowMainMenu();
                    break;
            }
        }
    }
}
