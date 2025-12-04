using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel.GUI
{
    internal class GUI_Display
    {
        private static Markup headertitle = 
            new Markup("[bold #af8700 on black]Graef [/][bold #c0c0c0]Elektro[/][white]grosshandel[/]");

        private static Layout HeaderTitel = 
                           new Layout("HeaderTitle").Update(new Panel(
                               headertitle.Justify(Justify.Left)).Expand());

        private static Markup headersubtitle = 
            new Markup("[#c0c0c0]Ihr[/] [bold #af8700 on black]Partner[/] [#c0c0c0]fuer Elektrozubehoer[/]");

        private static Layout HeaderSubtitle = 
                           new Layout("HeaderSubtitle").Update(new Panel(
                               headersubtitle.Justify(Justify.Center)).Expand());

        public static void DisplayWindow(Layout Body)
        {
            //Create Layout and structure
            Layout window = new Layout("Window")
                .SplitRows(
                new Layout("Header")
                .SplitColumns(
                new Layout("HeaderTitle"),
                new Layout("HeaderSubtitle")),
                new Layout("Body"),
                new Layout("Footer"));
            
            window["Window"].Size = Console.WindowHeight;
            window["Header"].Size = 3;
            window["Footer"].Size = 3;
            window["HeaderTitle"].Size = 35;


            window["Body"].Update(Body);
            window["HeaderTitle"].Update(HeaderTitel);
            window["HeaderSubtitle"].Update(HeaderSubtitle);




            AnsiConsole.Clear();
            AnsiConsole.Write(window);  
            return;
        }
    }
}
