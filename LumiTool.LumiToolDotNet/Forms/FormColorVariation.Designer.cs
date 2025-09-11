using LumiTool.LumiToolDotNet.Resources;

namespace LumiTool.Forms
{
    partial class FormColorVariation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColorVariation));
            btnBundleOpen = new Button();
            btnBundleSave = new Button();
            SuspendLayout();
            // 
            // btnBundleOpen
            // 
            btnBundleOpen.Image = Resources.folder;
            btnBundleOpen.Location = new Point(12, 12);
            btnBundleOpen.Name = "btnBundleOpen";
            btnBundleOpen.Size = new Size(121, 40);
            btnBundleOpen.TabIndex = 1;
            btnBundleOpen.Text = "Open";
            btnBundleOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleOpen.UseVisualStyleBackColor = true;
            btnBundleOpen.Click += btnBundleOpen_Click;
            // 
            // btnBundleSave
            // 
            btnBundleSave.Image = Resources.save;
            btnBundleSave.Location = new Point(139, 12);
            btnBundleSave.Name = "btnBundleSave";
            btnBundleSave.Size = new Size(121, 40);
            btnBundleSave.TabIndex = 3;
            btnBundleSave.Text = "Save";
            btnBundleSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleSave.UseVisualStyleBackColor = true;
            btnBundleSave.Click += btnBundleSave_Click;
            // 
            // FormColorVariation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 423);
            Controls.Add(btnBundleSave);
            Controls.Add(btnBundleOpen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormColorVariation";
            Text = "ColorVariation Generator";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBundleOpen;
        private Button btnBundleSave;
    }
}