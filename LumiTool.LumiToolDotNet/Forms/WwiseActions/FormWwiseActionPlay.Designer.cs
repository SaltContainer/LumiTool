namespace LumiTool.Forms.WwiseActions
{
    partial class FormWwiseActionPlay : FormWwiseActionBase
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
            grpActionPlay = new GroupBox();
            lbFadeCurve = new Label();
            numFadeCurve = new NumericUpDown();
            numBankID = new NumericUpDown();
            lbBankID = new Label();
            grpActionPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBankID).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Size = new Size(626, 37);
            // 
            // grpActionPlay
            // 
            grpActionPlay.Controls.Add(lbBankID);
            grpActionPlay.Controls.Add(numBankID);
            grpActionPlay.Controls.Add(lbFadeCurve);
            grpActionPlay.Controls.Add(numFadeCurve);
            grpActionPlay.Location = new Point(328, 12);
            grpActionPlay.Name = "grpActionPlay";
            grpActionPlay.Size = new Size(310, 644);
            grpActionPlay.TabIndex = 5;
            grpActionPlay.TabStop = false;
            grpActionPlay.Text = "Action Play";
            // 
            // lbFadeCurve
            // 
            lbFadeCurve.AutoSize = true;
            lbFadeCurve.Location = new Point(102, 24);
            lbFadeCurve.Name = "lbFadeCurve";
            lbFadeCurve.Size = new Size(69, 15);
            lbFadeCurve.TabIndex = 10;
            lbFadeCurve.Text = "Fade Curve:";
            // 
            // numFadeCurve
            // 
            numFadeCurve.Location = new Point(177, 22);
            numFadeCurve.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numFadeCurve.Name = "numFadeCurve";
            numFadeCurve.Size = new Size(127, 23);
            numFadeCurve.TabIndex = 9;
            // 
            // numBankID
            // 
            numBankID.Location = new Point(177, 52);
            numBankID.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            numBankID.Name = "numBankID";
            numBankID.Size = new Size(127, 23);
            numBankID.TabIndex = 11;
            // 
            // lbBankID
            // 
            lbBankID.AutoSize = true;
            lbBankID.Location = new Point(121, 54);
            lbBankID.Name = "lbBankID";
            lbBankID.Size = new Size(50, 15);
            lbBankID.TabIndex = 12;
            lbBankID.Text = "Bank ID:";
            // 
            // FormWwiseActionPlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 711);
            Controls.Add(grpActionPlay);
            MaximumSize = new Size(666, 750);
            MinimumSize = new Size(666, 750);
            Name = "FormWwiseActionPlay";
            Text = "Enter Data for ActionPlay";
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(grpActionPlay, 0);
            grpActionPlay.ResumeLayout(false);
            grpActionPlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBankID).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpActionPlay;
        private Label lbFadeCurve;
        private NumericUpDown numFadeCurve;
        private Label lbBankID;
        private NumericUpDown numBankID;
    }
}