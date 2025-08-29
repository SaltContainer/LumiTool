namespace LumiTool.Forms
{
    partial class FormBundlePrepperMass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBundlePrepperMass));
            grpConvert = new GroupBox();
            btnConvertApply = new Button();
            checkConvertPlatform = new CheckBox();
            checkConvertShaders = new CheckBox();
            grpBundle = new GroupBox();
            checkTpk = new CheckBox();
            lbBundleName = new Label();
            btnBundleOpen = new Button();
            ttBundlePrepper = new ToolTip(components);
            grpOutput = new GroupBox();
            lbOutputBundleName = new Label();
            btnOutputBundleOpen = new Button();
            checkReassignDependencies = new CheckBox();
            grpConvert.SuspendLayout();
            grpBundle.SuspendLayout();
            grpOutput.SuspendLayout();
            SuspendLayout();
            // 
            // grpConvert
            // 
            grpConvert.Controls.Add(btnConvertApply);
            grpConvert.Controls.Add(checkConvertPlatform);
            grpConvert.Controls.Add(checkConvertShaders);
            grpConvert.Controls.Add(checkReassignDependencies);
            grpConvert.Location = new Point(12, 123);
            grpConvert.Name = "grpConvert";
            grpConvert.Size = new Size(526, 101);
            grpConvert.TabIndex = 16;
            grpConvert.TabStop = false;
            grpConvert.Text = "Prepare Rebuilt Bundles";
            // 
            // btnConvertApply
            // 
            btnConvertApply.Location = new Point(362, 15);
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
            // checkConvertShaders
            // 
            checkConvertShaders.AutoSize = true;
            checkConvertShaders.Checked = true;
            checkConvertShaders.CheckState = CheckState.Checked;
            checkConvertShaders.Location = new Point(8, 47);
            checkConvertShaders.Name = "checkConvertShaders";
            checkConvertShaders.Size = new Size(121, 19);
            checkConvertShaders.TabIndex = 11;
            checkConvertShaders.Text = "Re-assign Shaders";
            checkConvertShaders.UseVisualStyleBackColor = true;
            // 
            // grpBundle
            // 
            grpBundle.Controls.Add(checkTpk);
            grpBundle.Controls.Add(lbBundleName);
            grpBundle.Controls.Add(btnBundleOpen);
            grpBundle.Location = new Point(12, 12);
            grpBundle.Name = "grpBundle";
            grpBundle.Size = new Size(260, 105);
            grpBundle.TabIndex = 14;
            grpBundle.TabStop = false;
            grpBundle.Text = "Loaded Bundle Folder";
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
            lbBundleName.Text = "Folder Path: ";
            // 
            // btnBundleOpen
            // 
            btnBundleOpen.Image = Resources.Resources.folder;
            btnBundleOpen.Location = new Point(6, 59);
            btnBundleOpen.Name = "btnBundleOpen";
            btnBundleOpen.Size = new Size(248, 40);
            btnBundleOpen.TabIndex = 0;
            btnBundleOpen.Text = "Open";
            btnBundleOpen.TextAlign = ContentAlignment.MiddleRight;
            btnBundleOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleOpen.UseVisualStyleBackColor = true;
            btnBundleOpen.Click += btnBundleOpen_Click;
            // 
            // grpOutput
            // 
            grpOutput.Controls.Add(lbOutputBundleName);
            grpOutput.Controls.Add(btnOutputBundleOpen);
            grpOutput.Location = new Point(278, 12);
            grpOutput.Name = "grpOutput";
            grpOutput.Size = new Size(260, 105);
            grpOutput.TabIndex = 15;
            grpOutput.TabStop = false;
            grpOutput.Text = "Output Folder";
            // 
            // lbOutputBundleName
            // 
            lbOutputBundleName.AutoEllipsis = true;
            lbOutputBundleName.Location = new Point(6, 19);
            lbOutputBundleName.Name = "lbOutputBundleName";
            lbOutputBundleName.Size = new Size(248, 37);
            lbOutputBundleName.TabIndex = 1;
            lbOutputBundleName.Text = "Folder Path: ";
            // 
            // btnOutputBundleOpen
            // 
            btnOutputBundleOpen.Image = Resources.Resources.folder;
            btnOutputBundleOpen.Location = new Point(6, 59);
            btnOutputBundleOpen.Name = "btnOutputBundleOpen";
            btnOutputBundleOpen.Size = new Size(248, 40);
            btnOutputBundleOpen.TabIndex = 0;
            btnOutputBundleOpen.Text = "Open";
            btnOutputBundleOpen.TextAlign = ContentAlignment.MiddleRight;
            btnOutputBundleOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOutputBundleOpen.UseVisualStyleBackColor = true;
            btnOutputBundleOpen.Click += btnOutputBundleOpen_Click;
            // 
            // checkReassignDependencies
            // 
            checkReassignDependencies.AutoSize = true;
            checkReassignDependencies.Location = new Point(8, 72);
            checkReassignDependencies.Name = "checkReassignDependencies";
            checkReassignDependencies.Size = new Size(228, 19);
            checkReassignDependencies.TabIndex = 12;
            checkReassignDependencies.Text = "Re-assign References to Dependencies";
            checkReassignDependencies.UseVisualStyleBackColor = true;
            // 
            // FormBundlePrepperMass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 236);
            Controls.Add(grpConvert);
            Controls.Add(grpBundle);
            Controls.Add(grpOutput);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(566, 275);
            MinimumSize = new Size(566, 275);
            Name = "FormBundlePrepperMass";
            Text = "Bundle Prepper (Mass)";
            FormClosed += FormBundlePrepperMass_FormClosed;
            Shown += FormBundlePrepperMass_Shown;
            grpConvert.ResumeLayout(false);
            grpConvert.PerformLayout();
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            grpOutput.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpConvert;
        private Button btnConvertApply;
        private CheckBox checkConvertPlatform;
        private CheckBox checkConvertShaders;
        private GroupBox grpBundle;
        private CheckBox checkTpk;
        private Label lbBundleName;
        private Button btnBundleOpen;
        private ToolTip ttBundlePrepper;
        private GroupBox grpOutput;
        private Label lbOutputBundleName;
        private Button btnOutputBundleOpen;
        private CheckBox checkReassignDependencies;
    }
}