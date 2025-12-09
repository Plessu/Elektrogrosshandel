// """

using Spectre.Console;

namespace Elektrogrosshandel.Functions.AddArticelFunctions
{
    internal class AddArticelSelector
    {

        public static void ShowAddSelector(string Option)
        {
            switch (Option)
            {
                case "Case":
                    AddCase.AddCaseMenu();
                    break;
                case "Cooling":
                    AddCoolingSystem.AddCoolingMenu();
                    break;
                case "CPU":
                    AddCPU.AddCPUMenu();
                    break;
                case "Display":
                    AddDisplay.AddDisplayMenu();
                    break;
                case "GPU":
                    AddGrafikkarte.AddGrafikkarteMenu();
                    break;
                case "Mainboard":
                    AddMainboard.AddMainboardMenu();
                    break;
                case "Peripherie":
                    AddPeripheral.AddPeripheralMenu();
                    break;
                case "PSU":
                    AddPowerSupply.AddPowerSupplyMenu();
                    break;
                case "RAM":
                    AddRam.AddRamMenu();
                    break;
                case "Software":
                    AddSoftware.AddSoftwareMenu();
                    break;
                case "Storage":
                    AddStorageDevice.AddStorageMenu();
                    break;
                default:
                    AnsiConsole.MarkupLine("[red]Invalid Option Selected[/]");
                    AnsiConsole.MarkupLine("Returning to Main Menu...");
                    MainMenu.ShowMainMenu();
                    break;
            }
        }
    }
}

