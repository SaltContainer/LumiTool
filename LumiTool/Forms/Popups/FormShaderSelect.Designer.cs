namespace LumiTool.Forms.Popups
{
    partial class FormShaderSelect
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
            lbText = new Label();
            comboShaders = new ComboBox();
            btnSelect = new Button();
            SuspendLayout();
            // 
            // lbText
            // 
            lbText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbText.Location = new Point(12, 9);
            lbText.Name = "lbText";
            lbText.Size = new Size(260, 38);
            lbText.TabIndex = 0;
            lbText.Text = "Please select the shader that material x uses.";
            // 
            // comboShaders
            // 
            comboShaders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboShaders.FormattingEnabled = true;
            comboShaders.Location = new Point(12, 50);
            comboShaders.Name = "comboShaders";
            comboShaders.Size = new Size(260, 23);
            comboShaders.TabIndex = 1;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSelect.Location = new Point(12, 79);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(260, 32);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // FormShaderSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 123);
            Controls.Add(btnSelect);
            Controls.Add(comboShaders);
            Controls.Add(lbText);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(300, 162);
            MinimizeBox = false;
            MinimumSize = new Size(300, 162);
            Name = "FormShaderSelect";
            Text = "Select Shader";
            ResumeLayout(false);
        }

        #endregion

        private Label lbText;
        private ComboBox comboShaders;
        private Button btnSelect;
    }
}