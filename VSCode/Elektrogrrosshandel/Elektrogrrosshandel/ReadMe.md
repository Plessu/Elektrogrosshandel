# Elekrogroßhandel — Kurzüberblick

Kurze Beschreibung
- Projektziel: Verwaltung und Präsentation von Artikeln für einen Elekrogroßhandel.
- Technologie: `Spectre.Console` für die Konsolen-UI, Zielplattform: `.NET 10`.
- Aufbau: Trennung von UI, Domänenmodellen und Datenlogik.

## Klassenübersicht

Folgende Klassen und Interfaces sind aktuell im Projekt vorhanden (kurze Beschreibung):

- `GUI_Display` — Layout und Hauptfensteranzeige (verwaltet Header, Body und Footer mittels `Spectre.Console`).
- `GUI_MainMenu` — Hauptmenü-Panel und Anzeigeelemente für Menüpunkte; stellt Menü- und Display-Panels bereit.
- `GetUserInput` — Hilfsklasse zum Einlesen von Benutzerauswahl (`TextPrompt` via `Spectre.Console`).
- `Program` — Einstiegspunkt (`Main`) und Steuerung der Menünavigation.
- `ArticleItem` — Domänenmodell für einzelne Artikel (Eigenschaften, Erzeugung, Lookup, Preisabfrage).
- `ArticleGroup` — Verwaltung von Artikelgruppen, Zuordnung von Artikeln zu Gruppen sowie Gruppen-CRUD-Methoden.
- `Bucket` — Warenkorb-ähnliche Struktur zur Sammlung von `ArticleItem`-Objekten mit Mengen und Gesamtpreis.
- `Account` — Repräsentation von Benutzerkonten / Account-Logik (Datei: `Account.cs`).
- `IUser` — Interface für Benutzerkonto-Funktionalität (Datei: `IUser.cs`).

Hinweis: Dateinamen im Projekt enthalten u. a. `ArticIeItem.cs` (enthält Klasse `ArticleItem`), `ArticleGroup.cs`, `Bucket.cs`, `GUI_Display.cs`, `GUI_MainMenu.cs`, `GetUserInput.cs`, `Program.cs`, `Account.cs`, `IUser.cs`.

## Versionsverlauf

- `0.01` — Initiale Basisstruktur (Grundgerüst, erste Hilfsdateien); Zustand vor dem Hinzufügen der UI-Klassen (`GUI_*`) und der Modellklassen (`Article*`).
- `0.1` — Erste funktionale Version nach dem Erstellen der `GUI_*`-Klassen und der `Article*`-Klassen (UI- und Modellimplementierung).

Wenn du möchtest, kann ich die README weiter detaillieren (z. B. öffentliche Methoden pro Klasse, UML- oder Sequenzdiagramme) oder die Datei direkt im Repository committen.