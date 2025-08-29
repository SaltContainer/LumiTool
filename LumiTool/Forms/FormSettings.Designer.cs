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
            grpRequired = new GroupBox();
            grpOptional = new GroupBox();
            lbDependencyRemapConfigPath = new Label();
            txtDependencyRemapConfigPath = new TextBox();
            btnDependencyRemapConfigPath = new Button();
            grpRequired.SuspendLayout();
            grpOptional.SuspendLayout();
            SuspendLayout();
            // 
            // lbShaderConfigPath
            // 
            lbShaderConfigPath.AutoSize = true;
            lbShaderConfigPath.Location = new Point(6, 28);
            lbShaderConfigPath.Name = "lbShaderConfigPath";
            lbShaderConfigPath.Size = new Size(112, 15);
            lbShaderConfigPath.TabIndex = 0;
            lbShaderConfigPath.Text = "Shader Config Path:";
            // 
            // txtShaderConfigPath
            // 
            txtShaderConfigPath.Location = new Point(124, 25);
            txtShaderConfigPath.Name = "txtShaderConfigPath";
            txtShaderConfigPath.Size = new Size(384, 23);
            txtShaderConfigPath.TabIndex = 1;
            // 
            // btnShaderConfigPath
            // 
            btnShaderConfigPath.Image = Resources.Resources.folder;
            btnShaderConfigPath.Location = new Point(514, 15);
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
            btnSave.Location = new Point(459, 146);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // grpRequired
            // 
            grpRequired.Controls.Add(lbShaderConfigPath);
            grpRequired.Controls.Add(txtShaderConfigPath);
            grpRequired.Controls.Add(btnShaderConfigPath);
            grpRequired.Location = new Point(12, 12);
            grpRequired.Name = "grpRequired";
            grpRequired.Size = new Size(560, 61);
            grpRequired.TabIndex = 4;
            grpRequired.TabStop = false;
            grpRequired.Text = "Required";
            // 
            // grpOptional
            // 
            grpOptional.Controls.Add(lbDependencyRemapConfigPath);
            grpOptional.Controls.Add(txtDependencyRemapConfigPath);
            grpOptional.Controls.Add(btnDependencyRemapConfigPath);
            grpOptional.Location = new Point(12, 79);
            grpOptional.Name = "grpOptional";
            grpOptional.Size = new Size(560, 61);
            grpOptional.TabIndex = 5;
            grpOptional.TabStop = false;
            grpOptional.Text = "Optional";
            // 
            // lbDependencyRemapConfigPath
            // 
            lbDependencyRemapConfigPath.AutoSize = true;
            lbDependencyRemapConfigPath.Location = new Point(6, 28);
            lbDependencyRemapConfigPath.Name = "lbDependencyRemapConfigPath";
            lbDependencyRemapConfigPath.Size = new Size(206, 15);
            lbDependencyRemapConfigPath.TabIndex = 3;
            lbDependencyRemapConfigPath.Text = "Dependency Remapping Config Path:";
            // 
            // txtDependencyRemapConfigPath
            // 
            txtDependencyRemapConfigPath.Location = new Point(218, 25);
            txtDependencyRemapConfigPath.Name = "txtDependencyRemapConfigPath";
            txtDependencyRemapConfigPath.Size = new Size(290, 23);
            txtDependencyRemapConfigPath.TabIndex = 3;
            // 
            // btnDependencyRemapConfigPath
            // 
            btnDependencyRemapConfigPath.Image = Resources.Resources.folder;
            btnDependencyRemapConfigPath.Location = new Point(514, 15);
            btnDependencyRemapConfigPath.Name = "btnDependencyRemapConfigPath";
            btnDependencyRemapConfigPath.Size = new Size(40, 40);
            btnDependencyRemapConfigPath.TabIndex = 3;
            btnDependencyRemapConfigPath.UseVisualStyleBackColor = true;
            btnDependencyRemapConfigPath.Click += btnDependencyRemapConfigPath_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 198);
            Controls.Add(grpOptional);
            Controls.Add(grpRequired);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(600, 237);
            MinimumSize = new Size(600, 237);
            Name = "FormSettings";
            Text = "Settings";
            FormClosed += FormSettings_FormClosed;
            Shown += FormSettings_Shown;
            grpRequired.ResumeLayout(false);
            grpRequired.PerformLayout();
            grpOptional.ResumeLayout(false);
            grpOptional.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbShaderConfigPath;
        private TextBox txtShaderConfigPath;
        private ToolTip ttSettings;
        private Button btnShaderConfigPath;
        private Button btnSave;
        private GroupBox grpRequired;
        private GroupBox grpOptional;
        private Label lbDependencyRemapConfigPath;
        private TextBox txtDependencyRemapConfigPath;
        private Button btnDependencyRemapConfigPath;
    }
}