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
            MenuSelection(5);
        }
        static void MenuSelection(int UserChoice)
        {
            switch (UserChoice)
            {
                case 1:
                    AnsiConsole.MarkupLine("[bold green]News selected.[/]");
                    break;
                case 5:
                    
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

                    break;
            }
        }
    }
}
