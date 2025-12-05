# Versionsverlauf für Userklassen

Dokument zur Nachverfolgung des Versionsverlauf für Userlassen.
Beinhaltet Einträge zu neuen Releases, Änderungen, Breaking Changes und Migrationshinweisen.

------------------------------
- Änderungsverlauf (Kurzfassung)
------------------------------

- 2025-12-05: `UserRegistration` v1.0.0 veröffentlicht.
- 2025-12-05: `Account` v1.2.0 veröffentlicht.
- 2025-12-05: `Bucket` v1.1.0 veröffentlicht.

Neue/Benutzer-Releases
----------------------
- Klasse: `ElektroGrosshandel.User.UserRegistration`
  - Version: `1.0.0`
  - Datum: `2025-12-05`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `Logik zum Erstellen Neuer Benuutzer`
  - Änderungen:
  - Breaking Changes:
    - `AddAccount` als statische Methode in `UserRegistration` implementiert.
  - Migrationshinweise:
    - `AddAccount` beachten
  - Tests: `ElektroGrosshandel.User.Account.TestData`, `ElektroGrosshandel.User.Account.SerializationTests`


- Klasse: `ElektroGrosshandel.User.Account`
  - Version: `1.2.0`
  - Datum: `2025-12-05`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `Thread-Safety, sichere ID-Erzeugung und Serialisierung erweitert.`
  - Änderungen:
    - Fix: Synchronisierung für statische Collections (`Accounts`, `UsedAccountIDs`) mittels `lock` hinzugefügt.
    - Feature: `RandomNumberGenerator.GetInt32` für ID-Erzeugung verwendet.
    - Feature: `SaveAccountToFile` / `LoadAccountFromFile` hinzugefügt (DTO-Basierte JSON-Serialisierung, Salt in Base64).
    - Refactor: `newAccount` in eine statische Fabrikmethode `CreateNewAccount` überführt.
  - Breaking Changes:
    - `newAccount` wurde zur statischen `CreateNewAccount` geändert — Aufrufer anpassen.
    - Property `AcountRole` empfohlen umzubenennen auf `AccountRole` (nicht automatisch umbenannt).
  - Migrationshinweise:
    - Ersetze Aufrufe von `newAccount(...)` durch `Account.CreateNewAccount(...)`.
    - Prüfe Persistenz: sensible Daten werden in Klartext-JSON geschrieben — optional schützen.
  - Tests: `ElektroGrosshandel.User.Account.TestData`, `ElektroGrosshandel.User.Account.SerializationTests`

- Klasse: `ElektroGrosshandel.User.Bucket`
  - Version: `1.1.0`
  - Datum: `2025-12-05`
  - Autor: `Giacomo Graef`
  - Zusammenfassung: `Fehlerbehebungen, Thread-Safety, sichere ID-Erzeugung und API-Verbesserungen für Bucket-Management.`
  - Änderungen:
    - Fix: Beim Hinzufügen neuer Artikel wurde die Menge nicht zur `Quantity`-Liste hinzugefügt.
    - Fix: `CreatedAt` auf `DateTime.UtcNow` umgestellt.
    - Fix: Null-/Argument-Checks für `bucketName` und Eingabeparameter ergänzt.
    - Feature: Statische Collections (`Buckets`, `UsedBucketIDs`) mit `lock` synchronisiert.
    - Feature: `RandomNumberGenerator.GetInt32` für Bucket-ID-Generierung verwendet.
    - Refactor: `UsedBucketIDs` von `List<int>` auf `HashSet<int>` umgestellt (Lookup O(1)).
    - Refactor: `AddArticelToBucket` in eine Instanzmethode `AddArticle` überführt und intern synchronisiert.
    - Refactor: Parallele Listen (`Articels`, `Quantity`, `ArticelIDs`) dokumentiert; Empfehlung: `Dictionary`/`BucketItem` als nächste Iteration.
    - Style: Tippfehler korrigiert — `Articels` → `Articles`, `ArticelIDs` → `ArticleIds`.
  - Breaking Changes:
    - API: Statische Methode `AddArticelToBucket(Bucket, ...)` wurde entfernt; nutze `bucket.AddArticle(...)`.
    - Naming: Feld-/Property-Namen wurden korrigiert (`Articels` → `Articles`, `ArticelIDs` → `ArticleIds`) — Serialisierungsnamen prüfen.
  - Migrationshinweise:
    - Ersetze Aufrufe von `AddArticelToBucket(bucket, id, qty)` durch `bucket.AddArticle(id, qty)`.
    - Passe Serialisierung/Deserialisierung an geänderte Feld-/Property-Namen an oder nutze DTOs mit `[JsonPropertyName]`.
    - Überprüfe Persistenz: sensible Bucket-Metadaten nicht unverschlüsselt persistieren (falls relevant).
  - Tests: `ElektroGrosshandel.User.Bucket.ThreadSafetyTests`, `ElektroGrosshandel.User.Bucket.IdGenerationTests`, `ElektroGrosshandel.User.Bucket.BehaviorTests`





Konventionen
------------------------
  - Datumsformat `YYYY-MM-DD`.
  - Versionsschema `Major.Minor.Patch`.
  - Alle Code- und Typnamen in Backticks (`).
  - Kürze und Präzision; jede Änderung maximal eine Zeile Beschreibung.
 

Umsetzungsschritte
------------------------
  1. Sammle aktuelle Klassenamen im Ordner `Elektrogrrosshandel\User` (z. B. `Account`, `UserManager`, `UserProfile`).
  2. Erstelle für jede Klasse einen Eintrag gemäß obiger Struktur.
  3. Ergänze ein kurzes Änderungsverzeichnis oben (letzte Releases zuerst).
  4. Validere Konsistenz: Versionssprünge sinnvoll (z. B. Breaking Change -> Major+1).
  5. Speichere Ergebnis in `Elektrogrrosshandel\User\__VI_User.md` mit Markdown-Formatierung.
- Ausgabe: Markdown-Datei mit Beispiel-Historie für `User`-Klassen, fiktiven, plausiblen Versionen und Tests.

Hinweise / Empfehlungen
------------------------
- Benutze konsistente Namenskonventionen: `AccountRole` statt `AcountRole`.
- Sensible Daten (Passwort-Hash/Salt) nicht unverschlüsselt in Produktionsumgebungen speichern.
- Bei Breaking Changes Major-Version erhöhen.
- Ergänze in Zukunft Einträge für `Bucket`-Serialisierung, falls `ActiveBucket` / `SafedBuckets` persistiert werden sollen.
- Wenn du möchtest, generiere ich die initiale `__VI_User.md` als Release-Template mit Platzhaltern für künftige Einträge.