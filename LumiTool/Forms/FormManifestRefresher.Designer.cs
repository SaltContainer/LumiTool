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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManifestRefresher));
            grpManifest = new GroupBox();
            lbManifestName = new Label();
            btnManifestOpen = new Button();
            btnManifestSave = new Button();
            btnTest = new Button();
            grpManifest.SuspendLayout();
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
            btnManifestOpen.Image = Resources.Resources.folder;
            btnManifestOpen.Location = new Point(6, 40);
            btnManifestOpen.Name = "btnManifestOpen";
            btnManifestOpen.Size = new Size(121, 40);
            btnManifestOpen.TabIndex = 0;
            btnManifestOpen.Text = "Open";
            btnManifestOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManifestOpen.UseVisualStyleBackColor = true;
            btnManifestOpen.Click += btnManifestOpen_Click;
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
            // btnTest
            // 
            btnTest.Location = new Point(64, 146);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(131, 47);
            btnTest.TabIndex = 4;
            btnTest.Text = "Testing!!";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // FormManifestRefresher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 246);
            Controls.Add(btnTest);
            Controls.Add(grpManifest);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(300, 285);
            MinimumSize = new Size(300, 285);
            Name = "FormManifestRefresher";
            Text = "Manifest Refresher";
            FormClosed += FormManifestRefresher_FormClosed;
            Shown += FormManifestRefresher_Shown;
            grpManifest.ResumeLayout(false);
            grpManifest.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpManifest;
        private Label lbManifestName;
        private Button btnManifestOpen;
        private Button btnManifestSave;
        private Button btnTest;
    }
}