using LumiTool.LumiToolDotNet.Resources;

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
            txtNewEvent = new TextBox();
            grpBank = new GroupBox();
            lbBankName = new Label();
            btnBankOpen = new Button();
            btnBankSave = new Button();
            ttWwiseBankCloner = new ToolTip(components);
            grpLoop = new GroupBox();
            lbRegTotalDuration = new Label();
            lbRegLoopEnd = new Label();
            lbRegLoopStart = new Label();
            lbRegInitialDelay = new Label();
            numRegTotalDuration = new NumericUpDown();
            numRegLoopEnd = new NumericUpDown();
            numRegLoopStart = new NumericUpDown();
            numRegInitialDelay = new NumericUpDown();
            checkLoop = new CheckBox();
            btnNewEventHash = new Button();
            comboEventType = new ComboBox();
            lbEventType = new Label();
            grpRegular = new GroupBox();
            grpDS = new GroupBox();
            lbDSInitialDelay = new Label();
            lbDSTotalDuration = new Label();
            numDSInitialDelay = new NumericUpDown();
            lbDSLoopEnd = new Label();
            numDSLoopStart = new NumericUpDown();
            lbDSLoopStart = new Label();
            numDSLoopEnd = new NumericUpDown();
            numDSTotalDuration = new NumericUpDown();
            grpBank.SuspendLayout();
            grpLoop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRegTotalDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRegLoopEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRegLoopStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRegInitialDelay).BeginInit();
            grpRegular.SuspendLayout();
            grpDS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDSInitialDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDSLoopStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDSLoopEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDSTotalDuration).BeginInit();
            SuspendLayout();
            // 
            // btnApply
            // 
            btnApply.Location = new Point(12, 162);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(260, 41);
            btnApply.TabIndex = 11;
            btnApply.Text = "Clone";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // lbNewEvent
            // 
            lbNewEvent.AutoSize = true;
            lbNewEvent.Location = new Point(13, 107);
            lbNewEvent.Name = "lbNewEvent";
            lbNewEvent.Size = new Size(101, 15);
            lbNewEvent.TabIndex = 4;
            lbNewEvent.Text = "New Event Name:";
            // 
            // txtNewEvent
            // 
            txtNewEvent.Location = new Point(120, 104);
            txtNewEvent.Name = "txtNewEvent";
            txtNewEvent.Size = new Size(121, 23);
            txtNewEvent.TabIndex = 5;
            // 
            // grpBank
            // 
            grpBank.Controls.Add(lbBankName);
            grpBank.Controls.Add(btnBankOpen);
            grpBank.Controls.Add(btnBankSave);
            grpBank.Location = new Point(12, 12);
            grpBank.Name = "grpBank";
            grpBank.Size = new Size(260, 86);
            grpBank.TabIndex = 0;
            grpBank.TabStop = false;
            grpBank.Text = "Loaded Bank";
            // 
            // lbBankName
            // 
            lbBankName.AutoSize = true;
            lbBankName.Location = new Point(6, 19);
            lbBankName.Name = "lbBankName";
            lbBankName.Size = new Size(74, 15);
            lbBankName.TabIndex = 0;
            lbBankName.Text = "Bank Name: ";
            // 
            // btnBankOpen
            // 
            btnBankOpen.AllowDrop = true;
            btnBankOpen.Image = Resources.folder;
            btnBankOpen.Location = new Point(6, 40);
            btnBankOpen.Name = "btnBankOpen";
            btnBankOpen.Size = new Size(121, 40);
            btnBankOpen.TabIndex = 1;
            btnBankOpen.Text = "Open";
            btnBankOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBankOpen.UseVisualStyleBackColor = true;
            btnBankOpen.Click += btnBankOpen_Click;
            btnBankOpen.DragDrop += btnBankOpen_DragDrop;
            btnBankOpen.DragEnter += btnBankOpen_DragEnter;
            // 
            // btnBankSave
            // 
            btnBankSave.Image = Resources.save;
            btnBankSave.Location = new Point(133, 40);
            btnBankSave.Name = "btnBankSave";
            btnBankSave.Size = new Size(121, 40);
            btnBankSave.TabIndex = 2;
            btnBankSave.Text = "Save";
            btnBankSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBankSave.UseVisualStyleBackColor = true;
            btnBankSave.Click += btnBankSave_Click;
            // 
            // grpLoop
            // 
            grpLoop.Controls.Add(grpDS);
            grpLoop.Controls.Add(grpRegular);
            grpLoop.Controls.Add(checkLoop);
            grpLoop.Location = new Point(278, 12);
            grpLoop.Name = "grpLoop";
            grpLoop.Size = new Size(494, 191);
            grpLoop.TabIndex = 10;
            grpLoop.TabStop = false;
            grpLoop.Text = "Looping";
            // 
            // lbRegTotalDuration
            // 
            lbRegTotalDuration.AutoSize = true;
            lbRegTotalDuration.Location = new Point(5, 111);
            lbRegTotalDuration.Name = "lbRegTotalDuration";
            lbRegTotalDuration.Size = new Size(114, 15);
            lbRegTotalDuration.TabIndex = 7;
            lbRegTotalDuration.Text = "Total Source Length:";
            // 
            // lbRegLoopEnd
            // 
            lbRegLoopEnd.AutoSize = true;
            lbRegLoopEnd.Location = new Point(59, 82);
            lbRegLoopEnd.Name = "lbRegLoopEnd";
            lbRegLoopEnd.Size = new Size(60, 15);
            lbRegLoopEnd.TabIndex = 5;
            lbRegLoopEnd.Text = "Loop End:";
            // 
            // lbRegLoopStart
            // 
            lbRegLoopStart.AutoSize = true;
            lbRegLoopStart.Location = new Point(55, 53);
            lbRegLoopStart.Name = "lbRegLoopStart";
            lbRegLoopStart.Size = new Size(64, 15);
            lbRegLoopStart.TabIndex = 3;
            lbRegLoopStart.Text = "Loop Start:";
            // 
            // lbRegInitialDelay
            // 
            lbRegInitialDelay.AutoSize = true;
            lbRegInitialDelay.Location = new Point(48, 24);
            lbRegInitialDelay.Name = "lbRegInitialDelay";
            lbRegInitialDelay.Size = new Size(71, 15);
            lbRegInitialDelay.TabIndex = 1;
            lbRegInitialDelay.Text = "Initial Delay:";
            // 
            // numRegTotalDuration
            // 
            numRegTotalDuration.DecimalPlaces = 5;
            numRegTotalDuration.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRegTotalDuration.Location = new Point(125, 109);
            numRegTotalDuration.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numRegTotalDuration.Name = "numRegTotalDuration";
            numRegTotalDuration.Size = new Size(107, 23);
            numRegTotalDuration.TabIndex = 8;
            // 
            // numRegLoopEnd
            // 
            numRegLoopEnd.DecimalPlaces = 5;
            numRegLoopEnd.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRegLoopEnd.Location = new Point(125, 80);
            numRegLoopEnd.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numRegLoopEnd.Name = "numRegLoopEnd";
            numRegLoopEnd.Size = new Size(107, 23);
            numRegLoopEnd.TabIndex = 6;
            // 
            // numRegLoopStart
            // 
            numRegLoopStart.DecimalPlaces = 5;
            numRegLoopStart.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRegLoopStart.Location = new Point(125, 51);
            numRegLoopStart.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numRegLoopStart.Name = "numRegLoopStart";
            numRegLoopStart.Size = new Size(107, 23);
            numRegLoopStart.TabIndex = 4;
            // 
            // numRegInitialDelay
            // 
            numRegInitialDelay.DecimalPlaces = 5;
            numRegInitialDelay.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numRegInitialDelay.Location = new Point(125, 22);
            numRegInitialDelay.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numRegInitialDelay.Name = "numRegInitialDelay";
            numRegInitialDelay.Size = new Size(107, 23);
            numRegInitialDelay.TabIndex = 2;
            // 
            // checkLoop
            // 
            checkLoop.AutoSize = true;
            checkLoop.Location = new Point(13, 19);
            checkLoop.Name = "checkLoop";
            checkLoop.Size = new Size(112, 19);
            checkLoop.TabIndex = 0;
            checkLoop.Text = "Edit Loop Points";
            checkLoop.UseVisualStyleBackColor = true;
            checkLoop.CheckedChanged += checkLoop_CheckedChanged;
            // 
            // btnNewEventHash
            // 
            btnNewEventHash.Location = new Point(247, 104);
            btnNewEventHash.Name = "btnNewEventHash";
            btnNewEventHash.Size = new Size(26, 23);
            btnNewEventHash.TabIndex = 6;
            btnNewEventHash.Text = "#";
            btnNewEventHash.UseVisualStyleBackColor = true;
            btnNewEventHash.Click += btnNewEventHash_Click;
            // 
            // comboEventType
            // 
            comboEventType.FormattingEnabled = true;
            comboEventType.Location = new Point(84, 133);
            comboEventType.Name = "comboEventType";
            comboEventType.Size = new Size(188, 23);
            comboEventType.TabIndex = 12;
            // 
            // lbEventType
            // 
            lbEventType.AutoSize = true;
            lbEventType.Location = new Point(12, 136);
            lbEventType.Name = "lbEventType";
            lbEventType.Size = new Size(66, 15);
            lbEventType.TabIndex = 13;
            lbEventType.Text = "Event Type:";
            // 
            // grpRegular
            // 
            grpRegular.Controls.Add(numRegTotalDuration);
            grpRegular.Controls.Add(lbRegTotalDuration);
            grpRegular.Controls.Add(numRegLoopEnd);
            grpRegular.Controls.Add(lbRegLoopEnd);
            grpRegular.Controls.Add(numRegLoopStart);
            grpRegular.Controls.Add(lbRegLoopStart);
            grpRegular.Controls.Add(numRegInitialDelay);
            grpRegular.Controls.Add(lbRegInitialDelay);
            grpRegular.Location = new Point(6, 44);
            grpRegular.Name = "grpRegular";
            grpRegular.Size = new Size(238, 141);
            grpRegular.TabIndex = 9;
            grpRegular.TabStop = false;
            grpRegular.Text = "Regular";
            // 
            // grpDS
            // 
            grpDS.Controls.Add(numDSTotalDuration);
            grpDS.Controls.Add(lbDSTotalDuration);
            grpDS.Controls.Add(numDSLoopEnd);
            grpDS.Controls.Add(lbDSLoopEnd);
            grpDS.Controls.Add(numDSLoopStart);
            grpDS.Controls.Add(lbDSLoopStart);
            grpDS.Controls.Add(numDSInitialDelay);
            grpDS.Controls.Add(lbDSInitialDelay);
            grpDS.Location = new Point(250, 44);
            grpDS.Name = "grpDS";
            grpDS.Size = new Size(238, 141);
            grpDS.TabIndex = 10;
            grpDS.TabStop = false;
            grpDS.Text = "DS Sounds";
            // 
            // lbDSInitialDelay
            // 
            lbDSInitialDelay.AutoSize = true;
            lbDSInitialDelay.Location = new Point(48, 24);
            lbDSInitialDelay.Name = "lbDSInitialDelay";
            lbDSInitialDelay.Size = new Size(71, 15);
            lbDSInitialDelay.TabIndex = 1;
            lbDSInitialDelay.Text = "Initial Delay:";
            // 
            // lbDSTotalDuration
            // 
            lbDSTotalDuration.AutoSize = true;
            lbDSTotalDuration.Location = new Point(5, 111);
            lbDSTotalDuration.Name = "lbDSTotalDuration";
            lbDSTotalDuration.Size = new Size(114, 15);
            lbDSTotalDuration.TabIndex = 7;
            lbDSTotalDuration.Text = "Total Source Length:";
            // 
            // numDSInitialDelay
            // 
            numDSInitialDelay.DecimalPlaces = 5;
            numDSInitialDelay.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numDSInitialDelay.Location = new Point(125, 22);
            numDSInitialDelay.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numDSInitialDelay.Name = "numDSInitialDelay";
            numDSInitialDelay.Size = new Size(107, 23);
            numDSInitialDelay.TabIndex = 2;
            // 
            // lbDSLoopEnd
            // 
            lbDSLoopEnd.AutoSize = true;
            lbDSLoopEnd.Location = new Point(59, 82);
            lbDSLoopEnd.Name = "lbDSLoopEnd";
            lbDSLoopEnd.Size = new Size(60, 15);
            lbDSLoopEnd.TabIndex = 5;
            lbDSLoopEnd.Text = "Loop End:";
            // 
            // numDSLoopStart
            // 
            numDSLoopStart.DecimalPlaces = 5;
            numDSLoopStart.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numDSLoopStart.Location = new Point(125, 51);
            numDSLoopStart.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numDSLoopStart.Name = "numDSLoopStart";
            numDSLoopStart.Size = new Size(107, 23);
            numDSLoopStart.TabIndex = 4;
            // 
            // lbDSLoopStart
            // 
            lbDSLoopStart.AutoSize = true;
            lbDSLoopStart.Location = new Point(55, 53);
            lbDSLoopStart.Name = "lbDSLoopStart";
            lbDSLoopStart.Size = new Size(64, 15);
            lbDSLoopStart.TabIndex = 3;
            lbDSLoopStart.Text = "Loop Start:";
            // 
            // numDSLoopEnd
            // 
            numDSLoopEnd.DecimalPlaces = 5;
            numDSLoopEnd.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numDSLoopEnd.Location = new Point(125, 80);
            numDSLoopEnd.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numDSLoopEnd.Name = "numDSLoopEnd";
            numDSLoopEnd.Size = new Size(107, 23);
            numDSLoopEnd.TabIndex = 6;
            // 
            // numDSTotalDuration
            // 
            numDSTotalDuration.DecimalPlaces = 5;
            numDSTotalDuration.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numDSTotalDuration.Location = new Point(125, 109);
            numDSTotalDuration.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numDSTotalDuration.Name = "numDSTotalDuration";
            numDSTotalDuration.Size = new Size(107, 23);
            numDSTotalDuration.TabIndex = 8;
            // 
            // FormWwiseEventCloner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 215);
            Controls.Add(grpLoop);
            Controls.Add(btnApply);
            Controls.Add(btnNewEventHash);
            Controls.Add(lbEventType);
            Controls.Add(lbNewEvent);
            Controls.Add(comboEventType);
            Controls.Add(txtNewEvent);
            Controls.Add(grpBank);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(800, 254);
            MinimumSize = new Size(800, 254);
            Name = "FormWwiseEventCloner";
            Text = "Wwise Event Cloner";
            FormClosed += FormWwiseBankCloner_FormClosed;
            Shown += FormWwiseBankCloner_Shown;
            grpBank.ResumeLayout(false);
            grpBank.PerformLayout();
            grpLoop.ResumeLayout(false);
            grpLoop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRegTotalDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRegLoopEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRegLoopStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRegInitialDelay).EndInit();
            grpRegular.ResumeLayout(false);
            grpRegular.PerformLayout();
            grpDS.ResumeLayout(false);
            grpDS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDSInitialDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDSLoopStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDSLoopEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDSTotalDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnApply;
        private Label lbNewEvent;
        private TextBox txtNewEvent;
        private GroupBox grpBank;
        private Label lbBankName;
        private Button btnBankOpen;
        private Button btnBankSave;
        private ToolTip ttWwiseBankCloner;
        private GroupBox grpLoop;
        private Label lbRegTotalDuration;
        private Label lbRegLoopEnd;
        private Label lbRegLoopStart;
        private Label lbRegInitialDelay;
        private NumericUpDown numRegTotalDuration;
        private NumericUpDown numRegLoopEnd;
        private NumericUpDown numRegLoopStart;
        private NumericUpDown numRegInitialDelay;
        private CheckBox checkLoop;
        private Button btnNewEventHash;
        private ComboBox comboEventType;
        private Label lbEventType;
        private GroupBox grpDS;
        private Label lbDSInitialDelay;
        private Label lbDSTotalDuration;
        private NumericUpDown numDSInitialDelay;
        private Label lbDSLoopEnd;
        private NumericUpDown numDSLoopStart;
        private Label lbDSLoopStart;
        private NumericUpDown numDSLoopEnd;
        private NumericUpDown numDSTotalDuration;
        private GroupBox grpRegular;
    }
}