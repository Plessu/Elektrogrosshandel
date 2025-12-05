# Übersicht: Klassen im Ordner `Functions`

Funktionsübersicht der Funktionen im Ordner `Functions`.

## `LogIn.cs`
Kurzbeschreibung:
- Verantwortlich für die Benutzeranmeldung der Konsolen-Anwendung: Darstellung des Login-Menüs, Einlesen von Benutzername und Passwort, Validierung via `Account`/`PasswordHelper` und Navigation zum Hauptmenü (`MainMenu`).

Implementierung (wichtigste Details):
- Sichtbare Methoden:
  - `static public void LogingIn()` — zeigt das Login-Fenster (`GUI_LogIn.ShowLoginMenu(...)`) an, rendert es mit `GUI_Display.DisplayWindow(...)` und fragt die Menüauswahl via `UserInput.MenuChoice(...)` ab.
  - `private static void MenuSelection(int Choice)` — wertet die Auswahl über `switch` aus und implementiert derzeit `case 1` (Login) und `case 2` (Register: nur Markup).
- Kontrollfluss:
  - Sequenz: `LogingIn()` → `GUI_LogIn.ShowLoginMenu(userName)` → `GUI_Display.DisplayWindow(...)` → `UserInput.MenuChoice(...)` → `MenuSelection(choice)` → bei `case 1`: Benutzernamen-Loop → Passwortabfrage → `PasswordHelper.VerifyPassword(...)` → bei Erfolg `MainMenu.DisplayMainMenu()`.
- Abhängigkeiten:
  - UI/Präsentation: `GUI_LogIn`, `GUI_Display`, `Spectre.Console` (`AnsiConsole`).
  - Eingabe: `UserInput`.
  - Authentifizierung/Daten: `Account`, `PasswordHelper`.
  - Navigation: `MainMenu`.
  - Zusätzliche API: `Thread.Sleep(...)` verwendet, aber `using System.Threading;` fehlt in der Datei.
- Implementierungsentscheidungen:
  - Statische Methoden und direkte Aufrufe (`MainMenu.DisplayMainMenu()`), hohe Kopplung an konkrete Implementierungen.
  - `switch`-basierte Auswahlverarbeitung; wenige implementierte Fälle.

Typische Schnittstellen/Verhalten:
- `void LogingIn()` — Initialisiere und zeige Login-UI, starte Auswahlverarbeitung.
- `void MenuSelection(int choice)` — führe Aktion basierend auf Auswahl aus.
- Erwartung: `GUI_LogIn.MaxMenuItems()` liefert gültige Range für `UserInput.MenuChoice`.

Wichtige Hinweise / Gotchas:
- Inkonsistente Instanz-/Statisch-Nutzung:
  - Feld `public Account ActiveAccount = new Account();` ist instanziell und wird nicht verwendet; alle Methoden sind `static`.
- Schleifen- und Kontrollflussprobleme:
  - Äußere `do { ... } while (false);` ist wirkungslos — wahrscheinlich ein Fehler (führt nur einmal aus).
  - Innere `do { ... } while (true);` zum Abfragen des Benutzernamens ist potentiell eine Endlosschleife ohne Abbruch oder Max-Versuche.
- Namenskonventionen:
  - Parameter/Variablen wie `Choice`, `UserChoice` nutzen PascalCase; Projektkonventionen erwarten `camelCase` (z. B. `choice`, `userName`).
- Fehlende Robustheit:
  - Kein `default`-Case im `switch` → ungültige Menüauswahl nicht behandelt.
  - Rückgaben von `GUI_LogIn.ShowLoginMenu(...)` und `UserInput.MenuChoice(...)` werden nicht auf `null` oder Fehler geprüft.
- Kompilations-/Referenzproblem:
  - `Thread.Sleep(1000);` benötigt `using System.Threading;` oder besser: asynchrone Alternative.
- Sicherheit:
  - Passwort als `string` im Klartext gehandhabt; keine Speicherbereinigung.
  - Keine Begrenzung der Login-Versuche (Brute-Force-Risiko).
  - Vergleichsmethode in `PasswordHelper` könnte ein naiver String-Vergleich sein — Timing-Attack-Risiko (siehe `CryptographicOperations.FixedTimeEquals`).
- Testbarkeit:
  - Statische Methoden und direkte Abhängigkeiten erschweren Unit-Tests und Mocking.

Verbesserungsvorschläge (priorisiert):
- Sofortige Korrekturen:
  - Entferne oder nutze `ActiveAccount` konsistent (z. B. `ActiveAccount = Account.Load(userName)` nach erfolgreichem Login).
  - Ersetze `do { ... } while(false);` durch eine sinnvolle Retry/Loop-Logik, z. B. `while (!loggedIn && attempts < maxAttempts)`.
  - Begrenze Login-Versuche und implementiere Verzögerung/Sperre nach mehrfachen Fehlversuchen.
  - Füge `default`-Case im `switch` hinzu und validiere Menü-Eingaben frühzeitig.
  - Importiere fehlende Namespaces (`using System.Threading;`) oder vermeide blockierende `Thread.Sleep`.
