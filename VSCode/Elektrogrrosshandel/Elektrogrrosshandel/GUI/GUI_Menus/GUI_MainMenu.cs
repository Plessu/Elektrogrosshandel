using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    //Main Menu dispalyed via Spectre.Console NuGet Plugin
    internal class GUI_MainMenu
    {
        //Menu Items
        private static List<Markup> menuItemsShop = new List<Markup>
        {
                new Markup("[#c0c0c0]  1. Product Catalog[/]"),
                new Markup("[#c0c0c0]  2. Discount Promotion[/]"),
                new Markup("[#c0c0c0]  3. PC Builder[/]")
        };
        private static List<Markup> menuItemsAccount = new List<Markup>
        {
                new Markup("[#c0c0c0]  4. User[/]"),
                new Markup("[#c0c0c0]  5. Shopping Cart[/]"),
                new Markup("[#c0c0c0]  6. Place Order[/]")
        };
        private static List<Markup> menuItemsPublic = new List<Markup>
        {
                new Markup("[#c0c0c0]  7. Customer Support[/]"),
                new Markup("[#c0c0c0]  8. Impressum[/]"),
                new Markup("[#c0c0c0]  9. AdminBereich[/]") 
        };
        private static Layout MainMenu()
        {
            Layout mainMenu = new Layout("Main Menu")
                .SplitColumns(
                    new Layout("Left").Size(35)
                        .SplitRows(
                            new Layout("Shop").Size(5),
                            new Layout("Account").Size(5),
                            new Layout("Public Area").Size(5)),
                    new Layout("Right"));

            mainMenu["Left"]["Shop"].Update(PanelMenuShop().Expand());
            mainMenu["Left"]["Account"].Update(PanelMenuAccount().Expand());
            mainMenu["Left"]["Public Area"].Update(PanelMenuPublic().Expand());
            mainMenu["Right"].Update(PanelDisplay().Expand());

            return mainMenu;
        }
            

         
        
        //Layout
        private static Panel PanelMenuShop()
        {
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItemsShop), VerticalAlignment.Top));
            panelMenu.Height = 5;
            panelMenu.Width = 35;
            panelMenu.Border(BoxBorder.Rounded);
            panelMenu.BorderColor(Color.DarkGoldenrod);
            panelMenu.Header("[bold #af8700 on black]Shop[/]");
            panelMenu.HeaderAlignment(Justify.Left);
            
            return panelMenu;
        }

        private static Panel PanelMenuAccount()
        {
            List<Markup> menu = new List<Markup>();
            menu = menuItemsAccount;

            if (Account.GetAccountRole(Program.ActiveUser) == "Admin")
            {
                menu.Add(new Markup("[#c0c0c0]  9. Admin Panel[/]"));
            }

            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItemsAccount), VerticalAlignment.Top));
            panelMenu.Height = 5;
            panelMenu.Width = 35;
            panelMenu.Border(BoxBorder.Rounded);
            panelMenu.BorderColor(Color.DarkGoldenrod);
            panelMenu.Header("[bold #af8700 on black]Account[/]");
            panelMenu.HeaderAlignment(Justify.Left);

            return panelMenu;
        }

        private static Panel PanelMenuPublic()
        {
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItemsPublic), VerticalAlignment.Middle));
            panelMenu.Height = 5;
            panelMenu.Width = 35;
            panelMenu.Border(BoxBorder.Rounded);
            panelMenu.BorderColor(Color.DarkGoldenrod);
            panelMenu.Header("[bold #af8700 on black]Public Area[/] ");
            panelMenu.HeaderAlignment(Justify.Left);

            return panelMenu;
        }

        private static Panel PanelDisplay()
        {
            //Create Panel for Display area
            Panel panelDisplay = new Panel(
                new Markup("[italic #00afff]Please select an option from the menu.[/]"));
            panelDisplay.Height = 15;
            panelDisplay.Width = 81;
            panelDisplay.Border(BoxBorder.Rounded);
            panelDisplay.Header("[bold #af8700 on black]Welcome Area[/]");
            panelDisplay.HeaderAlignment(Justify.Left);
            return panelDisplay;
        }
        public static Layout ShowMainMenu()
        {
            Layout mainMenuLayout = MainMenu();
            return mainMenuLayout;
        }
        public static int MaxMenuItems()
        {
            int maxMenuItems = (int) menuItemsShop.LongCount() + menuItemsAccount.Count() + menuItemsPublic.Count();
            return maxMenuItems;
        }
    }
}
