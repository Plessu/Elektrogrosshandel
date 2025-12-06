using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class AccountMenuInfo
    {
        public static void ShowAccountInfo(out int choice)
        {
            AnsiConsole.MarkupLine("[bold green]User selected.[/]");
            Thread.Sleep(500);

            GUI_Display.DisplayWindow(GUI_AccountInfoMenu.ShowAccountInfoMenu());
            choice = UserInput.MenuChoice(GUI_AccountInfoMenu.MaxMenuItems());
            return;
        }
    }
}
