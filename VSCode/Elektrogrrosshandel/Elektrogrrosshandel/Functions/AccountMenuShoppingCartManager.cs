using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class AccountMenuShoppingCartManager
    {
        public static void ShowShoppingCartManager(out int choice)
        {
            AnsiConsole.MarkupLine("[bold green]ShoppingCart Manager selected.[/]");
            Thread.Sleep(500);

            GUI_Display.DisplayWindow(GUI_AccountShoppingCartManager.ShowShoppingCartManager());
            choice = UserInput.MenuChoice(GUI_AccountShoppingCartManager.MaxMenuItems());
            return;
        }
    }
}
