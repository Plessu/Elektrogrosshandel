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
- ~~`IUser`~~ — ~~Interface für Benutzerkonto-Funktionalität (Datei: `IUser.cs`).~~
  - Hinweis: In Version `0.2` wurde das `IUser`-Interface in die `Account`-Klasse gemerged, um die Logik zu vereinfachen und Redundanzen zu vermeiden. Siehe `Account.cs` für die zusammengeführte Implementierung.

Hinweis: Dateinamen im Projekt enthalten u. a. `ArticIeItem.cs` (enthält Klasse `ArticleItem`), `ArticleGroup.cs`, `Bucket.cs`,
`GUI_Display.cs`, `GUI_MainMenu.cs`, `GetUserInput.cs`, `Program.cs`, `Account.cs`, ~~`IUser.cs`~~.

## Versionsverlauf

- `0.01` — Initiale Basisstruktur (Grundgerüst, erste Hilfsdateien); Zustand vor dem Hinzufügen der UI-Klassen (`GUI_*`) und der Modellklassen (`Article*`).
- `0.1` — Erste funktionale Version nach dem Erstellen der `GUI_*`-Klassen und der `Article*`-Klassen (UI- und Modellimplementierung).
- `0.2` — Account Klassen Update
  - `IUser` wurde in `Account` gemerged. Ziel: vereinfachte Kontenlogik, weniger Indirektion durch Interfaces, leichteres Testen und weniger Boilerplate.
  - Breaking Change: Referenzen auf `IUser` müssen durch direkte Verwendung von `Account` ersetzt oder entsprechend angepasst werden.
  - Empfehlung zur Migration:
    - Entferne oder archiviere `IUser.cs` (falls noch vorhanden).
    - Ersetze Typen `IUser` in Code und Tests durch `Account` oder passe Methoden-Signaturen an.
    - Prüfe `Account.cs` auf die erwarteten öffentlichen Methoden/Eigenschaften, passe Aufrufe an.
    - Führe vorhandene Unit-Tests durch und aktualisiere sie bei Bedarf.
  - Kurz: Weniger Interfaces, klarere Implementierung — bewusstes Design-Tradeoff für ein kleines Konsolenprojekt.

Wenn du möchtest, kann ich die README weiter detaillieren (z. B. öffentliche Methoden pro Klasse, UML- oder Sequenzdiagramme) oder die Datei direkt im Repository committen.