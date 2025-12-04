# Elektrogroßhandel — Kurzüberblick

Kurze Beschreibung
- Projektziel: Verwaltung und Präsentation von Artikeln für einen Elektrogroßhandel.
- Technologie: `Spectre.Console` für die Konsolen-UI, Zielplattform: `.NET 10`.
- Aufbau: Trennung von UI, Domänenmodellen und Datenlogik; leichte, testbare Komponenten.

Schnellstart
- Voraussetzungen: `.NET 10 SDK` installiert, Visual Studio oder `dotnet` CLI.
- Projekt ausführen:
  - In Visual Studio: Projekt öffnen und starten.
  - Mit CLI: `dotnet run --project Elektrogroßhandel`
- Tests (falls vorhanden): `dotnet test`

Projektstruktur (Auszug)
- `GUI_Display` — Layout und Hauptfensteranzeige (verwaltet Header, Body und Footer mittels `Spectre.Console`).
- `GUI_MainMenu` — Hauptmenü-Panel und Anzeigeelemente für Menüpunkte; stellt Menü- und Display-Panels bereit.
- `GetUserInput` — Hilfsklasse zum Einlesen von Benutzerauswahl (`TextPrompt` via `Spectre.Console`).
- `Program` — Einstiegspunkt (`Main`) und Steuerung der Menünavigation.
- `ArticleItem` — Domänenmodell für einzelne Artikel (Eigenschaften, Erzeugung, Lookup, Preisabfrage).
- `ArticleGroup` — Verwaltung von Artikelgruppen, Zuordnung von Artikeln zu Gruppen sowie Gruppen-CRUD-Methoden.
- `Bucket` — Warenkorb-ähnliche Struktur zur Sammlung von `ArticleItem`-Objekten mit Mengen und Gesamtpreis.
- `Account` — Repräsentation von Benutzerkonten / Account-Logik (Datei: `Account.cs`).
- `ComputerHardware.cs` — Neue Basisklasse für Computerartikel (siehe unten).
- `CPU.cs`, `GPU.cs`, `Motherboard.cs`, `Storage.cs`, `PowerSupply.cs` — Spezifische Erben von `ComputerHardware` mit zusätzlichen Eigenschaften / Preislogik.

Wichtige Hinweise / Migration
- In Version `0.2` wurde das `IUser`-Interface in die `Account`-Klasse gemerged, um die Kontenlogik zu vereinfachen.
  - Auswirkungen: Alle Verwendungen von `IUser` müssen durch `Account` ersetzt werden.
  - Empfehlung zur Migration:
    - Entferne oder archiviere `IUser.cs` (falls noch vorhanden).
    - Ersetze Typen `IUser` in Code und Tests durch `Account`.
    - Prüfe `Account.cs` auf öffentliche Methoden/Eigenschaften und passe Aufrufer entsprechend an.
    - Führe Unit-Tests durch und passe sie bei Bedarf an.

Artikel-Logik — `ComputerHardware` (neu, Version 0.3)
- Übersicht
  - Ziel: Eine klare, erweiterbare Modellhierarchie für Computer-Hardware-Artikel bereitstellen.
  - Basis: `ComputerHardware` als abstrakte/konkrete Basisklasse, die gemeinsame Eigenschaften und Verhalten kapselt.
  - Erben: `CPU`, `GPU`, `Motherboard`, `Storage`, `PowerSupply` (jeweils eigene Dateien).

- Empfohlene öffentliche Eigenschaften in `ComputerHardware`
  - `Guid Id` — eindeutiger Identifikator
  - `string Name`
  - `string Manufacturer`
  - `decimal Price`
  - `int Stock`
  - `string Category` — z. B. "CPU", "GPU"
  - `Dictionary<string, string> Specs` — Key/Value für Modell-spezifische Spezifikationen

- Empfohlene öffentliche Methoden
  - `virtual decimal GetPrice()` — Rückgabe des effektiven Preises (z. B. mit Rabatten)
  - `bool Validate()` — Validierung der minimalen Eigenschaften (Name, Price >= 0, Stock >= 0)
  - `ArticleItem ToArticleItem()` — Konvertierung zu vorhandenem `ArticleItem`-Modell, damit UI / `Bucket` kompatibel bleibt

- Beispiel: Spezifische Eigenschaften (Beispielimplementierung)
  - `CPU`:
    - `int CoreCount`
    - `double BaseClockGhz`
  - `GPU`:
    - `int MemoryGB`
    - `string Chipset`
  - `Motherboard`:
    - `string Socket`
    - `string FormFactor`
  - `Storage`:
    - `int CapacityGB`
    - `string Type` (z. B. "SSD", "HDD")
  - `PowerSupply`:
    - `int Watt`
    - `string Certification` (z. B. "80+ Gold")

- Integration mit bestehendem System
  - `ArticleGroup` kann `ArticleItem`-Einträge aufnehmen. Neue `ComputerHardware`-Instanzen sollten mittels `ToArticleItem()` in `ArticleItem` überführt werden, bevor sie gruppiert oder in den `Bucket` gelegt werden.
  - `Bucket.Add(articleItem, quantity)` bleibt die zentrale Methode, um Waren in den Warenkorb zu legen.
  - UI-Komponenten (z. B. `GUI_MainMenu`) können beim Anzeigen zusätzliche `Specs`-Informationen mit anzeigen.

- Weiterführende Dokumentation
  - Detaillierte Funktionen, Logik und Implementierungsbeispiele der Hardware-Klassen (`ComputerHardware` und deren Erben) sind in der Dokumentationsdatei `TO.ComputerHardware.md` beschrieben.
  - Siehe: [TO.ComputerHardware.md](TO.ComputerHardware.md) — dort werden Methoden, Validierungsregeln, `ToArticleItem()`-Konvertierung sowie konkrete Beispiele ausführlich erklärt.

- Beispielanwendung (Pseudocode in C#)