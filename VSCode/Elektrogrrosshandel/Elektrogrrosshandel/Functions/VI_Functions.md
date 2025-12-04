# Versionsverlauf für Funktionsklassen

  - Änderungsverlauf (Kurzfassung)
------------------------------
- 2025-12-04: `LogIn` v1.0.0 veröffentlicht.
- 2025-12-04: `MainMenu` v1.0.2 veröffentlicht.

Neue/Benutzer-Releases
----------------------

- Klasse: `ElektroGrosshandel.Functions.LogIn`
  - Version: `1.0.0`
  - Datum: `2025-12-04`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Erste stabile Veröffentlichung der LogIn-Funktion.
  - Änderungen:
    - Feature: `LogIn` hinzugefügt (Logik zum Anzeigen des Menüs: Login/Register)
    - Feature: `MenuSelection` hinzugefügt (Logik zur Auswahl des Menüs)
    - Test: `Werden später hinzugefügt`
  - Breaking Changes:
    - Programmstart wurde auf `LogIn` geändert (Startpunkt des Programms verschoben)
  - Migrationshinweise:
    - Startlogik anpassen: Altes Startskript/Initialisierung auf `LogIn` umleiten.
  - Tests: `Keine (werden später hinzugefügt)`

- Klasse: `ElektroGrosshandel.Functions.MainMenu`
  - Version: `1.0.2`
  - Datum: `2025-12-04`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Erste stabile Veröffentlichung der MainMenu-Funktion.
  - Änderungen:
    - Feature: `DisplayMainMenu` hinzugefügt (Logik zum Anzeigen des Main Menüs)
    - Feature: `MenuSelection` hinzugefügt (Logik zur Auswahl des Untermenüs)
    - Test: `Werden später hinzugefügt`
  - Breaking Changes:
    - Programmstart wurde auf `LogIn` geändert (MainMenu-Startlogik verschoben)
  - Migrationshinweise:
    - Die Darstellung des Hauptmenüs wurde in die `LogIn`-Funktion verschoben; bei direktem Aufruf von `MainMenu` prüfen, ob Init-Parameter benötigt werden.
  - Tests: `Keine (werden später hinzugefügt)`






Anleitung zum Hinzufügen eines neuen Eintrags
----------------------------------------------
1. Öffne `Elektrogrrosshandel\Functions\VI_Functions.md`.
2. Füge unter "Beispiel-Einträge" oder am Dokumentende einen neuen Eintrag nach der Vorlage hinzu.
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
- Kurze, prägnante Zusammenfassungen (1–2 Sätze).
- Detaillierte technische Hinweise in "Breaking Changes" und "Migrationshinweise".
- Verweise auf Unittests immer im Format `Projekt.Tests.KlassenNameTests`.
- Klassen- und Namespace-Angaben immer in Backticks: `` `Namespace.KlassenName` ``

Kontakt
-------
Bei Fragen zur Versionierung oder Konventionen: `giacomograef@academy.lug.de`