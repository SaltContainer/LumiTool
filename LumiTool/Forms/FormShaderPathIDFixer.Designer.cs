namespace LumiTool.Forms
{
    partial class FormShaderPathIDFixer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShaderPathIDFixer));
            btnFix = new Button();
            grpBundle = new GroupBox();
            lbBundleName = new Label();
            btnBundleOpen = new Button();
            btnBundleSave = new Button();
            grpBundleV = new GroupBox();
            lbBundleVName = new Label();
            btnBundleVOpen = new Button();
            ttShaderPathIDFixer = new ToolTip(components);
            grpBundle.SuspendLayout();
            grpBundleV.SuspendLayout();
            SuspendLayout();
            // 
            // btnFix
            // 
            btnFix.Location = new Point(12, 196);
            btnFix.Name = "btnFix";
            btnFix.Size = new Size(260, 38);
            btnFix.TabIndex = 11;
            btnFix.Text = "Fix PathIDs of Bundle";
            btnFix.UseVisualStyleBackColor = true;
            btnFix.Click += btnFix_Click;
            // 
            // grpBundle
            // 
            grpBundle.Controls.Add(lbBundleName);
            grpBundle.Controls.Add(btnBundleOpen);
            grpBundle.Controls.Add(btnBundleSave);
            grpBundle.Location = new Point(12, 12);
            grpBundle.Name = "grpBundle";
            grpBundle.Size = new Size(260, 86);
            grpBundle.TabIndex = 10;
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
            btnBundleOpen.AllowDrop = true;
            btnBundleOpen.Image = Resources.Resources.folder;
            btnBundleOpen.Location = new Point(6, 40);
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
            grpBundleV.Location = new Point(12, 104);
            grpBundleV.Name = "grpBundleV";
            grpBundleV.Size = new Size(260, 86);
            grpBundleV.TabIndex = 12;
            grpBundleV.TabStop = false;
            grpBundleV.Text = "Loaded Vanilla Bundle";
            // 
            // lbBundleVName
            // 
            lbBundleVName.AutoSize = true;
            lbBundleVName.Location = new Point(6, 19);
            lbBundleVName.Name = "lbBundleVName";
            lbBundleVName.Size = new Size(85, 15);
            lbBundleVName.TabIndex = 3;
            lbBundleVName.Text = "Bundle Name: ";
            // 
            // btnBundleVOpen
            // 
            btnBundleVOpen.AllowDrop = true;
            btnBundleVOpen.Image = Resources.Resources.folder;
            btnBundleVOpen.Location = new Point(6, 40);
            btnBundleVOpen.Name = "btnBundleVOpen";
            btnBundleVOpen.Size = new Size(248, 40);
            btnBundleVOpen.TabIndex = 0;
            btnBundleVOpen.Text = "Open";
            btnBundleVOpen.TextAlign = ContentAlignment.MiddleRight;
            btnBundleVOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleVOpen.UseVisualStyleBackColor = true;
            btnBundleVOpen.Click += btnBundleVOpen_Click;
            btnBundleVOpen.DragDrop += btnBundleVOpen_DragDrop;
            btnBundleVOpen.DragEnter += btnBundleVOpen_DragEnter;
            // 
            // FormShaderPathIDFixer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 246);
            Controls.Add(btnFix);
            Controls.Add(grpBundleV);
            Controls.Add(grpBundle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(300, 285);
            MinimumSize = new Size(300, 285);
            Name = "FormShaderPathIDFixer";
            Text = "Shader Bundle PathIDs Fixer";
            FormClosed += FormShaderPathIDFixer_FormClosed;
            Shown += FormShaderPathIDFixer_Shown;
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            grpBundleV.ResumeLayout(false);
            grpBundleV.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnFix;
        private GroupBox grpBundle;
        private Label lbBundleName;
        private Button btnBundleOpen;
        private Button btnBundleSave;
        private GroupBox grpBundleV;
        private Label lbBundleVName;
        private Button btnBundleVOpen;
        private ToolTip ttShaderPathIDFixer;
    }
}