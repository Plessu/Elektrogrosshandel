// """

using Spectre.Console;

namespace Elektrogrosshandel.GUI
{
    internal class GUI_Display
    {
        private static Markup headertitle = GUI_Theme.HeaderTitleMarkup;
        private static Layout HeaderTitel =
                           new Layout("HeaderTitle").Update(new Panel(
                               headertitle.Justify(Justify.Left)).Expand());

        private static Markup headersubtitle = GUI_Theme.HeaderSubtitleMarkup;
        private static Layout HeaderSubtitle =
                           new Layout("HeaderSubtitle").Update(new Panel(
                               headersubtitle.Justify(Justify.Center)).Expand());

        public static void DisplayWindow(Layout Body)
        {
            int consoleHight = Console.WindowHeight;
            int bodyHeiht = (int)(consoleHight * 0.75);

            //Create Layout and structure
            Layout window = new Layout("Window")
                .SplitRows(
                new Layout("Header")
                .SplitColumns(
                new Layout("HeaderTitle"),
                new Layout("HeaderSubtitle")),
                new Layout("Body"),
                new Layout("Footer"));

            window["Window"].Size = 28;
            window["Header"].Size = 3;
            window["Footer"].Size = 3;
            window["HeaderTitle"].Size = 35;

            window["Body"].Update(Body).Size(bodyHeiht);
            window["HeaderTitle"].Update(HeaderTitel);
            window["HeaderSubtitle"].Update(HeaderSubtitle);

            window["Footer"].Update(new Panel(
                new Markup($"{Account.GetAccountNameByAccount(Program.ActiveUser)}")
                .Justify(Justify.Center)).Expand());

            AnsiConsole.Clear();
            AnsiConsole.Write(window);
            return;
        }
    }
}
