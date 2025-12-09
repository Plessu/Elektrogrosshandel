using Spectre.Console;
using Elektrogrosshandel;
using System.Threading;

namespace Elektrogrosshandel.Functions
{
    internal class AccountEdit
    {
        /// <summary>
        /// Baut die Anzeige-Liste mit aktuellen Account-Daten zur Laufzeit.
        /// Wird von den GUI-Klassen benutzt, damit immer die aktuellen Werte angezeigt werden.
        /// </summary>
        public static List<Markup> BuildAccountInformationForGui(Account account)
        {
            if (account == null)
            {
                return new List<Markup> { new Markup("[red]No active user.[/]") };
            }

            return new List<Markup>
            {
                new Markup($"FirstName: {account.FirstName ?? string.Empty}"),
                new Markup($"LastName: {account.LastName ?? string.Empty}"),
                new Markup($"FirmName: {account.FirmName ?? string.Empty}"),
                new Markup($"Email: {account.Email ?? string.Empty}"),
                new Markup($"PhoneNumber: {account.PhoneNumber ?? string.Empty}"),
                new Markup($"\nAccountID: {Account.GetAccountID(account)}"),
                new Markup($"AcountRole: {Account.GetAccountRole(account) ?? string.Empty}"),
                new Markup($"UserName: {Account.GetUserName(account) ?? string.Empty}"),
                new Markup($"CreatedAt: {DateTime.Now}")
            };
        }

        // Neue Hilfsmethode: fragt das aktuelle Passwort ab und validiert es.
        // Bei falschem Passwort wird das Account-Menu angezeigt und die Methode liefert false zurück.
        private static bool VerifyCurrentPasswordOrAbort()
        {
            AnsiConsole.MarkupLine("[#c0c0c0]Please verify your current password before changing.[/]");
            string currentPassword = Functions.UserInput.GetPasswordInput("[bold yellow]Current password:[/]");
            string currentUserName = Account.GetUserName(Program.ActiveUser);

            if (!PasswordHelper.VerifyPassword(currentUserName, currentPassword))
            {
                AnsiConsole.MarkupLine("[bold red]Current password incorrect. Aborted.[/]");
                Thread.Sleep(800);
                AccountMenu.ShowAccountMenu(1);
                return false;
            }

            return true;
        }

        public static void AccountEditSelector(string UserInput)
        {
            switch (UserInput.ToLower())
            {
                case "firstname":

                    if (!VerifyCurrentPasswordOrAbort()) return;

                    string newFirstName;

                    newFirstName = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new First name:[/]");
                    // Verwende zentrale Änderungsmethode, damit auch AccountInformation aktualisiert wird
                    Account.ChangeAccountFirstName(Program.ActiveUser, newFirstName);

                    AnsiConsole.MarkupLine("[bold green]First name updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);

                    return;

                case "lastname":

                    if (!VerifyCurrentPasswordOrAbort()) return;

                    string newLastName;

                    newLastName = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new Last Name:[/]");
                    Account.ChangeAccountLastName(Program.ActiveUser, newLastName);

                    AnsiConsole.MarkupLine("[bold green]Last name updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);

                    return;

                case "email":

                    if (!VerifyCurrentPasswordOrAbort()) return;

                    string newEmail;

                    newEmail = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new Email:[/]");
                    Account.ChangeAccountEmail(Program.ActiveUser, newEmail);

                    AnsiConsole.MarkupLine("[bold green]Email updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);

                    return;

                case "phonenumber":

                    if (!VerifyCurrentPasswordOrAbort()) return;

                    string newPhoneNumber;

                    newPhoneNumber = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new Phone Number:[/]");
                    Account.ChangeAccountPhoneNumber(Program.ActiveUser, newPhoneNumber);

                    AnsiConsole.MarkupLine("[bold green]Phone number updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);

                    return;

                case "firmname":

                    if (!VerifyCurrentPasswordOrAbort()) return;

                    string newFirmName;

                    newFirmName = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new Firm name (leave empty to clear):[/]");
                    Account.ChangeAccountFirmName(Program.ActiveUser, newFirmName);

                    AnsiConsole.MarkupLine("[bold green]Firm name updated successfully![/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(1);

                    return;

                case "username":

                    if (!VerifyCurrentPasswordOrAbort()) return;

                    string newUserName;

                    newUserName = Functions.UserInput.GetStringInput("[bold yellow]Please enter your new Username:[/]");
                    bool userNameChanged = Account.TryChangeAccountUserName(Program.ActiveUser, newUserName);

                    if (!userNameChanged)
                    {
                        AnsiConsole.MarkupLine("[bold red]Username already in use or invalid. Change aborted.[/]");
                        Thread.Sleep(800);
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[bold green]Username updated successfully![/]");
                        Thread.Sleep(500);
                    }

                    AccountMenu.ShowAccountMenu(1);

                    return;

                case "password":
                      
                    // Passwort-Änderung behält die vorhandene Logik, nutzt jedoch dieselbe Helper-Methode zur Verifikation.
                    if (!VerifyCurrentPasswordOrAbort()) return;

                    string newPassword = Functions.UserInput.GetPasswordInput("[bold yellow]Enter new password:[/]");
                    string newPasswordConfirm = Functions.UserInput.GetPasswordInput("[bold yellow]Confirm new password:[/]");

                    if (newPassword != newPasswordConfirm)
                    {
                        AnsiConsole.MarkupLine("[bold red]New passwords do not match. Aborted.[/]");
                        Thread.Sleep(800);
                        AccountMenu.ShowAccountMenu(1);
                        return;
                    }

                    Account.ChangeAccountPassword(Program.ActiveUser, newPassword);
                    AnsiConsole.MarkupLine("[bold green]Password updated successfully![/]");
                    Thread.Sleep(500);
                    AccountMenu.ShowAccountMenu(1);

                    return;

                case "serialcode":

                    if (!VerifyCurrentPasswordOrAbort()) return;

                    string newSerialInput;
                    newSerialInput = Functions.UserInput.GetStringInput("[bold yellow]Enter new Serial Code (integer):[/]");

                    if (int.TryParse(newSerialInput, out int newSerial))
                    {
                        Account.ChangeAccountSerialCode(Program.ActiveUser, newSerial);
                        AnsiConsole.MarkupLine("[bold green]Serial code (and derived role) updated successfully![/]");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[bold red]Invalid serial code. Aborted.[/]");
                        Thread.Sleep(800);
                    }

                    AccountMenu.ShowAccountMenu(1);

                    return;

                default:

                    AnsiConsole.MarkupLine("[bold red]Invalid input. Please choose an editable property (firstname, lastname, email, phonenumber, firmname, username, password, serialcode).[/]");
                    Thread.Sleep(500);

                    AccountMenu.ShowAccountMenu(3);

                    return;
            }
        }
    }
}
