using _1СBackUpManager.Enums;
using _1СBackUpManager.Models;
using _1СBackUpManager.Services;

namespace _1СBackUpManager
{
    public partial class MainForm : Form
    {

        private bool _loadingSettings;
        private readonly SettingsService _settingsService = new SettingsService();
        private readonly BackupService _backupService = new BackupService();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _loadingSettings = true;

                BackupOptions options = _settingsService.Load();

                txtBackupFolder.Text = options.BackupFolder;
                rbDT.Checked = options.BackupType == BackupType.DT;
                rbCD.Checked = options.BackupType == BackupType.CD;
                cbZip.Checked = options.CompressToZip;
            }
            catch (Exception ex)
            {
                Log($"Не вдалося завантажити налаштування: {ex.Message}",LogType.Error);
            }
            finally { _loadingSettings = false; }

            RefreshBaseList();
        }

        // ====================================================
        // Допоміжні методи
        // ====================================================
        private void Log(string message,LogType type = LogType.Info)
        {
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
        }

        private void SaveSettings()
        {
            if (_loadingSettings)
                return;

            BackupOptions options = new BackupOptions();

            options.BackupFolder = txtBackupFolder.Text;
            options.BackupType = rbDT.Checked ? BackupType.DT : BackupType.CD;
            options.CompressToZip = cbZip.Checked;

            _settingsService.Save(options);
        }

        private BackupOptions GetBackupOptions()
        {
            BackupOptions options = new BackupOptions();
            options.BackupFolder = txtBackupFolder.Text;
            options.BackupType = rbDT.Checked ? BackupType.DT : BackupType.CD;
            options.CompressToZip = cbZip.Checked;

            return options;
        }

        // ====================================================
        // Події контролів
        // ====================================================
        private void RefreshBaseList()
        {
            checkedListBox1.Items.Clear();

            BaseFinder basesFinder = new BaseFinder();
            List<BaseInfo> bases = basesFinder.FindBases();
            foreach (var item in bases)
            {
                checkedListBox1.Items.Add(item);
            }
            rtbLog.AppendText($"Знайдено {bases.Count} баз.{Environment.NewLine}");
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                Log("Не вибрано жодної бази.");
                return;
            }

            Log("Початок резервного копіювання...");
            BackupOptions options = GetBackupOptions();

            progressBarBackup.Minimum = 0;
            progressBarBackup.Maximum = checkedListBox1.CheckedItems.Count;
            progressBarBackup.Value = 0;

            foreach (BaseInfo baseInfo in checkedListBox1.CheckedItems)
            {
                Log($"Починаю резервне копіювання {baseInfo.Name}...");

                try
                {
                    string backupFilePath = _backupService.Backup(baseInfo, options);
                    Log($"✔ {baseInfo.Name} успішно.", LogType.Success);
                    Log($"Файл: {backupFilePath}", LogType.Success);
                }
                catch (Exception ex)
                {
                    Log($"✖ {baseInfo.Name}: {ex.Message}",LogType.Error);
                }
                progressBarBackup.Value++;
            }
            Log("Завершення резервного копіювання");

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}