# Übersicht: Klassen im Ordner `Functions`

Funktionsübersicht der Funktionen im Ordner `Functions`.

## `Login.cs`
Kurzbeschreibung:
- Verantwortlich für die Benutzeranmeldung der Anwendung.
- Erwartete Aufgaben: Entgegennahme und Validierung von Anmeldedaten, Authentifizierungslogik, Fehlerbehandlung bei fehlerhaften Eingaben und Initialisierung der Benutzersitzung/Session nach erfolgreicher Anmeldung.
- Typische Schnittstellen/Verhalten (je nach Implementierung): Anzeige des Login-Dialogs/Formulars, Aufruf eines Authentifizierungsservices, Zurückgeben des Anmeldeergebnisses und ggf. Rolle/Rechte des Benutzers.

Wichtige Hinweise / Gotchas:
- Sensible Daten (Passwörter) sollten niemals im Klartext geloggt oder gespeichert werden.
- Validierung sowohl client- als auch serverseitig durchführen.
- Bei asynchronen Aufrufen auf UI-Thread-Kontext achten (z. B. bei Desktop-UI).

## `Mainmenu.cs`
Kurzbeschreibung:
- Steuert das Hauptmenü und die Navigation der Anwendung.
- Erwartete Aufgaben: Aufbau und Darstellung der Menüstruktur, Weiterleitung zu Untermodulen/Funktionen, Aktivierung/Deaktivierung von Menüeinträgen basierend auf Benutzerrechten und Zustand der Anwendung.
- Typische Schnittstellen/Verhalten: Methoden zum Initialisieren des Menüs, Event-Handler für Menüauswahl, Aktualisierung der sichtbaren Optionen bei Rollenwechsel.

Wichtige Hinweise / Gotchas:
- Bei komplexer Menülogik Trennung von Darstellung und Logik (z. B. ViewModel) erwägen.
- Berechtigungsprüfungen zentralisieren, nicht nur im UI, um Sicherheit zu gewährleisten.

---

Für den vollständigen Versionsverlauf und Änderungen siehe `VI_Funktions.md`.