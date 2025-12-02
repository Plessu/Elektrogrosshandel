using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    internal class GUI_Display
    {
        private static Markup headertitle = 
            new Markup("[bold red]Graef[/] \n[bold white]Elektrogrosshandel[/]");

        private static Layout HeaderTitel = 
                           new Layout("HeaderTitle").Update(new Panel(
                               headertitle.Justify(Justify.Left)).Expand());

        private static Markup headersubtitle = 
            new Markup("[white]Ihr[/] [bold red]Partner[/] [white]fuer Elektrozubehoer[/]");

        private static Layout HeaderSubtitle = 
                           new Layout("HeaderSubtitle").Update(new Panel(
                               headersubtitle.Justify(Justify.Center)).Expand());

        public static void MainWindow(Panel BodyMenu, Panel BodyDisplay)
        {
            //Create Layout and structure
            Layout mainWindow = new Layout("MainWindow")
                .SplitRows(
                new Layout("Header")
                .SplitColumns(
                new Layout("HeaderTitle"),
                new Layout("HeaderSubtitle")),
                new Layout("Body").SplitColumns(
                    new Layout("BodyMenu"),
                    new Layout("BodyDisplay")),
                new Layout("Footer"));
            
            mainWindow["MainWindow"].Size = 30;
            mainWindow["Header"].Size = 4;
            mainWindow["Footer"].Size = 3;
            mainWindow["Body"].Size = 20;
            mainWindow["HeaderTitle"].Size = 20;

            Panel bodyMenuPanel = new Panel(BodyMenu);
            Panel bodyDisplay = new Panel(BodyDisplay);

            mainWindow["HeaderTitle"].Update(HeaderTitel);
            mainWindow["HeaderSubtitle"].Update(HeaderSubtitle);
            mainWindow["BodyMenu"].Update(bodyMenuPanel.Expand());
            mainWindow["BodyDisplay"].Update(bodyDisplay.Expand());



            AnsiConsole.Clear();
            AnsiConsole.Write(mainWindow);  
            return;
        }
    }
}
