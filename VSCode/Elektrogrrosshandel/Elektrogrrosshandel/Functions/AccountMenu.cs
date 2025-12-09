// """

using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Hardware;
using Spectre.Console;

namespace Elektrogrosshandel.Functions
{
    internal class AccountMenu
    {
        public static void ShowAccountMenu(int i)
        {
            AccountMenuSelector(i);
        }

        private static void AccountMenuSelector(int choice)
        {
            switch (choice)
            {
                case 1:

                    AnsiConsole.MarkupLine("[bold green]User selected.[/]");
                    Thread.Sleep(500);

                    GUI_Display.DisplayWindow(GUI_AccountInfoMenu.ShowAccountInfoMenu());

                    AnsiConsole.MarkupLine("\n[bold yellow]What would you like to do next? ( 1 - 4 )[/]");
                    AccountMenuSelector(UserInput.MenuChoice(4));


                    break;

                case 2:

                    string userInput;

                    AnsiConsole.MarkupLine("[bold green]Orders selected.[/]");
                    Thread.Sleep(500);

                    GUI_Display.DisplayWindow(GUI_AccountOrders.ShowAccountOrders());

                    userInput = UserInput.GetStringInput("\n[bold yellow]Enter Order ID to view specific order or Switch Menu (1-3)[/]");

                    if (int.TryParse(userInput, out choice))
                    {
                        if (choice >= 1 && choice <= GUI_AccountOrders.MaxMenuItems())
                        {
                            ShowAccountMenu(choice);
                        }
                        else
                        {
                            Order order = new Order();
                            order = Account.GetOrderByOrderID(Program.ActiveUser, choice);

                            AnsiConsole.MarkupLine($"\n[bold green]You selected Order ID: {choice}[/]");
                            Thread.Sleep(500);

                            GUI_Display.DisplayWindow(GUI_AccountOrdersSelected.DisplayDetailedOrderInfo(order));

                            AnsiConsole.MarkupLine("\n[bold yellow]Beliebige Taste drücken um ins Account Menü zurück zu kehren.[/]");
                            Console.ReadKey();
                            AnsiConsole.MarkupLine("\n[bold yellow]Returning to Account Menu...[/]");
                            Thread.Sleep(500);

                            ShowAccountMenu(1);
                        }
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("\n[bold red]Invalid input. Returning to Account Orders.[/]");
                        Thread.Sleep(500);
                        ShowAccountMenu(1);
                    }

                    break;

                case 3:

                    string userInputEdit;
                    AnsiConsole.MarkupLine("[bold green]Edit Account selected.[/]");
                    Thread.Sleep(500);

                    GUI_Display.DisplayWindow(GUI_AccountEdit.ShowAccountEditMenu());

                    userInputEdit = UserInput.GetStringInput("\n[bold yellow]Enter Proppertie you want to change or Switch Menu (1 - 4)[/]");
                    if (int.TryParse(userInputEdit, out choice))
                    {
                        if (choice >= 1 && choice <= GUI_AccountEdit.MaxMenuItems())
                        {
                            ShowAccountMenu(choice);
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("\n[bold red]Invalid input. Returning to Account Menu.[/]");
                            Thread.Sleep(500);
                            ShowAccountMenu(1);
                        }
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("\n[bold red]You choose to change a property.[/]");
                        Thread.Sleep(500);

                        AccountEdit.AccountEditSelector(userInputEdit);
                    }

                    break;

                case 4:

                    MainMenu.ShowMainMenu();

                    break;
            }
        }
    }
}
