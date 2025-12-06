# Versionsverlauf für Funktionsklassen

  - Änderungsverlauf (Kurzfassung)
------------------------------

- 2025-12-06: `AccountMenuShoppingCartManager` v1.0.0 veröffentlicht.
- 2025-12-06: `AccountMenuInfo` v1.0.0 veröffentlicht.
- 2025-12-06: `AccountMenu` v1.0.0 veröffentlicht.
- 2025-12-06: `MainMenu` v1.1.0 veröffentlicht.
- 2025-12-05: `LogIn` v1.1.0 veröffentlicht.
- 2025-12-05: `PasswordHelper` v1.0.0 veröffentlicht.
- 2025-12-04: `LogIn` v1.0.0 veröffentlicht.
- 2025-12-04: `MainMenu` v1.0.2 veröffentlicht.

Neue/Benutzer-Releases
----------------------

- - Klasse: `ElektroGrosshandel.Functions.AccountMenuShoppingCartManager`
  - Version: `1.0.0`
  - Datum: `2025-12-06`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `AccountMenuShoppingCartManager` forged.
  - Änderungen:
    - Feature: `AccountMenuShoppingCartManager` regelt die Anzeige des ShoppingCart Managers.
  - Breaking Changes:
    - Einführung von `AccountMenuShoppingCartManager` (Änderung der Menüführung durch `AccountMenu`)
    - Menüführung wird über `AccountMenu` gehandhabt.
    - Logik für GUI-Aufruf des Submenüs `GUI_AcountShoppingCartManager`
  - Migrationshinweise:
    - Siehe `AccountMenu` für Integratonshinweise zu Submenüs/Subklassen.
    - Beachte out int choice in `AccountMenu` für Menüauswahl.
  - Tests: `Keine`

---

- Klasse: `ElektroGrosshandel.Functions.AccountMenuInfo`
  - Version: `1.0.0`
  - Datum: `2025-12-06`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `AccountMenuInfo` forged.
  - Änderungen:
    - Feature: `AccountMenuInfo` regelt die Anzeige des Benutzer Info Menüs.
  - Breaking Changes:
    - Einführung von `AccountMenuInfo` (Änderung der Menüführung durch `AccountMenu`)
    - Menüführung wird über `AccountMenu` gehandhabt.
    - Logik für GUI-Aufruf des Submenüs `GUI_AcountMenuInfo`
  - Migrationshinweise:
    - Siehe `AccountMenu` für Integratonshinweise zu Submenüs/Subklassen.
    - Beachte out int choice in `AccountMenu` für Menüauswahl.
  - Tests: `Keine`

---

- Klasse: `ElektroGrosshandel.Functions.AccountMenu`
  - Version: `1.0.0`
  - Datum: `2025-12-06`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `AccountMenu` forged.
  - Änderungen:
    - Feature: `AccountMenu` regelt die Anzeige und Auswahl des Benutzerkontomenüs.
  - Breaking Changes:
    - Einführung von `AccountMenu` (Änderung der Menüstruktur)
    - Menüfunktionalität ausgelagert von `MainMenu` zu `AccountMenu`.
    - Menüführung wird jetzt über `AccountMenu` gehandhabt.
    - Logik für GUI-Aufruf der Submenüs in Subklassen ausgelagert.
  - Migrationshinweise:
    - Siehe `AccountMenu` für Integratonshinweise zu Submenüs/Subklassen.
  - Tests: `Keine`


---

- Klasse: `ElektroGrosshandel.Functions.MainMenu`
  - Version: `1.1.0`
  - Datum: `2025-12-06`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `AccountMenu` integration.
  - Änderungen:
    - Feature: `AccountMenu` integration (Logik für User Menü Option)
  - Breaking Changes:
    - Einführung von `AccountMenu` (Änderung der Menüstruktur)
  - Migrationshinweise:
    - Siehe `AccountMenu` für Integration in `MainMenu`.
  - Tests: `Keine`


---

- Klasse: `ElektroGrosshandel.Functions.LogIn`
  - Version: `1.1.0`
  - Datum: `2025-12-05`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `PasswortHelper` integration in die LogIn-Funktion.
  - Änderungen:
    - Feature: `PasswordHelper` integration (Verwendung von PasswordHelper zur Passwortvalidierung)
  - Breaking Changes:
    - Passwortvalidierung Logik integriert (Änderung der Login-Logik)
  - Migrationshinweise:
    - Siehe Konstruktor `PasswordHelper` bei implementierung der LogIn-Funktion.
  - Tests: `ElektroGrosshandel.Functions.LogIn.TestData`

---

- Klasse: `ElektroGrosshandel.Functions.PasswordHelper`
  - Version: `1.0.0`
  - Datum: `2025-12-05`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Erste stabile Veröffentlichung der PasswordHelper-Funktion.
  - Änderungen:
    - Feature: `VerifyHash` hinzugefügt (Logik zum Passwort prüfen)
    - Feature: `GetHash` hinzugefügt (Logik zur Erstellung eines Hashs)
    - Test: `ElektroGrosshandel.Functions.LogIn.TestData`
  - Breaking Changes:
    - Logik in `LogIn` angepasst (Password-Hashing integriert)
  - Migrationshinweise:
    - Startlogik anpassen: `Login` Password-Validierung auf `PasswordHelper` umgestellt.
  - Tests: `ElektroGrosshandel.Functions.LogIn.TestData`

---

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

---

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
    - Die Darstellung des Hauptmenüs wurde in die `LogIn`-Funktion verschoben;
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