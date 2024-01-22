namespace LumiTool.Forms
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
            grpBundle = new GroupBox();
            lbBundleName = new Label();
            btnBundleOpen = new Button();
            btnBundleSave = new Button();
            grpBundleV = new GroupBox();
            lbBundleVName = new Label();
            btnBundleVOpen = new Button();
            button1 = new Button();
            button2 = new Button();
            grpBundle.SuspendLayout();
            grpBundleV.SuspendLayout();
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
            // button1
            // 
            button1.Location = new Point(12, 104);
            button1.Name = "button1";
            button1.Size = new Size(112, 44);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(130, 104);
            button2.Name = "button2";
            button2.Size = new Size(112, 44);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 243);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(grpBundleV);
            Controls.Add(grpBundle);
            Name = "FormMap";
            Text = "FormMap";
            FormClosed += FormMap_FormClosed;
            Shown += FormMap_Shown;
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            grpBundleV.ResumeLayout(false);
            grpBundleV.PerformLayout();
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
        private Button button1;
        private Button button2;
    }
}