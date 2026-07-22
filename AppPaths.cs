using System;
using System.Collections.Generic;
using System.Text;

namespace _1СBackUpManager
{
    internal static class AppPaths
    {

       public static string AppDataFolder
        {
            get
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string appFolder = Path.Combine(appDataPath, "1CBackUpManager");
                Directory.CreateDirectory(appFolder);
                return appFolder;
            }
        }

       public static string SettingsFilePath
        {
            get
            {
                return Path.Combine(AppDataFolder, "settings.json");
            }
        }

        public static string CredentialsFilePath
        {
            get
            {
                return Path.Combine(AppDataFolder, "credentials.dat");
            }
        }
    }
}
