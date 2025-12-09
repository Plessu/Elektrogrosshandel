# Versionsverlauf (zusammengeführt)

Dieses Dokument fasst den Versionsverlauf aus den vorhandenen __VI-Template-Dateien im Repository zusammen (als Grundlage wurden die Dateien in den Namespaces `GUI`, `User`, `Functions` sowie der Hardware-Entwurf verwendet). Es dient als zentrale Nachverfolgung für Releases, Änderungen, Breaking Changes und Migrationshinweise.

Wichtig: Die Zusammenstellung basiert auf den gefundenen __VI-Dateien und den dort dokumentierten Einträgen. Die Code-/Commit-Suche kann unvollständig sein — für eine 100% vollständige Historie ist ein Durchlauf der vollständigen Git-Commit-History erforderlich. Weitere __VI-Dateien im Repo findest du über die GitHub-Code-Suche: https://github.com/Plessu/Elektrogrosshandel/search?q=__VI&type=code

Änderungsverlauf (Kurzfassung)
------------------------------
- 2025-12-08: `Functions.AddArticelFunctions.AddCase` v1.0.0 veröffentlicht.
- 2025-12-08: `Functions.AdminMenu` v1.0.0 veröffentlicht.
- 2025-12-07: `GUI.GUI_Menus.GUI_PlaceOrder` v1.0.0 veröffentlicht.
- 2025-12-07: `Functions.MainMenu` v2.0.0 veröffentlicht.
- 2025-12-07: `Functions.AccountMenu` v2.0.0 veröffentlicht.
- 2025-12-07: `Functions.ShoppingCartManager` v2.0.0 veröffentlicht.
- 2025-12-07: `Hardware.Order` v1.0.0 veröffentlicht.
- 2025-12-06: `GUI.GUI_Menus.GUI_SCM_*` v1.0.0 veröffentlicht.
- 2025-12-06: `Functions.AccountMenuShoppingCartManager` v1.0.0 veröffentlicht.
- 2025-12-06: `Functions.AccountMenuInfo` v1.0.0 veröffentlicht.
- 2025-12-06: `Functions.AccountMenu` v1.0.0 veröffentlicht.
- 2025-12-05: `User.Account` v2.0.0 veröffentlicht.
- 2025-12-05: `User.Bucket` v2.0.0 veröffentlicht.
- 2025-12-05: `User.UserRegistration` v1.0.0 veröffentlicht.
- 2025-12-05: `Hardware.ComputerHardware` v2.0.0 veröffentlicht.
- 2025-12-05: `Hardware.ComputerHardware` v1.0.0 veröffentlicht.
- 2025-12-05: `GUI.GUI_Menus.GUI_UserRegistration` v1.0.0 veröffentlicht.
- 2025-12-05: `Functions.LogIn` v1.1.0 veröffentlicht.
- 2025-12-04: `GUI.GUI_Menus.GUI_Display` v1.0.0 veröffentlicht.
- 2025-12-04: `GUI.GUI_Menus.GUI_Login` v1.0.0 veröffentlicht.
- 2025-12-04: `GUI.GUI_Menus.GUI_MainMenu` v1.0.0 veröffentlicht.
- 2025-12-04: `Functions.LogIn` v1.0.0 veröffentlicht.
- 2025-12-04: `Functions.MainMenu` v1.0.2 veröffentlicht.

Neue / Benutzer-Releases (Detail)
---------------------------------

- Klasse: `ElektroGrosshandel.Functions.AddArticelFunctions.AddCase`
  - Version: `1.0.0`
  - Datum: `2025-12-08`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `AddCase` Menü zum Hinzufügen von Gehäusen implementiert.
  - Beschreibungen:
    - Feature: Neue Funktion `AddCase` zum Erfassen und Anlegen von `Case`-Objekten (inkl. Validierung der Eingaben).
    - Refactor: Eingabeaufforderungen als `List<string>` statt `Markup`-Objekten implementiert.
    - Fix: Validierungslogik für numerische Felder und Abmessungen ergänzt.
  - Änderungen:
    - Implementierung des AddCase-Menüs und zugehöriger Validierungen.
  - Breaking Changes:
    - Keine
  - Migrationshinweise:
    - Keine, neue Funktion ergänzt das bestehende Menüsystem.
  - Tests:
    - `Keine`

---

- Klasse: `ElektroGrosshandel.Functions.AdminMenu`
  - Version: `1.0.0`
  - Datum: `2025-12-08`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Admin-Menü zur Verwaltung von Artikeln implementiert.
  - Beschreibungen:
    - Feature: `ShowAdminMenu` und `MenuSelection` implementiert (Auswahl: Add/Remove Artikel, Navigation zu AccountMenu).
    - Integration: GUI-Aufrufe zu `GUI_AdminMenuAddArtikel` und `GUI_AdminMenuDeleteArtikel` sind eingebunden.
  - Breaking Changes:
    - Keine
  - Migrationshinweise:
    - Keine
  - Tests:
    - `Keine`

---

- Klasse: `ElektroGrosshandel.GUI.GUI_Menus.GUI_PlaceOrder`
  - Version: `1.0.0`
  - Datum: `2025-12-07`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Erstveröffentlichung des Place-Order-Layouts mit Panels für Produktliste und Bestellübersicht.
  - Beschreibungen:
    - Feature: `PlaceOrder` Window hinzugefügt (Layout mit getrennten Panels für Produktliste und Bestellübersicht).
    - Feature: `Bucket` Integration zur Anzeige der Artikel im Warenkorb.
  - Änderungen:
    - Neue GUI-Layouts und Integration mit Backend-`Bucket`.
  - Breaking Changes:
    - Funktionsweise der Bestellübersicht und Produktanzeige neu definiert.
  - Migrationshinweise:
    - Siehe `Functions.PlaceOrder` für Details zur Nutzung des Place-Order-GUI.
  - Tests:
    - `Keine (werden später hinzugefügt)`

---

- Klasse: `ElektroGrosshandel.GUI.GUI_Menus.GUI_SCM_*`
  - Version: `1.0.0`
  - Datum: `2025-12-06`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: Erstveröffentlichung des `ShoppingCartManager` und der zugehörigen GUI-Komponenten.
  - Beschreibungen:
    - Feature: `Functions.ShoppingCartManager` regelt Menüführung und Logik für den Einkaufswagen-Manager.
    - Klassen: `GUI_SCM_CurrentShoppingCart`, `GUI_SCM_SavedShoppingCarts`, `GUI_SCM_SaveCart`, `GUI_SCM_DeleteOrder` implementiert.
  - Breaking Changes:
    - `ShoppingCartManager` als neue Funktionalität hinzugefügt.
  - Migrationshinweise:
    - Siehe `Functions.ShoppingCartManager` für Details zur Nutzung des ShoppingCartManager-GUI.
  - Tests:
    - `Keine (werden später hinzugefügt)`

---

- Klasse: `ElektroGrosshandel.User.Account`
  - Version: `2.0.0`
  - Datum: `2025-12-05`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `Bucket` Verwaltung zu `Account` verschoben; Bucket Verwaltung aus `User.Bucket` entfernt.
  - Beschreibungen:
    - Logik: `BucketList` wird nun zur Verwaltung in `
