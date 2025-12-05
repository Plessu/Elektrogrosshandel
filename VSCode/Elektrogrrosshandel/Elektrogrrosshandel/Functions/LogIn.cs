using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel;
using Elektrogrosshandel.GUI;
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
                    string userName;
                    string password;
                    bool userExists;
                    bool passwordIsValid;

                    do
                    {
                        AnsiConsole.MarkupLine("[bold green]LogIn selected.[/]");

                        do 
                        {
                            userName = UserInput.GetStringInput("Please enter your username: ");
                            userExists = Account.DoesAccountExist(userName);
                            if (!userExists)
                            {
                                AnsiConsole.MarkupLine("[bold red]Username does not exist. Please try again.[/]");
                            }
                            else
                            {
                                break;
                            }
                        } while (true);

                        GUI_Display.DisplayWindow(GUI_LogIn.ShowLoginMenu(userName));

                        password = UserInput.GetStringInput("Please enter your password: ");
                        passwordIsValid = PasswordHelper.VerifyPassword(userName, password);

                        if (passwordIsValid)
                        {
                            AnsiConsole.MarkupLine("[bold green]Login successful![/]");
                            Thread.Sleep(1000);
                            MainMenu.DisplayMainMenu();
                            break;
                        }
                        else
                        {
                            AnsiConsole.Clear();
                            GUI_Display.DisplayWindow(GUI_LogIn.ShowLoginMenu(userName));
                            AnsiConsole.MarkupLine("[bold red]Invalid username or password.[/]");
                        }

                    } while (false);

                    break;
                case 2:
                    AnsiConsole.MarkupLine("[bold green]Register selected.[/]");
                    break;
            }
        }

    }
}
