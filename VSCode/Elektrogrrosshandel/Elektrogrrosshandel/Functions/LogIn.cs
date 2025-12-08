using Elektrogrosshandel;
using Elektrogrosshandel.User;
using Elektrogrosshandel.GUI.GUI_Menus;
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

                    AnsiConsole.MarkupLine("[bold green]LogIn selected.[/]");
                    do
                    {
                        userName = UserInput.GetStringInput("Please enter your username: ");
                        userExists = Account.DoesAccountExist(userName);
                        if (userExists == false)
                        {
                            AnsiConsole.MarkupLine("[bold red]Username does not exist. Please try again.[/]");
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                    do
                    {
                        GUI_Display.DisplayWindow(GUI_LogIn.ShowLoginMenu(userName));

                        password = UserInput.GetPasswordInput("Please enter your password: ");
                        passwordIsValid = PasswordHelper.VerifyPassword(userName, password);

                        if (passwordIsValid == false)
                        {
                            AnsiConsole.MarkupLine("[bold red]Invalid password.[/]");
                            Thread.Sleep(500);
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                    
                    Account ActiveUser = Account.GetAccountByUserName(userName);
                    Program.SetActiveUser(ActiveUser);

                    AnsiConsole.MarkupLine("[bold green]Login successful![/]");
                    Thread.Sleep(1000);
                    MainMenu.ShowMainMenu();
                    break;

                case 2:
                    UserRegistration.AddAccount();
                    break;
            }
        }
    }
}
