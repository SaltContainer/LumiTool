namespace LumiTool.Forms.WwiseActions
{
    partial class FormWwiseActionSetState : FormWwiseActionBase
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
            grpActionSetState = new GroupBox();
            lbStateGroupID = new Label();
            numStateGroupID = new NumericUpDown();
            lbTargetStateID = new Label();
            numTargetStateID = new NumericUpDown();
            grpActionSetState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStateGroupID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTargetStateID).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Size = new Size(626, 37);
            // 
            // grpActionSetState
            // 
            grpActionSetState.Controls.Add(lbTargetStateID);
            grpActionSetState.Controls.Add(numTargetStateID);
            grpActionSetState.Controls.Add(lbStateGroupID);
            grpActionSetState.Controls.Add(numStateGroupID);
            grpActionSetState.Location = new Point(328, 12);
            grpActionSetState.Name = "grpActionSetState";
            grpActionSetState.Size = new Size(310, 644);
            grpActionSetState.TabIndex = 5;
            grpActionSetState.TabStop = false;
            grpActionSetState.Text = "Action Set State";
            // 
            // lbStateGroupID
            // 
            lbStateGroupID.AutoSize = true;
            lbStateGroupID.Location = new Point(85, 24);
            lbStateGroupID.Name = "lbStateGroupID";
            lbStateGroupID.Size = new Size(86, 15);
            lbStateGroupID.TabIndex = 10;
            lbStateGroupID.Text = "State Group ID:";
            // 
            // numStateGroupID
            // 
            numStateGroupID.Location = new Point(177, 22);
            numStateGroupID.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            numStateGroupID.Name = "numStateGroupID";
            numStateGroupID.Size = new Size(127, 23);
            numStateGroupID.TabIndex = 9;
            // 
            // lbTargetStateID
            // 
            lbTargetStateID.AutoSize = true;
            lbTargetStateID.Location = new Point(86, 54);
            lbTargetStateID.Name = "lbTargetStateID";
            lbTargetStateID.Size = new Size(85, 15);
            lbTargetStateID.TabIndex = 11;
            lbTargetStateID.Text = "Target State ID:";
            // 
            // numTargetStateID
            // 
            numTargetStateID.Location = new Point(177, 52);
            numTargetStateID.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            numTargetStateID.Name = "numTargetStateID";
            numTargetStateID.Size = new Size(127, 23);
            numTargetStateID.TabIndex = 12;
            // 
            // FormWwiseActionSetState
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 711);
            Controls.Add(grpActionSetState);
            MaximumSize = new Size(666, 750);
            MinimumSize = new Size(666, 750);
            Name = "FormWwiseActionSetState";
            Text = "Enter Data for ActionSetState";
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(grpActionSetState, 0);
            grpActionSetState.ResumeLayout(false);
            grpActionSetState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStateGroupID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTargetStateID).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpActionSetState;
        private Label lbStateGroupID;
        private NumericUpDown numStateGroupID;
        private NumericUpDown numTargetStateID;
        private Label lbTargetStateID;
    }
}