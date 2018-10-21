using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace RetroSonicEditor.Tools.MapEditor
{
    public partial class StageChunksView : DockContent
    {
        public Image _tiles1;
        public Image _tiles2;
        public Image _tiles3;

        public List<Bitmap> Chunks = new List<Bitmap>();

        public StageMapView MapView;

        //private Point tilePoint;
        public int selectedChunk;

        #region Retro-Sonic Development Kit
        public RetroSonicV2.til _chunks;
        public List<RetroSonicV2.Object> stageObjects = new List<RetroSonicV2.Object>();
        #endregion

        public StageChunksView(StageMapView mpv)
        {
            InitializeComponent();
            MapView = mpv;
        }

        public void SetChunks()
        {
            LoadChunks();
            Refresh();
        }

        void LoadChunks()
        {
            BlocksList.Images.Clear();
            for (int i = 0; i < _tiles1.Height/128; i++)
            {
                Bitmap b = CropImage((Bitmap)_tiles1, new Rectangle(0, i * 128, 128, 128));
                //b.MakeTransparent(Color.FromArgb(255, 0, 0, 0));
                Chunks.Add(b);
                BlocksList.Images.Add(b);
                //b.Dispose();
            }
            for (int i = 0; i < _tiles2.Height / 128; i++)
            {
                Bitmap b = CropImage((Bitmap)_tiles2, new Rectangle(0, i * 128, 128, 128));
                //b.MakeTransparent(Color.FromArgb(255, 0, 0, 0));
                Chunks.Add(b);
                BlocksList.Images.Add(b);
                //b.Dispose();
            }
            for (int i = 0; i < _tiles3.Height / 128; i++)
            {
                Bitmap b = CropImage((Bitmap)_tiles3, new Rectangle(0, i * 128, 128, 128));
                //b.MakeTransparent(Color.FromArgb(255, 0, 0, 0));
                Chunks.Add(b);
                BlocksList.Images.Add(b);
                //b.Dispose();
            }
            BlocksList.SelectedIndex = 0;
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        private void BlocksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedChunk = BlocksList.SelectedIndex;
            Console.WriteLine("New Chunk " + selectedChunk);
        }

        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ObjectList_DoubleClick(object sender, EventArgs e)
        {

            ObjectPropertiesForm frm = new ObjectPropertiesForm();
            frm.Setup(MapView._Scene.Objects[ObjectList.SelectedIndex]);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                MapView._Scene.Objects[ObjectList.SelectedIndex] = frm.Object;
                RefreshObjList();
            }
        }

        public void RefreshObjList()
        {
            ObjectList.Items.Clear();
            Object_Definitions.Retro_SonicGlobalObjects RSObj = new Object_Definitions.Retro_SonicGlobalObjects();
            for (int i = 0; i < stageObjects.Count; i++)
            {
                string Obj = "";
                //string t = RSObj.GetObjectByType(stageObjects[i].type, stageObjects[i].subtype).Name;
                //if (t != null) { Obj = t + ", " + stageObjects[i].xPos + ", " + stageObjects[i].yPos; }
                //else { Obj = "Unnamed Object" + ", " + stageObjects[i].xPos + ", " + stageObjects[i].yPos; }
                Obj = "Unnamed Object, " + stageObjects[i].Type + ", " + stageObjects[i].ChunkPosX + ", " + stageObjects[i].PosOffsetX + ", " + stageObjects[i].ChunkPosY + ", " + stageObjects[i].PosOffsetY;
                Console.WriteLine(Obj);
                ObjectList.Items.Add(Obj);
            }
        }

    }
}
