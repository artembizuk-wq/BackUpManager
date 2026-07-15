using _1СBackUpManager.Enums;
using _1СBackUpManager.Models;
using System.Diagnostics;
using System.IO.Compression;


namespace _1СBackUpManager.Services
{
    internal class BackupService
    {

        private const string DatabaseFileName = "1Cv8.1CD";
        private const string OneCExecutable =@"C:\Program Files\1cv8\8.3.18.1334\bin\1cv8.exe";

        public async Task<string> BackupAsync(BaseInfo baseInfo, BackupOptions options)
        {
            ValidateBackupFolder(options);
            ValidateDatabase(baseInfo);
            ValidateDatabaseNotInUse(baseInfo);
            string backupFilePath = await CreateBackupAsync(baseInfo, options);

            if (options.CompressToZip)
            {
                backupFilePath = CompressToZip(backupFilePath);
            }
            return backupFilePath;
        }

        private async Task<string> CreateBackupAsync(BaseInfo baseInfo, BackupOptions options)
        {
            switch (options.BackupType)
            {
                case BackupType.CD:
                    return await BackupCdAsync(baseInfo, options);

                case BackupType.DT:
                    return await BackupDtAsync(baseInfo, options);

                default:
                    throw new ArgumentOutOfRangeException(nameof(options.BackupType));
            }
        }

        private async Task<string> BackupDtAsync(BaseInfo baseInfo, BackupOptions options)
        {
            string backupFileName = CreateBackupFileName(baseInfo, options.BackupType);
            string backupFilePath = Path.Combine(options.BackupFolder, backupFileName);
            string arguments = BuildDesignerArguments(baseInfo,backupFilePath);

            ProcessStartInfo startInfo = new()
            {
                FileName = OneCExecutable,
                Arguments = arguments
            };

            using Process? process = Process.Start(startInfo);

            if (process == null)
            {
                throw new InvalidOperationException("Не вдалося запустити 1С Designer.");
            }

            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException( $"Designer завершився з кодом {process.ExitCode}.");
            }

            if (!File.Exists(backupFilePath))
            {
                throw new FileNotFoundException(
                    "Файл резервної копії не був створений.",
                    backupFilePath);
            }
            return backupFilePath;
        }
        private string BuildDesignerArguments( BaseInfo baseInfo,string dtFilePath)
        {
            return string.Join(" ",
            [
                "DESIGNER",
                $"/F \"{baseInfo.Path}\"",
                $"/N Бизюк",
                $"/P Marina23",
                $"/DumpIB \"{dtFilePath}\"",
                "/DisableStartupMessages"
            ]
                );
           
        }

        private async Task<string> BackupCdAsync(BaseInfo baseInfo, BackupOptions options)
        {
            return await Task.Run(() =>
            {
                string databaseFile = GetDatabaseFile(baseInfo);
                string backupFileName = CreateBackupFileName(baseInfo, options.BackupType);
                string backupFilePath = Path.Combine(options.BackupFolder, backupFileName);

                File.Copy(databaseFile, backupFilePath, false);
                return backupFilePath;
            });        
        }

        private string GetDatabaseFile(BaseInfo baseInfo)
        {
            return Path.Combine(baseInfo.Path, DatabaseFileName);
        }

        private void ValidateBackupFolder(BackupOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.BackupFolder))
            {
                throw new ArgumentException("Не вказано папку для резервних копій.");
            }
            Directory.CreateDirectory(options.BackupFolder);
        }

        private void ValidateDatabase(BaseInfo baseInfo)
        {
            if (string.IsNullOrWhiteSpace(baseInfo.Path))
            {
                throw new ArgumentException("Не вказано шлях до бази.");
            }
            string databaseFile = GetDatabaseFile(baseInfo);
           
            if (!File.Exists(databaseFile))
            {
                throw new FileNotFoundException("Не знайдено файл бази.",databaseFile);
            }
        }

        private void ValidateDatabaseNotInUse(BaseInfo baseInfo)
        {
            string databaseFile = GetDatabaseFile(baseInfo);
          
            try
            {
                using FileStream stream = File.Open(databaseFile, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                throw new InvalidOperationException($"База даних {baseInfo.Name} зараз використовується. Закрийте 1С та повторіть спробу.");
            }
        }
    
        private string CreateBackupFileName(BaseInfo baseInfo,BackupType backupType)
        {
            string extension = GetBackupExtension(backupType);
            DateTime backupDate = DateTime.Now;
            return $"{baseInfo.Name}_{backupDate:yyyyMMdd_HHmmss}{extension}";
        }

        private string GetBackupExtension(BackupType backupType)
        {
            switch (backupType)
            {
                case BackupType.CD:
                    return ".1CD";
                case BackupType.DT:
                    return ".dt";
                default:
                    throw new ArgumentOutOfRangeException(nameof(backupType));
            }
        }

        private string CompressToZip(string backupFilePath)
        {
            string zipFilePath = Path.ChangeExtension(backupFilePath, ".zip");

            using ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create);
            archive.CreateEntryFromFile(backupFilePath, Path.GetFileName(backupFilePath),CompressionLevel.Optimal);

            File.Delete(backupFilePath);
            
            return zipFilePath;

        }
    }
}
