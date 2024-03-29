﻿using AssetsTools.NET.Extra;
using LumiTool.Data;
using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormMap : Form
    {
        LumiToolEngine engine;
        BundleFileInstance bundle = null!;
        AssetsFileInstance afileInst = null!;
        BundleFileInstance bundleV = null!;
        AssetsFileInstance afileInstV = null!;

        public FormMap(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbBundleName.Text = "Bundle Name: ";
            lbBundleVName.Text = "Bundle Name: ";
            btnBundleSave.Enabled = false;
            btnConvertApply.Enabled = false;
            checkConvertPlatform.Enabled = false;
            checkConvertDependencies.Enabled = false;
            checkConvertShaders.Enabled = false;
        }

        private void UpdateComponentsOnLoadCommon()
        {
            bool active = bundle != null && bundleV != null;
            btnBundleSave.Enabled = active;
            btnConvertApply.Enabled = active;
            checkConvertPlatform.Enabled = active;
            checkConvertDependencies.Enabled = active;
            checkConvertShaders.Enabled = active;
        }

        private void UpdateComponentsOnLoadEditing()
        {
            lbBundleName.Text = "Bundle Name: " + bundle.name;
            UpdateComponentsOnLoadCommon();
        }

        private void UpdateComponentsOnLoadVanilla()
        {
            lbBundleVName.Text = "Bundle Name: " + bundleV.name;
            UpdateComponentsOnLoadCommon();
        }

        private void btnBundleOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bundle = engine.LoadBundle(openFileDialog.FileName);
                    afileInst = engine.LoadAssetsFileFromBundle(bundle);

                    UpdateComponentsOnLoadEditing();
                }
            }
        }

        private void btnBundleSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    engine.SaveBundleToFile(bundle, saveFileDialog.FileName);
                    MessageBox.Show("Successfully saved the new bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBundleVOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bundleV = engine.LoadBundleV(openFileDialog.FileName);
                    afileInstV = engine.LoadAssetsFileFromBundleV(bundleV);

                    UpdateComponentsOnLoadVanilla();
                }
            }
        }

        private void FormMap_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            bundle = null!;
            afileInst = null!;
            bundleV = null!;
            afileInstV = null!;
            engine.UnloadBundles();
        }

        private void btnConvertApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkConvertPlatform.Checked) engine.SetPlatformOfBundle(bundle, afileInst, Platform.Switch);
                if (checkConvertDependencies.Checked) engine.CopyDependencies(afileInst, afileInstV);
                if (checkConvertShaders.Checked) engine.FixShadersOfMaterials(bundle, afileInst);
                MessageBox.Show("Successfully converted the map bundle. Don't forget to save your bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an exception when converting the map bundle. Full Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
