using LumiTool.LumiToolDotNet.Resources;

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
            btnAddAction = new Button();
            btnRemoveAction = new Button();
            btnEditAction = new Button();
            comboActions = new ComboBox();
            lbActions = new Label();
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
            btnBankOpen.Image = Resources.folder;
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
            listActions.Size = new Size(472, 244);
            listActions.TabIndex = 2;
            // 
            // btnAddAction
            // 
            btnAddAction.Image = Resources.plus_big;
            btnAddAction.Location = new Point(543, 264);
            btnAddAction.Name = "btnAddAction";
            btnAddAction.Size = new Size(39, 39);
            btnAddAction.TabIndex = 5;
            btnAddAction.UseVisualStyleBackColor = true;
            btnAddAction.Click += btnAddAction_Click;
            // 
            // btnRemoveAction
            // 
            btnRemoveAction.Image = Resources.minus_big;
            btnRemoveAction.Location = new Point(588, 264);
            btnRemoveAction.Name = "btnRemoveAction";
            btnRemoveAction.Size = new Size(39, 39);
            btnRemoveAction.TabIndex = 6;
            btnRemoveAction.UseVisualStyleBackColor = true;
            btnRemoveAction.Click += btnRemoveAction_Click;
            // 
            // btnEditAction
            // 
            btnEditAction.Image = Resources.pencil_big;
            btnEditAction.Location = new Point(633, 264);
            btnEditAction.Name = "btnEditAction";
            btnEditAction.Size = new Size(39, 39);
            btnEditAction.TabIndex = 7;
            btnEditAction.UseVisualStyleBackColor = true;
            btnEditAction.Click += btnEditAction_Click;
            // 
            // comboActions
            // 
            comboActions.FormattingEnabled = true;
            comboActions.Location = new Point(305, 273);
            comboActions.Name = "comboActions";
            comboActions.Size = new Size(232, 23);
            comboActions.TabIndex = 4;
            // 
            // lbActions
            // 
            lbActions.AutoSize = true;
            lbActions.Location = new Point(200, 276);
            lbActions.Name = "lbActions";
            lbActions.Size = new Size(99, 15);
            lbActions.TabIndex = 3;
            lbActions.Text = "New Action Type:";
            // 
            // FormWwiseEventBrowser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 315);
            Controls.Add(lbActions);
            Controls.Add(comboActions);
            Controls.Add(btnEditAction);
            Controls.Add(btnRemoveAction);
            Controls.Add(btnAddAction);
            Controls.Add(listActions);
            Controls.Add(listEvents);
            Controls.Add(grpBank);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(700, 354);
            MinimumSize = new Size(700, 354);
            Name = "FormWwiseEventBrowser";
            Text = "Wwise Event Browser";
            FormClosed += FormWwiseEventBrowser_FormClosed;
            Shown += FormWwiseEventBrowser_Shown;
            grpBank.ResumeLayout(false);
            grpBank.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttWwiseEventBrowser;
        private GroupBox grpBank;
        private Label lbBankName;
        private Button btnBankOpen;
        private ListBox listEvents;
        private ListBox listActions;
        private Button btnAddAction;
        private Button btnRemoveAction;
        private Button btnEditAction;
        private ComboBox comboActions;
        private Label lbActions;
    }
}