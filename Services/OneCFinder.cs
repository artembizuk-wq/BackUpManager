using System;
using System.Collections.Generic;
using System.Text;

namespace _1СBackUpManager.Services
{
    internal class OneCFinder
    {
        public string FindDesigner()
        {
            string? designerPath = FindInProgramFiles();

            if (designerPath != null)
            {
                return designerPath;

            }
            throw new FileNotFoundException("Не вдалося знайти версію платформи");
        }

        private string? FindInProgramFiles()
        {
            string[] roots =
              [
              Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
              Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
              ];

            foreach (string root in roots)
            {
                string? path = FindInRoot(root);

                if (path != null)
                    return path;
            }

            return null;
        }

        private string? FindInRoot(string root)
        {
            string[] folders =
              [
               Path.Combine(root, "1cv8"),
               Path.Combine(root, "1C")
               ];

            foreach (string folder in folders)
            {
                if (!Directory.Exists(folder))
                    continue;

                string? versionFolder = FindLatestVersion(folder);
               

                if (versionFolder == null)
                    continue;

                string? exePath = FindDesignerExe(versionFolder);

                if (exePath != null)
                    return exePath;
            }

            return null;
        }

        private string? FindLatestVersion(string folder)
        {
            string? latestPath = null;
            Version? latestVersion = null;

            foreach (string path in Directory.GetDirectories(folder))
            {
                string folderName = Path.GetFileName(path);

                if (!Version.TryParse(folderName, out Version? version))
                    continue;

                if (latestVersion == null || version > latestVersion)
                {
                    latestVersion = version;
                    latestPath = path;
                }
            }

            return latestPath;
        }

        private string? FindDesignerExe(string versionFolder)
        {
            string exePath = Path.Combine(versionFolder, "bin", "1cv8.exe");

            if (File.Exists(exePath))
                return exePath;

            return null;
        }
    }
}
