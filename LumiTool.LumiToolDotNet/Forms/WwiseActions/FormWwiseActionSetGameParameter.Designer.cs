namespace LumiTool.Forms.WwiseActions
{
    partial class FormWwiseActionSetGameParameter : FormWwiseActionBase
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
            grpActionSetGameParameter = new GroupBox();
            grpExceptions = new GroupBox();
            lbExceptionBus = new Label();
            checkExceptionBus = new CheckBox();
            lbExceptionID = new Label();
            numExceptionID = new NumericUpDown();
            btnExceptionsEdit = new Button();
            btnExceptionsRemove = new Button();
            btnExceptionsAdd = new Button();
            listExceptions = new ListBox();
            lbRangedMax = new Label();
            numRangedMax = new NumericUpDown();
            lbRangedMin = new Label();
            numRangedMin = new NumericUpDown();
            lbRangedBase = new Label();
            numRangedBase = new NumericUpDown();
            lbValueMeaning = new Label();
            numValueMeaning = new NumericUpDown();
            lbBypassTransition = new Label();
            numBypassTransition = new NumericUpDown();
            lbFadeCurve = new Label();
            numFadeCurve = new NumericUpDown();
            grpActionSetGameParameter.SuspendLayout();
            grpExceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numExceptionID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRangedMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRangedMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRangedBase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numValueMeaning).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBypassTransition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Size = new Size(626, 37);
            // 
            // grpActionSetGameParameter
            // 
            grpActionSetGameParameter.Controls.Add(grpExceptions);
            grpActionSetGameParameter.Controls.Add(lbRangedMax);
            grpActionSetGameParameter.Controls.Add(numRangedMax);
            grpActionSetGameParameter.Controls.Add(lbRangedMin);
            grpActionSetGameParameter.Controls.Add(numRangedMin);
            grpActionSetGameParameter.Controls.Add(lbRangedBase);
            grpActionSetGameParameter.Controls.Add(numRangedBase);
            grpActionSetGameParameter.Controls.Add(lbValueMeaning);
            grpActionSetGameParameter.Controls.Add(numValueMeaning);
            grpActionSetGameParameter.Controls.Add(lbBypassTransition);
            grpActionSetGameParameter.Controls.Add(numBypassTransition);
            grpActionSetGameParameter.Controls.Add(lbFadeCurve);
            grpActionSetGameParameter.Controls.Add(numFadeCurve);
            grpActionSetGameParameter.Location = new Point(328, 12);
            grpActionSetGameParameter.Name = "grpActionSetGameParameter";
            grpActionSetGameParameter.Size = new Size(310, 644);
            grpActionSetGameParameter.TabIndex = 5;
            grpActionSetGameParameter.TabStop = false;
            grpActionSetGameParameter.Text = "Action Set Game Parameter";
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
            grpExceptions.Location = new Point(6, 200);
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
            // lbRangedMax
            // 
            lbRangedMax.AutoSize = true;
            lbRangedMax.Location = new Point(38, 174);
            lbRangedMax.Name = "lbRangedMax";
            lbRangedMax.Size = new Size(133, 15);
            lbRangedMax.TabIndex = 21;
            lbRangedMax.Text = "Ranged Parameter Max:";
            // 
            // numRangedMax
            // 
            numRangedMax.DecimalPlaces = 5;
            numRangedMax.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRangedMax.Location = new Point(177, 172);
            numRangedMax.Maximum = new decimal(new int[] { 1215752191, 23, 0, 327680 });
            numRangedMax.Minimum = new decimal(new int[] { 1215752191, 23, 0, -2147155968 });
            numRangedMax.Name = "numRangedMax";
            numRangedMax.Size = new Size(127, 23);
            numRangedMax.TabIndex = 25;
            // 
            // lbRangedMin
            // 
            lbRangedMin.AutoSize = true;
            lbRangedMin.Location = new Point(40, 144);
            lbRangedMin.Name = "lbRangedMin";
            lbRangedMin.Size = new Size(131, 15);
            lbRangedMin.TabIndex = 20;
            lbRangedMin.Text = "Ranged Parameter Min:";
            // 
            // numRangedMin
            // 
            numRangedMin.DecimalPlaces = 5;
            numRangedMin.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRangedMin.Location = new Point(177, 142);
            numRangedMin.Maximum = new decimal(new int[] { 1215752191, 23, 0, 327680 });
            numRangedMin.Minimum = new decimal(new int[] { 1215752191, 23, 0, -2147155968 });
            numRangedMin.Name = "numRangedMin";
            numRangedMin.Size = new Size(127, 23);
            numRangedMin.TabIndex = 24;
            // 
            // lbRangedBase
            // 
            lbRangedBase.AutoSize = true;
            lbRangedBase.Location = new Point(37, 114);
            lbRangedBase.Name = "lbRangedBase";
            lbRangedBase.Size = new Size(134, 15);
            lbRangedBase.TabIndex = 22;
            lbRangedBase.Text = "Ranged Parameter Base:";
            // 
            // numRangedBase
            // 
            numRangedBase.DecimalPlaces = 5;
            numRangedBase.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRangedBase.Location = new Point(177, 112);
            numRangedBase.Maximum = new decimal(new int[] { 1215752191, 23, 0, 327680 });
            numRangedBase.Minimum = new decimal(new int[] { 1215752191, 23, 0, -2147155968 });
            numRangedBase.Name = "numRangedBase";
            numRangedBase.Size = new Size(127, 23);
            numRangedBase.TabIndex = 23;
            // 
            // lbValueMeaning
            // 
            lbValueMeaning.AutoSize = true;
            lbValueMeaning.Location = new Point(83, 84);
            lbValueMeaning.Name = "lbValueMeaning";
            lbValueMeaning.Size = new Size(88, 15);
            lbValueMeaning.TabIndex = 19;
            lbValueMeaning.Text = "Value Meaning:";
            // 
            // numValueMeaning
            // 
            numValueMeaning.Location = new Point(177, 82);
            numValueMeaning.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numValueMeaning.Name = "numValueMeaning";
            numValueMeaning.Size = new Size(127, 23);
            numValueMeaning.TabIndex = 18;
            // 
            // lbBypassTransition
            // 
            lbBypassTransition.AutoSize = true;
            lbBypassTransition.Location = new Point(71, 54);
            lbBypassTransition.Name = "lbBypassTransition";
            lbBypassTransition.Size = new Size(100, 15);
            lbBypassTransition.TabIndex = 17;
            lbBypassTransition.Text = "Bypass Transition:";
            // 
            // numBypassTransition
            // 
            numBypassTransition.Location = new Point(177, 52);
            numBypassTransition.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBypassTransition.Name = "numBypassTransition";
            numBypassTransition.Size = new Size(127, 23);
            numBypassTransition.TabIndex = 16;
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
            // FormWwiseActionSetGameParameter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 711);
            Controls.Add(grpActionSetGameParameter);
            MaximumSize = new Size(666, 750);
            MinimumSize = new Size(666, 750);
            Name = "FormWwiseActionSetGameParameter";
            Text = "Enter Data for ActionSetGameParameter";
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(grpActionSetGameParameter, 0);
            grpActionSetGameParameter.ResumeLayout(false);
            grpActionSetGameParameter.PerformLayout();
            grpExceptions.ResumeLayout(false);
            grpExceptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numExceptionID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRangedMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRangedMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRangedBase).EndInit();
            ((System.ComponentModel.ISupportInitialize)numValueMeaning).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBypassTransition).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpActionSetGameParameter;
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
        private Label lbBypassTransition;
        private NumericUpDown numBypassTransition;
        private Label lbValueMeaning;
        private NumericUpDown numValueMeaning;
        private Label lbRangedMax;
        private NumericUpDown numRangedMax;
        private Label lbRangedMin;
        private NumericUpDown numRangedMin;
        private Label lbRangedBase;
        private NumericUpDown numRangedBase;
    }
}