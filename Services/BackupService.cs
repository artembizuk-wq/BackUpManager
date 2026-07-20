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

        public async Task<string> BackupAsync(BaseInfo baseInfo, BackupOptions options,IProgress<BackupProgress>?progress = null,CancellationToken cancellationToken = default)
        {
            ValidateBackupFolder(options);
            ValidateDatabase(baseInfo);
            ValidateDatabaseNotInUse(baseInfo);
            string backupFilePath = await CreateBackupAsync(baseInfo, options, progress, cancellationToken);

            if (options.CompressToZip)
            {
                backupFilePath = CompressToZip(backupFilePath);
            }
            return backupFilePath;
        }

        private async Task<string> CreateBackupAsync(BaseInfo baseInfo, BackupOptions options, IProgress<BackupProgress>? progress = null, CancellationToken cancellationToken = default)
        {
            switch (options.BackupType)
            {
                case BackupType.CD:
                    return await BackupCdAsync(baseInfo, options, progress, cancellationToken);

                case BackupType.DT:
                    return await BackupDtAsync(baseInfo, options, progress, cancellationToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(options.BackupType));
            }
        }

        private async Task<string> BackupDtAsync(BaseInfo baseInfo, BackupOptions options, IProgress<BackupProgress>? progress = null, CancellationToken cancellationToken = default)
        {
            string backupFileName = CreateBackupFileName(baseInfo, options.BackupType);
            string backupFilePath = Path.Combine(options.BackupFolder, backupFileName);
            string arguments = BuildDesignerArguments(baseInfo,backupFilePath);

            ProcessStartInfo startInfo = new()
                {
                    FileName = OneCExecutable,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                using Process? process = Process.Start(startInfo);

                try
                {
                    if (process == null)
                {
                    throw new InvalidOperationException("Не вдалося запустити 1С Designer.");
                }

                await process.WaitForExitAsync(cancellationToken);

                if (process.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Designer завершився з кодом {process.ExitCode}.");
                }

                if (!File.Exists(backupFilePath))
                {
                    throw new FileNotFoundException(
                        "Файл резервної копії не був створений.",
                        backupFilePath);
                }
                return backupFilePath;
            }
            catch (OperationCanceledException)
            {

                if(process != null && !process.HasExited)
                {
                    process.Kill();
                    await process.WaitForExitAsync();
                }

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(backupFilePath);

                foreach (string file in Directory.GetFiles(options.BackupFolder, $"{fileNameWithoutExtension}.*"))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {
                        // Можна залогувати або просто проігнорувати
                    }
                }


                throw;
            }
        }
        private string BuildDesignerArguments( BaseInfo baseInfo,string dtFilePath)
        {
            CredentialService credentialService = new();
            Credentials credentials = credentialService.Load();

            return string.Join(" ",
            [
                "DESIGNER",
                $"/F \"{baseInfo.Path}\"",
                $"/N {credentials.UserName}",
                $"/P {credentials.Password}",
                $"/DumpIB \"{dtFilePath}\"",
                "/DisableStartupMessages"
            ]
                );
           
        }

        private async Task<string> BackupCdAsync(BaseInfo baseInfo, BackupOptions options, IProgress<BackupProgress>? progress = null, CancellationToken cancellationToken = default)
        {
           
                string databaseFile = GetDatabaseFile(baseInfo);
                string backupFileName = CreateBackupFileName(baseInfo, options.BackupType);
                string backupFilePath = Path.Combine(options.BackupFolder, backupFileName);

                try
                {
                    await using FileStream source = new(
                   databaseFile,
                   FileMode.Open,
                   FileAccess.Read,
                   FileShare.Read,
                   bufferSize: 81920,
                   useAsync: true);

                await using FileStream destination = new(
                    backupFilePath,
                    FileMode.CreateNew,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 81920,
                    useAsync: true);

                //await source.CopyToAsync(destination);

                byte[] buffer = new byte[4 * 1024 * 1024];
                long totalBytes = source.Length;
                long copiedBytes = 0;
                int bytesRead;

                int lastPercent = -1;

                while ((bytesRead = await source.ReadAsync(buffer, cancellationToken)) > 0)
                {
                    await destination.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken);

                    copiedBytes += bytesRead;

                    int percent = (int)(copiedBytes * 100 / totalBytes);

                    if (percent != lastPercent)
                    {
                        lastPercent = percent;

                        progress?.Report(new BackupProgress
                        {
                            Percent = percent,
                            Message = $"Копіювання {baseInfo.Name}"
                        });
                    }
                }

                progress?.Report(new BackupProgress
                {
                    Percent = 100,
                    Message = "Копіювання завершено"
                });

                return backupFilePath;
            }
            catch (OperationCanceledException)
            {
                if (File.Exists(backupFilePath))
                {
                    File.Delete(backupFilePath);
                }

                throw;
            }
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
