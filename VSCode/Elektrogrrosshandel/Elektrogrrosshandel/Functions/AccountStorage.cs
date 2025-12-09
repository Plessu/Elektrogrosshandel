using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Spectre.Console;

namespace Elektrogrosshandel.Functions
{
    internal static class AccountStorage
    {
        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new DefaultContractResolver
                {
                    DefaultMembersSearchFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
                },
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter> { new MarkupJsonConverter() }
            };
        }

        public static void SaveAllAccounts(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Pfad ist ungültig.", nameof(filePath));

            var accounts = Elektrogrosshandel.Account.GetAllAccounts() ?? new List<Elektrogrosshandel.Account>();
            var settings = GetSerializerSettings();

            string json = JsonConvert.SerializeObject(accounts, settings);

            var dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(filePath, json);
        }

        public static List<Elektrogrosshandel.Account> LoadAllAccounts(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Pfad ist ungültig.", nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException("Die Datei wurde nicht gefunden.", filePath);

            var settings = GetSerializerSettings();

            string json = File.ReadAllText(filePath);
            var deserialized = JsonConvert.DeserializeObject<List<Elektrogrosshandel.Account>>(json, settings)
                               ?? new List<Elektrogrosshandel.Account>();

            // Setze das private static Feld 'Accounts' in Account via Reflection
            Type accountType = typeof(Elektrogrosshandel.Account);
            FieldInfo accountsField = accountType.GetField("Accounts", BindingFlags.Static | BindingFlags.NonPublic);
            if (accountsField != null)
            {
                // setze neues List<Account> (oder überschreibe vorhandene)
                accountsField.SetValue(null, deserialized);
            }
            else
            {
                // Falls Feld nicht gefunden, versuche vorhandene öffentliche API zu nutzen (füge einzeln hinzu)
                var addMethod = accountType.GetMethod("AddAccountToList", BindingFlags.Instance | BindingFlags.NonPublic);
                if (addMethod != null)
                {
                    // Leere vorhandene Liste falls vorhanden
                    FieldInfo usedIdsField = accountType.GetField("UsedAccountIDs", BindingFlags.Static | BindingFlags.NonPublic);
                    if (usedIdsField != null)
                    {
                        usedIdsField.SetValue(null, new List<int>());
                    }

                    foreach (var acc in deserialized)
                    {
                        // rufe private Instanzmethode AddAccountToList auf
                        addMethod.Invoke(acc, new object[] { acc });
                    }
                }
            }

            // Aktualisiere UsedAccountIDs (privates static Feld)
            FieldInfo usedAccountIDsField = accountType.GetField("UsedAccountIDs", BindingFlags.Static | BindingFlags.NonPublic);
            if (usedAccountIDsField != null)
            {
                var idList = new List<int>();
                PropertyInfo idProp = accountType.GetProperty("AccountID", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (idProp != null)
                {
                    foreach (var acc in deserialized)
                    {
                        var val = idProp.GetValue(acc);
                        if (val is int i)
                        {
                            if (!idList.Contains(i)) idList.Add(i);
                        }
                    }
                }
                usedAccountIDsField.SetValue(null, idList);
            }

            return deserialized;
        }
    }

    public class MarkupJsonConverter : JsonConverter<Markup?>
    {
        public override void WriteJson(JsonWriter writer, Markup? value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString());
        }

        public override Markup? ReadJson(JsonReader reader, Type objectType, Markup? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var s = reader.Value as string;
            return s == null ? null : new Markup(s);
        }
    }
}

