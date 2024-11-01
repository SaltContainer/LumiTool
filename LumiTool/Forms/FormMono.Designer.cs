namespace LumiTool.Forms
{
    partial class FormMono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMono));
            grpBundle = new GroupBox();
            lbBundleName = new Label();
            btnBundleOpen = new Button();
            btnBundleSave = new Button();
            btnAddMono = new Button();
            txtAssembly = new TextBox();
            lbAssembly = new Label();
            lbNamespace = new Label();
            txtNamespace = new TextBox();
            lbClass = new Label();
            txtClass = new TextBox();
            grpBundle.SuspendLayout();
            SuspendLayout();
            // 
            // grpBundle
            // 
            grpBundle.Controls.Add(lbBundleName);
            grpBundle.Controls.Add(btnBundleOpen);
            grpBundle.Controls.Add(btnBundleSave);
            grpBundle.Location = new Point(12, 12);
            grpBundle.Name = "grpBundle";
            grpBundle.Size = new Size(260, 86);
            grpBundle.TabIndex = 2;
            grpBundle.TabStop = false;
            grpBundle.Text = "Loaded Bundle";
            // 
            // lbBundleName
            // 
            lbBundleName.AutoSize = true;
            lbBundleName.Location = new Point(6, 19);
            lbBundleName.Name = "lbBundleName";
            lbBundleName.Size = new Size(85, 15);
            lbBundleName.TabIndex = 1;
            lbBundleName.Text = "Bundle Name: ";
            // 
            // btnBundleOpen
            // 
            btnBundleOpen.AllowDrop = true;
            btnBundleOpen.Image = Resources.Resources.folder;
            btnBundleOpen.Location = new Point(6, 40);
            btnBundleOpen.Name = "btnBundleOpen";
            btnBundleOpen.Size = new Size(121, 40);
            btnBundleOpen.TabIndex = 0;
            btnBundleOpen.Text = "Open";
            btnBundleOpen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleOpen.UseVisualStyleBackColor = true;
            btnBundleOpen.Click += btnBundleOpen_Click;
            btnBundleOpen.DragDrop += btnBundleOpen_DragDrop;
            btnBundleOpen.DragEnter += btnBundleOpen_DragEnter;
            // 
            // btnBundleSave
            // 
            btnBundleSave.Image = Resources.Resources.save;
            btnBundleSave.Location = new Point(133, 40);
            btnBundleSave.Name = "btnBundleSave";
            btnBundleSave.Size = new Size(121, 40);
            btnBundleSave.TabIndex = 2;
            btnBundleSave.Text = "Save";
            btnBundleSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBundleSave.UseVisualStyleBackColor = true;
            btnBundleSave.Click += btnBundleSave_Click;
            // 
            // btnAddMono
            // 
            btnAddMono.Location = new Point(12, 200);
            btnAddMono.Name = "btnAddMono";
            btnAddMono.Size = new Size(260, 34);
            btnAddMono.TabIndex = 3;
            btnAddMono.Text = "Add MonoScript";
            btnAddMono.UseVisualStyleBackColor = true;
            btnAddMono.Click += btnAddMono_Click;
            // 
            // txtAssembly
            // 
            txtAssembly.Location = new Point(79, 113);
            txtAssembly.Name = "txtAssembly";
            txtAssembly.Size = new Size(193, 23);
            txtAssembly.TabIndex = 4;
            // 
            // lbAssembly
            // 
            lbAssembly.AutoSize = true;
            lbAssembly.Location = new Point(12, 116);
            lbAssembly.Name = "lbAssembly";
            lbAssembly.Size = new Size(61, 15);
            lbAssembly.TabIndex = 5;
            lbAssembly.Text = "Assembly:";
            // 
            // lbNamespace
            // 
            lbNamespace.AutoSize = true;
            lbNamespace.Location = new Point(12, 145);
            lbNamespace.Name = "lbNamespace";
            lbNamespace.Size = new Size(72, 15);
            lbNamespace.TabIndex = 7;
            lbNamespace.Text = "Namespace:";
            // 
            // txtNamespace
            // 
            txtNamespace.Location = new Point(90, 142);
            txtNamespace.Name = "txtNamespace";
            txtNamespace.Size = new Size(182, 23);
            txtNamespace.TabIndex = 6;
            // 
            // lbClass
            // 
            lbClass.AutoSize = true;
            lbClass.Location = new Point(12, 174);
            lbClass.Name = "lbClass";
            lbClass.Size = new Size(37, 15);
            lbClass.TabIndex = 9;
            lbClass.Text = "Class:";
            // 
            // txtClass
            // 
            txtClass.Location = new Point(55, 171);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(217, 23);
            txtClass.TabIndex = 8;
            // 
            // FormMono
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 246);
            Controls.Add(lbClass);
            Controls.Add(txtClass);
            Controls.Add(lbNamespace);
            Controls.Add(txtNamespace);
            Controls.Add(lbAssembly);
            Controls.Add(txtAssembly);
            Controls.Add(btnAddMono);
            Controls.Add(grpBundle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(300, 285);
            MinimumSize = new Size(300, 285);
            Name = "FormMono";
            Text = "MonoScript Insertion";
            FormClosed += FormMono_FormClosed;
            Shown += FormMono_Shown;
            grpBundle.ResumeLayout(false);
            grpBundle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpBundle;
        private Label lbBundleName;
        private Button btnBundleOpen;
        private Button btnBundleSave;
        private Button btnAddMono;
        private TextBox txtAssembly;
        private Label lbAssembly;
        private Label lbNamespace;
        private TextBox txtNamespace;
        private Label lbClass;
        private TextBox txtClass;
    }
}