Plan (Pseudocode) — Schritt‑für‑Schritt (detailliert)
- Lies die vorhandenen Dateien:
  - Öffne `ComputerHardware.cs`
  - Öffne `GraphicCard.cs`
  - Prüfe weitere Hardware‑Dateien im Ordner `Hardware` (z. B. `Motherboard.cs`, `Case.cs`, `HardwareRegistry.cs` falls vorhanden)
- Ermittele aktuelle Verantwortlichkeiten:
  - Identifiziere statische Sammlungen (z. B. `GraphicCards`, `Devices`) — in welcher Klasse sind sie?
  - Identifiziere Fabrikmethoden / private Konstruktoren (z. B. `CreateMotherboard`, `CreateArticelID`)
  - Prüfe Konstruktorverhalten (registrieren Instanzen sich automatisch?)
  - Prüfe Properties/Felder, die in Basisklasse und abgeleiteten Klassen dupliziert sind
  - Suche nach Utilities wie `GetArticelByID(...)` und validiere deren Logik
- Analysiere neue Struktur (aktualisierte Dateien):
  - Wenn Statische Sammlungen verschoben wurden: notiere neue Klasse (z. B. `HardwareRegistry`) und ihr API
  - Wenn `ComputerHardware` zu `abstract` oder responsibilities reduziert wurden, notiere Änderungen (z. B. kein automatisches Registrieren mehr)
  - Wenn `GraphicCard` private Felder entfernt / auf Basiseigenschaften umgestellt hat, notiere konkrete Feldänderungen
- Erstelle korrigierende Empfehlungen:
  - Liste "Gotchas" (Logikfehler, Duplikate, Namensinkonsistenzen)
  - Empfehle präzise Code‑Änderungen (z. B. `GetArticelByID`-Fix, Entfernen duplizierter Felder)
- Biete kurze, kommentierte Code‑Snippets zur Behebung:
  - Minimaler `HardwareRegistry` (falls noch nicht vorhanden)
  - Verbessertes `ComputerHardware` (protected ctor, Eigenschaften)
  - Fix für `GetArticelByID`
  - Vereinfachte `GraphicCard`-Factory
- Fasse zusammen und gebe nächste Schritte für Refactoring / Tests:
  - Unit Tests für `GetArticelByID`
  - Code‑Review für Namenskonventionen (`Articel` vs `Article`)
  - Migration der statischen Sammlungen in `HardwareRegistry` falls noch nicht geschehen

Technische Übersicht — aktualisierte Struktur der Hardware‑Dateien

Kurzüberblick (aktualisiert)
- Die Hardware‑Klassen befinden sich im Namespace `Elektrogrrosshandel.Hardware`.
- Die Verantwortlichkeit für globale Sammlungen wurde aus `ComputerHardware` ausgelagert in eine zentrale Hilfsklasse `HardwareRegistry` (oder ein gleichwertiges Pattern).
  - `HardwareRegistry` enthält jetzt `List<ComputerHardware> Devices`, `List<GraphicCard> GraphicCards`, etc.
- `ComputerHardware` ist reduziert/`abstract` und enthält nur gemeinsame Eigenschaften und Basiskonstruktor (registriert nicht mehr automatisch).
- `GraphicCard` erbt von `ComputerHardware` und verwendet eine klar benannte Factory (`CreateGraphicCard`) oder öffentliche Fabrikmethoden; interne Duplikate von Feldern wurden entfernt — abgeleitete Klassen verwenden Basiseigenschaften.
- Utility‑Methoden wie `GetArticelByID` wurden überarbeitet, um korrekte Suchreihenfolge, Typprüfung und Null‑Sicherheit sicherzustellen.

Verantwortlichkeiten (konkret)
- `HardwareRegistry` (neu / zentral)
  - Verantwortlich für das Halten und Verwalten aller statischen Listen: `Devices`, `GraphicCards`, `Motherboards`, `Cases`, ...
  - API‑Beispiele: `Register(ComputerHardware device)`, `AddGraphicCard(GraphicCard gc)`, `FindById(int id)`
- `ComputerHardware`
  - Gemeinsame Eigenschaften: `int ArticelID`, `string ArticelModel`, `int ArticelManufacturerID`, evtl. `int ParentGroupID` / `string ParentGroupName`
  - Gemeinsame Funktionalität: Validierung, ToString(), minimaler Konstruktor (protected)
  - Keine direkten statischen Sammlungen mehr
- `GraphicCard`
  - Spezifische Eigenschaften: `EnergyConsumption`, `MemorySize`, `InterfaceType` (keine Duplikation von `ArticelID` etc.)
  - Factory: `static GraphicCard CreateGraphicCard(...)` erstellt Instanz, erzeugt ID und ruft `HardwareRegistry.Register(...)` / `HardwareRegistry.AddGraphicCard(...)`.

Gotchas (gefunden / empfohlen zu beheben)
- Duplizierte Felder:
  - Problem: `GraphicCard` definiert Felder wie `ArticelID` parallel zur Basisklasse — führt zu Verwirrung und fehlerhaften Zugriffen.
  - Empfehlung: Entferne duplizierte Felder in abgeleiteten Klassen und verwende die Basiseigenschaften.
- Automatische Registrierung im Basiskonstruktor:
  - Problem: `public ComputerHardware() { Devices.Add(this); }` sorgt dafür, dass jedes Objekt schon während Konstruktion in globale Listen gelangt (auch wenn Konstruktor noch nicht vollständig initialisiert ist).
  - Empfehlung: Mache Registrierung explizit (z. B. `HardwareRegistry.Register(instance)` nach erfolgreicher Instanziierung) oder registriere in facto­ry‑Methoden.
- `GetArticelByID` Logikfehler:
  - Problem: Implementierung durchsucht möglicherweise nur eine Liste oder verwendet falsche Vergleichslogik (z. B. Vergleich von ID mit ParentGroupID).
  - Empfehlung: Implementiere ein robustes Suchverfahren über `HardwareRegistry` mit exakter ID‑Vergleichslogik und Typangabe.
- Namensinkonsistenz `Articel` vs `Article`:
  - Empfehlung: Falls möglich, konsistente Umbenennung zu `Article` in einem Refactor‑Commit; ansonsten vereinheitlichen und dokumentieren.
- Factory‑Namensgebung:
  - Problem: Methode `CreateMotherboard` wird in `GraphicCard` verwendet — irreführend.
  - Empfehlung: Benenne Fabrikmethoden sinnvoll (z. B. `CreateGraphicCard`).

Konkrete Korrektur‑Snippets (minimal, kommentiert)
- Beispiel: `HardwareRegistry` (zentrale statische Sammlungen)