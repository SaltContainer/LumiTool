using LumiTool.LumiToolDotNet.Resources;

namespace LumiTool.Forms
{
    partial class FormRenameBundle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRenameBundle));
            grpBundle = new GroupBox();
            lbBundleName = new Label();
            btnBundleOpen = new Button();
            btnBundleSave = new Button();
            txtBundleRename = new TextBox();
            txtCABRename = new TextBox();
            lbBundleRename = new Label();
            lbCABRename = new Label();
            btnApply = new Button();
            ttRenameBundle = new ToolTip(components);
            grpBundle.SuspendLayout();
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
            // btnBundleOpen
            // 
            btnBundleOpen.AllowDrop = true;
            btnBundleOpen.Image = Resources.folder;
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
            // btnBundleSave
            // 
            btnBundleSave.Image = Resources.save;
            btnBundleSave.Location = new Point(133, 40);
            btnBundleSave.Name = "btnBundleSave";
            btnBundleSave.Size = new Size(121, 40);
            btnBundleSave.TabIndex = 2;
            btnBundleSave.Text = "Save";
            btnBundleSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleSave.UseVisualStyleBackColor = true;
            btnBundleSave.Click += btnBundleSave_Click;
            // 
            // txtBundleRename
            // 
            txtBundleRename.Location = new Point(87, 104);
            txtBundleRename.Name = "txtBundleRename";
            txtBundleRename.Size = new Size(185, 23);
            txtBundleRename.TabIndex = 2;
            // 
            // txtCABRename
            // 
            txtCABRename.Location = new Point(78, 133);
            txtCABRename.Name = "txtCABRename";
            txtCABRename.Size = new Size(194, 23);
            txtCABRename.TabIndex = 4;
            // 
            // lbBundleRename
            // 
            lbBundleRename.AutoSize = true;
            lbBundleRename.Location = new Point(12, 107);
            lbBundleRename.Name = "lbBundleRename";
            lbBundleRename.Size = new Size(69, 15);
            lbBundleRename.TabIndex = 1;
            lbBundleRename.Text = "New Name:";
            // 
            // lbCABRename
            // 
            lbCABRename.AutoSize = true;
            lbCABRename.Location = new Point(12, 136);
            lbCABRename.Name = "lbCABRename";
            lbCABRename.Size = new Size(60, 15);
            lbCABRename.TabIndex = 3;
            lbCABRename.Text = "New CAB:";
            // 
            // btnApply
            // 
            btnApply.Location = new Point(12, 162);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(260, 41);
            btnApply.TabIndex = 5;
            btnApply.Text = "Rename";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // FormRenameBundle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 211);
            Controls.Add(btnApply);
            Controls.Add(lbCABRename);
            Controls.Add(lbBundleRename);
            Controls.Add(txtCABRename);
            Controls.Add(txtBundleRename);
            Controls.Add(grpBundle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(300, 250);
            MinimumSize = new Size(300, 250);
            Name = "FormRenameBundle";
            Text = "Bundle Renamer";
            FormClosed += FormRenameBundle_FormClosed;
            Shown += FormRenameBundle_Shown;
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpBundle;
        private Label lbBundleName;
        private Button btnBundleOpen;
        private Button btnBundleSave;
        private TextBox txtBundleRename;
        private TextBox txtCABRename;
        private Label lbBundleRename;
        private Label lbCABRename;
        private Button btnApply;
        private ToolTip ttRenameBundle;
    }
}