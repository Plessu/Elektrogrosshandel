using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class AccountMenuShoppingCartManager
    {
        public static void ShowShoppingCartManager()
        {
            int menuchoice;

            GUI_Display.DisplayWindow(GUI_AccountSCM_CurrentShoppingCart.ShowSCM_CurrentCart());

            menuchoice = UserInput.MenuChoice(GUI_AccountSCM_CurrentShoppingCart.MaxMenuItems());


        }

        private static void NavigateShoppingCartManager(int menuchoice)
        {
            int choice;

            switch (menuchoice)
            {
                case 1:
                
                    GUI_Display.DisplayWindow(GUI_AccountSCM_CurrentShoppingCart.ShowSCM_CurrentCart());
                    
                    AnsiConsole.MarkupLine("[bold green]Current Shopping Cart displayed.[/]");
                    
                    choice = UserInput.MenuChoice(GUI_AccountSCM_CurrentShoppingCart.MaxMenuItems());
                    NavigateShoppingCartManager(choice);
                    
                    break;
                
                case 2:
                    
                    GUI_Display.DisplayWindow(GUI_AccountSCM_SaveCart.ShowSaveCart());
                    
                    Account.SaveCurrentBucket(UserInput.GetStringInput("[bold yellow]Please enter a Name for the Bucket."));
                    
                    AnsiConsole.MarkupLine("[bold green]Shopping Cart saved successfully![/]");
                    Thread.Sleep(200);
                    
                    ShowShoppingCartManager();

                    break;

                case 3:

                    string cartloadchoice;

                    GUI_Display.DisplayWindow(GUI_AccountSCM_SavedShoppingCarts.ShowSavedCarts());
                    AnsiConsole.MarkupLine("[bold green]Saved Shopping Carts displayed.[/]");
                    AnsiConsole.MarkupLine("[bold yellow]Choose to Load a Cart or switch to another Menu (\" Load \" or 1 - 4)[/]");

                    do
                    {
                        cartloadchoice = UserInput.GetStringInput("Enter your choice: ");

                        if (cartloadchoice.ToLower() == "load")
                        {
                            bool isInt;
                            string cartid;

                            GUI_Display.DisplayWindow(GUI_AccountSCM_SavedShoppingCarts.ShowSavedCarts());
                            AnsiConsole.MarkupLine("[bold green]Load Shopping Cart selected.[/]");
                            AnsiConsole.MarkupLine("[bold yellow]Please enter the ID of the Shopping Cart you wish to load.[/]");

                            do
                            {
                                cartid = UserInput.GetStringInput("Enter Shopping Cart ID or \"back\" to get Back to your Current Cart: ");

                                if (cartid.ToLower() == "back")
                                {
                                    ShowShoppingCartManager();
                                    break;
                                }

                                isInt = int.TryParse(cartid, out int temp);

                                if (!isInt)
                                {
                                    AnsiConsole.MarkupLine("[bold red]Invalid ID format. Please enter a numeric ID.[/]");
                                    Thread.Sleep(200);
                                    continue;
                                }

                                else
                                {
                                    if (Account.LoadSavedBucket(temp))
                                    {
                                        GUI_Display.DisplayWindow(GUI_AccountSCM_SavedShoppingCarts.ShowSavedCarts());
                                        AnsiConsole.MarkupLine("[bold green]Shopping Cart loaded successfully![/]");
                                        break;
                                    }
                                    else
                                    {
                                        AnsiConsole.MarkupLine("[bold red]Failed to load Shopping Cart. Please check the ID and try again.[/]");
                                        continue;
                                    }
                                }
                            } while (true);
                        }

                        else if (int.TryParse(cartloadchoice, out choice))
                        {
                            if (choice > 4 || choice < 1)
                            {
                                AnsiConsole.MarkupLine("[bold red]Invalid choice. Please try again.[/]");
                                Thread.Sleep(200);

                                continue;
                            }
                            NavigateShoppingCartManager(choice);
                        }

                        else
                        {
                            AnsiConsole.MarkupLine("[bold red]Invalid choice. Please try again.[/]");
                            Thread.Sleep(200);

                            continue;
                        }
                    } while (true);

                    break;

                case 4:

                    string cartdeletechoice;
                    bool isInteger;

                    GUI_Display.DisplayWindow(GUI_AccountSCM_DeleteShoppingCart.ShowDeleteCart());
                    AnsiConsole.MarkupLine("[bold green]Delete Shopping Cart selected.[/]");

                    do
                    {
                        cartdeletechoice = UserInput.GetStringInput("[bold yellow]Please enter the ID of the Shopping Cart you wish to delete or \"back\" to get Back to your Current Cart.[/]");

                        if (cartdeletechoice.ToLower() == "back")
                        {
                            ShowShoppingCartManager();

                            break;
                        }

                        isInteger = int.TryParse(cartdeletechoice, out int deleteID);



                        if (Account.DeleteSavedBucket(deleteID))
                        {
                            GUI_Display.DisplayWindow(GUI_AccountSCM_DeleteShoppingCart.ShowDeleteCart());

                            AnsiConsole.MarkupLine("[bold green]Shopping Cart deleted successfully![/]");
                            AnsiConsole.MarkupLine("[bold yellow]Returning to Shopping Cart Manager...[/]");

                            Thread.Sleep(200);

                            ShowShoppingCartManager();

                            break;
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[bold red]Failed to delete Shopping Cart. Please check the ID and try again.[/]");
                            continue;
                        }
                    } while (true);

                    break;

                case 5:
                    
                    GUI_Display.DisplayWindow(GUI_AccountInfoMenu.ShowAccountInfoMenu());
                    break;
            }
        }
    }
}
