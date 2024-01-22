namespace LumiTool.Forms
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            imgDJ = new PictureBox();
            linklbRepo = new LinkLabel();
            lbAbout = new Label();
            lbDev = new Label();
            ((System.ComponentModel.ISupportInitialize)imgDJ).BeginInit();
            SuspendLayout();
            // 
            // imgDJ
            // 
            imgDJ.Location = new Point(12, 12);
            imgDJ.Name = "imgDJ";
            imgDJ.Size = new Size(198, 198);
            imgDJ.SizeMode = PictureBoxSizeMode.Zoom;
            imgDJ.TabIndex = 0;
            imgDJ.TabStop = false;
            // 
            // linklbRepo
            // 
            linklbRepo.AutoSize = true;
            linklbRepo.Location = new Point(12, 287);
            linklbRepo.Name = "linklbRepo";
            linklbRepo.Size = new Size(104, 15);
            linklbRepo.TabIndex = 1;
            linklbRepo.TabStop = true;
            linklbRepo.Text = "GitHub Repository";
            linklbRepo.LinkClicked += linklbRepo_LinkClicked;
            // 
            // lbAbout
            // 
            lbAbout.AutoSize = true;
            lbAbout.Location = new Point(12, 223);
            lbAbout.Name = "lbAbout";
            lbAbout.Size = new Size(133, 15);
            lbAbout.TabIndex = 2;
            lbAbout.Text = "LumiTool version x.x.x.x";
            // 
            // lbDev
            // 
            lbDev.AutoSize = true;
            lbDev.Location = new Point(12, 255);
            lbDev.Name = "lbDev";
            lbDev.Size = new Size(88, 15);
            lbDev.TabIndex = 3;
            lbDev.Text = "Developed by x";
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(222, 311);
            Controls.Add(lbAbout);
            Controls.Add(lbDev);
            Controls.Add(linklbRepo);
            Controls.Add(imgDJ);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(238, 350);
            MinimumSize = new Size(238, 350);
            Name = "FormAbout";
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)imgDJ).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox imgDJ;
        private LinkLabel linklbRepo;
        private Label lbAbout;
        private Label lbDev;
    }
}