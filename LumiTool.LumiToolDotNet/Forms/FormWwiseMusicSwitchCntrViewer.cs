using LumiTool.Data.Wwise;
using LumiTool.Engine;
using Microsoft.Msagl.Drawing;

namespace LumiTool.Forms
{
    public partial class FormWwiseMusicSwitchCntrViewer : Form
    {
        LumiToolEngine engine;

        WwiseData bank;
        string originalPath = string.Empty;

        public FormWwiseMusicSwitchCntrViewer(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            listMusicSwitch.Enabled = false;
            graphMusicSwitch.Enabled = false;

            ClearListBoxes();

            ttWwiseMusicSwitchCntrViewer.SetToolTip(lbBankName, "");
        }

        private void UpdateComponentsOnLoad()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            listMusicSwitch.Enabled = true;
            graphMusicSwitch.Enabled = true;

            AddMusicSwitchCntrsToListBox();

            ttWwiseMusicSwitchCntrViewer.SetToolTip(lbBankName, originalPath);
        }

        private void ClearListBoxes()
        {
            listMusicSwitch.Items.Clear();
        }

        private void AddMusicSwitchCntrsToListBox()
        {
            listMusicSwitch.Items.Clear();
            var mscs = engine.GetMusicSwitchCntrsOfBank(bank).OrderBy(x => x.id);
            foreach (var msc in mscs)
                listMusicSwitch.Items.Add(msc);
        }

        private void OpenBank(string path)
        {
            originalPath = path;
            bank = engine.LoadBank(path);
            UpdateComponentsOnLoad();
        }

        private void ShowMusicSwitchCntrInGraph(MusicSwitchCntr msc)
        {
            Graph graph = new Graph();
            int index = 0;
            AddChildrenNodesToGraph(graph, msc.decisionTree, 0, string.Empty, ref index);

            graphMusicSwitch.Graph = graph;
        }

        private void AddChildrenNodesToGraph(Graph graph, Data.Wwise.Node node, int depth, string parentName, ref int currIndex)
        {
            //var name = $"[{depth}-{node.key}] {node.weight}W {node.probability}%";
            var name = $"{currIndex}";
            graph.AddNode(name);

            if (node.audioNodeId == 380621555)
                MessageBox.Show($"Hi!!!! I'm index {currIndex}", "test");

            if (!string.IsNullOrEmpty(parentName))
                graph.AddEdge(parentName, name);

            foreach (var child in node.nodes)
            {
                currIndex++;
                AddChildrenNodesToGraph(graph, child, depth + 1, name, ref currIndex);
            }
        }

        private void btnBankOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenBank(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while loading the bank. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBankSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    engine.SaveBank(bank, saveFileDialog.FileName);
                    MessageBox.Show("Successfully saved the new bank!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while saving the new bank. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormWwiseMusicSwitchCntrViewer_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormWwiseMusicSwitchCntrViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            bank = null;
            originalPath = string.Empty;
        }

        private void btnBankOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btnBankOpen_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
                MessageBox.Show("Multiple files were dragged into the tool. The Wwise MusicSwitchCntr Viewer only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenBank(files[0]);
        }

        private void listMusicSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMusicSwitch.SelectedIndex > -1 && listMusicSwitch.SelectedIndex < listMusicSwitch.Items.Count)
                ShowMusicSwitchCntrInGraph(listMusicSwitch.SelectedItem as MusicSwitchCntr);
        }
    }
}
