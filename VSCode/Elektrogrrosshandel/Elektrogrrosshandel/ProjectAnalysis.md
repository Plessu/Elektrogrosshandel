# Projektanalyse — Elektrogroßhandel

Kurzbeschreibung
- Ziel: Verwaltung und Bereitstellung technischer Informationen zu Computer- und Elektro-Hardware für einen Großhandel.
- Zielgruppe: Entwickler, Integratoren, Tester und technische Redakteure.
- Plattform: `.NET 10`, Visual Studio (IDE mit integriertem Editor, Test-Runner, Output-Pane und Terminal).

Wesentliche Projektartefakte
- Quellcode: `src/` (Domain, Application, Infrastructure, API/GUI)
- Dokumentation: `docs/`
- Spezifikations- und Designdateien: `TO_ComputerHardware` (siehe Verweis unten)
- Readme: `Elektrogrrosshandel\ReadMe.md`

Technische Spezifikationen (Übersicht)
- Ziel-Framework: `.NET 10` (LTS-Target)
- Sprache: C#
- Architektur: Schichtenarchitektur (Domain / Application / Infrastructure / Presentation)
- Persistenz: primär `Entity Framework Core` mit relationaler DB (Postgres/MS SQL) — optional JSON-Dateibasierte Fixtures für Tests
- Serialisierung: `System.Text.Json` (konfigurierbar)
- Dependency Injection: `Microsoft.Extensions.DependencyInjection`
- Logging: `Microsoft.Extensions.Logging`
- Unit Tests: `xUnit` (oder `NUnit`) mit Mocks via `Moq` oder `NSubstitute`
- CI/CD: GitHub Actions oder Azure Pipelines (Build, Tests, Publish)
- Konfiguration: `appsettings.json` mit Umgebungsüberschreibung (`appsettings.Development.json`)

Domain-Modell (Kernkonzepte)
- `HardwareGroup` (z. B. CPU, Mainboard, Speicher, Netzteil, Peripherie)
  - Eigenschaften: `Id`, `Name`, `Description`, `CategoryCode`, `SupportedInterfaces`
  - Beziehungen: 1..* `HardwareItem`
- `HardwareItem`
  - Eigenschaften: `Id`, `Sku`, `Manufacturer`, `Model`, `Specs` (strukturierte Typ-Eigenschaften), `CompatibilityTags`, `Price`, `Stock`
- `Spec`-Objekte
  - Typisierte Unterobjekte für gruppenspezifische Daten (z. B. `CpuSpec`, `MemorySpec`, `PowerSupplySpec`)
  - Validierung: Business-Rule-Validierung in Domain-Entities / Value Objects
- Repositories / Services
  - `IHardwareRepository` (CRUD, Query by Category, Filter by Compatibility)
  - `IHardwareCatalogService` (Business-Logik: Kompatibilitätsprüfungen, Empfehlungsalgorithmen)
  - `IHardwareFactory` (Kapselt Erzeugung von gruppenspezifischen `HardwareItem` mit passenden `Spec`-Objekten)

Designentscheidungen & Logikhinweise
- Trennung von polymorpher Spezifikation:
  - Verwenden von Vererbung oder Composition für `Spec`-Typen; bevorzugt: composition mit Interfaces (`ICpuSpec`, `IMemorySpec`) und konkreten Value Objects für einfache Testbarkeit.
- Validierung:
  - Domain-Objekte validieren ihre invarianten Regeln (z. B. `PowerSupplySpec.MaxOutput` ≥ `SystemRequiredWatts`).
  - Application Layer orchestriert komplexe Validierungen über mehrere Entities.
- Serialisierung und Persistenz:
  - Spezielle `Spec`-Objekte als eigene Entities oder als JSON-Value-Objects in der DB abbilden (je nach Abfragebedarf).
- Erweiterbarkeit:
  - Neue Hardware-Gruppen sollten durch Implementierung neuer `Spec`-Typen und Registrierung im `IHardwareFactory` hinzufügbar sein.
- Performance:
  - Für Katalog-Abfragen Paging, selektive Spaltenprojektion und optional Full-Text-Indexing einplanen.
