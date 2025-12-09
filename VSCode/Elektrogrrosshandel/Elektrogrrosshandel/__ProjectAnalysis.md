# Projektanalyse — Elektrogroßhandel (aktualisiert)

Datum: 2025-12-09
Repo: Plessu/Elektrogrosshandel
Analyse von: GitHub-Automation (auf Basis des Repositoriums und der bereitgestellten Projektdatei)

Kurzbeschreibung / Zweck
- Ziel: Verwaltung, Validierung und Bereitstellung technischer Produktdaten für Computer- und Elektro-Hardware in einem Großhandelskontext.
- Zielgruppe: Entwickler (Backend, Integrationen), Tester, technische Redakteure und DevOps.
- Plattform: .NET 10, C#, typische Entwicklung mit Visual Studio / VS Code.

Quellenbasis der Analyse
- Bestehende Projektanalyse-Datei im Repo (VSCode/Elektrogrrosshandel/Elektrogrrosshandel/__ProjectAnalysis.md).
- Repository-Metadaten: Sprachanalyse ergibt 100% C#.
- Annahmen: Die Dateien TO_ComputerHardware, src/, docs/ und die im alten Analyse-Dokument genannten Artefakte existieren wie beschrieben. Diese Analyse ergänzt und konkretisiert die vorhandene Zusammenfassung; für endgültige Verifizierung bitte Repo-Inhalte (Dateien/Ordner) durchsehen.

Repository-Struktur (Empfohlen / Erwartet)
- src/                — Quellcode (Domain, Application, Infrastructure, API/Presentation)
- docs/               — Projektdokumentation, API- und Architekturdiagramme
- tests/              — Unit- und Integration-Tests (xUnit / NUnit)
- VSCode/             — Editor-spezifische Einstellungen
- TO_ComputerHardware — Detaillierte Spezifikation (klassendiagramme, Validierungsregeln)
- .github/workflows/  — CI/CD-Workflows (GitHub Actions) — falls vorhanden
- Dockerfile / compose — Containerisierung und lokale Entwicklung

Code-Basis & Architektur
- Sprache: C# auf .NET 10 (LTS). Architekturprinzipien: Schichtenarchitektur (Domain, Application, Infrastructure, Presentation) und klare Trennung von Zuständigkeiten.
- Domain-orientiert: Entities (HardwareGroup, HardwareItem), Value-Objects (Specs), Repositories und Domain-Services.
- Persistenz: EF Core mit relationalen DBs (Postgres / MS SQL) vorgesehen; für Tests: In-Memory oder Sqlite-In-Memory empfohlen.
- Serilisierung: System.Text.Json (konfigurierbar)
- DI: Microsoft.Extensions.DependencyInjection
- Logging: Microsoft.Extensions.Logging

Detaillierte Analyse der Domäne
- Kernmodelle (bestätigte und empfohlene Eigenschaften):
  - HardwareGroup: Id (Guid), Name, Description, CategoryCode, SupportedInterfaces, Metadata
  - HardwareItem: Id, Sku, Manufacturer, Model, Specs (komplexes Objekt), CompatibilityTags (Tags statt Strings), Price (Money value object), Stock (Quantity value object)
  - Spec-Objekte: Typsichere Value Objects pro Hardware-Gruppe (CpuSpec, MemorySpec, PowerSupplySpec, StorageSpec, GpuSpec, MotherboardSpec, CaseSpec, CoolingSpec, PeripheralSpec)
- Empfehlungen:
  - Verwende Composition statt tiefer Vererbung für Specs; implementiere interfaces wie ICpuSpec, IMemorySpec, IStorageSpec.
  - Mache Specs serialisierbar als JSON-Value-Objects, aber ermögliche separate Tabellen, wenn umfangreiche Abfragen nötig sind.
  - Definiere Value Objects für Geld (Currency + Amount), Maßeinheiten (Watt, GB, mm), SKU-Format (validierbar) und Lagerstand.

Validierung & Geschäftslogik
- Domain-Validation: Entities und Value Objects validieren Invarianten synchron (Konstruktor/Factory) und geben Result-/Error-Objekte zurück (kein Exceptions-Flow für normale Validierung).
- Business-Regeln:
  - PowerSupplySpec.MaxOutput >= SystemRequiredWatts
  - MemorySpec.Frequency innerhalb unterstützter Spannungen und Mainboard-Kompatibilitäten
  - Kompatibilitätsprüfungen als eigenständige Domain-Service (IHardwareCompatibilityService) mit deterministischen Regeln
- Empfehlung: Nutze ein Result<T, Error> Pattern (z. B. OneOf/LanguageExt/eigene Impl.) für sichere Fehlerpropagation.

Persistenz & Mappings
- EF Core: Entities abbilden, Value Objects entweder als Owned Entities (EF Core Owned Types) oder als JSON-Columns (z. B. Postgres jsonb).
- Indexierung: Indexe auf SKU, CategoryCode, Manufacturer, Price und Full-Text-Index für Beschreibung/Specs zur Suche.
- Migrationen: Behalte Migrations im Repository (migrations/ Ordner) und nutze versionierte Migrationen für DB-Updates.

