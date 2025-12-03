using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
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

        public static void MainWindow(Layout Body)
        {
            //Create Layout and structure
            Layout mainWindow = new Layout("MainWindow")
                .SplitRows(
                new Layout("Header")
                .SplitColumns(
                new Layout("HeaderTitle"),
                new Layout("HeaderSubtitle")),
                new Layout("Body"),
                new Layout("Footer"));
            
            mainWindow["MainWindow"].Size = 26;
            mainWindow["Header"].Size = 3;
            mainWindow["Footer"].Size = 3;
            mainWindow["HeaderTitle"].Size = 35;

            Layout body = 
                new Layout("BodyMenu").Update(
                    new Layout(Body));

            mainWindow["Body"].Update(new Layout(body));
            mainWindow["HeaderTitle"].Update(HeaderTitel);
            mainWindow["HeaderSubtitle"].Update(HeaderSubtitle);




            AnsiConsole.Clear();
            AnsiConsole.Write(mainWindow);  
            return;
        }
    }
}
