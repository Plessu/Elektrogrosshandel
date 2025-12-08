using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.GUI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class MainMenu
    {
        static public void ShowMainMenu()
        {
            int menuChoices;
            menuChoices = GUI_MainMenu.MaxMenuItems();

            if (Account.GetAccountRole(Program.ActiveUser) != "Admin")
            {
                menuChoices--;    
            }

            GUI_Display.DisplayWindow(GUI_MainMenu.ShowMainMenu());
            MenuSelection(UserInput.MenuChoice(menuChoices));
        }
        static void MenuSelection(int UserChoice)
        {
            switch (UserChoice)
            {
                case 1:
                    AnsiConsole.MarkupLine("[bold green]News selected.[/]");
                    break;

                case 4:
                    AccountMenu.ShowAccountMenu();
                    break;
                case 5:
                    ShoppingCartManager.ShowShoppingCartManager();
                    break;
                case 9: 
                    if (Account.GetAccountRole(Program.ActiveUser) == "Admin")
                    {
                        AdminMenu.ShowAdminMenu();
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[bold red]Invalid choice. Please try again.[/]");
                        ShowMainMenu();
                    }
                    break;

            }
        }
    }
}
