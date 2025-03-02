namespace LumiTool.Forms
{
    partial class FormWwiseBankCloner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWwiseBankCloner));
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
            grpBank.SuspendLayout();
            SuspendLayout();
            // 
            // btnApply
            // 
            btnApply.Location = new Point(12, 191);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(260, 41);
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
            txtNewEvent.Size = new Size(153, 23);
            txtNewEvent.TabIndex = 19;
            // 
            // txtOldEvent
            // 
            txtOldEvent.Location = new Point(141, 104);
            txtOldEvent.Name = "txtOldEvent";
            txtOldEvent.Size = new Size(131, 23);
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
            txtGroup.Size = new Size(176, 23);
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
            // FormWwiseBankCloner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 244);
            Controls.Add(btnApply);
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
            MaximumSize = new Size(300, 283);
            MinimumSize = new Size(300, 283);
            Name = "FormWwiseBankCloner";
            Text = "Wwise Bank Cloner";
            FormClosed += FormWwiseBankCloner_FormClosed;
            Shown += FormWwiseBankCloner_Shown;
            grpBank.ResumeLayout(false);
            grpBank.PerformLayout();
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
    }
}