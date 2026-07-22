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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnRefresh = new Button();
            clbBases = new CheckedListBox();
            btnBackup = new Button();
            label1 = new Label();
            txtBackupFolder = new TextBox();
            btnBrowseFolder = new Button();
            groupBox1 = new GroupBox();
            cbZip = new CheckBox();
            rbCD = new RadioButton();
            rbDT = new RadioButton();
            groupBox2 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCancel = new Button();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            rtbLog = new RichTextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            progressBarBackup = new ProgressBar();
            lblstatus = new Label();
            labelpersent = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(245, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(25, 25);
            btnRefresh.TabIndex = 0;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += button1_Click;
            // 
            // clbBases
            // 
            clbBases.Anchor = AnchorStyles.None;
            clbBases.CheckOnClick = true;
            clbBases.FormattingEnabled = true;
            clbBases.Location = new Point(3, 51);
            clbBases.Name = "clbBases";
            clbBases.Size = new Size(333, 166);
            clbBases.TabIndex = 1;
            clbBases.SelectedIndexChanged += clbBases_SelectedIndexChanged;
            // 
            // btnBackup
            // 
            btnBackup.AutoSize = true;
            btnBackup.Font = new Font("Segoe UI", 8F);
            btnBackup.Image = (Image)resources.GetObject("btnBackup.Image");
            btnBackup.ImageAlign = ContentAlignment.MiddleLeft;
            btnBackup.Location = new Point(3, 3);
            btnBackup.Name = "btnBackup";
            btnBackup.Padding = new Padding(4, 0, 4, 0);
            btnBackup.Size = new Size(133, 25);
            btnBackup.TabIndex = 2;
            btnBackup.Text = "Створити backup";
            btnBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // label1
            // 
            label1.Location = new Point(14, 22);
            label1.Name = "label1";
            label1.Size = new Size(53, 22);
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
            btnBrowseFolder.Image = (Image)resources.GetObject("btnBrowseFolder.Image");
            btnBrowseFolder.Location = new Point(296, 21);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(22, 22);
            btnBrowseFolder.TabIndex = 6;
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
            groupBox2.Controls.Add(flowLayoutPanel1);
            groupBox2.Controls.Add(panel1);
            groupBox2.Controls.Add(clbBases);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(336, 218);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Бази даних";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnBackup);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnRefresh);
            flowLayoutPanel1.Location = new Point(3, 13);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(330, 31);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(142, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(4, 0, 4, 0);
            btnCancel.Size = new Size(97, 25);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Скасувати";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += buttonCancel_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(330, 22);
            panel1.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(txtBackupFolder);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(groupBox1);
            groupBox3.Controls.Add(btnBrowseFolder);
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
            tableLayoutPanel1.Controls.Add(rtbLog, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 224F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayoutPanel1.Size = new Size(684, 461);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.White;
            rtbLog.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(rtbLog, 2);
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 10F);
            rtbLog.HideSelection = false;
            rtbLog.Location = new Point(3, 252);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(678, 206);
            rtbLog.TabIndex = 11;
            rtbLog.Text = "";
            rtbLog.WordWrap = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(progressBarBackup, 1, 0);
            tableLayoutPanel2.Controls.Add(lblstatus, 0, 0);
            tableLayoutPanel2.Controls.Add(labelpersent, 2, 0);
            tableLayoutPanel2.Location = new Point(3, 227);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(678, 19);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // progressBarBackup
            // 
            progressBarBackup.Dock = DockStyle.Fill;
            progressBarBackup.Location = new Point(172, 3);
            progressBarBackup.Name = "progressBarBackup";
            progressBarBackup.Size = new Size(480, 13);
            progressBarBackup.Style = ProgressBarStyle.Continuous;
            progressBarBackup.TabIndex = 12;
            // 
            // lblstatus
            // 
            lblstatus.Dock = DockStyle.Fill;
            lblstatus.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblstatus.Location = new Point(3, 0);
            lblstatus.Name = "lblstatus";
            lblstatus.Size = new Size(163, 19);
            lblstatus.TabIndex = 8;
            lblstatus.TextAlign = ContentAlignment.MiddleLeft;
            lblstatus.Click += label2_Click;
            // 
            // labelpersent
            // 
            labelpersent.AutoSize = true;
            labelpersent.Dock = DockStyle.Fill;
            labelpersent.Location = new Point(658, 0);
            labelpersent.Name = "labelpersent";
            labelpersent.Size = new Size(17, 19);
            labelpersent.TabIndex = 13;
            labelpersent.Text = "%";
            labelpersent.TextAlign = ContentAlignment.MiddleLeft;
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
            groupBox2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefresh;
        private CheckedListBox clbBases;
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
        private RichTextBox rtbLog;
        private ProgressBar progressBarBackup;
        private Label lblstatus;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelpersent;
        private Panel panel1;
        private Button btnCancel;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
