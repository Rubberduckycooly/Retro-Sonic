using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroSonicEditor.Tools.MapEditor
{
    public partial class ObjectPropertiesForm : Form
    {

        public RetroSonicV2.Object Object = new RetroSonicV2.Object();

        public ObjectPropertiesForm()
        {
            InitializeComponent();
        }

        public void Setup(RetroSonicV2.Object obj)
        {
            Object = obj;
            RefreshUI();
        }

        void RefreshUI()
        {
            Byte1NUD.Value = Object.Type;
            Byte2NUD.Value = Object.ChunkPosX;
            Byte3NUD.Value = Object.PosOffsetX;
            Byte4NUD.Value = Object.ChunkPosY;
            Byte5NUD.Value = Object.PosOffsetY;
        }

        private void Byte1NUD_ValueChanged(object sender, EventArgs e)
        {
            Object.Type = (byte)Byte1NUD.Value;
        }

        private void Byte2NUD_ValueChanged(object sender, EventArgs e)
        {
            Object.ChunkPosX = (byte)Byte2NUD.Value;
        }

        private void Byte3NUD_ValueChanged(object sender, EventArgs e)
        {
            Object.PosOffsetX = (byte)Byte3NUD.Value;
        }

        private void Byte4NUD_ValueChanged(object sender, EventArgs e)
        {
            Object.ChunkPosY = (byte)Byte4NUD.Value;
        }
        private void Byte5NUD_ValueChanged(object sender, EventArgs e)
        {
            Object.PosOffsetY = (byte)Byte5NUD.Value;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
