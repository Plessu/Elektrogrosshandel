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
        static public void DisplayMainMenu()
        {
            GUI_Display.DisplayWindow(GUI_MainMenu.ShowMainMenu());
            MenuSelection(UserInput.MenuChoice(GUI_AccountInfoMenu.MaxMenuItems()));
        }
        static void MenuSelection(int UserChoice)
        {
            switch (UserChoice)
            {
                case 1:
                    AnsiConsole.MarkupLine("[bold green]News selected.[/]");
                    break;

                case 5:
                    AccountMenu.ShowAccountMenu();
                    break;
                case 6:
                    ShoppingCartManager.ShowShoppingCartManager();
                    break;

            }
        }
    }
}
