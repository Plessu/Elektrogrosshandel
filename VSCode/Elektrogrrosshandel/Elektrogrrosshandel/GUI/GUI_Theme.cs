using Spectre.Console;

namespace Elektrogrosshandel.GUI
{
    internal static class GUI_Theme
    {
        // Farben
        public static readonly string Gold = "#af8700";
        public static readonly string Grey = "#c0c0c0";
        public static readonly string Accent = "#00afff";

        // Standard Header-Markup: "Graef" in Gold
        public static readonly Markup HeaderTitleMarkup =
            new Markup($"[bold {Gold} on black]Graef [/][bold {Grey}]Elektro[/][white]grosshandel[/]");

        public static readonly Markup HeaderSubtitleMarkup =
            new Markup($"[{Grey}]Ihr[/] [bold {Gold} on black]Partner[/] [{Grey}]fuer Elektrozubehoer[/]");

        // Erzeugt ein standardisiertes Panel mit Rows
        public static Panel CreatePanelForRows(IEnumerable<Markup> rows,
                                              string header,
                                              Justify headerJustify = Justify.Left,
                                              int height = 0,
                                              int width = 0,
                                              bool expand = false)
        {
            var panel = new Panel(new Rows(rows))
            {
                Header = new PanelHeader($"[bold {Gold} on black]{header}[/]", headerJustify),
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = expand
            };

            if (height > 0) panel.Height = height;
            if (width > 0) panel.Width = width;

            // Korrigiert: BorderColor gibt es nicht, stattdessen BorderStyle verwenden
            panel.BorderStyle = new Style(Color.DarkGoldenrod);
            return panel;
        }

        // Convenience für linke Menü-Panels (feste Maße im aktuellen Design)
        public static Panel CreateMenuPanel(IEnumerable<Markup> rows, string header)
        {
            return CreatePanelForRows(rows, header, Justify.Center, height: 15, width: 35, expand: true);
        }

        // Convenience für rechte Informations-Panels
        public static Panel CreateInfoPanel(IEnumerable<Markup> rows, string header)
        {
            return CreatePanelForRows(rows, header, Justify.Left, height: 15, width: 85, expand: true);
        }
    }
}
