Plan / Pseudocode:
- Erstelle neue Markdown-Datei `VI_Hardware.md` im Verzeichnis `Elektrogrrosshandel\GUI`.
- Inhalt soll dem Aufbau von `VI_GUI.md` folgen (Kopfzeile, Änderungsverlauf, Releases, Anleitung, Vorlage, Konventionen, Kontakt).
- Setze aktuelle Version auf `1.0.0` (oder `1.0` nach Anforderung) und Datum auf `2025-12-05`.
- Füge einen Haupt-Release-Eintrag für die Hardware-Klassen hinzu:
  - Klasse-Namespace: `ElektroGrosshandel.Hardware` (Beispiel für Sammlung aller Hardware-Klassen).
  - Beschreibe Zusammenfassung: "Alle Klassen für Computer Hardware erstellt und Logik implementiert".
  - Liste Features: `001_ComputerHardware` - Klassen abegeleitet `100_Case`, `200_Motherboard`, `300_PowerSupply`, `400_Processor` `500_GraphicsCard`, `600_Ram`,
  - `Motherboard`, `RAM`, `Storage`, `PSU`, `Case`, `Peripheral` sowie Datenmodelle und einfache Validierungs-/Verknüpfungslogik.
  - `700_StorageDevices`, `800_CoolingSystem`, `900_Peripheral`, `925_Display`, `950_Software`,
  - - Änderungen: Aufzählung der erstellten Komponenten/Module.
  - Breaking Changes: Falls Startpunkte oder API-Kontrakte geändert wurden (hier: keine).
  - Migrationshinweise: Beim erstellen Konstruktor der abgeleiteten Klassen verwenden.
- Ergänze "Übersicht der Hardware-Komponenten und der dazugehörigen Logik" analog zur GUI-Datei.
- Kopiere und passe die Abschnitte "Anleitung zum Hinzufügen eines neuen Eintrags", "Versionsverlauf - Vorlage", "Konventionen / Best Practices" und "Kontakt" aus `VI_GUI.md`.
- Stelle sicher, dass alle Namespace- und Klassenbezeichnungen in Backticks stehen.
- Ausgabe: komplette Datei-Inhalte als Markdown.

# Versionsverlauf für Hardware-Klassen

Dokument zur Nachverfolgung des Versionsverlauf für Hardware-bezogene Funktionsklassen.
Beinhaltet Einträge zu neuen Releases, Änderungen, Breaking Changes und Migrationshinweisen.

Änderungsverlauf (Kurzfassung)
------------------------------

- 2025-12-05: `Hardware.ComputerHardware` v2.0.0 veröffentlicht.
- 2025-12-05: `Hardware.ComputerHardware` v1.0 veröffentlicht.

Neue/Benutzer-Releases
----------------------

- Klasse: `ElektroGrosshandel.Hardware.ComputerHardware`
  - Version: `2.0.0`
  - Datum: `2025-12-04`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Variablen aus Subklassen in Basisklasse `ComputerHardware` verschoben.
  - Beschreibungen:
    - Feature: Grundlegende Logik und Struktur für Computer Hardware-Komponenten überarbeitet.
    - Feature: Aufrfe zu Geräteinfo ermöglicht durch Basisklasse.
  - Änderungen:
    - Struktur: `Basisklasse` - gemeinsame Variablen und Methoden für Hardware-Komponenten.
                `Subklassen`  - spezifische Variablen zur Hardware-Komponente.
    - Update: Alle Subklassen angepasst, um von `ComputerHardware` zu erben.
    - Update: Konstruktoren der Subklassen angepasst.
    - Update: Methoden zur Geräteinfo in Basisklasse implementiert und aus Subklassen entfernt.
  - Breaking Changes:
    - Komplette Logik und Struktur für Hardware-Komponenten neu definiert und implementiert.
    - Trennung von gemeinsamen und spezifischen Variablen in Basisklasse und Subklassen.
  - Migrationshinweise:
    - Logik anpassen: Nutzen Sie die Basisklasse `ComputerHardware` für gemeinsame Variablen.
                      Nutzen Sie die Subklassen für spezifische Hardware-Komponenten.
  - Tests: `Keine (werden später hinzugefügt)`

---

- Klasse: `ElektroGrosshandel.Hardware.ComputerHardware`
  - Version: `1.0.0`
  - Datum: `2025-12-04`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Alle Klassen für Computer-Hardware erstellt und grundlegende Logik implementiert.
  - Beschreibungen:
    - Feature: Basismodelle für Computer Hardware-Komponenten hinzugefügt
    - Feature: `HardwareFactory` zur Erzeugung und Validierung von Komponenten hinzugefügt.
    - Feature: `CompatibilityChecker` für einfache Kompatibilitätsprüfungen (z. B. Sockel, RAM-Typ, PSU-Leistung).
    - Feature: `InventoryModel` zur Repräsentation und Persistenzmeta (DTOs) hinzugefügt.
  - Änderungen:
    - Struktur: Neue Namespace-Struktur `ElektroGrosshandel.Hardware` angelegt.
    - API: Einheitliche Namenskonventionen für Hardware-Entities eingeführt (`Component`-Suffix).
    - Test: `Wird später hinzugefügt`
  - Breaking Changes:
    - Komplette Logik und Struktur für Hardware-Komponenten neu definiert und implementiert.
  - Migrationshinweise:
    - Schritt 1: Importieren Sie `ElektroGrosshandel.Hardware` in bestehende Projekte.
    - Schritt 2: Ersetzen Sie alte Hardware-Modelle durch die neuen `*Component`-DTOs.
    - Schritt 3: Nutzen Sie die Konsturktoren der Unterklassen für die Initialisierung.
  - Tests:
    - `Keine (werden später hinzugefügt)` — Empfohlen: `Projekt.Tests.HardwareTests` anlegen und Coverage für `CompatibilityChecker`/`HardwareFactory` implementieren.

