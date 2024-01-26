namespace LumiTool.Forms
{
    partial class FormCharacter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCharacter));
            grpConvert = new GroupBox();
            btnConvertApply = new Button();
            checkConvertPlatform = new CheckBox();
            checkConvertDependencies = new CheckBox();
            checkConvertShaders = new CheckBox();
            checkConvertCopyMonos = new CheckBox();
            checkConvertMergeAnims = new CheckBox();
            grpBundleV = new GroupBox();
            lbBundleVName = new Label();
            btnBundleVOpen = new Button();
            grpBundle = new GroupBox();
            lbBundleName = new Label();
            btnBundleOpen = new Button();
            btnBundleSave = new Button();
            grpConvert.SuspendLayout();
            grpBundleV.SuspendLayout();
            grpBundle.SuspendLayout();
            SuspendLayout();
            // 
            // grpConvert
            // 
            grpConvert.Controls.Add(btnConvertApply);
            grpConvert.Controls.Add(checkConvertPlatform);
            grpConvert.Controls.Add(checkConvertDependencies);
            grpConvert.Controls.Add(checkConvertShaders);
            grpConvert.Controls.Add(checkConvertCopyMonos);
            grpConvert.Controls.Add(checkConvertMergeAnims);
            grpConvert.Location = new Point(12, 104);
            grpConvert.Name = "grpConvert";
            grpConvert.Size = new Size(458, 155);
            grpConvert.TabIndex = 16;
            grpConvert.TabStop = false;
            grpConvert.Text = "Convert Windows Character Bundle";
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
            // checkConvertCopyMonos
            // 
            checkConvertCopyMonos.AutoSize = true;
            checkConvertCopyMonos.Checked = true;
            checkConvertCopyMonos.CheckState = CheckState.Checked;
            checkConvertCopyMonos.Location = new Point(8, 97);
            checkConvertCopyMonos.Name = "checkConvertCopyMonos";
            checkConvertCopyMonos.Size = new Size(147, 19);
            checkConvertCopyMonos.TabIndex = 12;
            checkConvertCopyMonos.Text = "Copy MonoBehaviours";
            checkConvertCopyMonos.UseVisualStyleBackColor = true;
            // 
            // checkConvertMergeAnims
            // 
            checkConvertMergeAnims.AutoSize = true;
            checkConvertMergeAnims.Checked = true;
            checkConvertMergeAnims.CheckState = CheckState.Checked;
            checkConvertMergeAnims.Location = new Point(8, 122);
            checkConvertMergeAnims.Name = "checkConvertMergeAnims";
            checkConvertMergeAnims.Size = new Size(148, 19);
            checkConvertMergeAnims.TabIndex = 13;
            checkConvertMergeAnims.Text = "Merge Animation Clips";
            checkConvertMergeAnims.UseVisualStyleBackColor = true;
            // 
            // grpBundleV
            // 
            grpBundleV.Controls.Add(lbBundleVName);
            grpBundleV.Controls.Add(btnBundleVOpen);
            grpBundleV.Location = new Point(278, 12);
            grpBundleV.Name = "grpBundleV";
            grpBundleV.Size = new Size(198, 86);
            grpBundleV.TabIndex = 15;
            grpBundleV.TabStop = false;
            grpBundleV.Text = "Loaded Vanilla Bundle";
            // 
            // lbBundleVName
            // 
            lbBundleVName.AutoSize = true;
            lbBundleVName.Location = new Point(6, 19);
            lbBundleVName.Name = "lbBundleVName";
            lbBundleVName.Size = new Size(85, 15);
            lbBundleVName.TabIndex = 1;
            lbBundleVName.Text = "Bundle Name: ";
            // 
            // btnBundleVOpen
            // 
            btnBundleVOpen.Image = Resources.Resources.folder;
            btnBundleVOpen.Location = new Point(6, 40);
            btnBundleVOpen.Name = "btnBundleVOpen";
            btnBundleVOpen.Size = new Size(186, 40);
            btnBundleVOpen.TabIndex = 0;
            btnBundleVOpen.Text = "Open";
            btnBundleVOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleVOpen.UseVisualStyleBackColor = true;
            btnBundleVOpen.Click += btnBundleVOpen_Click;
            // 
            // grpBundle
            // 
            grpBundle.Controls.Add(lbBundleName);
            grpBundle.Controls.Add(btnBundleOpen);
            grpBundle.Controls.Add(btnBundleSave);
            grpBundle.Location = new Point(12, 12);
            grpBundle.Name = "grpBundle";
            grpBundle.Size = new Size(260, 86);
            grpBundle.TabIndex = 14;
            grpBundle.TabStop = false;
            grpBundle.Text = "Loaded Bundle";
            // 
            // lbBundleName
            // 
            lbBundleName.AutoSize = true;
            lbBundleName.Location = new Point(6, 19);
            lbBundleName.Name = "lbBundleName";
            lbBundleName.Size = new Size(85, 15);
            lbBundleName.TabIndex = 1;
            lbBundleName.Text = "Bundle Name: ";
            // 
            // btnBundleOpen
            // 
            btnBundleOpen.Image = Resources.Resources.folder;
            btnBundleOpen.Location = new Point(6, 40);
            btnBundleOpen.Name = "btnBundleOpen";
            btnBundleOpen.Size = new Size(121, 40);
            btnBundleOpen.TabIndex = 0;
            btnBundleOpen.Text = "Open";
            btnBundleOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleOpen.UseVisualStyleBackColor = true;
            btnBundleOpen.Click += btnBundleOpen_Click;
            // 
            // btnBundleSave
            // 
            btnBundleSave.Image = Resources.Resources.save;
            btnBundleSave.Location = new Point(133, 40);
            btnBundleSave.Name = "btnBundleSave";
            btnBundleSave.Size = new Size(121, 40);
            btnBundleSave.TabIndex = 2;
            btnBundleSave.Text = "Save";
            btnBundleSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleSave.UseVisualStyleBackColor = true;
            btnBundleSave.Click += btnBundleSave_Click;
            // 
            // FormCharacter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 271);
            Controls.Add(grpConvert);
            Controls.Add(grpBundleV);
            Controls.Add(grpBundle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(504, 310);
            MinimumSize = new Size(504, 310);
            Name = "FormCharacter";
            Text = "Character Stuff";
            FormClosed += FormCharacter_FormClosed;
            Shown += FormCharacter_Shown;
            grpConvert.ResumeLayout(false);
            grpConvert.PerformLayout();
            grpBundleV.ResumeLayout(false);
            grpBundleV.PerformLayout();
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpConvert;
        private Button btnConvertApply;
        private CheckBox checkConvertPlatform;
        private CheckBox checkConvertDependencies;
        private CheckBox checkConvertShaders;
        private GroupBox grpBundleV;
        private Label lbBundleVName;
        private Button btnBundleVOpen;
        private GroupBox grpBundle;
        private Label lbBundleName;
        private Button btnBundleOpen;
        private Button btnBundleSave;
        private CheckBox checkConvertCopyMonos;
        private CheckBox checkConvertMergeAnims;
    }
}