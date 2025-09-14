namespace LumiTool.Forms.WwiseActions
{
    partial class FormWwiseActionStop : FormWwiseActionBase
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
            grpActionStop = new GroupBox();
            grpExceptions = new GroupBox();
            lbExceptionBus = new Label();
            checkExceptionBus = new CheckBox();
            lbExceptionID = new Label();
            numExceptionID = new NumericUpDown();
            btnExceptionsAdd = new Button();
            btnExceptionsRemove = new Button();
            btnExceptionsEdit = new Button();
            listExceptions = new ListBox();
            lbDynamicSequence = new Label();
            checkDynamicSequence = new CheckBox();
            lbStateTransition = new Label();
            checkStateTransition = new CheckBox();
            lbFadeCurve = new Label();
            numFadeCurve = new NumericUpDown();
            grpActionStop.SuspendLayout();
            grpExceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numExceptionID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Size = new Size(626, 37);
            // 
            // grpActionStop
            // 
            grpActionStop.Controls.Add(grpExceptions);
            grpActionStop.Controls.Add(lbDynamicSequence);
            grpActionStop.Controls.Add(checkDynamicSequence);
            grpActionStop.Controls.Add(lbStateTransition);
            grpActionStop.Controls.Add(checkStateTransition);
            grpActionStop.Controls.Add(lbFadeCurve);
            grpActionStop.Controls.Add(numFadeCurve);
            grpActionStop.Location = new Point(328, 12);
            grpActionStop.Name = "grpActionStop";
            grpActionStop.Size = new Size(310, 644);
            grpActionStop.TabIndex = 1;
            grpActionStop.TabStop = false;
            grpActionStop.Text = "Action Stop";
            // 
            // grpExceptions
            // 
            grpExceptions.Controls.Add(lbExceptionBus);
            grpExceptions.Controls.Add(checkExceptionBus);
            grpExceptions.Controls.Add(lbExceptionID);
            grpExceptions.Controls.Add(numExceptionID);
            grpExceptions.Controls.Add(btnExceptionsAdd);
            grpExceptions.Controls.Add(btnExceptionsRemove);
            grpExceptions.Controls.Add(btnExceptionsEdit);
            grpExceptions.Controls.Add(listExceptions);
            grpExceptions.Location = new Point(6, 110);
            grpExceptions.Name = "grpExceptions";
            grpExceptions.Size = new Size(298, 257);
            grpExceptions.TabIndex = 8;
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
            // btnExceptionsAdd
            // 
            btnExceptionsAdd.Image = LumiToolDotNet.Resources.Resources.pencil_big;
            btnExceptionsAdd.Location = new Point(253, 212);
            btnExceptionsAdd.Name = "btnExceptionsAdd";
            btnExceptionsAdd.Size = new Size(39, 39);
            btnExceptionsAdd.TabIndex = 7;
            btnExceptionsAdd.UseVisualStyleBackColor = true;
            btnExceptionsAdd.Click += btnExceptionsAdd_Click;
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
            // btnExceptionsEdit
            // 
            btnExceptionsEdit.Image = LumiToolDotNet.Resources.Resources.plus_big;
            btnExceptionsEdit.Location = new Point(253, 122);
            btnExceptionsEdit.Name = "btnExceptionsEdit";
            btnExceptionsEdit.Size = new Size(39, 39);
            btnExceptionsEdit.TabIndex = 5;
            btnExceptionsEdit.UseVisualStyleBackColor = true;
            btnExceptionsEdit.Click += btnExceptionsEdit_Click;
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
            // lbDynamicSequence
            // 
            lbDynamicSequence.AutoSize = true;
            lbDynamicSequence.Location = new Point(12, 84);
            lbDynamicSequence.Name = "lbDynamicSequence";
            lbDynamicSequence.Size = new Size(159, 15);
            lbDynamicSequence.TabIndex = 6;
            lbDynamicSequence.Text = "Apply to Dynamic Sequence:";
            // 
            // checkDynamicSequence
            // 
            checkDynamicSequence.AutoSize = true;
            checkDynamicSequence.Location = new Point(177, 85);
            checkDynamicSequence.Name = "checkDynamicSequence";
            checkDynamicSequence.Size = new Size(15, 14);
            checkDynamicSequence.TabIndex = 7;
            checkDynamicSequence.UseVisualStyleBackColor = true;
            // 
            // lbStateTransition
            // 
            lbStateTransition.AutoSize = true;
            lbStateTransition.Location = new Point(28, 54);
            lbStateTransition.Name = "lbStateTransition";
            lbStateTransition.Size = new Size(143, 15);
            lbStateTransition.TabIndex = 4;
            lbStateTransition.Text = "Apply to State Transitions:";
            // 
            // checkStateTransition
            // 
            checkStateTransition.AutoSize = true;
            checkStateTransition.Location = new Point(177, 55);
            checkStateTransition.Name = "checkStateTransition";
            checkStateTransition.Size = new Size(15, 14);
            checkStateTransition.TabIndex = 5;
            checkStateTransition.UseVisualStyleBackColor = true;
            // 
            // lbFadeCurve
            // 
            lbFadeCurve.AutoSize = true;
            lbFadeCurve.Location = new Point(102, 24);
            lbFadeCurve.Name = "lbFadeCurve";
            lbFadeCurve.Size = new Size(69, 15);
            lbFadeCurve.TabIndex = 1;
            lbFadeCurve.Text = "Fade Curve:";
            // 
            // numFadeCurve
            // 
            numFadeCurve.Location = new Point(177, 22);
            numFadeCurve.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numFadeCurve.Name = "numFadeCurve";
            numFadeCurve.Size = new Size(127, 23);
            numFadeCurve.TabIndex = 0;
            // 
            // FormWwiseActionStop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 711);
            Controls.Add(grpActionStop);
            MaximumSize = new Size(666, 750);
            MinimumSize = new Size(666, 750);
            Name = "FormWwiseActionStop";
            Text = "Enter Data for ActionStop";
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(grpActionStop, 0);
            grpActionStop.ResumeLayout(false);
            grpActionStop.PerformLayout();
            grpExceptions.ResumeLayout(false);
            grpExceptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numExceptionID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpActionStop;
        private Label lbFadeCurve;
        private NumericUpDown numFadeCurve;
        private Label lbStateTransition;
        private CheckBox checkStateTransition;
        private Label lbDynamicSequence;
        private CheckBox checkDynamicSequence;
        private GroupBox grpExceptions;
        private Label lbExceptionBus;
        private Label lbExceptionID;
        private NumericUpDown numExceptionID;
        private Button btnExceptionsAdd;
        private Button btnExceptionsRemove;
        private Button btnExceptionsEdit;
        private ListBox listExceptions;
        private CheckBox checkExceptionBus;
    }
}