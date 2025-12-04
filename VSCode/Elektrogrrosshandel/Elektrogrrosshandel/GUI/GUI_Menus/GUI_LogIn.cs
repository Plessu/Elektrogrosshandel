using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    //Main Menu dispalyed via Spectre.Console NuGet Plugin
    internal class GUI_LogIn
    {
        private int maxMenuItems = menuItems.Count();

        //Menu Items
        private static List<Markup> menuItems = new List<Markup>
            {
                new Markup("[#c0c0c0]  1. LogIn[/]"),
                new Markup("[#c0c0c0]  2. Register[/]"),
        };

        private static Layout LoginMenu(string userName)
        {


            Console.BufferHeight = 3000;
            Console.BufferWidth = 250;
            Console.WindowHeight = 12;
            Console.WindowWidth = 120;

            Layout loginMenu = new Layout("LogIn")
                .SplitColumns(
                    new Layout("Left").Size(35)
                        .SplitRows(
                            new Layout("Menu").Size(6)),

                    new Layout("Right"));

            loginMenu["Left"]["Menu"].Update(PanelMenu().Expand());
            loginMenu["Right"].Update(PanelDisplay(userName).Expand());

            return loginMenu;
        }




        //Layout
        private static Panel PanelMenu()
        {
            Panel panelMenu = new Panel(
                Align.Left(new Rows(menuItems), VerticalAlignment.Top));
            panelMenu.Height = 6;
            panelMenu.Width = 35;
            panelMenu.Border(BoxBorder.Rounded);
            panelMenu.BorderColor(Color.DarkGoldenrod);
            panelMenu.Header("[bold #af8700 on black]Wellcome[/]");
            panelMenu.HeaderAlignment(Justify.Left);

            return panelMenu;
        }

        private static Panel PanelDisplay(string Username)
        {
            //Create Panel for Display area
            Panel panelDisplay = new Panel(
                new Markup($"[italic #00afff]Username:[/][white] {Username}[/]\n[italic #00afff]Password: [/]"));
            panelDisplay.Height = 6;
            panelDisplay.Width = 81;
            panelDisplay.Border(BoxBorder.Rounded);
            panelDisplay.Header("[bold #af8700 on black]LogIn[/]");
            panelDisplay.HeaderAlignment(Justify.Left);
            return panelDisplay;
        }
        public static Layout ShowLoginMenu(string? userName)
        {
            if (userName == null)
            {
                userName = "";
            }
            Layout logInLayout = LoginMenu(userName);
            return logInLayout;
        }

        public static int MaxMenuItems()
        {
            return menuItems.Count;
        }
    }
}
