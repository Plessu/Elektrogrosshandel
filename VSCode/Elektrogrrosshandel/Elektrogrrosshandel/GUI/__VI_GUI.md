# Versionsverlauf für Funktionsklassen

Dokument zur Nachverfolgung des Versionsverlauf für Funktionsklassen
Beinhaltet Einträge zu neuen Releases, Änderungen, Breaking Changes und Migrationshinweisen.


Änderungsverlauf (Kurzfassung)
------------------------------

- 2025-12-04: `GUI_Display` v1.0.0 veröffentlicht.
- 2025-12-04: `GUI_Login` v1.0.0 veröffentlicht.
- 2025-12-04: `GUI_MainMenu` v1.0.0 veröffentlicht.

Neue/Benutzer-Releases
----------------------


- Klasse: `ElektroGrosshandel.GUI.GUI_Menus.GUI_UserRegistration`
  - Version: `1.0.0`
  - Datum: `2025-12-05`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Erstveröffentlichung des User-Registration-Layouts mit Panels für persönliche Daten und Account-Informationen sowie Branding-Figlets.
  - Beschreibungen:
    - Feature: `User Registration Window` hinzugefügt (Layout mit getrennten Panels für Personal- und Account-Informationen).
    - Feature: `Branding Figlets` („Graef Elektro Grosshandel“) in der rechten Spalte.
    - Feature: `Null-sichere öffentliche API` `ShowUserRegistrationMenu` nimmt nullable Strings entgegen und ersetzt null durch leere Strings.
  - Änderungen:
    - UI: Neues Layout `User Registration` mit Spalten- und Zeilenaufteilung (`SplitColumns` / `SplitRows`).
    - Panels: `PanelPersonalInformation` und `PanelAccountInformation` implementiert (Felder sichtbar, Farben, Header, fixe Höhe/Breite).
    - Konsolen-Konfiguration: `Console.BufferHeight`, `Console.BufferWidth`, `Console.WindowHeight`, `Console.WindowWidth` werden gesetzt.
    - Styling: Farben, Border, Header und Alignment für Panels festgelegt.
    - API: Öffentliche Methode `ShowUserRegistrationMenu` erstellt und gibt ein `Layout` zurück.
  - Breaking Changes:
    - Globales Setzen von Konsolen-Buffer- und Fenstergrößen in der Methode kann andere GUIs/Module beeinflussen (ergibt ungeplantes Verhalten, wenn mehrere Views unterschiedliche Größen erwarten).
    - Feste Panel-Größen (Height/Width) können bei anderen Terminal-/Font-Einstellungen zu Layout-Überläufen führen.
  - Migrationshinweise:
    - Konsolen-Größen: Falls zentralisierte Fenster-/Layout-Steuerung vorhanden ist, entfernen oder verschieben Sie die Calls zu `Console.Buffer*` und `Console.Window*` in eine zentrale Initialisierung, um Seiteneffekte zu vermeiden.
    - Aufrufer anpassen: `ShowUserRegistrationMenu` erwartet Parameter-Reihenfolge `firstName, lastName, firmName, email, phoneNumber, userName, passWord, serialNumber` — prüfen und ggf. Aufrufer aktualisieren.
    - Layout-Tests: Bei anderen Terminalgrößen Panel-Größen prüfen und ggf. dynamisch anpassen statt feste Werte zu verwenden.
  - Tests: `Keine (werden später hinzugefügt)`
--- 
- Klasse: `ElektroGrosshandel.GUI_Menus.GUI_MainMenu`
  - Version: `1.0.0`
  - Datum: `2025-12-04`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Erste stabile Veröffentlichung der MainMenu Funktion.
  - Beschreibungen:
    - Feature: `MainMenu` hinzugefügt (Grundlegende Anzeige Logik)
  - Änderungen:
    - Layout: `LogIn` hinzugefügt (Layout Login/Register)
    - Layout: `MainMenu` abgeändert (Layout MainMenu)
    - Test: `Werden später hinzugefügt`
  - Breaking Changes:
    - Programmstart wurde auf `LogIn` geändert (Startpunkt des Programms verschoben)
  - Migrationshinweise:
    - Startlogik anpassen: Altes Startskript/Initialisierung auf `LogIn` umleiten.
  - Tests: `Keine (werden später hinzugefügt)`

---
- Klasse: `ElektroGrosshandel.GUI.GUI_Display`
  - Version: `1.0.0`
  - Datum: `2025-12-04`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Erste stabile Veröffentlichung der Anzeige Funktion.
  - Beschreibungen:
    - Feature: `Display Window` hinzugefügt (Grundlegende Anzeige Logik)
  - Breaking Changes:
    - Alle Anzeigenfunktionen sind neu und haben keine Breaking Changes.
  - Migrationshinweise:
    - Siehe Dokumentation in `Elektrogrrosshandel/GUI/TO_GUI_Display.md` für Details zur Nutzung der Anzeige-Funktionen.
  - Tests: `Keine (werden später hinzugefügt)`

Übersicht der GUI-Menüs und der dazugehörigen Logik.
----------------------------------------------
  - 2025-12-04: `GUI_Login` <- `Functions.LogIn`.
  - 2025-12-04: `GUI_MainMenu` <- `Functions.MainMenu`.

Anleitung zum Hinzufügen eines neuen Eintrags
----------------------------------------------
1. Öffne `Elektrogrosshandel\GUI\VI_GUI.md`.
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