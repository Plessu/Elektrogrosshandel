using Elektrogrosshandel;
using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Functions;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console.Rendering;

namespace Elektrogrosshandel.User
{
    internal class UserRegistration
    {
        internal static void AddAccount ()
        {
            string firstName = null;
            string lastName = null;
            string firmName = null;
            string userName = null;
            string password = null;
            string pass;
            string email = null;
            string phoneNumber = null;
            string serialCodeString = null;

            
            bool userAllreadyExists = true;
            int serialCode = -1;

            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName, email, phoneNumber,
                                                                                    userName, password, serialCodeString));
            
            firstName = UserInput.GetStringInput("Vorname");
            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName,email, phoneNumber, 
                                                                                    userName, password, serialCodeString));
            
            lastName = UserInput.GetStringInput("Nachname");
            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName, email, phoneNumber,
                                                                                    userName, password, serialCodeString));
            
            firmName = UserInput.GetStringInput("Firmenname ( \"-\" falls nicht gewünscht)");
            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName, email, phoneNumber, 
                                                                                    userName, password, serialCodeString));

            email = UserInput.GetStringInput("E-Mail Adresse");
            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName, email, phoneNumber,
                                                                                    userName, password, serialCodeString));

            phoneNumber = UserInput.GetStringInput("Telefonnummer");
            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName, email, phoneNumber, 
                                                                                    userName, password, serialCodeString));

            do
            {
                userName = UserInput.GetStringInput("Benutzername");
                userAllreadyExists = Account.DoesAccountExist(userName);

                if (userAllreadyExists == true)
                {
                    AnsiConsole.MarkupLine("[red]Der Benutzername ist bereits vergeben. Bitte wählen Sie einen anderen Benutzernamen.[/]");
                    userName = "";
                    continue;
                }
                break;

            } while (true);

            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName, email, phoneNumber, userName,
                                                                                    password, serialCodeString));

            pass = UserInput.GetPasswordInput("Passwort");
            password = "********";
            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName,email, phoneNumber, userName, 
                                                                                    password, serialCodeString));

            serialCode = UserInput.GetIntInput("Seriencode (Nur Zahlen)");
            serialCodeString = serialCode.ToString();
            GUI_Display.DisplayWindow(GUI_UserRegistration.ShowUserRegistrationMenu(firstName, lastName, firmName, email, phoneNumber, userName, 
                                                                                    password, serialCodeString));


            Account account = new Account();
            account = account.newAccount(userName, firstName, lastName, firmName, password, email, phoneNumber, serialCode);

            AnsiConsole.MarkupLine("[green]Ihr Konto wurde erfolgreich erstellt![/]");
            Program.SetActiveUser(account);

            Thread.Sleep(1000);

            MainMenu.DisplayMainMenu();
        }
    }
}
