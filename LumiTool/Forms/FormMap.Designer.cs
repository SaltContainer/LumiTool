﻿namespace LumiTool.Forms
{
    partial class FormMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMap));
            grpBundle = new GroupBox();
            lbBundleName = new Label();
            btnBundleOpen = new Button();
            btnBundleSave = new Button();
            grpBundleV = new GroupBox();
            lbBundleVName = new Label();
            btnBundleVOpen = new Button();
            btnConvertApply = new Button();
            checkConvertPlatform = new CheckBox();
            checkConvertDependencies = new CheckBox();
            checkConvertMaterials = new CheckBox();
            checkConvertTextures = new CheckBox();
            grpConvert = new GroupBox();
            checkConvertNewMaterials = new CheckBox();
            grpBundle.SuspendLayout();
            grpBundleV.SuspendLayout();
            grpConvert.SuspendLayout();
            SuspendLayout();
            // 
            // grpBundle
            // 
            grpBundle.Controls.Add(lbBundleName);
            grpBundle.Controls.Add(btnBundleOpen);
            grpBundle.Controls.Add(btnBundleSave);
            grpBundle.Location = new Point(12, 12);
            grpBundle.Name = "grpBundle";
            grpBundle.Size = new Size(260, 86);
            grpBundle.TabIndex = 2;
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
            // grpBundleV
            // 
            grpBundleV.Controls.Add(lbBundleVName);
            grpBundleV.Controls.Add(btnBundleVOpen);
            grpBundleV.Location = new Point(278, 12);
            grpBundleV.Name = "grpBundleV";
            grpBundleV.Size = new Size(198, 86);
            grpBundleV.TabIndex = 3;
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
            checkConvertDependencies.Checked = true;
            checkConvertDependencies.CheckState = CheckState.Checked;
            checkConvertDependencies.Location = new Point(8, 47);
            checkConvertDependencies.Name = "checkConvertDependencies";
            checkConvertDependencies.Size = new Size(131, 19);
            checkConvertDependencies.TabIndex = 10;
            checkConvertDependencies.Text = "Copy Dependencies";
            checkConvertDependencies.UseVisualStyleBackColor = true;
            // 
            // checkConvertMaterials
            // 
            checkConvertMaterials.AutoSize = true;
            checkConvertMaterials.Checked = true;
            checkConvertMaterials.CheckState = CheckState.Checked;
            checkConvertMaterials.Location = new Point(8, 72);
            checkConvertMaterials.Name = "checkConvertMaterials";
            checkConvertMaterials.Size = new Size(105, 19);
            checkConvertMaterials.TabIndex = 11;
            checkConvertMaterials.Text = "Copy Materials";
            checkConvertMaterials.UseVisualStyleBackColor = true;
            // 
            // checkConvertTextures
            // 
            checkConvertTextures.AutoSize = true;
            checkConvertTextures.Checked = true;
            checkConvertTextures.CheckState = CheckState.Checked;
            checkConvertTextures.Location = new Point(8, 97);
            checkConvertTextures.Name = "checkConvertTextures";
            checkConvertTextures.Size = new Size(212, 19);
            checkConvertTextures.TabIndex = 12;
            checkConvertTextures.Text = "Adjust Texture Path IDs of Materials";
            checkConvertTextures.UseVisualStyleBackColor = true;
            // 
            // grpConvert
            // 
            grpConvert.Controls.Add(btnConvertApply);
            grpConvert.Controls.Add(checkConvertPlatform);
            grpConvert.Controls.Add(checkConvertDependencies);
            grpConvert.Controls.Add(checkConvertMaterials);
            grpConvert.Controls.Add(checkConvertTextures);
            grpConvert.Controls.Add(checkConvertNewMaterials);
            grpConvert.Location = new Point(12, 104);
            grpConvert.Name = "grpConvert";
            grpConvert.Size = new Size(458, 175);
            grpConvert.TabIndex = 13;
            grpConvert.TabStop = false;
            grpConvert.Text = "Convert Windows Existing Map Bundle";
            // 
            // checkConvertNewMaterials
            // 
            checkConvertNewMaterials.AutoSize = true;
            checkConvertNewMaterials.Checked = true;
            checkConvertNewMaterials.CheckState = CheckState.Checked;
            checkConvertNewMaterials.Location = new Point(8, 122);
            checkConvertNewMaterials.Name = "checkConvertNewMaterials";
            checkConvertNewMaterials.Size = new Size(402, 19);
            checkConvertNewMaterials.TabIndex = 13;
            checkConvertNewMaterials.Text = "Assign Delphis/Map/Standard Shader to New Materials and Fix Textures";
            checkConvertNewMaterials.UseVisualStyleBackColor = true;
            // 
            // FormMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 291);
            Controls.Add(grpConvert);
            Controls.Add(grpBundleV);
            Controls.Add(grpBundle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(504, 330);
            MinimumSize = new Size(504, 330);
            Name = "FormMap";
            Text = "FormMap";
            FormClosed += FormMap_FormClosed;
            Shown += FormMap_Shown;
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            grpBundleV.ResumeLayout(false);
            grpBundleV.PerformLayout();
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
        private CheckBox checkConvertMaterials;
        private CheckBox checkConvertTextures;
        private GroupBox grpConvert;
        private CheckBox checkConvertNewMaterials;
    }
}