- Fehlerbehandlung:
  - Fehler als gut definierte Fehler-Typen / Result-Objekte zurückgeben (kein Ausnahmefluss für gewöhnliche Validierungsfehler).

Tests
- Unit Tests:
  - Domain: Validierung, Business-Logik, Value Objects
  - Application: Service-Orchestrierung, Schnittstellen
- Integration Tests:
  - Repository mit In-Memory-DB (`Sqlite` in Memory) oder Test-Container für echte DB
- Automatische Tests in CI: Build → Unit Tests → Integration Tests (optional)

Dev-Workflow & Konventionen
- Branching: `main` (stabil), `develop` (Integration), feature-Branches `feature/<name>`
- Code Style: Projekt verwendet `.editorconfig` und `CONTRIBUTING.md` (verbindlich)
- Code Reviews: Pflicht vor Merge in `main`
- Commit-Messages: konventionell (z. B. Conventional Commits)

Sicherheits- und Datenschutzhinweise
- Sensible Daten in `appsettings.*` nicht in Repo
- Secrets über Secret-Store (Azure Key Vault / GitHub Secrets)
- Audit-Logging für Bestands- und Preisänderungen

Deployment
- Produktruntime als Web-API oder Microservice, Containerbereitstellung via Docker
- Health-Endpoints, Metrics (Prometheus) und Tracing (OpenTelemetry) empfehlen

Datei mit tiefergehender Spezifikation
- Die detaillierten technischen Spezifikationen und die konkrete Logik der Hardware-Klassen sind in der Datei `TO_ComputerHardware` dokumentiert. Diese Datei enthält:
  - Klassendiagramme und Property-Listen für jede Hardware-Gruppe
  - Validierungsregeln und Business-Logik-Pseudocode
  - Mapping- und Persistenzstrategien für jede Gruppe
  - Beispiele für JSON-Serialisate und Test-Fixes

Versionsverlauf (Changelog) — Endet mit Version `0.4`
- Version `0.1` — Projektinitialisierung
  - Repository-Struktur erstellt (`src/`, `docs/`)
  - Grundlegende `README`- und Konfigurationsdateien angelegt
  - Baselines für `.editorconfig` und `CONTRIBUTING.md` definiert
- Version `0.2` — Domain-Modell & Persistenz-Setup
  - Erste Domain-Entities (`HardwareGroup`, `HardwareItem`) implementiert
  - `IHardwareRepository`-Schnittstelle und EF Core Kontext vorbereitet
  - Basis-Unit-Tests für Domain-Validierung hinzugefügt
- Version `0.3` — Erweiterung Spezifikations-Typen & Services
  - Implementierung von typisierten `Spec`-Objekten für Kerngruppen (z. B. CPU, Memory)
  - `IHardwareCatalogService` mit Kompatibilitätsprüfungen implementiert
  - Integration-Tests für Repository mit In-Memory-DB hinzugefügt
- Version `0.4` — Fertige Implementierung aller Hardware-Gruppen (Release)
  - Vollständige Implementierung aller vorgesehenen Hardware-Gruppen (z. B. CPU, Mainboard, RAM, GPU, Storage, Netzteil, Gehäuse, Kühlung, Peripherie)
  - Alle `Spec`-Typen, Mapping-Profile und Validierungsregeln abgeschlossen
  - `IHardwareFactory` und Registrierungen für alle Gruppen vorhanden
  - End-to-End Tests (Catalog → Repository → API) grün
  - Dokumentation in `TO_ComputerHardware` vervollständigt (technische Spezifikationen & Logik)
  - Release-Tag: `v0.4` im Repository

Empfohlene nächste Schritte
- Review der Datei `TO_ComputerHardware` lesen und prüfen, ob alle Gruppen-Requirements vollständig abgedeckt sind.
- CI/CD Pipeline anlegen (Build → Tests → Publish).
- Review und Ergänzung von `CONTRIBUTING.md` für Team-Standards.
- Security-Audit und Performance-Profiling vor Produktivsetzung.

Referenz
- Detaillierte technische Beschreibungen und konkrete Implementierungslogiken befinden sich in: `TO_ComputerHardware`
- Projekt-Readme: `Elektrogrrosshandel\ReadMe.md`