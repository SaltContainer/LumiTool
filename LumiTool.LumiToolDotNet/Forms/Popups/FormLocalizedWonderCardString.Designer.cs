namespace LumiTool.Forms.Popups
{
    partial class FormLocalizedWonderCardString
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
            txtJPN = new TextBox();
            lbJPN = new Label();
            lbDescription = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            txtUSA = new TextBox();
            txtFRA = new TextBox();
            txtITA = new TextBox();
            txtDEU = new TextBox();
            txtESP = new TextBox();
            txtKOR = new TextBox();
            txtSCH = new TextBox();
            txtTCH = new TextBox();
            lbUSA = new Label();
            lbFRA = new Label();
            lbITA = new Label();
            lbDEU = new Label();
            lbESP = new Label();
            lbKOR = new Label();
            lbSCH = new Label();
            lbTCH = new Label();
            comboJPN = new ComboBox();
            comboUSA = new ComboBox();
            comboFRA = new ComboBox();
            comboITA = new ComboBox();
            comboDEU = new ComboBox();
            comboESP = new ComboBox();
            comboKOR = new ComboBox();
            comboSCH = new ComboBox();
            comboTCH = new ComboBox();
            SuspendLayout();
            // 
            // txtJPN
            // 
            txtJPN.Location = new Point(127, 49);
            txtJPN.Name = "txtJPN";
            txtJPN.Size = new Size(93, 23);
            txtJPN.TabIndex = 2;
            txtJPN.TextChanged += txtLANG_TextChanged;
            // 
            // lbJPN
            // 
            lbJPN.AutoSize = true;
            lbJPN.Location = new Point(64, 52);
            lbJPN.Name = "lbJPN";
            lbJPN.Size = new Size(57, 15);
            lbJPN.TabIndex = 1;
            lbJPN.Text = "Japanese:";
            // 
            // lbDescription
            // 
            lbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbDescription.Location = new Point(12, 9);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(310, 37);
            lbDescription.TabIndex = 0;
            lbDescription.Text = "Enter x in each available language.";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(12, 310);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(152, 39);
            btnConfirm.TabIndex = 19;
            btnConfirm.Text = "Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(170, 310);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(152, 39);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtUSA
            // 
            txtUSA.Location = new Point(127, 78);
            txtUSA.Name = "txtUSA";
            txtUSA.Size = new Size(93, 23);
            txtUSA.TabIndex = 4;
            txtUSA.TextChanged += txtLANG_TextChanged;
            // 
            // txtFRA
            // 
            txtFRA.Location = new Point(127, 107);
            txtFRA.Name = "txtFRA";
            txtFRA.Size = new Size(93, 23);
            txtFRA.TabIndex = 6;
            txtFRA.TextChanged += txtLANG_TextChanged;
            // 
            // txtITA
            // 
            txtITA.Location = new Point(127, 136);
            txtITA.Name = "txtITA";
            txtITA.Size = new Size(93, 23);
            txtITA.TabIndex = 8;
            txtITA.TextChanged += txtLANG_TextChanged;
            // 
            // txtDEU
            // 
            txtDEU.Location = new Point(127, 165);
            txtDEU.Name = "txtDEU";
            txtDEU.Size = new Size(93, 23);
            txtDEU.TabIndex = 10;
            txtDEU.TextChanged += txtLANG_TextChanged;
            // 
            // txtESP
            // 
            txtESP.Location = new Point(127, 194);
            txtESP.Name = "txtESP";
            txtESP.Size = new Size(93, 23);
            txtESP.TabIndex = 12;
            txtESP.TextChanged += txtLANG_TextChanged;
            // 
            // txtKOR
            // 
            txtKOR.Location = new Point(127, 223);
            txtKOR.Name = "txtKOR";
            txtKOR.Size = new Size(93, 23);
            txtKOR.TabIndex = 14;
            txtKOR.TextChanged += txtLANG_TextChanged;
            // 
            // txtSCH
            // 
            txtSCH.Location = new Point(127, 252);
            txtSCH.Name = "txtSCH";
            txtSCH.Size = new Size(93, 23);
            txtSCH.TabIndex = 16;
            txtSCH.TextChanged += txtLANG_TextChanged;
            // 
            // txtTCH
            // 
            txtTCH.Location = new Point(127, 281);
            txtTCH.Name = "txtTCH";
            txtTCH.Size = new Size(93, 23);
            txtTCH.TabIndex = 18;
            txtTCH.TextChanged += txtLANG_TextChanged;
            // 
            // lbUSA
            // 
            lbUSA.AutoSize = true;
            lbUSA.Location = new Point(73, 81);
            lbUSA.Name = "lbUSA";
            lbUSA.Size = new Size(48, 15);
            lbUSA.TabIndex = 3;
            lbUSA.Text = "English:";
            // 
            // lbFRA
            // 
            lbFRA.AutoSize = true;
            lbFRA.Location = new Point(75, 110);
            lbFRA.Name = "lbFRA";
            lbFRA.Size = new Size(46, 15);
            lbFRA.TabIndex = 5;
            lbFRA.Text = "French:";
            // 
            // lbITA
            // 
            lbITA.AutoSize = true;
            lbITA.Location = new Point(79, 139);
            lbITA.Name = "lbITA";
            lbITA.Size = new Size(42, 15);
            lbITA.TabIndex = 7;
            lbITA.Text = "Italian:";
            // 
            // lbDEU
            // 
            lbDEU.AutoSize = true;
            lbDEU.Location = new Point(69, 168);
            lbDEU.Name = "lbDEU";
            lbDEU.Size = new Size(52, 15);
            lbDEU.TabIndex = 9;
            lbDEU.Text = "German:";
            // 
            // lbESP
            // 
            lbESP.AutoSize = true;
            lbESP.Location = new Point(70, 197);
            lbESP.Name = "lbESP";
            lbESP.Size = new Size(51, 15);
            lbESP.TabIndex = 11;
            lbESP.Text = "Spanish:";
            // 
            // lbKOR
            // 
            lbKOR.AutoSize = true;
            lbKOR.Location = new Point(74, 226);
            lbKOR.Name = "lbKOR";
            lbKOR.Size = new Size(47, 15);
            lbKOR.TabIndex = 13;
            lbKOR.Text = "Korean:";
            // 
            // lbSCH
            // 
            lbSCH.AutoSize = true;
            lbSCH.Location = new Point(13, 255);
            lbSCH.Name = "lbSCH";
            lbSCH.Size = new Size(108, 15);
            lbSCH.TabIndex = 15;
            lbSCH.Text = "Simplified Chinese:";
            // 
            // lbTCH
            // 
            lbTCH.AutoSize = true;
            lbTCH.Location = new Point(11, 284);
            lbTCH.Name = "lbTCH";
            lbTCH.Size = new Size(110, 15);
            lbTCH.TabIndex = 17;
            lbTCH.Text = "Traditional Chinese:";
            // 
            // comboJPN
            // 
            comboJPN.FormattingEnabled = true;
            comboJPN.Location = new Point(226, 49);
            comboJPN.Name = "comboJPN";
            comboJPN.Size = new Size(96, 23);
            comboJPN.TabIndex = 21;
            // 
            // comboUSA
            // 
            comboUSA.FormattingEnabled = true;
            comboUSA.Location = new Point(226, 78);
            comboUSA.Name = "comboUSA";
            comboUSA.Size = new Size(96, 23);
            comboUSA.TabIndex = 22;
            // 
            // comboFRA
            // 
            comboFRA.FormattingEnabled = true;
            comboFRA.Location = new Point(226, 107);
            comboFRA.Name = "comboFRA";
            comboFRA.Size = new Size(96, 23);
            comboFRA.TabIndex = 23;
            // 
            // comboITA
            // 
            comboITA.FormattingEnabled = true;
            comboITA.Location = new Point(226, 136);
            comboITA.Name = "comboITA";
            comboITA.Size = new Size(96, 23);
            comboITA.TabIndex = 24;
            // 
            // comboDEU
            // 
            comboDEU.FormattingEnabled = true;
            comboDEU.Location = new Point(226, 165);
            comboDEU.Name = "comboDEU";
            comboDEU.Size = new Size(96, 23);
            comboDEU.TabIndex = 25;
            // 
            // comboESP
            // 
            comboESP.FormattingEnabled = true;
            comboESP.Location = new Point(226, 194);
            comboESP.Name = "comboESP";
            comboESP.Size = new Size(96, 23);
            comboESP.TabIndex = 26;
            // 
            // comboKOR
            // 
            comboKOR.FormattingEnabled = true;
            comboKOR.Location = new Point(226, 223);
            comboKOR.Name = "comboKOR";
            comboKOR.Size = new Size(96, 23);
            comboKOR.TabIndex = 27;
            // 
            // comboSCH
            // 
            comboSCH.FormattingEnabled = true;
            comboSCH.Location = new Point(226, 252);
            comboSCH.Name = "comboSCH";
            comboSCH.Size = new Size(96, 23);
            comboSCH.TabIndex = 28;
            // 
            // comboTCH
            // 
            comboTCH.FormattingEnabled = true;
            comboTCH.Location = new Point(226, 281);
            comboTCH.Name = "comboTCH";
            comboTCH.Size = new Size(96, 23);
            comboTCH.TabIndex = 29;
            // 
            // FormLocalizedWonderCardString
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 361);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(lbDescription);
            Controls.Add(lbJPN);
            Controls.Add(txtJPN);
            Controls.Add(comboJPN);
            Controls.Add(lbUSA);
            Controls.Add(txtUSA);
            Controls.Add(comboUSA);
            Controls.Add(lbFRA);
            Controls.Add(txtFRA);
            Controls.Add(comboFRA);
            Controls.Add(lbITA);
            Controls.Add(txtITA);
            Controls.Add(comboITA);
            Controls.Add(lbDEU);
            Controls.Add(txtDEU);
            Controls.Add(comboDEU);
            Controls.Add(lbESP);
            Controls.Add(txtESP);
            Controls.Add(comboESP);
            Controls.Add(lbKOR);
            Controls.Add(txtKOR);
            Controls.Add(comboKOR);
            Controls.Add(lbSCH);
            Controls.Add(txtSCH);
            Controls.Add(comboSCH);
            Controls.Add(lbTCH);
            Controls.Add(txtTCH);
            Controls.Add(comboTCH);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(350, 400);
            MinimizeBox = false;
            MinimumSize = new Size(350, 400);
            Name = "FormLocalizedWonderCardString";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Localized String";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtJPN;
        private Label lbJPN;
        private Label lbDescription;
        private Button btnConfirm;
        private Button btnCancel;
        private TextBox txtUSA;
        private TextBox txtFRA;
        private TextBox txtITA;
        private TextBox txtDEU;
        private TextBox txtESP;
        private TextBox txtKOR;
        private TextBox txtSCH;
        private TextBox txtTCH;
        private Label lbUSA;
        private Label lbFRA;
        private Label lbITA;
        private Label lbDEU;
        private Label lbESP;
        private Label lbKOR;
        private Label lbSCH;
        private Label lbTCH;
        private ComboBox comboJPN;
        private ComboBox comboUSA;
        private ComboBox comboFRA;
        private ComboBox comboITA;
        private ComboBox comboDEU;
        private ComboBox comboESP;
        private ComboBox comboKOR;
        private ComboBox comboSCH;
        private ComboBox comboTCH;
    }
}