// """

using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Hardware;
using Spectre.Console;

namespace Elektrogrosshandel.Functions
{
    internal class PlaceOrder
    {
        public static void ShowPlaceOrder()
        {
            string ordername;

            GUI_Display.DisplayWindow(GUI_PlaceOrder.ShowPlaceOrderMenu());

            ordername = UserInput.GetStringInput("[bold yellow]Please enter a Name for the Order or back to cancel the order.[/]");

            if (ordername.ToLower() == "back")
            {
                AnsiConsole.MarkupLine("[bold red]Order cancelled, returning to Main Menu...[/]");
                Thread.Sleep(200);
                MainMenu.ShowMainMenu();
                return;
            }

            AnsiConsole.MarkupLine("[bold green]Placing Order...[/]");

            Order newOrder = Order.PlaceOrder(ordername);

            Account.AddOrderToAccount(Program.ActiveUser, newOrder);

            AnsiConsole.MarkupLine("[bold green]Order placed successfully![/]");
            HardWareStorage.SaveAllDevices("hardware_storage.json");
            AccountStorage.SaveAllAccounts("account_storage.json");

            Thread.Sleep(200);

            MainMenu.ShowMainMenu();

        }
    }
}
