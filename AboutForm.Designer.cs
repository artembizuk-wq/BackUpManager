namespace _1СBackUpManager
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            labelProgramName = new Label();
            labelVersion = new Label();
            labelDescription = new Label();
            labelAuthor = new Label();
            buttonОК = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(labelProgramName, 0, 0);
            tableLayoutPanel1.Controls.Add(labelVersion, 0, 1);
            tableLayoutPanel1.Controls.Add(labelDescription, 0, 2);
            tableLayoutPanel1.Controls.Add(labelAuthor, 0, 3);
            tableLayoutPanel1.Controls.Add(buttonОК, 0, 4);
            tableLayoutPanel1.Location = new Point(2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(268, 157);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelProgramName
            // 
            labelProgramName.AutoSize = true;
            labelProgramName.Dock = DockStyle.Fill;
            labelProgramName.Location = new Point(3, 0);
            labelProgramName.Name = "labelProgramName";
            labelProgramName.Size = new Size(262, 31);
            labelProgramName.TabIndex = 0;
            labelProgramName.Text = "1C Backup Manager";
            labelProgramName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Dock = DockStyle.Fill;
            labelVersion.Location = new Point(3, 31);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(262, 31);
            labelVersion.TabIndex = 1;
            labelVersion.Text = "labelVersion";
            labelVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Dock = DockStyle.Fill;
            labelDescription.Location = new Point(3, 62);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(262, 31);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Резервне копіювання баз 1С";
            labelDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.Dock = DockStyle.Fill;
            labelAuthor.Location = new Point(3, 93);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(262, 31);
            labelAuthor.TabIndex = 3;
            labelAuthor.Text = "© Artem Bizuk";
            labelAuthor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonОК
            // 
            buttonОК.Dock = DockStyle.Fill;
            buttonОК.Location = new Point(3, 127);
            buttonОК.Name = "buttonОК";
            buttonОК.Size = new Size(262, 27);
            buttonОК.TabIndex = 4;
            buttonОК.Text = "ОК";
            buttonОК.UseVisualStyleBackColor = true;
            buttonОК.Click += buttonОК_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 159);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Про програму";
            Load += AboutForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelProgramName;
        private Label labelVersion;
        private Label labelDescription;
        private Label labelAuthor;
        private Button buttonОК;
    }
}