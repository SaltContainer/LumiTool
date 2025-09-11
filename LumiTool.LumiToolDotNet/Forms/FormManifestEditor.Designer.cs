using LumiTool.LumiToolDotNet.Resources;

namespace LumiTool.Forms
{
    partial class FormManifestEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManifestEditor));
            grpManifest = new GroupBox();
            lbManifestName = new Label();
            btnManifestOpen = new Button();
            btnManifestSave = new Button();
            ttManifestEditor = new ToolTip(components);
            listRecords = new ListBox();
            lbProjectName = new Label();
            grpEditRecord = new GroupBox();
            btnSaveRecord = new Button();
            lbSize = new Label();
            numSize = new NumericUpDown();
            grpAssetPaths = new GroupBox();
            btnRenameAssetPath = new Button();
            btnRemoveAssetPath = new Button();
            btnAddAssetPath = new Button();
            lbAssetPath = new Label();
            txtAssetPath = new TextBox();
            listAssetPaths = new ListBox();
            grpDependency = new GroupBox();
            btnRenameDependency = new Button();
            btnRemoveDependency = new Button();
            btnAddDependency = new Button();
            lbDependencyName = new Label();
            txtDependencyName = new TextBox();
            listDependencies = new ListBox();
            lbBundleName = new Label();
            txtBundleName = new TextBox();
            checkStreamingScene = new CheckBox();
            txtProjectName = new TextBox();
            btnAddRecord = new Button();
            btnRemoveRecord = new Button();
            grpManifest.SuspendLayout();
            grpEditRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSize).BeginInit();
            grpAssetPaths.SuspendLayout();
            grpDependency.SuspendLayout();
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
            grpManifest.TabIndex = 0;
            grpManifest.TabStop = false;
            grpManifest.Text = "Loaded Manifest";
            // 
            // lbManifestName
            // 
            lbManifestName.AutoSize = true;
            lbManifestName.Location = new Point(6, 19);
            lbManifestName.Name = "lbManifestName";
            lbManifestName.Size = new Size(94, 15);
            lbManifestName.TabIndex = 0;
            lbManifestName.Text = "Manifest Name: ";
            // 
            // btnManifestOpen
            // 
            btnManifestOpen.AllowDrop = true;
            btnManifestOpen.Image = Resources.folder;
            btnManifestOpen.Location = new Point(6, 40);
            btnManifestOpen.Name = "btnManifestOpen";
            btnManifestOpen.Size = new Size(121, 40);
            btnManifestOpen.TabIndex = 1;
            btnManifestOpen.Text = "Open";
            btnManifestOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManifestOpen.UseVisualStyleBackColor = true;
            btnManifestOpen.Click += btnManifestOpen_Click;
            btnManifestOpen.DragDrop += btnManifestOpen_DragDrop;
            btnManifestOpen.DragEnter += btnManifestOpen_DragEnter;
            // 
            // btnManifestSave
            // 
            btnManifestSave.Image = Resources.save;
            btnManifestSave.Location = new Point(133, 40);
            btnManifestSave.Name = "btnManifestSave";
            btnManifestSave.Size = new Size(121, 40);
            btnManifestSave.TabIndex = 2;
            btnManifestSave.Text = "Save";
            btnManifestSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManifestSave.UseVisualStyleBackColor = true;
            btnManifestSave.Click += btnManifestSave_Click;
            // 
            // listRecords
            // 
            listRecords.FormattingEnabled = true;
            listRecords.ItemHeight = 15;
            listRecords.Location = new Point(12, 104);
            listRecords.Name = "listRecords";
            listRecords.Size = new Size(260, 364);
            listRecords.TabIndex = 1;
            listRecords.SelectedIndexChanged += listRecords_SelectedIndexChanged;
            // 
            // lbProjectName
            // 
            lbProjectName.AutoSize = true;
            lbProjectName.Location = new Point(6, 25);
            lbProjectName.Name = "lbProjectName";
            lbProjectName.Size = new Size(82, 15);
            lbProjectName.TabIndex = 0;
            lbProjectName.Text = "Project Name:";
            // 
            // grpEditRecord
            // 
            grpEditRecord.Controls.Add(btnSaveRecord);
            grpEditRecord.Controls.Add(lbSize);
            grpEditRecord.Controls.Add(numSize);
            grpEditRecord.Controls.Add(grpAssetPaths);
            grpEditRecord.Controls.Add(grpDependency);
            grpEditRecord.Controls.Add(lbBundleName);
            grpEditRecord.Controls.Add(txtBundleName);
            grpEditRecord.Controls.Add(checkStreamingScene);
            grpEditRecord.Controls.Add(txtProjectName);
            grpEditRecord.Controls.Add(lbProjectName);
            grpEditRecord.Location = new Point(278, 12);
            grpEditRecord.Name = "grpEditRecord";
            grpEditRecord.Size = new Size(494, 487);
            grpEditRecord.TabIndex = 4;
            grpEditRecord.TabStop = false;
            grpEditRecord.Text = "Record Editor";
            // 
            // btnSaveRecord
            // 
            btnSaveRecord.Location = new Point(343, 123);
            btnSaveRecord.Name = "btnSaveRecord";
            btnSaveRecord.Size = new Size(145, 25);
            btnSaveRecord.TabIndex = 7;
            btnSaveRecord.Text = "Save Edits to Record";
            btnSaveRecord.UseVisualStyleBackColor = true;
            btnSaveRecord.Click += btnSaveRecord_Click;
            // 
            // lbSize
            // 
            lbSize.AutoSize = true;
            lbSize.Location = new Point(14, 125);
            lbSize.Name = "lbSize";
            lbSize.Size = new Size(74, 15);
            lbSize.TabIndex = 5;
            lbSize.Text = "Size in bytes:";
            // 
            // numSize
            // 
            numSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numSize.Location = new Point(94, 123);
            numSize.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numSize.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numSize.Name = "numSize";
            numSize.Size = new Size(228, 23);
            numSize.TabIndex = 6;
            // 
            // grpAssetPaths
            // 
            grpAssetPaths.Controls.Add(btnRenameAssetPath);
            grpAssetPaths.Controls.Add(btnRemoveAssetPath);
            grpAssetPaths.Controls.Add(btnAddAssetPath);
            grpAssetPaths.Controls.Add(lbAssetPath);
            grpAssetPaths.Controls.Add(txtAssetPath);
            grpAssetPaths.Controls.Add(listAssetPaths);
            grpAssetPaths.Location = new Point(6, 319);
            grpAssetPaths.Name = "grpAssetPaths";
            grpAssetPaths.Size = new Size(482, 159);
            grpAssetPaths.TabIndex = 9;
            grpAssetPaths.TabStop = false;
            grpAssetPaths.Text = "Asset Paths";
            // 
            // btnRenameAssetPath
            // 
            btnRenameAssetPath.Location = new Point(395, 125);
            btnRenameAssetPath.Name = "btnRenameAssetPath";
            btnRenameAssetPath.Size = new Size(81, 23);
            btnRenameAssetPath.TabIndex = 5;
            btnRenameAssetPath.Text = "Rename";
            btnRenameAssetPath.UseVisualStyleBackColor = true;
            btnRenameAssetPath.Click += btnRenameAssetPath_Click;
            // 
            // btnRemoveAssetPath
            // 
            btnRemoveAssetPath.Image = Resources.minus_big;
            btnRemoveAssetPath.Location = new Point(432, 72);
            btnRemoveAssetPath.Name = "btnRemoveAssetPath";
            btnRemoveAssetPath.Size = new Size(44, 44);
            btnRemoveAssetPath.TabIndex = 2;
            btnRemoveAssetPath.UseVisualStyleBackColor = true;
            btnRemoveAssetPath.Click += btnRemoveAssetPath_Click;
            // 
            // btnAddAssetPath
            // 
            btnAddAssetPath.Image = Resources.plus_big;
            btnAddAssetPath.Location = new Point(432, 22);
            btnAddAssetPath.Name = "btnAddAssetPath";
            btnAddAssetPath.Size = new Size(44, 44);
            btnAddAssetPath.TabIndex = 1;
            btnAddAssetPath.UseVisualStyleBackColor = true;
            btnAddAssetPath.Click += btnAddAssetPath_Click;
            // 
            // lbAssetPath
            // 
            lbAssetPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbAssetPath.AutoSize = true;
            lbAssetPath.Location = new Point(23, 129);
            lbAssetPath.Name = "lbAssetPath";
            lbAssetPath.Size = new Size(65, 15);
            lbAssetPath.TabIndex = 3;
            lbAssetPath.Text = "Asset Path:";
            // 
            // txtAssetPath
            // 
            txtAssetPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAssetPath.Location = new Point(94, 125);
            txtAssetPath.Name = "txtAssetPath";
            txtAssetPath.Size = new Size(295, 23);
            txtAssetPath.TabIndex = 4;
            // 
            // listAssetPaths
            // 
            listAssetPaths.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listAssetPaths.FormattingEnabled = true;
            listAssetPaths.ItemHeight = 15;
            listAssetPaths.Location = new Point(6, 22);
            listAssetPaths.Name = "listAssetPaths";
            listAssetPaths.Size = new Size(420, 94);
            listAssetPaths.TabIndex = 0;
            listAssetPaths.SelectedIndexChanged += listAssetPaths_SelectedIndexChanged;
            // 
            // grpDependency
            // 
            grpDependency.Controls.Add(btnRenameDependency);
            grpDependency.Controls.Add(btnRemoveDependency);
            grpDependency.Controls.Add(btnAddDependency);
            grpDependency.Controls.Add(lbDependencyName);
            grpDependency.Controls.Add(txtDependencyName);
            grpDependency.Controls.Add(listDependencies);
            grpDependency.Location = new Point(6, 154);
            grpDependency.Name = "grpDependency";
            grpDependency.Size = new Size(482, 159);
            grpDependency.TabIndex = 8;
            grpDependency.TabStop = false;
            grpDependency.Text = "Dependencies";
            // 
            // btnRenameDependency
            // 
            btnRenameDependency.Location = new Point(395, 125);
            btnRenameDependency.Name = "btnRenameDependency";
            btnRenameDependency.Size = new Size(81, 23);
            btnRenameDependency.TabIndex = 5;
            btnRenameDependency.Text = "Rename";
            btnRenameDependency.UseVisualStyleBackColor = true;
            btnRenameDependency.Click += btnRenameDependency_Click;
            // 
            // btnRemoveDependency
            // 
            btnRemoveDependency.Image = Resources.minus_big;
            btnRemoveDependency.Location = new Point(432, 72);
            btnRemoveDependency.Name = "btnRemoveDependency";
            btnRemoveDependency.Size = new Size(44, 44);
            btnRemoveDependency.TabIndex = 2;
            btnRemoveDependency.UseVisualStyleBackColor = true;
            btnRemoveDependency.Click += btnRemoveDependency_Click;
            // 
            // btnAddDependency
            // 
            btnAddDependency.Image = Resources.plus_big;
            btnAddDependency.Location = new Point(432, 22);
            btnAddDependency.Name = "btnAddDependency";
            btnAddDependency.Size = new Size(44, 44);
            btnAddDependency.TabIndex = 1;
            btnAddDependency.UseVisualStyleBackColor = true;
            btnAddDependency.Click += btnAddDependency_Click;
            // 
            // lbDependencyName
            // 
            lbDependencyName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbDependencyName.AutoSize = true;
            lbDependencyName.Location = new Point(8, 129);
            lbDependencyName.Name = "lbDependencyName";
            lbDependencyName.Size = new Size(82, 15);
            lbDependencyName.TabIndex = 3;
            lbDependencyName.Text = "Bundle Name:";
            // 
            // txtDependencyName
            // 
            txtDependencyName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDependencyName.Location = new Point(96, 125);
            txtDependencyName.Name = "txtDependencyName";
            txtDependencyName.Size = new Size(295, 23);
            txtDependencyName.TabIndex = 4;
            // 
            // listDependencies
            // 
            listDependencies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listDependencies.FormattingEnabled = true;
            listDependencies.ItemHeight = 15;
            listDependencies.Location = new Point(6, 22);
            listDependencies.Name = "listDependencies";
            listDependencies.Size = new Size(420, 94);
            listDependencies.TabIndex = 0;
            listDependencies.SelectedIndexChanged += listDependencies_SelectedIndexChanged;
            // 
            // lbBundleName
            // 
            lbBundleName.AutoSize = true;
            lbBundleName.Location = new Point(6, 60);
            lbBundleName.Name = "lbBundleName";
            lbBundleName.Size = new Size(82, 15);
            lbBundleName.TabIndex = 2;
            lbBundleName.Text = "Bundle Name:";
            // 
            // txtBundleName
            // 
            txtBundleName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBundleName.Location = new Point(94, 57);
            txtBundleName.Name = "txtBundleName";
            txtBundleName.Size = new Size(394, 23);
            txtBundleName.TabIndex = 3;
            // 
            // checkStreamingScene
            // 
            checkStreamingScene.AutoSize = true;
            checkStreamingScene.CheckAlign = ContentAlignment.MiddleRight;
            checkStreamingScene.Location = new Point(94, 92);
            checkStreamingScene.Name = "checkStreamingScene";
            checkStreamingScene.Size = new Size(117, 19);
            checkStreamingScene.TabIndex = 4;
            checkStreamingScene.Text = "Streaming Scene:";
            checkStreamingScene.TextAlign = ContentAlignment.MiddleRight;
            checkStreamingScene.UseVisualStyleBackColor = true;
            // 
            // txtProjectName
            // 
            txtProjectName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProjectName.Location = new Point(94, 22);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(394, 23);
            txtProjectName.TabIndex = 1;
            // 
            // btnAddRecord
            // 
            btnAddRecord.Location = new Point(12, 474);
            btnAddRecord.Name = "btnAddRecord";
            btnAddRecord.Size = new Size(127, 25);
            btnAddRecord.TabIndex = 2;
            btnAddRecord.Text = "Add Record";
            btnAddRecord.UseVisualStyleBackColor = true;
            btnAddRecord.Click += btnAddRecord_Click;
            // 
            // btnRemoveRecord
            // 
            btnRemoveRecord.Location = new Point(145, 474);
            btnRemoveRecord.Name = "btnRemoveRecord";
            btnRemoveRecord.Size = new Size(127, 25);
            btnRemoveRecord.TabIndex = 3;
            btnRemoveRecord.Text = "Remove Record";
            btnRemoveRecord.UseVisualStyleBackColor = true;
            btnRemoveRecord.Click += btnRemoveRecord_Click;
            // 
            // FormManifestEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 511);
            Controls.Add(btnRemoveRecord);
            Controls.Add(btnAddRecord);
            Controls.Add(grpEditRecord);
            Controls.Add(listRecords);
            Controls.Add(grpManifest);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(800, 550);
            MinimumSize = new Size(800, 550);
            Name = "FormManifestEditor";
            Text = "Manifest Editor";
            FormClosed += FormManifestEditor_FormClosed;
            Shown += FormManifestEditor_Shown;
            grpManifest.ResumeLayout(false);
            grpManifest.PerformLayout();
            grpEditRecord.ResumeLayout(false);
            grpEditRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSize).EndInit();
            grpAssetPaths.ResumeLayout(false);
            grpAssetPaths.PerformLayout();
            grpDependency.ResumeLayout(false);
            grpDependency.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpManifest;
        private Label lbManifestName;
        private Button btnManifestOpen;
        private Button btnManifestSave;
        private ToolTip ttManifestEditor;
        private ListBox listRecords;
        private Label lbProjectName;
        private GroupBox grpEditRecord;
        private TextBox txtProjectName;
        private GroupBox grpDependency;
        private ListBox listDependencies;
        private Label lbBundleName;
        private TextBox txtBundleName;
        private CheckBox checkStreamingScene;
        private Label lbDependencyName;
        private TextBox txtDependencyName;
        private GroupBox grpAssetPaths;
        private Label lbAssetPath;
        private TextBox txtAssetPath;
        private ListBox listAssetPaths;
        private Label lbSize;
        private NumericUpDown numSize;
        private Button btnAddRecord;
        private Button btnRemoveRecord;
        private Button btnRemoveDependency;
        private Button btnAddDependency;
        private Button btnRemoveAssetPath;
        private Button btnAddAssetPath;
        private Button btnRenameAssetPath;
        private Button btnRenameDependency;
        private Button btnSaveRecord;
    }
}