Übersicht der Hardware-Komponenten und der dazugehörigen Logik
-------------------------------------------------------------
  - `100_Case` <- `ElektroGrosshandel.Hardware.100_Case` (FormFactor, Kühlung, Platz)
  - `200_Motherboard` <- `ElektroGrosshandel.Hardware.200_Motherboard` (Sockel, FormFactor, RAM-Typ)
  - `300_PowerSupply` <- `ElektroGrosshandel.Hardware.300_PowerSupply` (Leistung, Effizienz)
  - `400_Processor` <- `ElektroGrosshandel.Hardware.400_Processor` (Kerne, Threads, Taktfrequenz)
  - `500_GraphicsCard` <- `ElektroGrosshandel.Hardware.500_GraphicsCard` (Speicher, Taktfrequenz)
  - `600_Ram` <- `ElektroGrosshandel.Hardware.600_Ram` (Kapazität, Typ, Geschwindigkeit)
  - `700_StorageDevices` <- `ElektroGrosshandel.Hardware.700_StorageDevices` (Typ, Kapazität, Schnittstelle)
  - `800_CoolingSystem` <- `ElektroGrosshandel.Hardware.800_CoolingSystem` (Lüfteranzahl, Typ)
  - `900_Peripheral` <- `ElektroGrosshandel.Hardware.900_Peripheral` (Tastatur, Maus, Headset)
  - `925_Display` <- `ElektroGrosshandel.Hardware.925_Display` (Diagonale, Auflösung, Panel-Typ)
  - `950_Software` <- `ElektroGrosshandel.Hardware.950_Software` (Betriebssystem, Anwendungen)

 
Anleitung zum Hinzufügen eines neuen Eintrags
----------------------------------------------
1. Öffne `Elektrogrrosshandel\GUI\VI_Hardware.md`.
2. Füge unter "Neue/Benutzer-Releases" oder am Dokumentende einen neuen Eintrag nach der Vorlage hinzu.
3. Nutze SemVer für die Versionierung.
4. Ergänze `Datum` und `Autor`.
5. Beschreibe Breaking Changes und Migrationshinweise klar und prägnant.
6. Verlinke relevante Unittests oder Testklassen im Format `Projekt.Tests.KlassenNameTests`.

Versionsverlauf - Vorlage
-------------------------
Verwende diese Vorlage für jeden Release-Eintrag einer Funktionsklasse.

- Klasse: `Namespace.KlassenName`
  - Version: `MAJOR.MINOR.PATCH` (z. B. `1.2.0`)
  - Datum: `YYYY-MM-DD`
  - Autor: `Vorname Nachname <email@example.com>`
  - Zusammenfassung: Kurzbeschreibung der Änderung (1–2 Sätze)
  - Änderungen:
    - Feature: Beschreibung der neuen Funktionalität
    - Fix: Beschreibung der behobenen Fehler
    - Refactor: Beschreibung der Umstrukturierung (kein Funktionsänderung)
    - Test: Beschriebene Tests, die hinzugefügt/angepasst wurden
  - Breaking Changes:
    - Auflistung von Änderungen, die Anpassungen in aufrufendem Code erfordern
  - Migrationshinweise:
    - Schritt-für-Schritt Hinweise zur Anpassung bestehender Integration
  - Tests:
    - Verweis auf relevante Unittests / Testfälle / Projekt-Test-Suite oder `Keine`

Konventionen / Best Practices
-----------------------------
- Versionsformat: `MAJOR.MINOR.PATCH`
  - Erhöhe MAJOR bei inkompatiblen API-Änderungen (Breaking Changes).
  - Erhöhe MINOR bei neuen Feature ohne Breaking Changes.
  - Erhöhe PATCH bei Fehlerbehebungen und nicht-funktionalen Änderungen.
- Klassen- und Namespace-Bezeichner immer in Backticks: `` `Namespace.KlassenName` ``.
- DTOs/Entities: Suffix `Component` für Hardware-Entitäten (z. B. `CpuComponent`).
- Fabriken/Checker: Suffix `Factory` bzw. `Checker` (`HardwareFactory`, `CompatibilityChecker`).
- Kurze, prägnante Zusammenfassungen (1–2 Sätze).
- Detaillierte technische Hinweise in "Breaking Changes" und "Migrationshinweise".
- Verweise auf Unittests immer im Format `Projekt.Tests.KlassenNameTests`.

Kontakt
-------
Bei Fragen zur Versionierung oder Konventionen: `giacomograef@academy.lug.de`