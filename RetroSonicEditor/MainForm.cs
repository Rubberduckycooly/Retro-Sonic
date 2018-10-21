using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroSonicEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Tools.MapEditor.MainView OpenMapEditor()
        {
            Tools.MapEditor.MainView frm = new Tools.MapEditor.MainView();
            frm.TopLevel = false;
            frm.ControlBox = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            var newTab = new TabPage();
            newTab.Controls.Add(frm);
            this.TabControl.TabPages.Add(newTab);
            this.TabControl.SelectedTab = newTab;
            this.TabControl.SelectedTab.Text = frm.Text;
            frm.Show();
            return frm;
        }

        Tools.RetroSonicStageListEditor.MainForm OpenStageListEditor()
        {
            Tools.RetroSonicStageListEditor.MainForm frm = new Tools.RetroSonicStageListEditor.MainForm();
            frm.TopLevel = false;
            frm.ControlBox = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            var newTab = new TabPage();
            newTab.Controls.Add(frm);
            this.TabControl.TabPages.Add(newTab);
            this.TabControl.SelectedTab = newTab;
            this.TabControl.SelectedTab.Text = frm.Text;
            frm.Show();
            return frm;
        }

        private void animationEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mapEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMapEditor();
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab != null) TabControl.SelectedTab.Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void stageListEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenStageListEditor();
        }
    }
}
