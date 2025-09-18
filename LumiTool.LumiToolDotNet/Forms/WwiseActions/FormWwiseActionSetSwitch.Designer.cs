namespace LumiTool.Forms.WwiseActions
{
    partial class FormWwiseActionSetSwitch : FormWwiseActionBase
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
            grpActionSetSwitch = new GroupBox();
            lbSwitchStateID = new Label();
            numSwitchStateID = new NumericUpDown();
            lbSwitchGroupID = new Label();
            numSwitchGroupID = new NumericUpDown();
            grpActionSetSwitch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSwitchStateID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSwitchGroupID).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Size = new Size(626, 37);
            // 
            // grpActionSetSwitch
            // 
            grpActionSetSwitch.Controls.Add(lbSwitchStateID);
            grpActionSetSwitch.Controls.Add(numSwitchStateID);
            grpActionSetSwitch.Controls.Add(lbSwitchGroupID);
            grpActionSetSwitch.Controls.Add(numSwitchGroupID);
            grpActionSetSwitch.Location = new Point(328, 12);
            grpActionSetSwitch.Name = "grpActionSetSwitch";
            grpActionSetSwitch.Size = new Size(310, 644);
            grpActionSetSwitch.TabIndex = 6;
            grpActionSetSwitch.TabStop = false;
            grpActionSetSwitch.Text = "Action Set Switch";
            // 
            // lbSwitchStateID
            // 
            lbSwitchStateID.AutoSize = true;
            lbSwitchStateID.Location = new Point(83, 54);
            lbSwitchStateID.Name = "lbSwitchStateID";
            lbSwitchStateID.Size = new Size(88, 15);
            lbSwitchStateID.TabIndex = 11;
            lbSwitchStateID.Text = "Switch State ID:";
            // 
            // numSwitchStateID
            // 
            numSwitchStateID.Location = new Point(177, 52);
            numSwitchStateID.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            numSwitchStateID.Name = "numSwitchStateID";
            numSwitchStateID.Size = new Size(127, 23);
            numSwitchStateID.TabIndex = 12;
            // 
            // lbSwitchGroupID
            // 
            lbSwitchGroupID.AutoSize = true;
            lbSwitchGroupID.Location = new Point(76, 24);
            lbSwitchGroupID.Name = "lbSwitchGroupID";
            lbSwitchGroupID.Size = new Size(95, 15);
            lbSwitchGroupID.TabIndex = 10;
            lbSwitchGroupID.Text = "Switch Group ID:";
            // 
            // numSwitchGroupID
            // 
            numSwitchGroupID.Location = new Point(177, 22);
            numSwitchGroupID.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            numSwitchGroupID.Name = "numSwitchGroupID";
            numSwitchGroupID.Size = new Size(127, 23);
            numSwitchGroupID.TabIndex = 9;
            // 
            // FormWwiseActionSetSwitch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 711);
            Controls.Add(grpActionSetSwitch);
            MaximumSize = new Size(666, 750);
            MinimumSize = new Size(666, 750);
            Name = "FormWwiseActionSetSwitch";
            Text = "Enter Data for ActionSetSwitch";
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(grpActionSetSwitch, 0);
            grpActionSetSwitch.ResumeLayout(false);
            grpActionSetSwitch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSwitchStateID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSwitchGroupID).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpActionSetSwitch;
        private Label lbSwitchStateID;
        private NumericUpDown numSwitchStateID;
        private Label lbSwitchGroupID;
        private NumericUpDown numSwitchGroupID;
    }
}