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
            lbShaderConfigPath = new Label();
            txtShaderConfigPath = new TextBox();
            ttSettings = new ToolTip(components);
            btnShaderConfigPath = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lbShaderConfigPath
            // 
            lbShaderConfigPath.AutoSize = true;
            lbShaderConfigPath.Location = new Point(12, 25);
            lbShaderConfigPath.Name = "lbShaderConfigPath";
            lbShaderConfigPath.Size = new Size(112, 15);
            lbShaderConfigPath.TabIndex = 0;
            lbShaderConfigPath.Text = "Shader Config Path:";
            // 
            // txtShaderConfigPath
            // 
            txtShaderConfigPath.Location = new Point(130, 22);
            txtShaderConfigPath.Name = "txtShaderConfigPath";
            txtShaderConfigPath.Size = new Size(396, 23);
            txtShaderConfigPath.TabIndex = 1;
            // 
            // btnShaderConfigPath
            // 
            btnShaderConfigPath.Image = Resources.Resources.folder;
            btnShaderConfigPath.Location = new Point(532, 12);
            btnShaderConfigPath.Name = "btnShaderConfigPath";
            btnShaderConfigPath.Size = new Size(40, 40);
            btnShaderConfigPath.TabIndex = 2;
            btnShaderConfigPath.UseVisualStyleBackColor = true;
            btnShaderConfigPath.Click += btnShaderConfigPath_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Image = Resources.Resources.save;
            btnSave.Location = new Point(459, 59);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 111);
            Controls.Add(btnSave);
            Controls.Add(btnShaderConfigPath);
            Controls.Add(txtShaderConfigPath);
            Controls.Add(lbShaderConfigPath);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(600, 150);
            MinimumSize = new Size(600, 150);
            Name = "FormSettings";
            Text = "Settings";
            FormClosed += FormSettings_FormClosed;
            Shown += FormSettings_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbShaderConfigPath;
        private TextBox txtShaderConfigPath;
        private ToolTip ttSettings;
        private Button btnShaderConfigPath;
        private Button btnSave;
    }
}