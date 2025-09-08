using LumiTool.LumiToolDotNet.Resources;

namespace LumiTool.Forms
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            ttSettings = new ToolTip(components);
            btnSave = new Button();
            lbDependencyRemapConfigPath = new Label();
            txtDependencyRemapConfigPath = new TextBox();
            btnDependencyRemapConfigPath = new Button();
            comboCompression = new ComboBox();
            lbCompression = new Label();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Image = Resources.save;
            btnSave.Location = new Point(459, 81);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lbDependencyRemapConfigPath
            // 
            lbDependencyRemapConfigPath.AutoSize = true;
            lbDependencyRemapConfigPath.Location = new Point(12, 19);
            lbDependencyRemapConfigPath.Name = "lbDependencyRemapConfigPath";
            lbDependencyRemapConfigPath.Size = new Size(206, 15);
            lbDependencyRemapConfigPath.TabIndex = 3;
            lbDependencyRemapConfigPath.Text = "Dependency Remapping Config Path:";
            // 
            // txtDependencyRemapConfigPath
            // 
            txtDependencyRemapConfigPath.Location = new Point(224, 16);
            txtDependencyRemapConfigPath.Name = "txtDependencyRemapConfigPath";
            txtDependencyRemapConfigPath.Size = new Size(302, 23);
            txtDependencyRemapConfigPath.TabIndex = 3;
            // 
            // btnDependencyRemapConfigPath
            // 
            btnDependencyRemapConfigPath.Image = Resources.folder;
            btnDependencyRemapConfigPath.Location = new Point(532, 6);
            btnDependencyRemapConfigPath.Name = "btnDependencyRemapConfigPath";
            btnDependencyRemapConfigPath.Size = new Size(40, 40);
            btnDependencyRemapConfigPath.TabIndex = 3;
            btnDependencyRemapConfigPath.UseVisualStyleBackColor = true;
            btnDependencyRemapConfigPath.Click += btnDependencyRemapConfigPath_Click;
            // 
            // comboCompression
            // 
            comboCompression.FormattingEnabled = true;
            comboCompression.Location = new Point(406, 52);
            comboCompression.Name = "comboCompression";
            comboCompression.Size = new Size(166, 23);
            comboCompression.TabIndex = 4;
            // 
            // lbCompression
            // 
            lbCompression.AutoSize = true;
            lbCompression.Location = new Point(12, 55);
            lbCompression.Name = "lbCompression";
            lbCompression.Size = new Size(185, 15);
            lbCompression.TabIndex = 5;
            lbCompression.Text = "Asset Bundle Compression Mode:";
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 133);
            Controls.Add(btnDependencyRemapConfigPath);
            Controls.Add(txtDependencyRemapConfigPath);
            Controls.Add(lbDependencyRemapConfigPath);
            Controls.Add(comboCompression);
            Controls.Add(lbCompression);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(600, 172);
            MinimumSize = new Size(600, 172);
            Name = "FormSettings";
            Text = "Settings";
            FormClosed += FormSettings_FormClosed;
            Shown += FormSettings_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolTip ttSettings;
        private Button btnSave;
        private Label lbDependencyRemapConfigPath;
        private TextBox txtDependencyRemapConfigPath;
        private Button btnDependencyRemapConfigPath;
        private ComboBox comboCompression;
        private Label lbCompression;
    }
}