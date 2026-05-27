namespace LumiTool.Forms
{
    partial class FormWwiseMusicSwitchCntrViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWwiseMusicSwitchCntrViewer));
            grpBank = new GroupBox();
            lbBankName = new Label();
            btnBankOpen = new Button();
            ttWwiseMusicSwitchCntrViewer = new ToolTip(components);
            graphMusicSwitch = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            listMusicSwitch = new ListBox();
            grpBank.SuspendLayout();
            SuspendLayout();
            // 
            // grpBank
            // 
            grpBank.Controls.Add(lbBankName);
            grpBank.Controls.Add(btnBankOpen);
            grpBank.Location = new Point(12, 12);
            grpBank.Name = "grpBank";
            grpBank.Size = new Size(260, 86);
            grpBank.TabIndex = 1;
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
            btnBankOpen.Image = LumiToolDotNet.Resources.Resources.folder;
            btnBankOpen.ImageAlign = ContentAlignment.MiddleRight;
            btnBankOpen.Location = new Point(6, 40);
            btnBankOpen.Name = "btnBankOpen";
            btnBankOpen.Size = new Size(248, 40);
            btnBankOpen.TabIndex = 1;
            btnBankOpen.Text = "Open";
            btnBankOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBankOpen.UseVisualStyleBackColor = true;
            btnBankOpen.Click += btnBankOpen_Click;
            btnBankOpen.DragDrop += btnBankOpen_DragDrop;
            btnBankOpen.DragEnter += btnBankOpen_DragEnter;
            // 
            // graphMusicSwitch
            // 
            graphMusicSwitch.ArrowheadLength = 10D;
            graphMusicSwitch.AsyncLayout = false;
            graphMusicSwitch.AutoScroll = true;
            graphMusicSwitch.BackwardEnabled = false;
            graphMusicSwitch.BuildHitTree = true;
            graphMusicSwitch.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            graphMusicSwitch.EdgeInsertButtonVisible = true;
            graphMusicSwitch.FileName = "";
            graphMusicSwitch.ForwardEnabled = false;
            graphMusicSwitch.Graph = null;
            graphMusicSwitch.IncrementalDraggingModeAlways = false;
            graphMusicSwitch.InsertingEdge = false;
            graphMusicSwitch.LayoutAlgorithmSettingsButtonVisible = true;
            graphMusicSwitch.LayoutEditingEnabled = true;
            graphMusicSwitch.Location = new Point(278, 12);
            graphMusicSwitch.LooseOffsetForRouting = 0.25D;
            graphMusicSwitch.MouseHitDistance = 0.05D;
            graphMusicSwitch.Name = "graphMusicSwitch";
            graphMusicSwitch.NavigationVisible = true;
            graphMusicSwitch.NeedToCalculateLayout = true;
            graphMusicSwitch.OffsetForRelaxingInRouting = 0.6D;
            graphMusicSwitch.PaddingForEdgeRouting = 8D;
            graphMusicSwitch.PanButtonPressed = false;
            graphMusicSwitch.SaveAsImageEnabled = true;
            graphMusicSwitch.SaveAsMsaglEnabled = true;
            graphMusicSwitch.SaveButtonVisible = true;
            graphMusicSwitch.SaveGraphButtonVisible = true;
            graphMusicSwitch.SaveInVectorFormatEnabled = true;
            graphMusicSwitch.Size = new Size(515, 515);
            graphMusicSwitch.TabIndex = 2;
            graphMusicSwitch.TightOffsetForRouting = 0.125D;
            graphMusicSwitch.ToolBarIsVisible = true;
            graphMusicSwitch.Transform = (Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)resources.GetObject("graphMusicSwitch.Transform");
            graphMusicSwitch.UndoRedoButtonsVisible = true;
            graphMusicSwitch.WindowZoomButtonPressed = false;
            graphMusicSwitch.ZoomF = 1D;
            graphMusicSwitch.ZoomWindowThreshold = 0.05D;
            // 
            // listMusicSwitch
            // 
            listMusicSwitch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listMusicSwitch.FormattingEnabled = true;
            listMusicSwitch.ItemHeight = 15;
            listMusicSwitch.Location = new Point(12, 104);
            listMusicSwitch.Name = "listMusicSwitch";
            listMusicSwitch.Size = new Size(260, 409);
            listMusicSwitch.TabIndex = 3;
            listMusicSwitch.SelectedIndexChanged += listMusicSwitch_SelectedIndexChanged;
            // 
            // FormWwiseMusicSwitchCntrViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 539);
            Controls.Add(listMusicSwitch);
            Controls.Add(graphMusicSwitch);
            Controls.Add(grpBank);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(821, 578);
            MinimumSize = new Size(821, 578);
            Name = "FormWwiseMusicSwitchCntrViewer";
            Text = "Wwise MusicSwitchCntr Viewer";
            FormClosed += FormWwiseMusicSwitchCntrViewer_FormClosed;
            Shown += FormWwiseMusicSwitchCntrViewer_Shown;
            grpBank.ResumeLayout(false);
            grpBank.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBank;
        private Label lbBankName;
        private Button btnBankOpen;
        private ToolTip ttWwiseMusicSwitchCntrViewer;
        private Microsoft.Msagl.GraphViewerGdi.GViewer graphMusicSwitch;
        private ListBox listMusicSwitch;
    }
}