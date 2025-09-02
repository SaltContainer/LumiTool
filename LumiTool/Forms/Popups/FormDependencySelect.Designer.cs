namespace LumiTool.Forms.Popups
{
    partial class FormDependencySelect
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
            btnConfirm = new Button();
            listDependencies = new CheckedListBox();
            SuspendLayout();
            // 
            // lbText
            // 
            lbText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbText.AutoSize = true;
            lbText.Location = new Point(12, 9);
            lbText.Name = "lbText";
            lbText.Size = new Size(223, 15);
            lbText.TabIndex = 0;
            lbText.Text = "Please select the dependencies to remap.";
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnConfirm.Location = new Point(12, 117);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(260, 32);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnSelect_Click;
            // 
            // listDependencies
            // 
            listDependencies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listDependencies.FormattingEnabled = true;
            listDependencies.Location = new Point(12, 35);
            listDependencies.Name = "listDependencies";
            listDependencies.Size = new Size(260, 76);
            listDependencies.TabIndex = 1;
            // 
            // FormDependencySelect
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 161);
            Controls.Add(listDependencies);
            Controls.Add(btnConfirm);
            Controls.Add(lbText);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(300, 200);
            MinimizeBox = false;
            MinimumSize = new Size(300, 162);
            Name = "FormDependencySelect";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Dependencies to Remap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbText;
        private Button btnConfirm;
        private CheckedListBox listDependencies;
    }
}