- Sicherheitsverbesserungen:
  - Verwende in `PasswordHelper.VerifyPassword` einen constant-time Vergleich (`CryptographicOperations.FixedTimeEquals`) und lagere Salts/Hashes mit Metadaten (Version, Iterationen).
  - Vermeide dauerhafte Speicherung von Klartext-Passwörtern und lösche Passwort-Bytes nach Gebrauch.
- Architektur & Testbarkeit:
  - Extrahiere IO-Abstraktionen (`IUserInput`, `IGuiDisplay`, `INavigator`) und injiziere sie (DI) statt direkte, statische Aufrufe.
  - Mache `LogIn` instanziierbar und trenne Authentifizierungs-Logik in einen `IAuthenticationService`.
  - Schreibe Unit-Tests für Login-Pfade, Benutzernamen-Validierung, Fehlerszenarien.
- UX & Robustheit:
  - Implementiere konsistente UI-Flow-Schleife mit klaren Exit-Optionen und Feedback.
  - Einheitliche Verwendung von `GUI_Display` vs. `AnsiConsole.Clear()`.

Tests & Validierung:
- Unit-Tests:
  - Gültiger Login, ungültiger Login, Account nicht vorhanden, Max-Versuche erreicht.
- Integrationstests:
  - Login-Flow mit Mock-`Account`-Repo und Mock-`PasswordHelper`.
- UI-Tests:
  - End-to-End-Simulation der Konsoleneingabe (z. B. mit abstrahiertem `IUserInput`).

Kurzfazit:
- Die Klasse implementiert die grundlegende Login-Interaktion, weist jedoch mehrere Design- und Sicherheitsmängel auf (schlechte Schleifensteuerung, fehlende Namespaces, unsichere Passwortbehandlung, geringe Testbarkeit). Prioritäre Maßnahmen sind Korrektur der Schleifenlogik, Begrenzung von Versuchen, Verwendung von constant-time-Compare und Trennung von IO und Logik für bessere Testbarkeit.



## `Mainmenu.cs`
Kurzbeschreibung:
- Verantwortlich für Anzeige und Steuerung des Hauptmenüs der Konsolen-Anwendung.
- Erwartete Aufgaben: Erzeugen und Anzeigen der Menüstruktur, Abfrage der Benutzerauswahl, Auslösen der entsprechenden Aktionen/Navigationen und Management einfacher UI-States (z. B. aktiver Menüpunkt).

Implementierung (wichtigste Details):
- Sichtbare Methoden:
  - `static public void DisplayMainMenu()` — erzeugt das Menü-Layout (`GUI_MainMenu.ShowMainMenu()`), zeigt es über `GUI_Display.DisplayWindow(...)` an und fragt die Auswahl über `UserInput.MenuChoice(...)` ab.
  - `static void MenuSelection(int UserChoice)` — wertet die Auswahl mittels `switch` aus und führt die Aktion aus (aktuell nur `case 1` implementiert).
- Kontrollfluss:
  - Sequenz: `ShowMainMenu()` → `DisplayWindow(...)` → `MenuChoice(maxItems)` → `MenuSelection(choice)`.
- Abhängigkeiten:
  - UI-Module: `GUI_MainMenu`, `GUI_Display`
  - Eingabe: `UserInput`
  - Präsentation: `Spectre.Console` (`AnsiConsole.MarkupLine`)
- Implementierungsentscheidungen:
  - Verwendung statischer Methoden für einfache Aufrufe in Konsolen-Flow.
  - `switch`-basierte Auswahlverarbeitung; geringe Anzahl implementierter Fälle.

Typische Schnittstellen/Verhalten:
- `void DisplayMainMenu()` — Anzeige des Menüs und Verarbeitung einer Benutzerauswahl.
- `void MenuSelection(int userChoice)` — Ausführung der Aktion basierend auf Auswahlwert.
- Erwartung: `GUI_MainMenu.MaxMenuItems()` liefert die gültige Range für `UserInput.MenuChoice`.

Wichtige Hinweise / Gotchas:
- Namens- und Stilkonventionen: Parameter und lokale Variablen verwenden momentan PascalCase (`UserChoice`); Projektkonventionen erwarten in der Regel `camelCase` für Parameter (`userChoice`).
- Testbarkeit: Statische Methoden erschweren Unit-Tests und Mocking. Instanzklassen mit DI wären testbarer.
- Fehlende Robustheit:
  - Keine `default`-Branch im `switch` → ungültige Eingaben werden nicht behandelt.
  - Keine Null-/Fehlerprüfung für Rückgaben von `GUI_MainMenu.ShowMainMenu()` oder `UserInput.MenuChoice(...)`.
- UI-Thread & Asynchronität: Bei späteren asynchronen Aktionen müssen UI-gebundene Updates auf dem entsprechenden Thread erfolgen.
- Kopplung: Direkte Abhängigkeit an konkrete GUI-Helper (`GUI_MainMenu`, `GUI_Display`) erhöht Kopplung und erschwert Portierung.
- UX-Flow: `DisplayMainMenu()` zeigt das Menü nur einmal; es fehlt eine Schleife oder Steuerlogik für wiederholte Anzeigen und Exit-Handling.
- Logging & Sicherheit: Ausgabe von Informationen via `AnsiConsole` ist unkritisch, aber sensible Daten dürfen niemals geloggt werden.



