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
                new Markup("[#c0c0c0]  3. PC Builder[/]"),
                new Markup("[#c0c0c0]  4. Rack Builder[/]")
        };
        private static List<Markup> menuItemsAccount = new List<Markup>
        {
                new Markup("[#c0c0c0]  8. User[/]"),
                new Markup("[#c0c0c0]  5. Shoping Cart[/]"),
                new Markup("[#c0c0c0]  6. Orders[/]"),
                new Markup("[#c0c0c0]  7. Messages[/]"),
        };
        private static List<Markup> menuItemsPublic = new List<Markup>
        {
                new Markup("[#c0c0c0]  9. News[/]"),
                new Markup("[#c0c0c0] 10. Customer Support[/]"),
                new Markup("[#c0c0c0] 11. Impressum[/]")
        };
        private static Layout MainMenu()
        {
            Console.BufferHeight = 3000;
            Console.BufferWidth = 250;
            Console.WindowHeight = 23;
            Console.WindowWidth = 120;

            Layout mainMenu = new Layout("Main Menu")
                .SplitColumns(
                    new Layout("Left").Size(35)
                        .SplitRows(
                            new Layout("Shop").Size(6),
                            new Layout("Account").Size(6),
                            new Layout("Public Area").Size(6)),
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
            panelMenu.Height = 6;
            panelMenu.Width = 35;
            panelMenu.Border(BoxBorder.Rounded);
            panelMenu.BorderColor(Color.DarkGoldenrod);
            panelMenu.Header("[bold #af8700 on black]Shop[/]");
            panelMenu.HeaderAlignment(Justify.Left);
            
            return panelMenu;
        }

        private static Panel PanelMenuAccount()
        {
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItemsAccount), VerticalAlignment.Top));
            panelMenu.Height = 6;
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
                Align.Left(new Rows(menuItemsPublic), VerticalAlignment.Top));
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
            panelDisplay.Height = 17;
            panelDisplay.Width = 81;
            panelDisplay.Border(BoxBorder.Rounded);
            panelDisplay.Header("[bold #af8700 on black]Wellcome Area[/]");
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
            int maxMenuItems = menuItemsShop.Count() + menuItemsAccount.Count() + menuItemsPublic.Count();
            return maxMenuItems;
        }
    }
}
