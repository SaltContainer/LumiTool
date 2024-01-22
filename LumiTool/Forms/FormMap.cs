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
        }

        private void UpdateComponentsOnLoad()
        {
            lbBundleName.Text = "Bundle Name: " + bundle.name;
            btnBundleSave.Enabled = bundle != null && bundleV != null;
        }

        private void UpdateComponentsOnLoadVanilla()
        {
            lbBundleVName.Text = "Bundle Name: " + bundleV.name;
            btnBundleSave.Enabled = bundle != null && bundleV != null;
        }

        private void btnBundleOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bundle = engine.LoadBundle(openFileDialog.FileName);
                    afileInst = engine.LoadAssetsFileFromBundle(bundle);

                    UpdateComponentsOnLoad();
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
                    bundleV = engine.LoadBundle(openFileDialog.FileName);
                    afileInstV = engine.LoadAssetsFileFromBundle(bundleV);

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

        private void button1_Click(object sender, EventArgs e)
        {
            engine.SetPlatformOfBundle(bundle, afileInst, Platform.Switch);
            MessageBox.Show("Successfully set platform!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            engine.CopyMaterials(afileInst, afileInstV);
            MessageBox.Show("Successfully copied materials!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}