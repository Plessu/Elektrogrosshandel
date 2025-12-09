using System;
using Spectre.Console;
using Elektrogrosshandel.Functions;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class AccountEdit
    {
        public static void AccountEditSelector(string UserInput) 
        { 
            switch (UserInput.ToLower())
            {
                case "firstname":

                    string newFirstName;

                    newFirstName = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new First name:[/]");
                    Program.ActiveUser.FirstName = newFirstName;

                    AnsiConsole.MarkupLine("[bold green]Username updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);
                    
                    break;
                
                case "lastname":
                    
                    string newLastName;
                    
                    newLastName = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new Last Name:[/]");
                    Account.ChangeAccountLastName(Program.ActiveUser, newLastName);
                    
                    AnsiConsole.MarkupLine("[bold green]Password updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);

                    break;

                case "email":

                    string newEmail;
                    
                    newEmail = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new Email:[/]");  
                    Account.ChangeAccountEmail(Program.ActiveUser, newEmail);
                    
                    AnsiConsole.MarkupLine("[bold green]Email updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);

                    break;

                case "phonenumber":
                    
                    string newPhoneNumber;
                    
                    newPhoneNumber = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new Phone Number:[/]");
                    Account.ChangeAccountPhoneNumber(Program.ActiveUser, newPhoneNumber);
                    
                    AnsiConsole.MarkupLine("[bold green]Phone number updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);

                    break;

                default:
                    
                    AnsiConsole.MarkupLine("[bold red]Invalid input. Please choose 'username', 'password', or 'email'.[/]");
                    Thread.Sleep(500);
                    
                    AccountMenu.ShowAccountMenu(3);
                    
                    break;
            }
        }
    }
}
