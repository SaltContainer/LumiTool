namespace LumiTool.Forms.WwiseActions
{
    partial class FormWwiseActionMute : FormWwiseActionBase
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
            grpActionResume = new GroupBox();
            grpExceptions = new GroupBox();
            lbExceptionBus = new Label();
            checkExceptionBus = new CheckBox();
            lbExceptionID = new Label();
            numExceptionID = new NumericUpDown();
            btnExceptionsEdit = new Button();
            btnExceptionsRemove = new Button();
            btnExceptionsAdd = new Button();
            listExceptions = new ListBox();
            lbFadeCurve = new Label();
            numFadeCurve = new NumericUpDown();
            grpActionResume.SuspendLayout();
            grpExceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numExceptionID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Size = new Size(626, 37);
            // 
            // grpActionResume
            // 
            grpActionResume.Controls.Add(grpExceptions);
            grpActionResume.Controls.Add(lbFadeCurve);
            grpActionResume.Controls.Add(numFadeCurve);
            grpActionResume.Location = new Point(328, 12);
            grpActionResume.Name = "grpActionResume";
            grpActionResume.Size = new Size(310, 644);
            grpActionResume.TabIndex = 5;
            grpActionResume.TabStop = false;
            grpActionResume.Text = "Action Mute";
            // 
            // grpExceptions
            // 
            grpExceptions.Controls.Add(lbExceptionBus);
            grpExceptions.Controls.Add(checkExceptionBus);
            grpExceptions.Controls.Add(lbExceptionID);
            grpExceptions.Controls.Add(numExceptionID);
            grpExceptions.Controls.Add(btnExceptionsEdit);
            grpExceptions.Controls.Add(btnExceptionsRemove);
            grpExceptions.Controls.Add(btnExceptionsAdd);
            grpExceptions.Controls.Add(listExceptions);
            grpExceptions.Location = new Point(6, 50);
            grpExceptions.Name = "grpExceptions";
            grpExceptions.Size = new Size(298, 257);
            grpExceptions.TabIndex = 15;
            grpExceptions.TabStop = false;
            grpExceptions.Text = "Exceptions";
            // 
            // lbExceptionBus
            // 
            lbExceptionBus.AutoSize = true;
            lbExceptionBus.Location = new Point(54, 154);
            lbExceptionBus.Name = "lbExceptionBus";
            lbExceptionBus.Size = new Size(40, 15);
            lbExceptionBus.TabIndex = 3;
            lbExceptionBus.Text = "Is Bus:";
            // 
            // checkExceptionBus
            // 
            checkExceptionBus.AutoSize = true;
            checkExceptionBus.Location = new Point(100, 155);
            checkExceptionBus.Name = "checkExceptionBus";
            checkExceptionBus.Size = new Size(15, 14);
            checkExceptionBus.TabIndex = 9;
            checkExceptionBus.UseVisualStyleBackColor = true;
            // 
            // lbExceptionID
            // 
            lbExceptionID.AutoSize = true;
            lbExceptionID.Location = new Point(73, 124);
            lbExceptionID.Name = "lbExceptionID";
            lbExceptionID.Size = new Size(21, 15);
            lbExceptionID.TabIndex = 1;
            lbExceptionID.Text = "ID:";
            // 
            // numExceptionID
            // 
            numExceptionID.Location = new Point(100, 122);
            numExceptionID.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numExceptionID.Name = "numExceptionID";
            numExceptionID.Size = new Size(147, 23);
            numExceptionID.TabIndex = 2;
            // 
            // btnExceptionsEdit
            // 
            btnExceptionsEdit.Image = LumiToolDotNet.Resources.Resources.pencil_big;
            btnExceptionsEdit.Location = new Point(253, 212);
            btnExceptionsEdit.Name = "btnExceptionsEdit";
            btnExceptionsEdit.Size = new Size(39, 39);
            btnExceptionsEdit.TabIndex = 7;
            btnExceptionsEdit.UseVisualStyleBackColor = true;
            btnExceptionsEdit.Click += btnExceptionsEdit_Click;
            // 
            // btnExceptionsRemove
            // 
            btnExceptionsRemove.Image = LumiToolDotNet.Resources.Resources.minus_big;
            btnExceptionsRemove.Location = new Point(253, 167);
            btnExceptionsRemove.Name = "btnExceptionsRemove";
            btnExceptionsRemove.Size = new Size(39, 39);
            btnExceptionsRemove.TabIndex = 6;
            btnExceptionsRemove.UseVisualStyleBackColor = true;
            btnExceptionsRemove.Click += btnExceptionsRemove_Click;
            // 
            // btnExceptionsAdd
            // 
            btnExceptionsAdd.Image = LumiToolDotNet.Resources.Resources.plus_big;
            btnExceptionsAdd.Location = new Point(253, 122);
            btnExceptionsAdd.Name = "btnExceptionsAdd";
            btnExceptionsAdd.Size = new Size(39, 39);
            btnExceptionsAdd.TabIndex = 5;
            btnExceptionsAdd.UseVisualStyleBackColor = true;
            btnExceptionsAdd.Click += btnExceptionsAdd_Click;
            // 
            // listExceptions
            // 
            listExceptions.FormattingEnabled = true;
            listExceptions.ItemHeight = 15;
            listExceptions.Location = new Point(6, 22);
            listExceptions.Name = "listExceptions";
            listExceptions.Size = new Size(286, 94);
            listExceptions.TabIndex = 0;
            listExceptions.SelectedIndexChanged += listExceptions_SelectedIndexChanged;
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
            // FormWwiseActionMute
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 711);
            Controls.Add(grpActionResume);
            MaximumSize = new Size(666, 750);
            MinimumSize = new Size(666, 750);
            Name = "FormWwiseActionMute";
            Text = "Enter Data for ActionMute";
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(grpActionResume, 0);
            grpActionResume.ResumeLayout(false);
            grpActionResume.PerformLayout();
            grpExceptions.ResumeLayout(false);
            grpExceptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numExceptionID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpActionResume;
        private GroupBox grpExceptions;
        private Label lbExceptionBus;
        private CheckBox checkExceptionBus;
        private Label lbExceptionID;
        private NumericUpDown numExceptionID;
        private Button btnExceptionsEdit;
        private Button btnExceptionsRemove;
        private Button btnExceptionsAdd;
        private ListBox listExceptions;
        private Label lbFadeCurve;
        private NumericUpDown numFadeCurve;
    }
}