APIs / Schnittstellen
- Exponiere eine RESTful Web-API (oder minimal gRPC für interne Integrationen) mit folgenden Endpunkten:
  - GET /catalog?page=&size=&filters=
  - GET /catalog/{sku}
  - POST /catalog (Admin: create/update)
  - POST /compatibility/check (returns compatible items / incompatibilities)
- HATEOAS optional; API-Versionierung dringend empfohlen.
- Rate-limiting, Pagination und Feldprojektion (select) zur Performance-Optimierung.

Testing
- Unit Tests: xUnit empfohlen, Mocks via Moq oder NSubstitute.
- Integration Tests: Sqlite In-Memory oder Testcontainer (Docker) für Postgres.
- Contract Tests: Für Integrationen mit externen Systemen (z. B. PIMs, ERPs) empfohlen.
- CI: Build → Unit Tests → Integration Tests (DB-Tests optional in separate Job) → Publish.

CI/CD & DevOps
- GitHub Actions empfohlen (matrix builds für .NET 10, multiple OS if needed).
- Workflows: lint/format → build/test → publish packages → docker image build → deploy to staging.
- Secrets: GitHub Secrets / Azure Key Vault.
- Observability: Health endpoints, Prometheus metrics, OpenTelemetry tracing.

Security & Datenschutz
- Keine Secrets in Repo. AppSettings nutzen Environment-Overrides.
- Berechtigungen: RBAC für Admin-APIs; Auth via OAuth2/OpenID Connect (Azure AD / IdentityServer).
- Audit-Logging für Preis- und Bestandsänderungen.
- Validation & Sanitization: Input-Validierung, Max-Size-Limits für Dokumente/Uploads.

Performance & Skalierung
- Katalog-Queries skalieren: Paging, Feldprojektion, Caching (Redis) für häufige Abfragen.
- Heavy analytical queries: separate read-model oder OLAP-Pipeline.
- Bulk-Import/Update: Asynchrone Verarbeitung via Background Jobs (Hangfire / Azure Functions / Worker Service).

Operative Empfehlungen
- Backups & Migrationen: automatische DB-Backups, Test-Migrationen in CI.
- Monitoring: Prometheus + Grafana + Alerting.
- Feature Flags: für riskante Releases (LaunchDarkly / Unleash / simple DB-backed flags).

Code-Qualität & Konventionen
- .editorconfig, StyleCop oder Roslyn-Analyzers erzwingen Coding-Standards.
- Commit-Policy: Conventional Commits, PR-Templates, Review-Checklist.
- Tests-Coverage-Ziele: mind. 70% für Domain-Code, höhere Priorität auf kritische Pfade.

Dokumentation
- TO_ComputerHardware: zentrale Spezifikation — Review und Synchronisation mit Code.
- README: Setup, Build & Run, Test-Anweisungen, Architekturübersicht.
- API-Docs: OpenAPI / Swagger für die REST-API.

Technische Schulden / Risiken (kurz)
- Unklare Persistenzstrategie für Spec-Objekte (JSON vs relational) kann Refactor-Aufwand verursachen.
- Fehlende / nicht-automatisierte CI/CD kann Releases verzögern.
- Wenn Integrationstests fehlen, erhöht sich Risiko für Produktionsfehler.

Empfohlene unmittelbar umsetzbare nächste Schritte (Priorisiert)
1. GitHub Actions: Einrichten eines CI-Workflows (Build + Unit Tests + Report). 
2. Sicherstellen, dass TO_ComputerHardware aktuell ist und direkt in Tests/Mapping referenziert wird.
3. Implementiere ein Result-Pattern und Domain-Factories für die HardwareItem-Erzeugung.
4. Legen Sie EF-Core-Konfigurationen für Spec-Value-Objects fest (Owned vs Json).
5. Ergänze Integrationstests mit Sqlite-InMemory oder Testcontainers für die kritischen Repository-Operationen.
6. Hinzufügen von OpenAPI/Swagger-Dokumentation für die API.

Vorgeschlagene Roadmap (Kurz)
- Sprint 1: CI + Basis-Build, Linter, Editorconfig, Minimal-API mit Health Endpoint
- Sprint 2: Domain Harden, Value Objects, Unit-Tests (Domain)
- Sprint 3: Repo & Persistence (EF Core), Integration Tests
- Sprint 4: API Endpoints, Auth, OpenAPI, Paging/Filtering
- Sprint 5: Performance Tuning, Caching, Observability

Anhang: Gültigkeit & Annahmen
- Diese Analyse basiert auf der bisherigen Projektanalyse-Datei und Metadaten. Für eine 1:1-Validierung muss das vollständige Repository (src/, tests/, TO_ComputerHardware und .github/) geprüft werden. Falls du möchtest, kann ich die Repository-Inhalte jetzt auslesen und die Analyse weiter präzisieren — sag mir bitte, ob ich das tun soll.

Changelog
- Diese Datei aktualisiert und erweitert die ursprüngliche Projektanalyse (Ende-Datum 2025-12-09). Inhaltlich sind Empfehlungen ergänzt, konkrete technische Vorgaben ausgearbeitet und eine priorisierte To-Do-Liste ergänzt.
