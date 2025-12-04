using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrrosshandel;
using Elektrogrrosshandel.GUI;
using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
namespace Elektrogrosshandel.Functions

{
    internal class LogIn
    {
        public Account ActiveAccount = new Account();
        public static void LogingIn()
        {
            string userName = "";
            GUI_Display.DisplayWindow(GUI_LogIn.ShowLoginMenu(userName));
            MenuSelection(UserInput.MenuChoice(GUI_LogIn.MaxMenuItems()));
        }

        
        private static void MenuSelection(int Choice)
        {
            switch (Choice)
            {
                case 1:
                    AnsiConsole.MarkupLine("[bold green]LogIn selected.[/]");
                    GUI_Display.DisplayWindow(GUI_LogIn.ShowLoginMenu(UserInput.GetStringInput("Please enter your username: ")));
                    Console.ReadKey();
                    MainMenu.DisplayMainMenu();
                    break;
                case 2:
                    AnsiConsole.MarkupLine("[bold green]Register selected.[/]");
                    break;
            }
        }

    }
}