## `PasswordHelper.cs`

Optionale Verbesserungen:
- Architektur:
  - Übergang zu Instanzklasse mit injizierbaren Abhängigkeiten (`IUserInput`, `IGuiDisplay`, `INavigationService`) und Registrierung via DI-Container.
  - MVVM- oder Presenter-Pattern für klare Trennung von Logik und Darstellung.
- Robustheit:
  - `switch` um `default`-Case erweitern und ungültige Eingaben feedbacken.
  - Eingabe-/Range-Validierung zentralisieren.
  - Null-Checks und Fehlerbehandlung einbauen.
- UX & Performance:
  - Menü in Loop mit Exit-Option und optionalem "Zurück"-Verhalten anzeigen.
  - Lazy-Loading für große Menübäume.
- Testbarkeit:
  - Interfaces für GUI-Operationen mockbar machen und Unit-Tests für Auswahlverarbeitungs-Logik schreiben.
- Erweiterungen:
  - Lokalisierung der Menütexte via Ressourcen (`.resx`).
  - Persistente Speicherung des Menüzustands (z. B. zuletzt geöffnete Sektion).
  - Telemetrie/Instrumentation zur Messung Menünutzung.
- Modernisierung:
  - Asynchrone Signaturen (`Task`) für I/O-gebundene Menüaktionen.
  - Verwendung eines Command-Patterns (`ICommand`-ähnliche Implementierung) für Aktionen.

Tests & Validierung:
- Unit-Tests:
  - Auswahlverarbeitung (gültig/ungültig), Verhalten bei null/fehlerhaften Abhängigkeiten.
- Integrationstests:
  - Menü-Initialisierung mit Mock-UI-Komponenten.
- UI-Tests:
  - End-to-End-Tests der Konsoleninteraktion (bei Bedarf mit Spectre.Console-Mocks).
Kurzbeschreibung:
- Kapselt Erzeugung von Salt, Hashing von Kennwörtern und Verifikation gegen gespeicherte Werte.
- Implementiert PBKDF2 (`Rfc2898DeriveBytes.Pbkdf2`) mit `SHA256`.

Implementierung (wichtigste Details):
- Standardwerte: `saltSize = 16`, `hashSize = 32`, `iterations = 10000`.
- Private Hilfsfunktion: `GenerateSalt(int size = _saltSize)` — erzeugt kryptographisch sichere Zufallsbytes via `RandomNumberGenerator`.
- Überladene Methoden:
  - `string HashPassword(string password, byte[] salt)` — erzeugt Hash (Base64) aus Passwort und Salt.
  - `string HashPassword(string password, out byte[] Salt)` — erzeugt neuen Salt und gibt Hash (Base64) zurück.
- Verifikation:
  - `bool VerifyPassword(string userName, string password)` — holt Salt und gespeicherten Hash über `Account.GetAccountSalt(userName)` / `Account.GetAccountPasswordHash(userName)` und vergleicht das Ergebnis von `HashPassword` mit dem gespeicherten Hash.

Typische Schnittstellen/Verhalten:
- `HashPassword(string)` / `HashPassword(string, byte[])`
- `VerifyPassword(string userName, string password)`

Wichtige Hinweise / Gotchas:
- Die aktuelle `VerifyPassword` verwendet einen einfachen String-Vergleich (`==`). Für Sicherheit gegen Timing-Attacken `CryptographicOperations.FixedTimeEquals` (oder ein äquivalentes constant-time-Compare) verwenden.
- `iterations = 10000` ist funktional, kann aber für modernen Schutz gegen GPU-Brute-Force zu niedrig sein; Parameter an aktuelle Empfehlungen anpassen oder `Argon2`/`bcrypt` erwägen.
- Salt und Hash sollten zusammen mit Metadaten (Version, Iterationen) gespeichert werden, um Migration/Upgrade zu ermöglichen.
- Prüfe auf `null`/Fehler beim Aufrufen von `Account.GetAccountSalt` und `Account.GetAccountPasswordHash`.
- Sensible Daten (z. B. Passwort-Bytes) nach Gebrauch aus dem Speicher löschen, wenn möglich (`Span<byte>` / `Array.Clear`).
- Wenn Salt als `byte[]` gespeichert wird, konsistentes Encoding (z. B. Base64) verwenden.
- Logging von sensiblen Informationen strikt vermeiden.

Optionale Verbesserungen:
- Methode `NeedsRehash(string storedHash)` zur Erkennung veralteter Parameter implementieren und bei Anmeldung Rehash durchführen.
- Einheitstests für korrekte Verifikation, fehlerhafte Eingaben und Rehash-Szenarien anlegen.

---

Für den vollständigen Versionsverlauf und Änderungen siehe `VI_Funktions.md`.