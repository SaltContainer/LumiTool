namespace LumiTool.Forms
{
    partial class FormBundlePrepper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBundlePrepper));
            grpBundle = new GroupBox();
            checkTpk = new CheckBox();
            lbBundleName = new Label();
            btnBundleOpen = new Button();
            btnBundleSave = new Button();
            grpBundleV = new GroupBox();
            lbBundleVName = new Label();
            btnBundleVOpen = new Button();
            btnConvertApply = new Button();
            checkConvertPlatform = new CheckBox();
            checkConvertDependencies = new CheckBox();
            checkConvertShaders = new CheckBox();
            grpConvert = new GroupBox();
            ttBundlePrepper = new ToolTip(components);
            checkReassignDependencies = new CheckBox();
            grpBundle.SuspendLayout();
            grpBundleV.SuspendLayout();
            grpConvert.SuspendLayout();
            SuspendLayout();
            // 
            // grpBundle
            // 
            grpBundle.Controls.Add(checkTpk);
            grpBundle.Controls.Add(lbBundleName);
            grpBundle.Controls.Add(btnBundleOpen);
            grpBundle.Controls.Add(btnBundleSave);
            grpBundle.Location = new Point(12, 12);
            grpBundle.Name = "grpBundle";
            grpBundle.Size = new Size(260, 105);
            grpBundle.TabIndex = 2;
            grpBundle.TabStop = false;
            grpBundle.Text = "Loaded Rebuilt Bundle";
            // 
            // checkTpk
            // 
            checkTpk.AutoSize = true;
            checkTpk.Location = new Point(8, 38);
            checkTpk.Name = "checkTpk";
            checkTpk.Size = new Size(179, 19);
            checkTpk.TabIndex = 14;
            checkTpk.Text = "Load External Type Tree (.tpk)";
            checkTpk.UseVisualStyleBackColor = true;
            // 
            // lbBundleName
            // 
            lbBundleName.AutoEllipsis = true;
            lbBundleName.Location = new Point(6, 19);
            lbBundleName.Name = "lbBundleName";
            lbBundleName.Size = new Size(248, 15);
            lbBundleName.TabIndex = 1;
            lbBundleName.Text = "Bundle Name: ";
            // 
            // btnBundleOpen
            // 
            btnBundleOpen.AllowDrop = true;
            btnBundleOpen.Image = Resources.Resources.folder;
            btnBundleOpen.Location = new Point(6, 59);
            btnBundleOpen.Name = "btnBundleOpen";
            btnBundleOpen.Size = new Size(121, 40);
            btnBundleOpen.TabIndex = 0;
            btnBundleOpen.Text = "Open";
            btnBundleOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleOpen.UseVisualStyleBackColor = true;
            btnBundleOpen.Click += btnBundleOpen_Click;
            btnBundleOpen.DragDrop += btnBundleOpen_DragDrop;
            btnBundleOpen.DragEnter += btnBundleOpen_DragEnter;
            // 
            // btnBundleSave
            // 
            btnBundleSave.Image = Resources.Resources.save;
            btnBundleSave.Location = new Point(133, 59);
            btnBundleSave.Name = "btnBundleSave";
            btnBundleSave.Size = new Size(121, 40);
            btnBundleSave.TabIndex = 2;
            btnBundleSave.Text = "Save";
            btnBundleSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleSave.UseVisualStyleBackColor = true;
            btnBundleSave.Click += btnBundleSave_Click;
            // 
            // grpBundleV
            // 
            grpBundleV.Controls.Add(lbBundleVName);
            grpBundleV.Controls.Add(btnBundleVOpen);
            grpBundleV.Location = new Point(278, 12);
            grpBundleV.Name = "grpBundleV";
            grpBundleV.Size = new Size(198, 105);
            grpBundleV.TabIndex = 3;
            grpBundleV.TabStop = false;
            grpBundleV.Text = "Loaded Vanilla Bundle";
            // 
            // lbBundleVName
            // 
            lbBundleVName.AutoEllipsis = true;
            lbBundleVName.Location = new Point(6, 19);
            lbBundleVName.Name = "lbBundleVName";
            lbBundleVName.Size = new Size(186, 37);
            lbBundleVName.TabIndex = 1;
            lbBundleVName.Text = "Bundle Name: ";
            // 
            // btnBundleVOpen
            // 
            btnBundleVOpen.AllowDrop = true;
            btnBundleVOpen.Image = Resources.Resources.folder;
            btnBundleVOpen.Location = new Point(6, 59);
            btnBundleVOpen.Name = "btnBundleVOpen";
            btnBundleVOpen.Size = new Size(186, 40);
            btnBundleVOpen.TabIndex = 0;
            btnBundleVOpen.Text = "Open";
            btnBundleVOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleVOpen.UseVisualStyleBackColor = true;
            btnBundleVOpen.Click += btnBundleVOpen_Click;
            btnBundleVOpen.DragDrop += btnBundleVOpen_DragDrop;
            btnBundleVOpen.DragEnter += btnBundleVOpen_DragEnter;
            // 
            // btnConvertApply
            // 
            btnConvertApply.Location = new Point(294, 15);
            btnConvertApply.Name = "btnConvertApply";
            btnConvertApply.Size = new Size(158, 44);
            btnConvertApply.TabIndex = 8;
            btnConvertApply.Text = "Execute Script";
            btnConvertApply.UseVisualStyleBackColor = true;
            btnConvertApply.Click += btnConvertApply_Click;
            // 
            // checkConvertPlatform
            // 
            checkConvertPlatform.AutoSize = true;
            checkConvertPlatform.Checked = true;
            checkConvertPlatform.CheckState = CheckState.Checked;
            checkConvertPlatform.Location = new Point(8, 22);
            checkConvertPlatform.Name = "checkConvertPlatform";
            checkConvertPlatform.Size = new Size(168, 19);
            checkConvertPlatform.TabIndex = 9;
            checkConvertPlatform.Text = "Change Platform to Switch";
            checkConvertPlatform.UseVisualStyleBackColor = true;
            // 
            // checkConvertDependencies
            // 
            checkConvertDependencies.AutoSize = true;
            checkConvertDependencies.Location = new Point(8, 47);
            checkConvertDependencies.Name = "checkConvertDependencies";
            checkConvertDependencies.Size = new Size(131, 19);
            checkConvertDependencies.TabIndex = 10;
            checkConvertDependencies.Text = "Copy Dependencies";
            checkConvertDependencies.UseVisualStyleBackColor = true;
            // 
            // checkConvertShaders
            // 
            checkConvertShaders.AutoSize = true;
            checkConvertShaders.Checked = true;
            checkConvertShaders.CheckState = CheckState.Checked;
            checkConvertShaders.Location = new Point(8, 72);
            checkConvertShaders.Name = "checkConvertShaders";
            checkConvertShaders.Size = new Size(121, 19);
            checkConvertShaders.TabIndex = 11;
            checkConvertShaders.Text = "Re-assign Shaders";
            checkConvertShaders.UseVisualStyleBackColor = true;
            // 
            // grpConvert
            // 
            grpConvert.Controls.Add(btnConvertApply);
            grpConvert.Controls.Add(checkConvertPlatform);
            grpConvert.Controls.Add(checkConvertDependencies);
            grpConvert.Controls.Add(checkConvertShaders);
            grpConvert.Controls.Add(checkReassignDependencies);
            grpConvert.Location = new Point(12, 123);
            grpConvert.Name = "grpConvert";
            grpConvert.Size = new Size(458, 131);
            grpConvert.TabIndex = 13;
            grpConvert.TabStop = false;
            grpConvert.Text = "Prepare Rebuilt Bundle";
            // 
            // checkReassignDependencies
            // 
            checkReassignDependencies.AutoSize = true;
            checkReassignDependencies.Location = new Point(8, 97);
            checkReassignDependencies.Name = "checkReassignDependencies";
            checkReassignDependencies.Size = new Size(228, 19);
            checkReassignDependencies.TabIndex = 12;
            checkReassignDependencies.Text = "Re-assign References to Dependencies";
            checkReassignDependencies.UseVisualStyleBackColor = true;
            // 
            // FormBundlePrepper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 266);
            Controls.Add(grpConvert);
            Controls.Add(grpBundleV);
            Controls.Add(grpBundle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(504, 305);
            MinimumSize = new Size(504, 305);
            Name = "FormBundlePrepper";
            Text = "Bundle Prepper";
            FormClosed += FormBundlePrepper_FormClosed;
            Shown += FormBundlePrepper_Shown;
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            grpBundleV.ResumeLayout(false);
            grpConvert.ResumeLayout(false);
            grpConvert.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBundle;
        private Label lbBundleName;
        private Button btnBundleOpen;
        private Button btnBundleSave;
        private GroupBox grpBundleV;
        private Label lbBundleVName;
        private Button btnBundleVOpen;
        private Button btnConvertApply;
        private CheckBox checkConvertPlatform;
        private CheckBox checkConvertDependencies;
        private CheckBox checkConvertShaders;
        private GroupBox grpConvert;
        private CheckBox checkTpk;
        private ToolTip ttBundlePrepper;
        private CheckBox checkReassignDependencies;
    }
}