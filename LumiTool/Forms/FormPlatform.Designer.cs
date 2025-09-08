namespace LumiTool.Forms
{
    partial class FormPlatform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlatform));
            btnBundleOpen = new Button();
            grpBundle = new GroupBox();
            lbBundleName = new Label();
            btnBundleSave = new Button();
            comboPlatform = new ComboBox();
            lbPlatform = new Label();
            grpBundle.SuspendLayout();
            SuspendLayout();
            // 
            // btnBundleOpen
            // 
            btnBundleOpen.AllowDrop = true;
            btnBundleOpen.Image = Resources.Resources.folder;
            btnBundleOpen.Location = new Point(6, 40);
            btnBundleOpen.Name = "btnBundleOpen";
            btnBundleOpen.Size = new Size(121, 40);
            btnBundleOpen.TabIndex = 1;
            btnBundleOpen.Text = "Open";
            btnBundleOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleOpen.UseVisualStyleBackColor = true;
            btnBundleOpen.Click += btnBundleOpen_Click;
            btnBundleOpen.DragDrop += btnBundleOpen_DragDrop;
            btnBundleOpen.DragEnter += btnBundleOpen_DragEnter;
            // 
            // grpBundle
            // 
            grpBundle.Controls.Add(lbBundleName);
            grpBundle.Controls.Add(btnBundleOpen);
            grpBundle.Controls.Add(btnBundleSave);
            grpBundle.Location = new Point(12, 12);
            grpBundle.Name = "grpBundle";
            grpBundle.Size = new Size(260, 86);
            grpBundle.TabIndex = 0;
            grpBundle.TabStop = false;
            grpBundle.Text = "Loaded Bundle";
            // 
            // lbBundleName
            // 
            lbBundleName.AutoSize = true;
            lbBundleName.Location = new Point(6, 19);
            lbBundleName.Name = "lbBundleName";
            lbBundleName.Size = new Size(85, 15);
            lbBundleName.TabIndex = 0;
            lbBundleName.Text = "Bundle Name: ";
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
            // comboPlatform
            // 
            comboPlatform.FormattingEnabled = true;
            comboPlatform.Location = new Point(95, 107);
            comboPlatform.Name = "comboPlatform";
            comboPlatform.Size = new Size(171, 23);
            comboPlatform.TabIndex = 2;
            // 
            // lbPlatform
            // 
            lbPlatform.AutoSize = true;
            lbPlatform.Location = new Point(12, 110);
            lbPlatform.Name = "lbPlatform";
            lbPlatform.Size = new Size(83, 15);
            lbPlatform.TabIndex = 1;
            lbPlatform.Text = "New Platform:";
            // 
            // FormPlatform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 142);
            Controls.Add(lbPlatform);
            Controls.Add(comboPlatform);
            Controls.Add(grpBundle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(300, 181);
            MinimumSize = new Size(300, 181);
            Name = "FormPlatform";
            Text = "Change Bundle Platform";
            FormClosed += FormPlatform_FormClosed;
            Shown += FormPlatform_Shown;
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBundleOpen;
        private GroupBox grpBundle;
        private Label lbBundleName;
        private ComboBox comboPlatform;
        private Label lbPlatform;
        private Button btnBundleSave;
    }
}