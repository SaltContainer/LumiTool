﻿using LumiTool.Data;
using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormBundlePrepperMass : Form
    {
        LumiToolEngine engine;
        string folderPath = null;
        string outputPath = null;

        public FormBundlePrepperMass(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            ttBundlePrepper.SetToolTip(checkTpk, "Checking this before selecting the rebuilt bundles folder\nthe classdata.tpk file in the same folder as the executable.\nUse this if you built the bundles without a type tree.");
            ttBundlePrepper.SetToolTip(checkConvertPlatform, "Changes the platform metadata of the rebuilt bundles to Switch.");
            ttBundlePrepper.SetToolTip(checkConvertShaders, "When on, each material asset's shader will be remapped.\nThe user will be asked to identify the proper shader from a pre-set list\nfor each different shader that was detected.");
        }

        private void UpdateComponentsOnStart()
        {
            lbBundleName.Text = "Folder Path: ";
            lbOutputBundleName.Text = "Folder Path: ";
            btnConvertApply.Enabled = false;
            checkConvertPlatform.Enabled = false;
            checkConvertShaders.Enabled = false;
            checkTpk.Enabled = true;

            ttBundlePrepper.SetToolTip(lbBundleName, "");
        }

        private void UpdateComponentsOnLoadCommon()
        {
            bool active = folderPath != null && outputPath != null;
            btnConvertApply.Enabled = active;
            checkConvertPlatform.Enabled = active;
            checkConvertShaders.Enabled = active;
        }

        private void UpdateComponentsOnLoadEditing()
        {
            lbBundleName.Text = "Folder Path: " + folderPath;
            ttBundlePrepper.SetToolTip(lbBundleName, folderPath);
            checkTpk.Enabled = false;
            UpdateComponentsOnLoadCommon();
        }

        private void UpdateComponentsOnLoadVanilla()
        {
            lbOutputBundleName.Text = "Folder Path: " + outputPath;
            ttBundlePrepper.SetToolTip(lbOutputBundleName, outputPath);
            UpdateComponentsOnLoadCommon();
        }

        private void btnBundleOpen_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;

                UpdateComponentsOnLoadEditing();
            }
        }

        private void btnOutputBundleOpen_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = folderBrowserDialog.SelectedPath;

                UpdateComponentsOnLoadVanilla();
            }
        }

        private void FormBundlePrepperMass_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormBundlePrepperMass_FormClosed(object sender, FormClosedEventArgs e)
        {
            engine.UnloadBundles();
        }

        private void btnConvertApply_Click(object sender, EventArgs e)
        {
            bool classesLoaded = !checkTpk.Checked;
            bool exceptionHappened = false;
            Dictionary<long, Shader> foundShaders = new Dictionary<long, Shader>();

            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                try
                {
                    var bundle = engine.LoadBundle(file, BundleEngine.ManagerID.Modded);
                    var afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);

                    if (checkConvertPlatform.Checked) engine.SetPlatformOfBundle(bundle, afileInst, Platform.Switch);
                    if (checkConvertShaders.Checked) engine.FixShadersOfMaterials(bundle, afileInst, true, foundShaders);

                    if (!classesLoaded && checkTpk.Checked)
                    {
                        engine.LoadClassPackage(afileInst, BundleEngine.ManagerID.Modded);
                        classesLoaded = true;
                    }

                    engine.SaveBundleToFile(bundle, Path.Combine(outputPath, Path.GetFileName(file)));
                }
                catch (Exception ex)
                {
                    exceptionHappened = true;
                    MessageBox.Show("There was an exception when converting the bundle at \"" + file + "\". Full Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (exceptionHappened)
                MessageBox.Show("There were one or more exceptions while preparing bundles. Any successful prepared bundles were still saved to the output folder.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Successfully saved all the new bundles to the output folder!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
