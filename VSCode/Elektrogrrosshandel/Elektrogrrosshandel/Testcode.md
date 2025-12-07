/*
         Pseudocode / Plan (detailliert, deutsch):
         - Ziel: Account in eine JSON-Datei speichern und wieder laden, um Speicherung zu simulieren.
         - Erzeuge eine private DTO-Struktur 'SerializableAccount' mit allen serialisierbaren Feldern.
         - Bei Serialisierung:
           - Passwort-Salt (byte[]) in Base64-String umwandeln, weil JSON Binärdaten nicht direkt speichert.
           - DTO mit Werten aus dem Account füllen.
           - JsonSerializer mit WriteIndented=true verwenden und JSON in die angegebene Datei schreiben.
         - Beim Laden:
           - Datei einlesen und zu DTO deserialisieren.
           - Base64-Salt zurück in byte[] umwandeln.
           - Neue Account-Instanz erstellen und die private CreateAccount-Methode mit den geladenen Werten aufrufen.
           - CreatedAt, SafedBuckets und statische Listen (Accounts, UsedAccountIDs) passend aktualisieren.
           - Rückgabe der geladenen Account-Instanz.
         - Fehlerbehandlung:
           - Datei-Prüfung (existiert?), Deserialisierung auf null prüfen, Exceptions für IO weiterreichen.
         - Implementiere zwei statische Methoden:
           - SaveAccountToFile(Account account, string filePath)
           - LoadAccountFromFile(string filePath) : Account
        */

        // DTO für JSON-Serialisierung
        private class SerializableAccount
        {
            public int AccountID { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FirmName { get; set; }
            public string Password { get; set; }
            public string PasswordSaltBase64 { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime CreatedAt { get; set; }
            public string AcountRole { get; set; }
            public int SerialCode { get; set; }
            public bool IsFirmAccount { get; set; }
            public bool WantUSTax { get; set; }
        }

        // Speichert einen Account in eine JSON-Datei.
        public static void SaveAccountToFile(Account account, string filePath)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Pfad ist ungültig.", nameof(filePath));

            var dto = new SerializableAccount
            {
                AccountID = account.AccountID,
                UserName = account.UserName,
                FirstName = account.FirstName,
                LastName = account.LastName,
                FirmName = account.FirmName,
                Password = account.Password,
                PasswordSaltBase64 = account.PasswordSalt != null ? Convert.ToBase64String(account.PasswordSalt) : null,
                Email = account.Email,
                PhoneNumber = account.PhoneNumber,
                CreatedAt = account.CreatedAt,
                AcountRole = account.AcountRole,
                SerialCode = account.SerialCode,
                IsFirmAccount = account.IsFirmAccount,
                WantUSTax = account.WantUSTax
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(dto, options);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        // Lädt einen Account aus einer JSON-Datei und fügt ihn zur internen Liste hinzu.
        public static Account LoadAccountFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Pfad ist ungültig.", nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException("Die Datei wurde nicht gefunden.", filePath);

            string json = File.ReadAllText(filePath, Encoding.UTF8);
            var dto = JsonSerializer.Deserialize<SerializableAccount>(json);
            if (dto == null) throw new InvalidOperationException("Deserialisierung des Accounts fehlgeschlagen.");

            byte[] salt = null;
            if (!string.IsNullOrEmpty(dto.PasswordSaltBase64))
            {
                salt = Convert.FromBase64String(dto.PasswordSaltBase64);
            }
            else
            {
                salt = new byte[64];
            }

            Account account = new Account();
            account.CreateAccount(dto.AccountID, dto.UserName, dto.FirstName, dto.LastName, dto.FirmName,
                                  dto.Password, salt, dto.Email, dto.PhoneNumber, dto.AcountRole, dto.SerialCode,
                                  dto.IsFirmAccount, dto.WantUSTax);

            // CreatedAt vom DTO übernehmen
            account.CreatedAt = dto.CreatedAt;

            // Sicherstellen, dass SafedBuckets initialisiert sind (CreateAccount tut das bereits, aber zur Sicherheit)
            account.SafedBuckets = account.SafedBuckets ?? new List<Bucket>(10);

            // Interne Listen aktualisieren
            if (!UsedAccountIDs.Contains(account.AccountID))
            {
                UsedAccountIDs.Add(account.AccountID);
            }
            if (!Accounts.Contains(account))
            {
                Accounts.Add(account);
            }

            return account;
        }
    }