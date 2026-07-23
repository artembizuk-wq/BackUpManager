using _1СBackUpManager.Enums;
using _1СBackUpManager.Models;
using _1СBackUpManager.Services;
using System.Diagnostics;
using static System.Windows.Forms.Design.AxImporter;



namespace _1СBackUpManager
{
    public partial class MainForm : Form
    {

        private bool _loadingSettings;
        private readonly SettingsService _settingsService = new SettingsService();
        private readonly BackupService _backupService = new BackupService();
        private CancellationTokenSource? _cts;
        private BackupOptions _options = new();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
            try
            {
                _loadingSettings = true;
                btnCancel.Enabled = false;
                _options = _settingsService.Load();

                if (string.IsNullOrWhiteSpace(_options.OneCExePath)||!File.Exists(_options.OneCExePath))
                {
                    _options.OneCExePath = new OneCFinder().FindDesigner();
                    _settingsService.Save(_options);
                }
                txtBackupFolder.Text = _options.BackupFolder;
                rbDT.Checked = _options.BackupType == BackupType.DT;
                rbCD.Checked = _options.BackupType == BackupType.CD;
                cbZip.Checked = _options.CompressToZip;
              
            }
            catch (Exception ex)
            {
                Log($"Не вдалося завантажити налаштування: {ex.Message}", LogType.Error);
            }
            finally { _loadingSettings = false; }

            RefreshBaseList();   
        }

        // ====================================================
        // Допоміжні методи
        // ====================================================
        private void Log(string message, LogType type = LogType.Info)
        {
                Color color = type switch
                {
                    LogType.Success => Color.ForestGreen,
                    LogType.Error => Color.Firebrick,
                    _ => Color.Black
                };

                rtbLog.SelectionStart = rtbLog.TextLength;
                rtbLog.SelectionLength = 0;

                rtbLog.SelectionColor = color;

                rtbLog.AppendText($"{DateTime.Now:HH:mm:ss} {message}{Environment.NewLine}");

                rtbLog.SelectionColor = rtbLog.ForeColor;

                rtbLog.ScrollToCaret();       
        }

        private void SaveSettings()
        {
            if (_loadingSettings)
                return;

            
            _options.BackupFolder = txtBackupFolder.Text;
            _options.BackupType = rbDT.Checked ? BackupType.DT : BackupType.CD;
            _options.CompressToZip = cbZip.Checked;

            _settingsService.Save(_options);
        }

      
        // ====================================================
        // Події контролів
        // ====================================================
        private void RefreshBaseList()
        {
            clbBases.Items.Clear();

            BaseFinder basesFinder = new BaseFinder();
            List<BaseInfo> bases = basesFinder.FindBases();
            foreach (var item in bases)
            {
                clbBases.Items.Add(item);
            }
        }

        private async void btnBackup_Click(object sender, EventArgs e)
        {
            if (clbBases.CheckedItems.Count == 0)
            {
                Log("Не вибрано жодної бази.");
                return;
            }

            btnBackup.Enabled = false;
            btnRefresh.Enabled = false;
            btnCancel.Enabled = true;
            clbBases.Enabled = false;
            bool canceled = false;
            _cts = new CancellationTokenSource();

            try
            {

                Log("Початок резервного копіювання...");
                SaveSettings();


                if (_options.BackupType == BackupType.DT)
                {
                    progressBarBackup.Style = ProgressBarStyle.Marquee;
                    lblstatus.Text = "Створення резервної копії...";
                    labelpersent.Text = "";
                }
                else
                {
                    progressBarBackup.Style = ProgressBarStyle.Blocks;
                    progressBarBackup.Minimum = 0;
                    progressBarBackup.Maximum = 100;
                    progressBarBackup.Value = 0;
                }


                Progress<BackupProgress> progress =
                   new(p =>
                    {
                        progressBarBackup.Value = p.Percent;
                        lblstatus.Text = p.Message;
                        labelpersent.Text = $"{p.Percent}%";
                    });

                foreach (BaseInfo baseInfo in clbBases.CheckedItems)
                {
                    Log($"Починаю резервне копіювання {baseInfo.Name}...");
                    if (_options.BackupType == BackupType.CD)
                    {
                        progressBarBackup.Value = 0;
                    }

                    try
                    {
                        string backupFilePath = await _backupService.BackupAsync(baseInfo, _options, progress, _cts.Token);
                        Log($"✔ {baseInfo.Name} успішно.", LogType.Success);
                        Log($"Файл: {backupFilePath}", LogType.Success);
                    }
                    catch (OperationCanceledException)
                    {
                        Log($"⏹ Резервне копіювання {baseInfo.Name} скасовано.", LogType.Error);
                        canceled = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Log($"✖ {baseInfo.Name}: {ex.Message}", LogType.Error);
                    }

                }
                if (!canceled)
                {
                    progressBarBackup.Value = 100;
                    Log("Завершення резервного копіювання");
                }
            }


            finally
            {
                btnBackup.Enabled = true;
                btnRefresh.Enabled = true;
                btnCancel.Enabled = false;
                clbBases.Enabled = true;
                progressBarBackup.Style = ProgressBarStyle.Blocks;
                progressBarBackup.MarqueeAnimationSpeed = 0;
                progressBarBackup.Value = 0;
                lblstatus.Text = "";
                labelpersent.Text = "";

                _cts.Dispose();
                _cts = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBaseList();
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBackupFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
  
        }

    }
}