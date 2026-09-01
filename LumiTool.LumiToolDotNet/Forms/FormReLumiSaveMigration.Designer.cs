namespace LumiTool
{
    partial class FormReLumiSaveMigration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReLumiSaveMigration));
            lbVersion = new Label();
            comboVersion = new ComboBox();
            grpSaveFile = new GroupBox();
            lbSaveFileName = new Label();
            btnSaveFileOpen = new Button();
            btnSaveFileSave = new Button();
            grpSaveFile.SuspendLayout();
            SuspendLayout();
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Location = new Point(12, 110);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(48, 15);
            lbVersion.TabIndex = 4;
            lbVersion.Text = "Version:";
            // 
            // comboVersion
            // 
            comboVersion.FormattingEnabled = true;
            comboVersion.Location = new Point(66, 107);
            comboVersion.Name = "comboVersion";
            comboVersion.Size = new Size(200, 23);
            comboVersion.TabIndex = 5;
            // 
            // grpSaveFile
            // 
            grpSaveFile.Controls.Add(lbSaveFileName);
            grpSaveFile.Controls.Add(btnSaveFileOpen);
            grpSaveFile.Controls.Add(btnSaveFileSave);
            grpSaveFile.Location = new Point(12, 12);
            grpSaveFile.Name = "grpSaveFile";
            grpSaveFile.Size = new Size(260, 86);
            grpSaveFile.TabIndex = 3;
            grpSaveFile.TabStop = false;
            grpSaveFile.Text = "Loaded Save File";
            // 
            // lbSaveFileName
            // 
            lbSaveFileName.AutoSize = true;
            lbSaveFileName.Location = new Point(6, 19);
            lbSaveFileName.Name = "lbSaveFileName";
            lbSaveFileName.Size = new Size(93, 15);
            lbSaveFileName.TabIndex = 0;
            lbSaveFileName.Text = "Save File Name: ";
            // 
            // btnSaveFileOpen
            // 
            btnSaveFileOpen.AllowDrop = true;
            btnSaveFileOpen.Image = LumiToolDotNet.Resources.Resources.folder;
            btnSaveFileOpen.Location = new Point(6, 40);
            btnSaveFileOpen.Name = "btnSaveFileOpen";
            btnSaveFileOpen.Size = new Size(121, 40);
            btnSaveFileOpen.TabIndex = 1;
            btnSaveFileOpen.Text = "Open";
            btnSaveFileOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveFileOpen.UseVisualStyleBackColor = true;
            btnSaveFileOpen.Click += btnSaveFileOpen_Click;
            btnSaveFileOpen.DragDrop += btnSaveFileOpen_DragDrop;
            btnSaveFileOpen.DragEnter += btnSaveFileOpen_DragEnter;
            // 
            // btnSaveFileSave
            // 
            btnSaveFileSave.Image = LumiToolDotNet.Resources.Resources.save;
            btnSaveFileSave.Location = new Point(133, 40);
            btnSaveFileSave.Name = "btnSaveFileSave";
            btnSaveFileSave.Size = new Size(121, 40);
            btnSaveFileSave.TabIndex = 2;
            btnSaveFileSave.Text = "Save";
            btnSaveFileSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveFileSave.UseVisualStyleBackColor = true;
            btnSaveFileSave.Click += btnSaveFileSave_Click;
            // 
            // FormReLumiSaveMigration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 142);
            Controls.Add(lbVersion);
            Controls.Add(comboVersion);
            Controls.Add(grpSaveFile);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(300, 181);
            MinimumSize = new Size(300, 181);
            Name = "FormReLumiSaveMigration";
            Text = "Re:Lumi Save Migration";
            FormClosed += FormReLumiSaveMigration_FormClosed;
            Shown += FormReLumiSaveMigration_Shown;
            grpSaveFile.ResumeLayout(false);
            grpSaveFile.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbVersion;
        private ComboBox comboVersion;
        private GroupBox grpSaveFile;
        private Label lbSaveFileName;
        private Button btnSaveFileOpen;
        private Button btnSaveFileSave;
    }
}