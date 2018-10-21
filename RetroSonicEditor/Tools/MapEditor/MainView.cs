using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RetroSonicEditor.Tools.MapEditor
{
    public partial class MainView : Form
    {
        enum Placementmode
        {
            NONE,
            PlaceTiles,
            PlaceObjects
        }

        public Image _loadedTiles1;
        public Image _loadedTiles2;
        public Image _loadedTiles3;
        private StageChunksView _blocksViewer;
        private StageMapView _mapViewer;

        string tiles1;
        string tiles2;
        string tiles3;
        string mappings;
        string Map;
        string CollisionMasks;

        bool showgrid = false;
        int PlacementMode = 0;

        #region Retro-Sonic Development Kit
        RetroSonicV2.Scene _Scene;
        RetroSonicV2.til _Chunks;
        RetroSonicV2.Tileconfig _CollisionMasks;
        #endregion

        public MainView()
        {
            InitializeComponent();
            _mapViewer = new StageMapView();
            _mapViewer.Show(dpMain, WeifenLuo.WinFormsUI.Docking.DockState.Document);
            _blocksViewer = new StageChunksView(_mapViewer);
            _blocksViewer.Show(dpMain, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            _mapViewer._ChunkView = _blocksViewer;
        }

        private void tsmiFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Retro-Sonic .map files (*.map)|*.map";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tiles1 = Path.Combine(Path.GetDirectoryName(ofd.FileName), "EGL1.bmp");
                tiles2 = Path.Combine(Path.GetDirectoryName(ofd.FileName), "EGL2.bmp");
                tiles3 = Path.Combine(Path.GetDirectoryName(ofd.FileName), "EGL3.bmp");
                mappings = Path.Combine(Path.GetDirectoryName(ofd.FileName), "EGT.til");
                Map = ofd.FileName;
                CollisionMasks = Path.Combine(Path.GetDirectoryName(ofd.FileName), "EGC.tcf");
                if (File.Exists(tiles1) && File.Exists(tiles2) && File.Exists(tiles3) && File.Exists(mappings) && File.Exists(CollisionMasks))
                {
                    LoadLevel(ofd.FileName);
                }
                else
                {
                    MessageBox.Show("Tiles, Mappings and Collision Masks need to exist in the same folder as act data, just like the game.");
                }
            }
        }

        void LoadLevel(string level)
        {
            //Clears the map
            _mapViewer.DrawLevel();

            using (BinaryReader strm = new BinaryReader(File.OpenRead(level)))
            {
                _Scene = new RetroSonicV2.Scene(strm);
            }
            using (BinaryReader strm = new BinaryReader(File.OpenRead(mappings)))
            {
                _Chunks = new RetroSonicV2.til(strm);
            }
            _loadedTiles1 = Bitmap.FromFile(tiles1);
            _loadedTiles2 = Bitmap.FromFile(tiles2);
            _loadedTiles3 = Bitmap.FromFile(tiles3);
            _blocksViewer._chunks = _Chunks;
            _blocksViewer._tiles1 = _loadedTiles1;
            _blocksViewer._tiles2 = _loadedTiles2;
            _blocksViewer._tiles3 = _loadedTiles3;

            _blocksViewer.SetChunks();
            _blocksViewer.stageObjects = _Scene.Objects;
            _blocksViewer.RefreshObjList();

            _mapViewer._tiles1 = _loadedTiles1;
            _mapViewer._tiles2 = _loadedTiles2;
            _mapViewer._tiles3 = _loadedTiles3;
            _mapViewer._Scene = _Scene;
            _mapViewer._CollisionMasks = _CollisionMasks;
            _mapViewer.SetLevel();
        }

        private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Scene != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Image (*.png)|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap massive = new Bitmap(_Scene.MapLayout[0].Length * 128, _Scene.MapLayout.Length * 128);
                    using (Graphics g = Graphics.FromImage(massive))
                    {
                        for (int y = 0; y < _Scene.MapLayout.Length; y++)
                        {
                            for (int x = 0; x < _Scene.MapLayout[0].Length; x++)
                            {
                                //g.DrawImage(_Chunks.BlockList[_Scene.MapLayout[y][x]].Render(_loadedTiles), x * 128, y * 128);
                            }
                        }
                    }
                    massive.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    massive.Dispose();
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mapLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapLayersToolStripMenuItem.Checked)
            {
                mapLayersToolStripMenuItem.Checked = false;
                _mapViewer.ShowMap = false;
            }
            else if (!mapLayersToolStripMenuItem.Checked)
            {
                mapLayersToolStripMenuItem.Checked = true;
                _mapViewer.ShowMap = true;
            }
        }

        private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectsToolStripMenuItem.Checked)
            {
                objectsToolStripMenuItem.Checked = false;
                _mapViewer.ShowObjects = false;
            }
            else if (!objectsToolStripMenuItem.Checked)
            {
                objectsToolStripMenuItem.Checked = true;
                _mapViewer.ShowObjects = true;
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Map == null)
            {
                saveAsToolStripMenuItem_Click(this, e);
            }
            else
            {
                _mapViewer._Scene.Write(new BinaryWriter(File.OpenWrite(Map)));
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Retro-Sonic map files (*.map)|*.map";

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                _mapViewer._Scene.Write(new BinaryWriter(File.OpenWrite(dlg.FileName)));
            }
        }

        private void PlaceTileButton_Click(object sender, EventArgs e)
        {
            if (PlacementMode != 1)
            {
                PlacementMode = (int)Placementmode.PlaceTiles;
                PlaceTileButton.Checked = true;
                _mapViewer.PlacementMode = PlacementMode;
                PlaceTileButton.BackColor = SystemColors.ControlDarkDark;
                PlaceObjectButton.BackColor = SystemColors.Control;
                PlaceObjectButton.Checked = false;
            }
            else if (PlacementMode == 1)
            {
                PlacementMode = (int)Placementmode.NONE;
                PlaceTileButton.Checked = false;
                _mapViewer.PlacementMode = PlacementMode;
                PlaceTileButton.BackColor = SystemColors.Control;
                PlaceObjectButton.BackColor = SystemColors.Control;
                PlaceObjectButton.Checked = false;
            }
        }

        private void PlaceObject_Click(object sender, EventArgs e)
        {
            if (PlacementMode != 2)
            {
                PlacementMode = (int)Placementmode.PlaceObjects;
                PlaceObjectButton.Checked = true;
                _mapViewer.PlacementMode = PlacementMode;
                PlaceObjectButton.BackColor = SystemColors.ControlDarkDark;
                PlaceTileButton.BackColor = SystemColors.Control;
                PlaceTileButton.Checked = false;
            }
            else if (PlacementMode == 2)
            {
                PlacementMode = (int)Placementmode.NONE;
                PlaceObjectButton.Checked = false;
                _mapViewer.PlacementMode = PlacementMode;
                PlaceObjectButton.BackColor = SystemColors.Control;
                PlaceTileButton.BackColor = SystemColors.Control;
                PlaceTileButton.Checked = false;
            }
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showgrid)
            {
                showGridToolStripMenuItem.Checked = true;
                showgrid = true;
                _mapViewer.ShowGrid = true;
                _mapViewer.DrawLevel();
            }
            else if (showgrid)
            {
                showGridToolStripMenuItem.Checked = false;
                showgrid = false;
                _mapViewer.ShowGrid = false;
                _mapViewer.DrawLevel();
            }
        }

        private void refreshChunksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BinaryReader strm = new BinaryReader(File.OpenRead(mappings)))
            {
                _Chunks = new RetroSonicV2.til(strm);
            }
            _loadedTiles1 = Bitmap.FromFile(tiles1);
            _loadedTiles2 = Bitmap.FromFile(tiles2);
            _loadedTiles3 = Bitmap.FromFile(tiles3);
            _blocksViewer._chunks = _Chunks;
            _blocksViewer._tiles1 = _loadedTiles1;
            _blocksViewer._tiles2 = _loadedTiles2;
            _blocksViewer._tiles3 = _loadedTiles3;

            _blocksViewer.SetChunks();
            //_blocksViewer.ObjectDefinitions = _Scene.Objects;
            _blocksViewer.RefreshObjList();

            _mapViewer._tiles1 = _loadedTiles1;
            _mapViewer._tiles2 = _loadedTiles2;
            _mapViewer._tiles3 = _loadedTiles3;
            _mapViewer._Scene = _Scene;
            _mapViewer._CollisionMasks = _CollisionMasks;
            _mapViewer.SetLevel();
        }

        private void clearChunksToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    ushort[][] NewTiles1 = new ushort[10][];
                    for (ushort i = 0; i < 10; i++)
                    {
                        // first create arrays child arrays to the width
                        // a little inefficient, but at least they'll all be equal sized
                        NewTiles1[i] = new ushort[78];
                        for (int j = 0; j < 78; ++j)
                            NewTiles1[i][j] = 0; // fill the tiles with blanks
                    }
                    _mapViewer._Scene.MapLayout = NewTiles1;
                    _mapViewer.DrawLevel();
        }

        private void clearObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int o = 0; o < _mapViewer._Scene.Objects.Count; o++)
            {
                _mapViewer._Scene.Objects[o] = new RetroSonicV2.Object();
            }
            _blocksViewer.stageObjects = _mapViewer._Scene.Objects;
            _blocksViewer.RefreshObjList();
        }
    }

}
