using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroSonicEditor.Tools.RetroSonicStageListEditor
{
    public partial class MainForm : Form
    {
        public RetroSonicV2.mdf ZoneNames = new RetroSonicV2.mdf();
        public RetroSonicV2.ZoneDataFile ZoneData = new RetroSonicV2.ZoneDataFile();

        int currentStage = 0;

        string filePath;

        public MainForm()
        {
            InitializeComponent();
        }

        public void New()
        {
            ZoneNames = new RetroSonicV2.mdf();
            ZoneData = new RetroSonicV2.ZoneDataFile();
            filePath = "";
            RefreshUI();
        }

        public void Open(string filepath)
        {
            ZoneNames = new RetroSonicV2.mdf(new System.IO.StreamReader(System.IO.File.OpenRead(filepath)));
            string fp2 = filepath.Replace(".mdf", ".zdf");
            ZoneData = new RetroSonicV2.ZoneDataFile(new System.IO.StreamReader(System.IO.File.OpenRead(fp2)));
            filePath = filepath; 
            RefreshUI();
            RefreshList();
        }

        public void Save(string filepath)
        {
            ZoneNames.Write(new System.IO.StreamWriter(System.IO.File.Create(filepath)));
            string fp2 = filepath.Replace(".mdf", ".zdf");
            ZoneNames.Write(new System.IO.StreamWriter(System.IO.File.Create(fp2)));
        }

        void RefreshUI()
        {

            StgNameBox.Text = ZoneNames.ZoneNames[currentStage];
            StgFolderBox.Text = ZoneData.Zones[currentStage].ZoneFolder;
            Act1IDBox.Text = ZoneData.Zones[currentStage].ActID1;
            Act2IDBox.Text = ZoneData.Zones[currentStage].ActID2;
            Act3IDBox.Text = ZoneData.Zones[currentStage].ActID3;
        }

        void RefreshList()
        {
            StageListBox.Items.Clear();
            for (int i = 0; i < ZoneNames.ZoneNames.Count; i++)
            {
                StageListBox.Items.Add((ZoneNames.ZoneNames[i] + ", " + ZoneData.Zones[i].ZoneFolder + ", " + ZoneData.Zones[i].ActID1 + ", " + ZoneData.Zones[i].ActID2 + ", " + ZoneData.Zones[i].ActID3));
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Retro-Sonic Stage Lists|*.mdf";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Open(dlg.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath != null)
            {
                Save(filePath);
            }
            else
            {
                saveAsToolStripMenuItem_Click(this, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Retro-Sonic Stage Lists|*.mdf";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Open(dlg.FileName);
            }
        }

        private void StageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StageListBox.SelectedIndex >= 0)
            {
                currentStage = StageListBox.SelectedIndex;
                RefreshUI();
            }
        }

        private void StgNameBox_TextChanged(object sender, EventArgs e)
        {
            if (StageListBox.SelectedIndex >= 0)
            {
                ZoneNames.ZoneNames[StageListBox.SelectedIndex] = StgNameBox.Text;
                RefreshUI();
                if (StageListBox.SelectedIndex >= 0)
                {
                    StageListBox.Items[StageListBox.SelectedIndex] = (ZoneNames.ZoneNames[currentStage] + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ZoneFolder + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID1 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID2 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID3);
                }
            }
        }

        private void StgFolderBox_TextChanged(object sender, EventArgs e)
        {
            if (StageListBox.SelectedIndex >= 0)
            {
                ZoneData.Zones[StageListBox.SelectedIndex].ZoneFolder = StgFolderBox.Text;
                RefreshUI();
                if (StageListBox.SelectedIndex >= 0)
                {
                    StageListBox.Items[StageListBox.SelectedIndex] = (ZoneNames.ZoneNames[currentStage] + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ZoneFolder + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID1 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID2 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID3);
                }
            }
        }

        private void ActIDBox_TextChanged(object sender, EventArgs e)
        {
            if (StageListBox.SelectedIndex >= 0)
            {
                ZoneData.Zones[StageListBox.SelectedIndex].ActID1 = Act1IDBox.Text;
                RefreshUI();
                if (StageListBox.SelectedIndex >= 0)
                {
                    StageListBox.Items[StageListBox.SelectedIndex] = (ZoneNames.ZoneNames[currentStage] + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ZoneFolder + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID1 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID2 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID3);
                }
            }
        }

        private void Act2IDBox_TextChanged(object sender, EventArgs e)
        {
            if (StageListBox.SelectedIndex >= 0)
            {
                ZoneData.Zones[StageListBox.SelectedIndex].ActID2 = Act2IDBox.Text;
                RefreshUI();
                if (StageListBox.SelectedIndex >= 0)
                {
                    StageListBox.Items[StageListBox.SelectedIndex] = (ZoneNames.ZoneNames[currentStage] + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ZoneFolder + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID1 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID2 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID3);
                }
            }
        }
        private void Act3IDBox_TextChanged(object sender, EventArgs e)
        {
            if (StageListBox.SelectedIndex >= 0)
            {
                ZoneData.Zones[StageListBox.SelectedIndex].ActID3 = Act3IDBox.Text;
                RefreshUI();
                if (StageListBox.SelectedIndex >= 0)
                {
                    StageListBox.Items[StageListBox.SelectedIndex] = (ZoneNames.ZoneNames[currentStage] + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ZoneFolder + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID1 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID2 + ", " + ZoneData.Zones[StageListBox.SelectedIndex].ActID3);
                }
            }
        }

        private void AddStageButton_Click(object sender, EventArgs e)
        {
            ZoneNames.ZoneNames.Add("New Zone");
            RetroSonicV2.ZoneDataFile.ZoneData Lvl = new RetroSonicV2.ZoneDataFile.ZoneData();
            ZoneData.Zones.Add(Lvl);
            StageListBox.Items.Add("New Zone" + ", " + Lvl.ZoneFolder + ", " + Lvl.ActID1 + ", " + Lvl.ActID2 + ", " + Lvl.ActID3);
        }

        private void DeleteStageButton_Click(object sender, EventArgs e)
        {
            ZoneNames.ZoneNames.RemoveAt(currentStage);
            ZoneData.Zones.RemoveAt(currentStage);
            currentStage--;
            RefreshList();
            RefreshUI();
        }
    }
}
