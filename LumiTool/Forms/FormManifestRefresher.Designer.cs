namespace LumiTool.Forms
{
    partial class FormManifestRefresher
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManifestRefresher));
            grpManifest = new GroupBox();
            lbManifestName = new Label();
            btnManifestOpen = new Button();
            btnManifestSave = new Button();
            btnRefresh = new Button();
            grpMod = new GroupBox();
            lbModPath = new Label();
            btnModOpen = new Button();
            grpVanilla = new GroupBox();
            lbVanillaPath = new Label();
            btnVanillaOpen = new Button();
            ttManifestRefresher = new ToolTip(components);
            btnLog = new Button();
            grpManifest.SuspendLayout();
            grpMod.SuspendLayout();
            grpVanilla.SuspendLayout();
            SuspendLayout();
            // 
            // grpManifest
            // 
            grpManifest.Controls.Add(lbManifestName);
            grpManifest.Controls.Add(btnManifestOpen);
            grpManifest.Controls.Add(btnManifestSave);
            grpManifest.Location = new Point(12, 12);
            grpManifest.Name = "grpManifest";
            grpManifest.Size = new Size(260, 86);
            grpManifest.TabIndex = 3;
            grpManifest.TabStop = false;
            grpManifest.Text = "Loaded Manifest";
            // 
            // lbManifestName
            // 
            lbManifestName.AutoSize = true;
            lbManifestName.Location = new Point(6, 19);
            lbManifestName.Name = "lbManifestName";
            lbManifestName.Size = new Size(94, 15);
            lbManifestName.TabIndex = 1;
            lbManifestName.Text = "Manifest Name: ";
            // 
            // btnManifestOpen
            // 
            btnManifestOpen.AllowDrop = true;
            btnManifestOpen.Image = Resources.Resources.folder;
            btnManifestOpen.Location = new Point(6, 40);
            btnManifestOpen.Name = "btnManifestOpen";
            btnManifestOpen.Size = new Size(121, 40);
            btnManifestOpen.TabIndex = 0;
            btnManifestOpen.Text = "Open";
            btnManifestOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManifestOpen.UseVisualStyleBackColor = true;
            btnManifestOpen.Click += btnManifestOpen_Click;
            btnManifestOpen.DragDrop += btnManifestOpen_DragDrop;
            btnManifestOpen.DragEnter += btnManifestOpen_DragEnter;
            // 
            // btnManifestSave
            // 
            btnManifestSave.Image = Resources.Resources.save;
            btnManifestSave.Location = new Point(133, 40);
            btnManifestSave.Name = "btnManifestSave";
            btnManifestSave.Size = new Size(121, 40);
            btnManifestSave.TabIndex = 2;
            btnManifestSave.Text = "Save";
            btnManifestSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManifestSave.UseVisualStyleBackColor = true;
            btnManifestSave.Click += btnManifestSave_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(12, 370);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(260, 48);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh Manifest";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // grpMod
            // 
            grpMod.Controls.Add(lbModPath);
            grpMod.Controls.Add(btnModOpen);
            grpMod.Location = new Point(12, 104);
            grpMod.Name = "grpMod";
            grpMod.Size = new Size(260, 100);
            grpMod.TabIndex = 4;
            grpMod.TabStop = false;
            grpMod.Text = "Loaded Mod RomFS";
            // 
            // lbModPath
            // 
            lbModPath.AutoEllipsis = true;
            lbModPath.Location = new Point(6, 19);
            lbModPath.Name = "lbModPath";
            lbModPath.Size = new Size(248, 32);
            lbModPath.TabIndex = 1;
            lbModPath.Text = "Path: ";
            // 
            // btnModOpen
            // 
            btnModOpen.Image = Resources.Resources.folder;
            btnModOpen.Location = new Point(6, 54);
            btnModOpen.Name = "btnModOpen";
            btnModOpen.Size = new Size(248, 40);
            btnModOpen.TabIndex = 0;
            btnModOpen.Text = "Open";
            btnModOpen.TextAlign = ContentAlignment.MiddleRight;
            btnModOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnModOpen.UseVisualStyleBackColor = true;
            btnModOpen.Click += btnModOpen_Click;
            // 
            // grpVanilla
            // 
            grpVanilla.Controls.Add(lbVanillaPath);
            grpVanilla.Controls.Add(btnVanillaOpen);
            grpVanilla.Location = new Point(12, 210);
            grpVanilla.Name = "grpVanilla";
            grpVanilla.Size = new Size(260, 100);
            grpVanilla.TabIndex = 5;
            grpVanilla.TabStop = false;
            grpVanilla.Text = "Loaded Vanilla RomFS";
            // 
            // lbVanillaPath
            // 
            lbVanillaPath.AutoEllipsis = true;
            lbVanillaPath.Location = new Point(6, 19);
            lbVanillaPath.Name = "lbVanillaPath";
            lbVanillaPath.Size = new Size(248, 32);
            lbVanillaPath.TabIndex = 1;
            lbVanillaPath.Text = "Path: ";
            // 
            // btnVanillaOpen
            // 
            btnVanillaOpen.Image = Resources.Resources.folder;
            btnVanillaOpen.Location = new Point(6, 54);
            btnVanillaOpen.Name = "btnVanillaOpen";
            btnVanillaOpen.Size = new Size(248, 40);
            btnVanillaOpen.TabIndex = 0;
            btnVanillaOpen.Text = "Open";
            btnVanillaOpen.TextAlign = ContentAlignment.MiddleRight;
            btnVanillaOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVanillaOpen.UseVisualStyleBackColor = true;
            btnVanillaOpen.Click += btnVanillaOpen_Click;
            // 
            // btnLog
            // 
            btnLog.Location = new Point(12, 316);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(260, 48);
            btnLog.TabIndex = 6;
            btnLog.Text = "Generate Log of Changes";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += btnLog_Click;
            // 
            // FormManifestRefresher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 430);
            Controls.Add(btnLog);
            Controls.Add(btnRefresh);
            Controls.Add(grpVanilla);
            Controls.Add(grpMod);
            Controls.Add(grpManifest);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(300, 469);
            MinimumSize = new Size(300, 469);
            Name = "FormManifestRefresher";
            Text = "Manifest Refresher";
            FormClosed += FormManifestRefresher_FormClosed;
            Shown += FormManifestRefresher_Shown;
            grpManifest.ResumeLayout(false);
            grpManifest.PerformLayout();
            grpMod.ResumeLayout(false);
            grpVanilla.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpManifest;
        private Label lbManifestName;
        private Button btnManifestOpen;
        private Button btnManifestSave;
        private Button btnRefresh;
        private GroupBox grpMod;
        private Label lbModPath;
        private Button btnModOpen;
        private GroupBox grpVanilla;
        private Label lbVanillaPath;
        private Button btnVanillaOpen;
        private ToolTip ttManifestRefresher;
        private Button btnLog;
    }
}