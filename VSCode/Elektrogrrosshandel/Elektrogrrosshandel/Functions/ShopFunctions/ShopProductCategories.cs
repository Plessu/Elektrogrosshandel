using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using Elektrogrosshandel.Hardware;

namespace Elektrogrosshandel.Functions.ShopFunctions
{
    internal class ShopProductCategories
    {
        public static void ShowShopProductCategories(string UserInput)
        {
            string userInput;
            int choice;

            switch (UserInput)
            {
                case "Case":

                    List<Markup> caseList = new List<Markup>();

                    AnsiConsole.MarkupLine("[bold green]Case category selected.[/]");
                    Thread.Sleep(200);

                    List<Case> cases = ComputerHardware.GetAllCases();

                    foreach (Case c in cases)
                    {
                        caseList.Add(ComputerHardware.GetArticelInfoByArticel(c));
                    }

                    GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(caseList));

                    userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                    if (int.TryParse(userInput, out choice))
                    {
                        if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                        {
                            ProductCatalog.ShowProductCatalog(choice);
                        }
                    }
                    else
                    {
                        ShopProductArticelOverrview.ShowArticelOverview(userInput);
                    }

                    break;

                case "Mainboard":
                    {
                        List<Markup> mainboardList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]Mainboard category selected.[/]");
                        Thread.Sleep(200);
                        List<Motherboard> mainboards = ComputerHardware.GetAllMotherboards();
                        foreach (Motherboard m in mainboards)
                        {
                            mainboardList.Add(ComputerHardware.GetArticelInfoByArticel(m));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(mainboardList));
                        
                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }

                case "CPU":
                    {
                        List<Markup> cpuList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]CPU category selected.[/]");
                        Thread.Sleep(200);
                        List<Processor> cpus = ComputerHardware.GetAllProcessors();
                        foreach (Processor cpu in cpus)
                        {
                            cpuList.Add(ComputerHardware.GetArticelInfoByArticel(cpu));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(cpuList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }

                case "RAM":
                    {
                        List<Markup> ramList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]RAM category selected.[/]");
                        Thread.Sleep(200);
                        List<Ram> rams = ComputerHardware.GetAllRAMs();
                        foreach (Ram ram in rams)
                        {
                            ramList.Add(ComputerHardware.GetArticelInfoByArticel(ram));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(ramList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }

                case "GPU":
                    {
                        List<Markup> gpuList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]GPU category selected.[/]");
                        Thread.Sleep(200);
                        List<GraphicsCard> gpus = ComputerHardware.GetAllGraphicsCards();
                        foreach (GraphicsCard gpu in gpus)
                        {
                            gpuList.Add(ComputerHardware.GetArticelInfoByArticel(gpu));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(gpuList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }

                case "PSU":
                    {
                        List<Markup> psuList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]PSU category selected.[/]");
                        Thread.Sleep(200);
                        List<PowerSupply> psus = ComputerHardware.GetAllPowerSupplies();
                        foreach (PowerSupply psu in psus)
                        {
                            psuList.Add(ComputerHardware.GetArticelInfoByArticel(psu));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(psuList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }
                case "Storage":
                    {
                        List<Markup> storageList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]Storage category selected.[/]");
                        Thread.Sleep(200);
                        List<StorageDevice> storages = ComputerHardware.GetAllStorageDevices();
                        foreach (StorageDevice storage in storages)
                        {
                            storageList.Add(ComputerHardware.GetArticelInfoByArticel(storage));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(storageList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }
                case "Cooling":
                    {
                        List<Markup> coolingList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]Cooling category selected.[/]");
                        Thread.Sleep(200);
                        List<CoolingSystem> coolings = ComputerHardware.GetAllCoolingSystems();
                        foreach (CoolingSystem cooling in coolings)
                        {
                            coolingList.Add(ComputerHardware.GetArticelInfoByArticel(cooling));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(coolingList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }
                
                case "Peripherie":
                    {
                        List<Markup> peripherieList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]Peripherie category selected.[/]");
                        Thread.Sleep(200);
                        List<Peripheral> peripheries = ComputerHardware.GetAllPeripherals();
                        foreach (Peripheral peripherie in peripheries)
                        {
                            peripherieList.Add(ComputerHardware.GetArticelInfoByArticel(peripherie));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(peripherieList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }
                
                case "Display":
                    {
                        List<Markup> displayList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]Display category selected.[/]");
                        Thread.Sleep(200);
                        List<Display> displays = ComputerHardware.GetAllDisplays();
                        foreach (Display display in displays)
                        {
                            displayList.Add(ComputerHardware.GetArticelInfoByArticel(display));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(displayList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }
               
                case "Software":
                    {
                        List<Markup> softwareList = new List<Markup>();
                        AnsiConsole.MarkupLine("[bold green]Software category selected.[/]");
                        Thread.Sleep(200);
                        List<Software> softwares = ComputerHardware.GetAllSoftwares();
                        foreach (Software software in softwares)
                        {
                            softwareList.Add(ComputerHardware.GetArticelInfoByArticel(software));
                        }
                        GUI_Display.DisplayWindow(GUI_ProductCatalogCategorieSelected.ShowCategorieSelected(softwareList));

                        userInput = Functions.UserInput.GetStringInput("Gib die ArticelID ein um eine Artikelbeschreibung zu sehen oder wechsel das Menü(1 - 3)");

                        if (int.TryParse(userInput, out choice))
                        {
                            if (choice >= 1 && choice <= GUI_ProductCatalogManufacturerSelected.MaxMenuItems())
                            {
                                ProductCatalog.ShowProductCatalog(choice);
                            }
                        }
                        else
                        {
                            ShopProductArticelOverrview.ShowArticelOverview(userInput);
                        }

                        break;
                    }

                default:
                    AnsiConsole.MarkupLine("[bold red]Invalid category selected.[/]");
                    AnsiConsole.MarkupLine("Please wait while we return you to the category selection menu...");
                    Thread.Sleep(200);

                    ProductCatalog.ShowProductCatalog(1);

                    break;
            }
        }
    }
}
