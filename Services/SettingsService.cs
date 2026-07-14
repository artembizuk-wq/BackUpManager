using System;
using System.Collections.Generic;
using System.Text;
using _1СBackUpManager.Models;
using System.IO;
using System.Text.Json;

namespace _1СBackUpManager.Services
{
    internal class SettingsService
    {
        private const string SettingsFile = "settings.json";

        public BackupOptions Load()
        {
            if (!File.Exists(SettingsFile))
            {
                return new BackupOptions();
            }
         
            try
            {
                string json = File.ReadAllText(SettingsFile);
                BackupOptions options = JsonSerializer.Deserialize<BackupOptions>(json);
                return options ?? new BackupOptions();
            }
            catch
            {
                return new BackupOptions();
            }
               
        }

        public void Save(BackupOptions options)
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();

            serializerOptions.WriteIndented = true;

            string json = JsonSerializer.Serialize(options, serializerOptions);

            File.WriteAllText(SettingsFile, json);
        }

    }
}
