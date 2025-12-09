// """

using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Spectre.Console;

namespace Elektrogrosshandel.Functions
{
    internal class MainMenu
    {
        static public void ShowMainMenu()
        {
            int menuChoices;
            menuChoices = GUI_MainMenu.MaxMenuItems();

            GUI_Display.DisplayWindow(GUI_MainMenu.ShowMainMenu());
            MenuSelection(UserInput.MenuChoice(menuChoices));
        }
        static void MenuSelection(int UserChoice)
        {
            switch (UserChoice)
            {
                case 1:
                    {
                        AnsiConsole.MarkupLine("[bold green]Shop selected.[/]");
                        Thread.Sleep(1000);

                        ProductCatalog.ShowProductCatalog(1);

                        break;
                    }

                case 2:
                    {
                        AnsiConsole.MarkupLine("[bold green]Not implemented yet.[/]");
                        AnsiConsole.MarkupLine("[bold yellow]Returning to Main Menu...[/]");
                        Thread.Sleep(1000);

                        MainMenu.ShowMainMenu();

                        break;
                    }

                case 3:
                    {
                        AnsiConsole.MarkupLine("[bold green]Not implemented yet.[/]");
                        AnsiConsole.MarkupLine("[bold yellow]Returning to Main Menu...[/]");
                        Thread.Sleep(1000);

                        MainMenu.ShowMainMenu();

                        break;
                    }

                case 4:
                    {
                        AnsiConsole.MarkupLine("[bold green]Account Menu selected.[/]");
                        Thread.Sleep(1000);

                        AccountMenu.ShowAccountMenu(1);

                        break;
                    }

                case 5:
                    {
                        AnsiConsole.MarkupLine("[bold green]Shopping Cart Manager selected.[/]");
                        Thread.Sleep(1000);

                        ShoppingCartManager.ShowShoppingCartManager();

                        break;
                    }

                case 6:
                    {
                        AnsiConsole.MarkupLine("[bold green]Checkout selected.[/]");
                        Thread.Sleep(1000);

                        PlaceOrder.ShowPlaceOrder();

                        break;
                    }

                case 7:
                    {
                        AnsiConsole.MarkupLine("[bold green]Not implemented yet.[/]");
                        AnsiConsole.MarkupLine("[bold yellow]Returning to Main Menu...[/]");
                        Thread.Sleep(1000);

                        MainMenu.ShowMainMenu();

                        break;
                    }

                case 8:
                    {
                        int userChoiceImpressum;

                        AnsiConsole.MarkupLine("[bold green]Impressum selected.[/]");
                        Thread.Sleep(1000);

                        GUI_Display.DisplayWindow(GUI_Impressum.ShowImpressum());

                        userChoiceImpressum = UserInput.MenuChoice(GUI_Impressum.MaxMenuItems());

                        MenuSelection(userChoiceImpressum);

                        break;
                    }

                case 9:
                    {
                        if (Account.GetAccountRole(Program.ActiveUser) == "Admin")
                        {
                            AnsiConsole.MarkupLine("[bold green]Admin Menu selected.[/]");
                            Thread.Sleep(1000);

                            AdminMenu.ShowAdminMenu();
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[bold red]Invalid choice. Please try again.[/]");
                            Thread.Sleep(1000);

                            ShowMainMenu();
                        }
                        break;
                    }

                case 10:
                    {
                        Program.ActiveUser = null;
                        AnsiConsole.MarkupLine("[bold green]Logging out...[/]");
                        HardWareStorage.SaveAllDevices("HardWareStorage.json");

                        Thread.Sleep(1000);
                        LogIn.LogingIn();
                        break;
                    }
            }
        }
    }
}
