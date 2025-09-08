namespace LumiTool.Forms
{
    partial class FormWwiseEventBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWwiseEventBrowser));
            ttWwiseEventBrowser = new ToolTip(components);
            grpBank = new GroupBox();
            lbBankName = new Label();
            btnBankOpen = new Button();
            listEvents = new ListBox();
            listActions = new ListBox();
            grpBank.SuspendLayout();
            SuspendLayout();
            // 
            // grpBank
            // 
            grpBank.Controls.Add(lbBankName);
            grpBank.Controls.Add(btnBankOpen);
            grpBank.Location = new Point(12, 12);
            grpBank.Name = "grpBank";
            grpBank.Size = new Size(182, 86);
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
            btnBankOpen.Image = Resources.Resources.folder;
            btnBankOpen.Location = new Point(6, 40);
            btnBankOpen.Name = "btnBankOpen";
            btnBankOpen.Size = new Size(170, 40);
            btnBankOpen.TabIndex = 1;
            btnBankOpen.Text = "Open";
            btnBankOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBankOpen.UseVisualStyleBackColor = true;
            btnBankOpen.Click += btnBankOpen_Click;
            btnBankOpen.DragDrop += btnBankOpen_DragDrop;
            btnBankOpen.DragEnter += btnBankOpen_DragEnter;
            // 
            // listEvents
            // 
            listEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listEvents.FormattingEnabled = true;
            listEvents.ItemHeight = 15;
            listEvents.Location = new Point(12, 104);
            listEvents.Name = "listEvents";
            listEvents.Size = new Size(182, 199);
            listEvents.TabIndex = 1;
            listEvents.SelectedIndexChanged += listEvents_SelectedIndexChanged;
            // 
            // listActions
            // 
            listActions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listActions.FormattingEnabled = true;
            listActions.ItemHeight = 15;
            listActions.Location = new Point(200, 14);
            listActions.Name = "listActions";
            listActions.Size = new Size(472, 289);
            listActions.TabIndex = 2;
            // 
            // FormWwiseEventBrowser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 315);
            Controls.Add(listActions);
            Controls.Add(listEvents);
            Controls.Add(grpBank);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(700, 354);
            MinimumSize = new Size(700, 354);
            Name = "FormWwiseEventBrowser";
            Text = "FormWwiseEventBrowser";
            FormClosed += FormWwiseEventBrowser_FormClosed;
            Shown += FormWwiseEventBrowser_Shown;
            grpBank.ResumeLayout(false);
            grpBank.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolTip ttWwiseEventBrowser;
        private GroupBox grpBank;
        private Label lbBankName;
        private Button btnBankOpen;
        private ListBox listEvents;
        private ListBox listActions;
    }
}