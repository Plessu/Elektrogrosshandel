Plan (Pseudocode) — Schritt‑für‑Schritt:
- Einlesen der vorhandenen Klassen `ComputerHardware` und `GraphicCard`.
- Beschreiben der Verantwortlichkeiten von `ComputerHardware`.
- Beschreiben, wie `GraphicCard` von `ComputerHardware` erbt und welche Members betroffen sind.
- Hervorheben von Code‑Beispielen (direkte, kommentierte Auszüge aus den Klassen).
- Auflisten von "Gotchas" (Fehlerquellen, Designprobleme) mit konkreten Korrekturvorschlägen.
- Anbieten kurzer, kommentierter Code‑Snippets zur Behebung der wichtigsten Probleme.
- Ausgabe als Markdown‑Technische Übersicht zur Ablage in `TO_ComputerHardware.md`.

Technische Übersicht — `ComputerHardware` und Vererbung zu `GraphicCard`

Kurzüberblick
- `ComputerHardware` ist eine Basisklasse (internal) in Namespace `Elektrogrrosshandel.Hardware`.
- Sie verwaltet zahlreiche statische Sammlungen (z. B. `Cases`, `Motherboards`, `GraphicCards`, ...) und eine globale `Devices`‑Liste aller Instanzen.
- `GraphicCard` erbt von `ComputerHardware` und verwendet ein Factory‑Muster (`CreateMotherboard` — eigentlich für Grafikkarten gedacht) zur Instanziierung.
- `GraphicCard` speichert viele spezifische Felder (z. B. `ArticelID`, `ArticelModel`, `EnergyConsumption`) und registriert sich beim Erzeugen in den statischen Sammlungen der Basisklasse.

Verantwortlichkeiten von `ComputerHardware`
- Zentraler Speicherort für Kategorien IDs und Namen:
  - `internal static readonly string ArticelParentGroup = "Computer Hardware";`
  - `internal static readonly int ArticelParentGroupID = 1001;`
- Statische Listen aller Unterkategorien:
  - `internal static List<GraphicCard> GraphicCards = new List<GraphicCard>();` usw.
- Globale Registrierung aller Hardware‑Objekte:
  - Konstruktor `public ComputerHardware() { Devices.Add(this); }`
- Hilfsfunktionen zum Hinzufügen in Kategorien:
  - `public static void AddGraphicCard(GraphicCard graphicCard) { GraphicCards.Add(graphicCard); }`
- Suche nach Artikeln:
  - `public static ComputerHardware GetArticelByID(int articelID) { ... }` (enthält einen Logikfehler; siehe Gotchas)

Wie `GraphicCard` von `ComputerHardware` erbt
- Deklaration: `internal class GraphicCard : ComputerHardware`
- Konstruktor ruft `: base()` auf — dadurch führt jeder `GraphicCard`‑Konstruktor die Basisklassenkonstruktion aus und registriert die Instanz in `ComputerHardware.Devices`.
- `GraphicCard` verwendet eine private Factory (`CreateMotherboard`), die:
  - Duplikate nach `ArticelModel` und `ArticelManufactrerID` verhindert.
  - Eine ID über `CreateArticelID()` erzeugt.
  - Private Konstruktoren nutzen, um direkte Erzeugung zu verhindern (Factory Pattern).
- Problem: `GraphicCard` definiert viele private Felder mit Namen, die stark denen in `ComputerHardware` ähneln oder sie duplizieren — das führt zu Verwirrung.

Kommentierte Code‑Auszüge (Original, mit Anmerkungen)

// Auszug: zentrale statische Listen in `ComputerHardware`