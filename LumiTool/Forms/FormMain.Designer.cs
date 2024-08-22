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
            btnPrepper = new Button();
            btnColorVariation = new Button();
            btnAbout = new Button();
            btnManifestRefresher = new Button();
            btnManifestEditor = new Button();
            btnShaderPathIDFixer = new Button();
            btnBundleRenamer = new Button();
            SuspendLayout();
            // 
            // btnPlatform
            // 
            btnPlatform.Location = new Point(12, 65);
            btnPlatform.Name = "btnPlatform";
            btnPlatform.Size = new Size(164, 59);
            btnPlatform.TabIndex = 1;
            btnPlatform.Text = "Change Bundle Platform";
            btnPlatform.UseVisualStyleBackColor = true;
            btnPlatform.Click += btnPlatform_Click;
            // 
            // btnMono
            // 
            btnMono.Location = new Point(182, 65);
            btnMono.Name = "btnMono";
            btnMono.Size = new Size(164, 59);
            btnMono.TabIndex = 2;
            btnMono.Text = "Add MonoScript";
            btnMono.UseVisualStyleBackColor = true;
            btnMono.Click += btnMono_Click;
            // 
            // btnPrepper
            // 
            btnPrepper.Location = new Point(12, 130);
            btnPrepper.Name = "btnPrepper";
            btnPrepper.Size = new Size(164, 59);
            btnPrepper.TabIndex = 4;
            btnPrepper.Text = "Bundle Prepper";
            btnPrepper.UseVisualStyleBackColor = true;
            btnPrepper.Click += btnPrepper_Click;
            // 
            // btnColorVariation
            // 
            btnColorVariation.Location = new Point(352, 130);
            btnColorVariation.Name = "btnColorVariation";
            btnColorVariation.Size = new Size(164, 59);
            btnColorVariation.TabIndex = 6;
            btnColorVariation.Text = "ColorVariation Generator";
            btnColorVariation.UseVisualStyleBackColor = true;
            btnColorVariation.Click += btnColorVariation_Click;
            // 
            // btnAbout
            // 
            btnAbout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAbout.Location = new Point(441, 12);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(75, 47);
            btnAbout.TabIndex = 0;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // btnManifestRefresher
            // 
            btnManifestRefresher.Location = new Point(12, 195);
            btnManifestRefresher.Name = "btnManifestRefresher";
            btnManifestRefresher.Size = new Size(164, 59);
            btnManifestRefresher.TabIndex = 7;
            btnManifestRefresher.Text = "AssetAssistant Manifest Refresher";
            btnManifestRefresher.UseVisualStyleBackColor = true;
            btnManifestRefresher.Click += btnManifestRefresher_Click;
            // 
            // btnManifestEditor
            // 
            btnManifestEditor.Location = new Point(182, 195);
            btnManifestEditor.Name = "btnManifestEditor";
            btnManifestEditor.Size = new Size(164, 59);
            btnManifestEditor.TabIndex = 8;
            btnManifestEditor.Text = "AssetAssistant Manifest Editor";
            btnManifestEditor.UseVisualStyleBackColor = true;
            btnManifestEditor.Click += btnManifestEditor_Click;
            // 
            // btnShaderPathIDFixer
            // 
            btnShaderPathIDFixer.Location = new Point(352, 65);
            btnShaderPathIDFixer.Name = "btnShaderPathIDFixer";
            btnShaderPathIDFixer.Size = new Size(164, 59);
            btnShaderPathIDFixer.TabIndex = 3;
            btnShaderPathIDFixer.Text = "Shader Bundle PathID Fixer";
            btnShaderPathIDFixer.UseVisualStyleBackColor = true;
            btnShaderPathIDFixer.Click += btnShaderPathIDFixer_Click;
            // 
            // btnBundleRenamer
            // 
            btnBundleRenamer.Location = new Point(182, 130);
            btnBundleRenamer.Name = "btnBundleRenamer";
            btnBundleRenamer.Size = new Size(164, 59);
            btnBundleRenamer.TabIndex = 5;
            btnBundleRenamer.Text = "Bundle Renamer";
            btnBundleRenamer.UseVisualStyleBackColor = true;
            btnBundleRenamer.Click += btnBundleRenamer_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 266);
            Controls.Add(btnBundleRenamer);
            Controls.Add(btnShaderPathIDFixer);
            Controls.Add(btnManifestEditor);
            Controls.Add(btnManifestRefresher);
            Controls.Add(btnAbout);
            Controls.Add(btnPlatform);
            Controls.Add(btnMono);
            Controls.Add(btnPrepper);
            Controls.Add(btnColorVariation);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(544, 305);
            MinimumSize = new Size(544, 305);
            Name = "FormMain";
            Text = "LumiTool";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlatform;
        private Button btnMono;
        private Button btnPrepper;
        private Button btnColorVariation;
        private Button btnAbout;
        private Button btnManifestRefresher;
        private Button btnManifestEditor;
        private Button btnShaderPathIDFixer;
        private Button btnBundleRenamer;
    }
}