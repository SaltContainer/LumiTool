namespace LumiTool.Forms.WwiseActions
{
    partial class FormWwiseActionBase
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
            lbExtID = new Label();
            numExtID = new NumericUpDown();
            grpCommon = new GroupBox();
            grpBundle2 = new GroupBox();
            grpBundle3Max = new GroupBox();
            numBundle3Max3 = new NumericUpDown();
            numBundle3Max2 = new NumericUpDown();
            numBundle3Max1 = new NumericUpDown();
            numBundle3Max0 = new NumericUpDown();
            grpBundle3Min = new GroupBox();
            numBundle3Min3 = new NumericUpDown();
            numBundle3Min2 = new NumericUpDown();
            numBundle3Min1 = new NumericUpDown();
            numBundle3Min0 = new NumericUpDown();
            lbBundle3ID = new Label();
            numBundle3ID = new NumericUpDown();
            btnEditBundle3 = new Button();
            btnRemoveBundle3 = new Button();
            btnAddBundle3 = new Button();
            listBundle2 = new ListBox();
            groupBundle0 = new GroupBox();
            lbBundle1Value = new Label();
            numBundle1Value = new NumericUpDown();
            lbBundle1ID = new Label();
            numBundle1ID = new NumericUpDown();
            btnEditBundle1 = new Button();
            btnRemoveBundle1 = new Button();
            btnAddBundle1 = new Button();
            listBundle0 = new ListBox();
            lbIsBus = new Label();
            checkIsBus = new CheckBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numExtID).BeginInit();
            grpCommon.SuspendLayout();
            grpBundle2.SuspendLayout();
            grpBundle3Max.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBundle3Max3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Max2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Max1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Max0).BeginInit();
            grpBundle3Min.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBundle3Min3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Min2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Min1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Min0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3ID).BeginInit();
            groupBundle0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBundle1Value).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBundle1ID).BeginInit();
            SuspendLayout();
            // 
            // lbExtID
            // 
            lbExtID.AutoSize = true;
            lbExtID.Location = new Point(60, 24);
            lbExtID.Name = "lbExtID";
            lbExtID.Size = new Size(40, 15);
            lbExtID.TabIndex = 0;
            lbExtID.Text = "ID Ext:";
            // 
            // numExtID
            // 
            numExtID.Location = new Point(106, 22);
            numExtID.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            numExtID.Name = "numExtID";
            numExtID.Size = new Size(198, 23);
            numExtID.TabIndex = 1;
            // 
            // grpCommon
            // 
            grpCommon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpCommon.Controls.Add(grpBundle2);
            grpCommon.Controls.Add(groupBundle0);
            grpCommon.Controls.Add(lbIsBus);
            grpCommon.Controls.Add(checkIsBus);
            grpCommon.Controls.Add(lbExtID);
            grpCommon.Controls.Add(numExtID);
            grpCommon.Location = new Point(12, 12);
            grpCommon.Name = "grpCommon";
            grpCommon.Size = new Size(310, 644);
            grpCommon.TabIndex = 0;
            grpCommon.TabStop = false;
            grpCommon.Text = "Common Data";
            // 
            // grpBundle2
            // 
            grpBundle2.Controls.Add(grpBundle3Max);
            grpBundle2.Controls.Add(grpBundle3Min);
            grpBundle2.Controls.Add(lbBundle3ID);
            grpBundle2.Controls.Add(numBundle3ID);
            grpBundle2.Controls.Add(btnEditBundle3);
            grpBundle2.Controls.Add(btnRemoveBundle3);
            grpBundle2.Controls.Add(btnAddBundle3);
            grpBundle2.Controls.Add(listBundle2);
            grpBundle2.Location = new Point(6, 343);
            grpBundle2.Name = "grpBundle2";
            grpBundle2.Size = new Size(298, 295);
            grpBundle2.TabIndex = 5;
            grpBundle2.TabStop = false;
            grpBundle2.Text = "Prop Bundle 2";
            // 
            // grpBundle3Max
            // 
            grpBundle3Max.Controls.Add(numBundle3Max3);
            grpBundle3Max.Controls.Add(numBundle3Max2);
            grpBundle3Max.Controls.Add(numBundle3Max1);
            grpBundle3Max.Controls.Add(numBundle3Max0);
            grpBundle3Max.Location = new Point(177, 151);
            grpBundle3Max.Name = "grpBundle3Max";
            grpBundle3Max.Size = new Size(70, 138);
            grpBundle3Max.TabIndex = 4;
            grpBundle3Max.TabStop = false;
            grpBundle3Max.Text = "Max";
            // 
            // numBundle3Max3
            // 
            numBundle3Max3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numBundle3Max3.Location = new Point(6, 109);
            numBundle3Max3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3Max3.Name = "numBundle3Max3";
            numBundle3Max3.Size = new Size(58, 23);
            numBundle3Max3.TabIndex = 3;
            // 
            // numBundle3Max2
            // 
            numBundle3Max2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numBundle3Max2.Location = new Point(6, 80);
            numBundle3Max2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3Max2.Name = "numBundle3Max2";
            numBundle3Max2.Size = new Size(58, 23);
            numBundle3Max2.TabIndex = 2;
            // 
            // numBundle3Max1
            // 
            numBundle3Max1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numBundle3Max1.Location = new Point(6, 51);
            numBundle3Max1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3Max1.Name = "numBundle3Max1";
            numBundle3Max1.Size = new Size(58, 23);
            numBundle3Max1.TabIndex = 1;
            // 
            // numBundle3Max0
            // 
            numBundle3Max0.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numBundle3Max0.Location = new Point(6, 22);
            numBundle3Max0.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3Max0.Name = "numBundle3Max0";
            numBundle3Max0.Size = new Size(58, 23);
            numBundle3Max0.TabIndex = 0;
            // 
            // grpBundle3Min
            // 
            grpBundle3Min.Controls.Add(numBundle3Min3);
            grpBundle3Min.Controls.Add(numBundle3Min2);
            grpBundle3Min.Controls.Add(numBundle3Min1);
            grpBundle3Min.Controls.Add(numBundle3Min0);
            grpBundle3Min.Location = new Point(100, 151);
            grpBundle3Min.Name = "grpBundle3Min";
            grpBundle3Min.Size = new Size(70, 138);
            grpBundle3Min.TabIndex = 3;
            grpBundle3Min.TabStop = false;
            grpBundle3Min.Text = "Min";
            // 
            // numBundle3Min3
            // 
            numBundle3Min3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numBundle3Min3.Location = new Point(6, 109);
            numBundle3Min3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3Min3.Name = "numBundle3Min3";
            numBundle3Min3.Size = new Size(58, 23);
            numBundle3Min3.TabIndex = 3;
            // 
            // numBundle3Min2
            // 
            numBundle3Min2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numBundle3Min2.Location = new Point(6, 80);
            numBundle3Min2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3Min2.Name = "numBundle3Min2";
            numBundle3Min2.Size = new Size(58, 23);
            numBundle3Min2.TabIndex = 2;
            // 
            // numBundle3Min1
            // 
            numBundle3Min1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numBundle3Min1.Location = new Point(6, 51);
            numBundle3Min1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3Min1.Name = "numBundle3Min1";
            numBundle3Min1.Size = new Size(58, 23);
            numBundle3Min1.TabIndex = 1;
            // 
            // numBundle3Min0
            // 
            numBundle3Min0.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numBundle3Min0.Location = new Point(6, 22);
            numBundle3Min0.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3Min0.Name = "numBundle3Min0";
            numBundle3Min0.Size = new Size(58, 23);
            numBundle3Min0.TabIndex = 0;
            // 
            // lbBundle3ID
            // 
            lbBundle3ID.AutoSize = true;
            lbBundle3ID.Location = new Point(73, 124);
            lbBundle3ID.Name = "lbBundle3ID";
            lbBundle3ID.Size = new Size(21, 15);
            lbBundle3ID.TabIndex = 1;
            lbBundle3ID.Text = "ID:";
            // 
            // numBundle3ID
            // 
            numBundle3ID.Location = new Point(100, 122);
            numBundle3ID.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle3ID.Name = "numBundle3ID";
            numBundle3ID.Size = new Size(147, 23);
            numBundle3ID.TabIndex = 2;
            // 
            // btnEditBundle3
            // 
            btnEditBundle3.Image = LumiToolDotNet.Resources.Resources.pencil_big;
            btnEditBundle3.Location = new Point(253, 212);
            btnEditBundle3.Name = "btnEditBundle3";
            btnEditBundle3.Size = new Size(39, 39);
            btnEditBundle3.TabIndex = 7;
            btnEditBundle3.UseVisualStyleBackColor = true;
            btnEditBundle3.Click += btnEditBundle3_Click;
            // 
            // btnRemoveBundle3
            // 
            btnRemoveBundle3.Image = LumiToolDotNet.Resources.Resources.minus_big;
            btnRemoveBundle3.Location = new Point(253, 167);
            btnRemoveBundle3.Name = "btnRemoveBundle3";
            btnRemoveBundle3.Size = new Size(39, 39);
            btnRemoveBundle3.TabIndex = 6;
            btnRemoveBundle3.UseVisualStyleBackColor = true;
            btnRemoveBundle3.Click += btnRemoveBundle3_Click;
            // 
            // btnAddBundle3
            // 
            btnAddBundle3.Image = LumiToolDotNet.Resources.Resources.plus_big;
            btnAddBundle3.Location = new Point(253, 122);
            btnAddBundle3.Name = "btnAddBundle3";
            btnAddBundle3.Size = new Size(39, 39);
            btnAddBundle3.TabIndex = 5;
            btnAddBundle3.UseVisualStyleBackColor = true;
            btnAddBundle3.Click += btnAddBundle3_Click;
            // 
            // listBundle2
            // 
            listBundle2.FormattingEnabled = true;
            listBundle2.ItemHeight = 15;
            listBundle2.Location = new Point(6, 22);
            listBundle2.Name = "listBundle2";
            listBundle2.Size = new Size(286, 94);
            listBundle2.TabIndex = 0;
            listBundle2.SelectedIndexChanged += listBundle2_SelectedIndexChanged;
            // 
            // groupBundle0
            // 
            groupBundle0.Controls.Add(lbBundle1Value);
            groupBundle0.Controls.Add(numBundle1Value);
            groupBundle0.Controls.Add(lbBundle1ID);
            groupBundle0.Controls.Add(numBundle1ID);
            groupBundle0.Controls.Add(btnEditBundle1);
            groupBundle0.Controls.Add(btnRemoveBundle1);
            groupBundle0.Controls.Add(btnAddBundle1);
            groupBundle0.Controls.Add(listBundle0);
            groupBundle0.Location = new Point(6, 80);
            groupBundle0.Name = "groupBundle0";
            groupBundle0.Size = new Size(298, 257);
            groupBundle0.TabIndex = 4;
            groupBundle0.TabStop = false;
            groupBundle0.Text = "Prop Bundle 0";
            // 
            // lbBundle1Value
            // 
            lbBundle1Value.AutoSize = true;
            lbBundle1Value.Location = new Point(56, 153);
            lbBundle1Value.Name = "lbBundle1Value";
            lbBundle1Value.Size = new Size(38, 15);
            lbBundle1Value.TabIndex = 3;
            lbBundle1Value.Text = "Value:";
            // 
            // numBundle1Value
            // 
            numBundle1Value.DecimalPlaces = 5;
            numBundle1Value.Location = new Point(100, 151);
            numBundle1Value.Maximum = new decimal(new int[] { 1215752191, 23, 0, 327680 });
            numBundle1Value.Minimum = new decimal(new int[] { 1215752191, 23, 0, -2147155968 });
            numBundle1Value.Name = "numBundle1Value";
            numBundle1Value.Size = new Size(147, 23);
            numBundle1Value.TabIndex = 4;
            // 
            // lbBundle1ID
            // 
            lbBundle1ID.AutoSize = true;
            lbBundle1ID.Location = new Point(73, 124);
            lbBundle1ID.Name = "lbBundle1ID";
            lbBundle1ID.Size = new Size(21, 15);
            lbBundle1ID.TabIndex = 1;
            lbBundle1ID.Text = "ID:";
            // 
            // numBundle1ID
            // 
            numBundle1ID.Location = new Point(100, 122);
            numBundle1ID.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBundle1ID.Name = "numBundle1ID";
            numBundle1ID.Size = new Size(147, 23);
            numBundle1ID.TabIndex = 2;
            // 
            // btnEditBundle1
            // 
            btnEditBundle1.Image = LumiToolDotNet.Resources.Resources.pencil_big;
            btnEditBundle1.Location = new Point(253, 212);
            btnEditBundle1.Name = "btnEditBundle1";
            btnEditBundle1.Size = new Size(39, 39);
            btnEditBundle1.TabIndex = 7;
            btnEditBundle1.UseVisualStyleBackColor = true;
            btnEditBundle1.Click += btnEditBundle1_Click;
            // 
            // btnRemoveBundle1
            // 
            btnRemoveBundle1.Image = LumiToolDotNet.Resources.Resources.minus_big;
            btnRemoveBundle1.Location = new Point(253, 167);
            btnRemoveBundle1.Name = "btnRemoveBundle1";
            btnRemoveBundle1.Size = new Size(39, 39);
            btnRemoveBundle1.TabIndex = 6;
            btnRemoveBundle1.UseVisualStyleBackColor = true;
            btnRemoveBundle1.Click += btnRemoveBundle1_Click;
            // 
            // btnAddBundle1
            // 
            btnAddBundle1.Image = LumiToolDotNet.Resources.Resources.plus_big;
            btnAddBundle1.Location = new Point(253, 122);
            btnAddBundle1.Name = "btnAddBundle1";
            btnAddBundle1.Size = new Size(39, 39);
            btnAddBundle1.TabIndex = 5;
            btnAddBundle1.UseVisualStyleBackColor = true;
            btnAddBundle1.Click += btnAddBundle1_Click;
            // 
            // listBundle0
            // 
            listBundle0.FormattingEnabled = true;
            listBundle0.ItemHeight = 15;
            listBundle0.Location = new Point(6, 22);
            listBundle0.Name = "listBundle0";
            listBundle0.Size = new Size(286, 94);
            listBundle0.TabIndex = 0;
            listBundle0.SelectedIndexChanged += listBundle0_SelectedIndexChanged;
            // 
            // lbIsBus
            // 
            lbIsBus.AutoSize = true;
            lbIsBus.Location = new Point(60, 54);
            lbIsBus.Name = "lbIsBus";
            lbIsBus.Size = new Size(40, 15);
            lbIsBus.TabIndex = 2;
            lbIsBus.Text = "Is Bus:";
            // 
            // checkIsBus
            // 
            checkIsBus.AutoSize = true;
            checkIsBus.Location = new Point(106, 55);
            checkIsBus.Name = "checkIsBus";
            checkIsBus.Size = new Size(15, 14);
            checkIsBus.TabIndex = 3;
            checkIsBus.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.Location = new Point(12, 662);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(310, 37);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FormWwiseActionBase
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 711);
            Controls.Add(btnSave);
            Controls.Add(grpCommon);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(350, 750);
            MinimizeBox = false;
            MinimumSize = new Size(350, 750);
            Name = "FormWwiseActionBase";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter Data For Action";
            ((System.ComponentModel.ISupportInitialize)numExtID).EndInit();
            grpCommon.ResumeLayout(false);
            grpCommon.PerformLayout();
            grpBundle2.ResumeLayout(false);
            grpBundle2.PerformLayout();
            grpBundle3Max.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numBundle3Max3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Max2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Max1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Max0).EndInit();
            grpBundle3Min.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numBundle3Min3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Min2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Min1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3Min0).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBundle3ID).EndInit();
            groupBundle0.ResumeLayout(false);
            groupBundle0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBundle1Value).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBundle1ID).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbExtID;
        private NumericUpDown numExtID;
        private GroupBox grpCommon;
        private Label lbIsBus;
        private CheckBox checkIsBus;
        private GroupBox groupBundle0;
        private ListBox listBundle0;
        private Button btnEditBundle1;
        private Button btnRemoveBundle1;
        private Button btnAddBundle1;
        private Label lbBundle1Value;
        private NumericUpDown numBundle1Value;
        private Label lbBundle1ID;
        private NumericUpDown numBundle1ID;
        private GroupBox grpBundle2;
        private NumericUpDown numBundle3Min0;
        private Label lbBundle3ID;
        private NumericUpDown numBundle3ID;
        private Button btnEditBundle3;
        private Button btnRemoveBundle3;
        private Button btnAddBundle3;
        private ListBox listBundle2;
        private NumericUpDown numBundle3Min3;
        private GroupBox grpBundle3Min;
        private NumericUpDown numBundle3Min2;
        private NumericUpDown numBundle3Min1;
        private GroupBox grpBundle3Max;
        private NumericUpDown numBundle3Max3;
        private NumericUpDown numBundle3Max2;
        private NumericUpDown numBundle3Max1;
        private NumericUpDown numBundle3Max0;
        protected Button btnSave;
    }
}