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
        public BackupOptions Load()
        {
            if (!File.Exists(AppPaths.SettingsFilePath))
            {
                return new BackupOptions();
            }
         
            try
            {
                string json = File.ReadAllText(AppPaths.SettingsFilePath);
                BackupOptions? options = JsonSerializer.Deserialize<BackupOptions>(json);
                return options ?? new BackupOptions();
            }
            catch (Exception)
            {
                return new BackupOptions();
            }
               
        }

        public void Save(BackupOptions options)
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();

            serializerOptions.WriteIndented = true;

            string json = JsonSerializer.Serialize(options, serializerOptions);

            File.WriteAllText(AppPaths.SettingsFilePath, json);
        }

    }
}
