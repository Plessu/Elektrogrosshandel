using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class AccountInfo
    {
        public static void ShowAccountInfo()
        {
            AnsiConsole.MarkupLine("[bold green]User selected.[/]");
            Thread.Sleep(500);

            GUI_Display.DisplayWindow(GUI_AccountInfoMenu.ShowAccountInfoMenu());

            switch (UserInput.MenuChoice(GUI_AccountInfoMenu.MaxMenuItems()))
            {
                case 5:
                    AnsiConsole.MarkupLine("[bold green]View Account Information selected.[/]");
                    Thread.Sleep(500);

                    GUI_Display.DisplayWindow(GUI_AccountInfoMenu.ShowAccountInfoMenu());
                    break;
            }
        }
    }
}
