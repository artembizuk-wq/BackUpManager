namespace _1СBackUpManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRefresh = new Button();
            checkedListBox1 = new CheckedListBox();
            btnBackup = new Button();
            label1 = new Label();
            txtBackupFolder = new TextBox();
            btnBrowseFolder = new Button();
            groupBox1 = new GroupBox();
            cbZip = new CheckBox();
            rbCD = new RadioButton();
            rbDT = new RadioButton();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            rtbLog = new RichTextBox();
            progressBarBackup = new ProgressBar();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(105, 23);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Оновити список";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += button1_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Dock = DockStyle.Fill;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(3, 19);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(330, 196);
            checkedListBox1.TabIndex = 1;
            // 
            // btnBackup
            // 
            btnBackup.Location = new Point(114, 3);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(219, 23);
            btnBackup.TabIndex = 2;
            btnBackup.Text = "Створити резервні копії";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // label1
            // 
            label1.Location = new Point(14, 22);
            label1.Name = "label1";
            label1.Size = new Size(52, 23);
            label1.TabIndex = 4;
            label1.Text = "Каталог ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBackupFolder
            // 
            txtBackupFolder.Location = new Point(72, 22);
            txtBackupFolder.Name = "txtBackupFolder";
            txtBackupFolder.Size = new Size(218, 23);
            txtBackupFolder.TabIndex = 5;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Location = new Point(296, 21);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(27, 23);
            btnBrowseFolder.TabIndex = 6;
            btnBrowseFolder.Text = "...";
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbZip);
            groupBox1.Controls.Add(rbCD);
            groupBox1.Controls.Add(rbDT);
            groupBox1.Location = new Point(14, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(309, 67);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Тип резервної копії";
            // 
            // cbZip
            // 
            cbZip.AutoSize = true;
            cbZip.Location = new Point(161, 15);
            cbZip.Name = "cbZip";
            cbZip.Size = new Size(115, 19);
            cbZip.TabIndex = 2;
            cbZip.Text = "Архівувати в ZIP";
            cbZip.UseVisualStyleBackColor = true;
            // 
            // rbCD
            // 
            rbCD.AutoSize = true;
            rbCD.Location = new Point(12, 40);
            rbCD.Name = "rbCD";
            rbCD.Size = new Size(76, 19);
            rbCD.TabIndex = 1;
            rbCD.Text = ".CD файл";
            rbCD.UseVisualStyleBackColor = true;
            // 
            // rbDT
            // 
            rbDT.AutoSize = true;
            rbDT.Checked = true;
            rbDT.Location = new Point(12, 15);
            rbDT.Name = "rbDT";
            rbDT.Size = new Size(73, 19);
            rbDT.TabIndex = 0;
            rbDT.TabStop = true;
            rbDT.Text = ".DT файл";
            rbDT.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkedListBox1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(336, 218);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Бази даних";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtBackupFolder);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(groupBox1);
            groupBox3.Controls.Add(btnBrowseFolder);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(345, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(336, 218);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Параметри резервного копіювання";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(rtbLog, 0, 3);
            tableLayoutPanel1.Controls.Add(progressBarBackup, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 224F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(684, 461);
            tableLayoutPanel1.TabIndex = 10;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel1
            // 
            tableLayoutPanel1.SetColumnSpan(panel1, 2);
            panel1.Controls.Add(btnBackup);
            panel1.Controls.Add(btnRefresh);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 227);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 34);
            panel1.TabIndex = 10;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.White;
            rtbLog.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(rtbLog, 2);
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 10F);
            rtbLog.HideSelection = false;
            rtbLog.Location = new Point(3, 282);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(678, 176);
            rtbLog.TabIndex = 11;
            rtbLog.Text = "";
            rtbLog.WordWrap = false;
            // 
            // progressBarBackup
            // 
            tableLayoutPanel1.SetColumnSpan(progressBarBackup, 2);
            progressBarBackup.Dock = DockStyle.Fill;
            progressBarBackup.Location = new Point(3, 267);
            progressBarBackup.Name = "progressBarBackup";
            progressBarBackup.Size = new Size(678, 9);
            progressBarBackup.Style = ProgressBarStyle.Continuous;
            progressBarBackup.TabIndex = 12;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(684, 461);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(700, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "1С Backup Manager";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefresh;
        private CheckedListBox checkedListBox1;
        private Button btnBackup;
        private Label label1;
        private TextBox txtBackupFolder;
        private Button btnBrowseFolder;
        private GroupBox groupBox1;
        private RadioButton rbCD;
        private RadioButton rbDT;
        private CheckBox cbZip;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private RichTextBox rtbLog;
        private ProgressBar progressBarBackup;
    }
}
