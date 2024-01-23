namespace LumiTool
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnPlatform = new Button();
            btnMono = new Button();
            btnMap = new Button();
            btnCharacter = new Button();
            btnAbout = new Button();
            SuspendLayout();
            // 
            // btnPlatform
            // 
            btnPlatform.Location = new Point(12, 65);
            btnPlatform.Name = "btnPlatform";
            btnPlatform.Size = new Size(164, 59);
            btnPlatform.TabIndex = 0;
            btnPlatform.Text = "Change Bundle Platform";
            btnPlatform.UseVisualStyleBackColor = true;
            btnPlatform.Click += btnPlatform_Click;
            // 
            // btnMono
            // 
            btnMono.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMono.Location = new Point(182, 65);
            btnMono.Name = "btnMono";
            btnMono.Size = new Size(164, 59);
            btnMono.TabIndex = 1;
            btnMono.Text = "Add MonoScript";
            btnMono.UseVisualStyleBackColor = true;
            btnMono.Click += btnMono_Click;
            // 
            // btnMap
            // 
            btnMap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnMap.Location = new Point(12, 130);
            btnMap.Name = "btnMap";
            btnMap.Size = new Size(164, 59);
            btnMap.TabIndex = 2;
            btnMap.Text = "Map Stuff";
            btnMap.UseVisualStyleBackColor = true;
            btnMap.Click += btnMap_Click;
            // 
            // btnCharacter
            // 
            btnCharacter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCharacter.Location = new Point(182, 130);
            btnCharacter.Name = "btnCharacter";
            btnCharacter.Size = new Size(164, 59);
            btnCharacter.TabIndex = 3;
            btnCharacter.Text = "Character Stuff";
            btnCharacter.UseVisualStyleBackColor = true;
            btnCharacter.Click += btnCharacter_Click;
            // 
            // btnAbout
            // 
            btnAbout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAbout.Location = new Point(271, 12);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(75, 47);
            btnAbout.TabIndex = 4;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 201);
            Controls.Add(btnAbout);
            Controls.Add(btnPlatform);
            Controls.Add(btnMono);
            Controls.Add(btnMap);
            Controls.Add(btnCharacter);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(374, 240);
            MinimumSize = new Size(374, 240);
            Name = "FormMain";
            Text = "LumiTool";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlatform;
        private Button btnMono;
        private Button btnMap;
        private Button btnCharacter;
        private Button btnAbout;
    }
}