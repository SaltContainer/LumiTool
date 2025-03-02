namespace LumiTool.Forms
{
    partial class FormWwiseEventCloner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWwiseEventCloner));
            btnApply = new Button();
            lbNewEvent = new Label();
            lbOldEvent = new Label();
            txtNewEvent = new TextBox();
            txtOldEvent = new TextBox();
            grpBank = new GroupBox();
            lbBankName = new Label();
            btnBankOpen = new Button();
            btnBankSave = new Button();
            ttWwiseBankCloner = new ToolTip(components);
            txtGroup = new TextBox();
            lbGroup = new Label();
            grpLoop = new GroupBox();
            lbTotalDuration = new Label();
            lbLoopEnd = new Label();
            lbLoopStart = new Label();
            lbInitialDelay = new Label();
            numTotalDuration = new NumericUpDown();
            numLoopEnd = new NumericUpDown();
            numLoopStart = new NumericUpDown();
            numInitialDelay = new NumericUpDown();
            checkLoop = new CheckBox();
            btnOldEventHash = new Button();
            btnNewEventHash = new Button();
            btnGroupHash = new Button();
            grpBank.SuspendLayout();
            grpLoop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLoopEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLoopStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numInitialDelay).BeginInit();
            SuspendLayout();
            // 
            // btnApply
            // 
            btnApply.Location = new Point(278, 191);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(249, 41);
            btnApply.TabIndex = 22;
            btnApply.Text = "Clone";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // lbNewEvent
            // 
            lbNewEvent.AutoSize = true;
            lbNewEvent.Location = new Point(12, 136);
            lbNewEvent.Name = "lbNewEvent";
            lbNewEvent.Size = new Size(101, 15);
            lbNewEvent.TabIndex = 21;
            lbNewEvent.Text = "New Event Name:";
            // 
            // lbOldEvent
            // 
            lbOldEvent.AutoSize = true;
            lbOldEvent.Location = new Point(12, 107);
            lbOldEvent.Name = "lbOldEvent";
            lbOldEvent.Size = new Size(123, 15);
            lbOldEvent.TabIndex = 20;
            lbOldEvent.Text = "Event Name To Clone:";
            // 
            // txtNewEvent
            // 
            txtNewEvent.Location = new Point(119, 133);
            txtNewEvent.Name = "txtNewEvent";
            txtNewEvent.Size = new Size(121, 23);
            txtNewEvent.TabIndex = 19;
            // 
            // txtOldEvent
            // 
            txtOldEvent.Location = new Point(141, 104);
            txtOldEvent.Name = "txtOldEvent";
            txtOldEvent.Size = new Size(99, 23);
            txtOldEvent.TabIndex = 18;
            // 
            // grpBank
            // 
            grpBank.Controls.Add(lbBankName);
            grpBank.Controls.Add(btnBankOpen);
            grpBank.Controls.Add(btnBankSave);
            grpBank.Location = new Point(12, 12);
            grpBank.Name = "grpBank";
            grpBank.Size = new Size(260, 86);
            grpBank.TabIndex = 17;
            grpBank.TabStop = false;
            grpBank.Text = "Loaded Bank";
            // 
            // lbBankName
            // 
            lbBankName.AutoSize = true;
            lbBankName.Location = new Point(6, 19);
            lbBankName.Name = "lbBankName";
            lbBankName.Size = new Size(74, 15);
            lbBankName.TabIndex = 1;
            lbBankName.Text = "Bank Name: ";
            // 
            // btnBankOpen
            // 
            btnBankOpen.AllowDrop = true;
            btnBankOpen.Image = Resources.Resources.folder;
            btnBankOpen.Location = new Point(6, 40);
            btnBankOpen.Name = "btnBankOpen";
            btnBankOpen.Size = new Size(121, 40);
            btnBankOpen.TabIndex = 0;
            btnBankOpen.Text = "Open";
            btnBankOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBankOpen.UseVisualStyleBackColor = true;
            btnBankOpen.Click += btnBankOpen_Click;
            btnBankOpen.DragDrop += btnBankOpen_DragDrop;
            btnBankOpen.DragEnter += btnBankOpen_DragEnter;
            // 
            // btnBankSave
            // 
            btnBankSave.Image = Resources.Resources.save;
            btnBankSave.Location = new Point(133, 40);
            btnBankSave.Name = "btnBankSave";
            btnBankSave.Size = new Size(121, 40);
            btnBankSave.TabIndex = 2;
            btnBankSave.Text = "Save";
            btnBankSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBankSave.UseVisualStyleBackColor = true;
            btnBankSave.Click += btnBankSave_Click;
            // 
            // txtGroup
            // 
            txtGroup.Location = new Point(96, 162);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(144, 23);
            txtGroup.TabIndex = 23;
            // 
            // lbGroup
            // 
            lbGroup.AutoSize = true;
            lbGroup.Location = new Point(12, 165);
            lbGroup.Name = "lbGroup";
            lbGroup.Size = new Size(78, 15);
            lbGroup.TabIndex = 24;
            lbGroup.Text = "Group Name:";
            // 
            // grpLoop
            // 
            grpLoop.Controls.Add(lbTotalDuration);
            grpLoop.Controls.Add(lbLoopEnd);
            grpLoop.Controls.Add(lbLoopStart);
            grpLoop.Controls.Add(lbInitialDelay);
            grpLoop.Controls.Add(numTotalDuration);
            grpLoop.Controls.Add(numLoopEnd);
            grpLoop.Controls.Add(numLoopStart);
            grpLoop.Controls.Add(numInitialDelay);
            grpLoop.Controls.Add(checkLoop);
            grpLoop.Location = new Point(278, 12);
            grpLoop.Name = "grpLoop";
            grpLoop.Size = new Size(249, 173);
            grpLoop.TabIndex = 25;
            grpLoop.TabStop = false;
            grpLoop.Text = "Looping";
            // 
            // lbTotalDuration
            // 
            lbTotalDuration.AutoSize = true;
            lbTotalDuration.Location = new Point(6, 140);
            lbTotalDuration.Name = "lbTotalDuration";
            lbTotalDuration.Size = new Size(114, 15);
            lbTotalDuration.TabIndex = 4;
            lbTotalDuration.Text = "Total Source Length:";
            // 
            // lbLoopEnd
            // 
            lbLoopEnd.AutoSize = true;
            lbLoopEnd.Location = new Point(60, 111);
            lbLoopEnd.Name = "lbLoopEnd";
            lbLoopEnd.Size = new Size(60, 15);
            lbLoopEnd.TabIndex = 3;
            lbLoopEnd.Text = "Loop End:";
            // 
            // lbLoopStart
            // 
            lbLoopStart.AutoSize = true;
            lbLoopStart.Location = new Point(56, 82);
            lbLoopStart.Name = "lbLoopStart";
            lbLoopStart.Size = new Size(64, 15);
            lbLoopStart.TabIndex = 2;
            lbLoopStart.Text = "Loop Start:";
            // 
            // lbInitialDelay
            // 
            lbInitialDelay.AutoSize = true;
            lbInitialDelay.Location = new Point(49, 53);
            lbInitialDelay.Name = "lbInitialDelay";
            lbInitialDelay.Size = new Size(71, 15);
            lbInitialDelay.TabIndex = 1;
            lbInitialDelay.Text = "Initial Delay:";
            // 
            // numTotalDuration
            // 
            numTotalDuration.DecimalPlaces = 5;
            numTotalDuration.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numTotalDuration.Location = new Point(126, 138);
            numTotalDuration.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numTotalDuration.Name = "numTotalDuration";
            numTotalDuration.Size = new Size(117, 23);
            numTotalDuration.TabIndex = 8;
            // 
            // numLoopEnd
            // 
            numLoopEnd.DecimalPlaces = 5;
            numLoopEnd.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numLoopEnd.Location = new Point(126, 109);
            numLoopEnd.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numLoopEnd.Name = "numLoopEnd";
            numLoopEnd.Size = new Size(117, 23);
            numLoopEnd.TabIndex = 7;
            // 
            // numLoopStart
            // 
            numLoopStart.DecimalPlaces = 5;
            numLoopStart.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numLoopStart.Location = new Point(126, 80);
            numLoopStart.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numLoopStart.Name = "numLoopStart";
            numLoopStart.Size = new Size(117, 23);
            numLoopStart.TabIndex = 6;
            // 
            // numInitialDelay
            // 
            numInitialDelay.DecimalPlaces = 5;
            numInitialDelay.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numInitialDelay.Location = new Point(126, 51);
            numInitialDelay.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numInitialDelay.Name = "numInitialDelay";
            numInitialDelay.Size = new Size(117, 23);
            numInitialDelay.TabIndex = 5;
            // 
            // checkLoop
            // 
            checkLoop.AutoSize = true;
            checkLoop.Location = new Point(15, 22);
            checkLoop.Name = "checkLoop";
            checkLoop.Size = new Size(112, 19);
            checkLoop.TabIndex = 0;
            checkLoop.Text = "Edit Loop Points";
            checkLoop.UseVisualStyleBackColor = true;
            checkLoop.CheckedChanged += checkLoop_CheckedChanged;
            // 
            // btnOldEventHash
            // 
            btnOldEventHash.Location = new Point(246, 104);
            btnOldEventHash.Name = "btnOldEventHash";
            btnOldEventHash.Size = new Size(26, 23);
            btnOldEventHash.TabIndex = 26;
            btnOldEventHash.Text = "#";
            btnOldEventHash.UseVisualStyleBackColor = true;
            btnOldEventHash.Click += btnOldEventHash_Click;
            // 
            // btnNewEventHash
            // 
            btnNewEventHash.Location = new Point(246, 133);
            btnNewEventHash.Name = "btnNewEventHash";
            btnNewEventHash.Size = new Size(26, 23);
            btnNewEventHash.TabIndex = 27;
            btnNewEventHash.Text = "#";
            btnNewEventHash.UseVisualStyleBackColor = true;
            btnNewEventHash.Click += btnNewEventHash_Click;
            // 
            // btnGroupHash
            // 
            btnGroupHash.Location = new Point(246, 162);
            btnGroupHash.Name = "btnGroupHash";
            btnGroupHash.Size = new Size(26, 23);
            btnGroupHash.TabIndex = 28;
            btnGroupHash.Text = "#";
            btnGroupHash.UseVisualStyleBackColor = true;
            btnGroupHash.Click += btnGroupHash_Click;
            // 
            // FormWwiseEventCloner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 244);
            Controls.Add(grpLoop);
            Controls.Add(btnApply);
            Controls.Add(btnGroupHash);
            Controls.Add(btnNewEventHash);
            Controls.Add(btnOldEventHash);
            Controls.Add(lbGroup);
            Controls.Add(lbNewEvent);
            Controls.Add(lbOldEvent);
            Controls.Add(txtGroup);
            Controls.Add(txtNewEvent);
            Controls.Add(txtOldEvent);
            Controls.Add(grpBank);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(555, 283);
            MinimumSize = new Size(555, 283);
            Name = "FormWwiseEventCloner";
            Text = "Wwise Event Cloner";
            FormClosed += FormWwiseBankCloner_FormClosed;
            Shown += FormWwiseBankCloner_Shown;
            grpBank.ResumeLayout(false);
            grpBank.PerformLayout();
            grpLoop.ResumeLayout(false);
            grpLoop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLoopEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLoopStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numInitialDelay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnApply;
        private Label lbNewEvent;
        private Label lbOldEvent;
        private TextBox txtNewEvent;
        private TextBox txtOldEvent;
        private GroupBox grpBank;
        private Label lbBankName;
        private Button btnBankOpen;
        private Button btnBankSave;
        private ToolTip ttWwiseBankCloner;
        private TextBox txtGroup;
        private Label lbGroup;
        private GroupBox grpLoop;
        private Label lbTotalDuration;
        private Label lbLoopEnd;
        private Label lbLoopStart;
        private Label lbInitialDelay;
        private NumericUpDown numTotalDuration;
        private NumericUpDown numLoopEnd;
        private NumericUpDown numLoopStart;
        private NumericUpDown numInitialDelay;
        private CheckBox checkLoop;
        private Button btnOldEventHash;
        private Button btnNewEventHash;
        private Button btnGroupHash;
    }
}