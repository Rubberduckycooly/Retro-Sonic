using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                BinaryReader reader = new System.IO.BinaryReader(File.OpenRead(dlg.FileName));
                //StreamReader reader = new System.IO.StreamReader(File.OpenRead(dlg.FileName));
                RetroSonicV2.Backgrounds BG = new RetroSonicV2.Backgrounds(reader);
                //RetroSonicV2.MapLayout Map = new RetroSonicV2.MapLayout(reader);
                //RetroSonicV2.ObjectLayout Objects2 = new RetroSonicV2.ObjectLayout(reader);
                //RetroSonicV2.til til = new RetroSonicV2.til(reader);
                //RetroSonicV2.Tileconfig tcf = new RetroSonicV2.Tileconfig(reader);
                //RetroSonicV2.zdf zdf = new RetroSonicV2.zdf(reader);
                //RetroSonicV2.mdf mdf = new RetroSonicV2.mdf(reader);
                Console.WriteLine("Current File Position: " + reader.BaseStream.Position + " File Length: " + reader.BaseStream.Length);
                Console.WriteLine("Done");
            }
        }
    }
}
