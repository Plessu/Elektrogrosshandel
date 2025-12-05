# Technische Dokumentation — `GUI_Displays.cs`

## Zweck der Datei

- Verwaltet mehrere Display-Modelle für unterschiedliche Ansichten durch bereitgestellte Layout Datei.
- Behandelt Benutzerinteraktionen und synchronisiert View mit zugrundeliegenden Datenquellen.

---

## API-Übersicht (Platzhalter)

- Klasse `DisplayWindow` (public)

---

## Konstruktordokumentation

Klasse: `ElektroGrosshandel.GUI.GUI_DIsplay.DisplayWindow`
Version: `1.0.0`
Datum: `2025-12-04`
Autor: `Giacomo Graef`
Technologien: `C#`, `.NET 6`, `Spectre.Console`

### Konstruktor:

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

## Versionsverlauf

- Siehe `Elektrogrrosshandel/GUI/VI_GUI.md`