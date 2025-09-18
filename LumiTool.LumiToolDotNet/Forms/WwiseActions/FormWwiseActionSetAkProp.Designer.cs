namespace LumiTool.Forms.WwiseActions
{
    partial class FormWwiseActionSetAkProp : FormWwiseActionBase
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
            grpActionSetAkProp = new GroupBox();
            grpExceptions = new GroupBox();
            lbExceptionBus = new Label();
            checkExceptionBus = new CheckBox();
            lbExceptionID = new Label();
            numExceptionID = new NumericUpDown();
            btnExceptionsEdit = new Button();
            btnExceptionsRemove = new Button();
            btnExceptionsAdd = new Button();
            listExceptions = new ListBox();
            lbRandomMax = new Label();
            numRandomMax = new NumericUpDown();
            lbRandomMin = new Label();
            numRandomMin = new NumericUpDown();
            lbRandomBase = new Label();
            numRandomBase = new NumericUpDown();
            lbFadeCurve = new Label();
            numFadeCurve = new NumericUpDown();
            grpActionSetAkProp.SuspendLayout();
            grpExceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numExceptionID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRandomMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRandomMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRandomBase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Size = new Size(626, 37);
            // 
            // grpActionSetAkProp
            // 
            grpActionSetAkProp.Controls.Add(grpExceptions);
            grpActionSetAkProp.Controls.Add(lbRandomMax);
            grpActionSetAkProp.Controls.Add(numRandomMax);
            grpActionSetAkProp.Controls.Add(lbRandomMin);
            grpActionSetAkProp.Controls.Add(numRandomMin);
            grpActionSetAkProp.Controls.Add(lbRandomBase);
            grpActionSetAkProp.Controls.Add(numRandomBase);
            grpActionSetAkProp.Controls.Add(lbFadeCurve);
            grpActionSetAkProp.Controls.Add(numFadeCurve);
            grpActionSetAkProp.Location = new Point(328, 12);
            grpActionSetAkProp.Name = "grpActionSetAkProp";
            grpActionSetAkProp.Size = new Size(310, 644);
            grpActionSetAkProp.TabIndex = 5;
            grpActionSetAkProp.TabStop = false;
            grpActionSetAkProp.Text = "Action Set AK Prop";
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
            grpExceptions.Location = new Point(6, 140);
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
            // lbRandomMax
            // 
            lbRandomMax.AutoSize = true;
            lbRandomMax.Location = new Point(24, 114);
            lbRandomMax.Name = "lbRandomMax";
            lbRandomMax.Size = new Size(147, 15);
            lbRandomMax.TabIndex = 13;
            lbRandomMax.Text = "Randomizer Modifier Max:";
            // 
            // numRandomMax
            // 
            numRandomMax.DecimalPlaces = 5;
            numRandomMax.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRandomMax.Location = new Point(177, 112);
            numRandomMax.Maximum = new decimal(new int[] { 1215752191, 23, 0, 327680 });
            numRandomMax.Minimum = new decimal(new int[] { 1215752191, 23, 0, -2147155968 });
            numRandomMax.Name = "numRandomMax";
            numRandomMax.Size = new Size(127, 23);
            numRandomMax.TabIndex = 19;
            // 
            // lbRandomMin
            // 
            lbRandomMin.AutoSize = true;
            lbRandomMin.Location = new Point(26, 84);
            lbRandomMin.Name = "lbRandomMin";
            lbRandomMin.Size = new Size(145, 15);
            lbRandomMin.TabIndex = 11;
            lbRandomMin.Text = "Randomizer Modifier Min:";
            // 
            // numRandomMin
            // 
            numRandomMin.DecimalPlaces = 5;
            numRandomMin.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRandomMin.Location = new Point(177, 82);
            numRandomMin.Maximum = new decimal(new int[] { 1215752191, 23, 0, 327680 });
            numRandomMin.Minimum = new decimal(new int[] { 1215752191, 23, 0, -2147155968 });
            numRandomMin.Name = "numRandomMin";
            numRandomMin.Size = new Size(127, 23);
            numRandomMin.TabIndex = 18;
            // 
            // lbRandomBase
            // 
            lbRandomBase.AutoSize = true;
            lbRandomBase.Location = new Point(23, 54);
            lbRandomBase.Name = "lbRandomBase";
            lbRandomBase.Size = new Size(148, 15);
            lbRandomBase.TabIndex = 16;
            lbRandomBase.Text = "Randomizer Modifier Base:";
            // 
            // numRandomBase
            // 
            numRandomBase.DecimalPlaces = 5;
            numRandomBase.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRandomBase.Location = new Point(177, 52);
            numRandomBase.Maximum = new decimal(new int[] { 1215752191, 23, 0, 327680 });
            numRandomBase.Minimum = new decimal(new int[] { 1215752191, 23, 0, -2147155968 });
            numRandomBase.Name = "numRandomBase";
            numRandomBase.Size = new Size(127, 23);
            numRandomBase.TabIndex = 17;
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
            // FormWwiseActionSetAkProp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 711);
            Controls.Add(grpActionSetAkProp);
            MaximumSize = new Size(666, 750);
            MinimumSize = new Size(666, 750);
            Name = "FormWwiseActionSetAkProp";
            Text = "Enter Data for ActionSetAkProp";
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(grpActionSetAkProp, 0);
            grpActionSetAkProp.ResumeLayout(false);
            grpActionSetAkProp.PerformLayout();
            grpExceptions.ResumeLayout(false);
            grpExceptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numExceptionID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRandomMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRandomMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRandomBase).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFadeCurve).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpActionSetAkProp;
        private GroupBox grpExceptions;
        private Label lbExceptionBus;
        private CheckBox checkExceptionBus;
        private Label lbExceptionID;
        private NumericUpDown numExceptionID;
        private Button btnExceptionsEdit;
        private Button btnExceptionsRemove;
        private Button btnExceptionsAdd;
        private ListBox listExceptions;
        private Label lbRandomMax;
        private Label lbRandomMin;
        private Label lbRandomBase;
        private Label lbFadeCurve;
        private NumericUpDown numFadeCurve;
        private NumericUpDown numRandomMax;
        private NumericUpDown numRandomMin;
        private NumericUpDown numRandomBase;
    }
}