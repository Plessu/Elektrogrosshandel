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

            GUI_Display.DisplayWindow(GUI_AccountSCM_ViewSavedShoppingCart.ShowSCM_SavedCarts());
            choice = UserInput.MenuChoice(GUI_AccountSCM_ViewSavedShoppingCart.MaxMenuItems());
            return;
        }
    }
}
