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
    public partial class StageMapView : DockContent
    {

        public Image _tiles1;
        public Image _tiles2;
        public Image _tiles3;
        public StageChunksView _ChunkView;

        public int PlacementMode = 0;
        private Bitmap PanelMap;

        

        public bool ShowMap = true;
        public bool ShowObjects = false;
        public bool ShowCollision = false;
        public bool ShowGrid = false;

        //Built-In Object Definitions for your convenience

        //Retro-Sonic Global Objects
        Object_Definitions.Retro_SonicGlobalObjects ObjectDefinitions = new Object_Definitions.Retro_SonicGlobalObjects();

        public List<Bitmap> Chunks = new List<Bitmap>();

        public Point tilePoint;

        #region Retro-Sonic Development Kit
        public RetroSonicV2.Scene _Scene;
        public RetroSonicV2.til _Chunks;
        public RetroSonicV2.Tileconfig _CollisionMasks;
        #endregion

        public StageMapView()
        {
            InitializeComponent();
            pnlMap.Paint += pnlMap_Paint;
            pnlMap.Resize += ((sender, e) => Refresh());
        }

        void pnlMap_Paint(object sender, PaintEventArgs e)
        {
            Size gridCellSize = new Size(128, 128);
            Pen p = new Pen(System.Drawing.Color.Yellow);
            if (_Scene == null) return;
            e.Graphics.Clear(Color.FromArgb(255, 255, 0, 255));
            Rectangle viewport4 = new Rectangle(-pnlMap.AutoScrollPosition.X, -pnlMap.AutoScrollPosition.Y, pnlMap.Width, pnlMap.Height);
            int startX4 = (viewport4.X / 128) - 1;
            if (startX4 < 0) startX4 = 0;
            int startY4 = (viewport4.Y / 128) - 1;
            if (startY4 < 0) startY4 = 0;
            int endX4 = startX4 + (pnlMap.Width / 128) + 1;
            int endY4 = startY4 + (pnlMap.Height / 128) + 1;
            for (int y = startY4; y < endY4; y++)
            {
                for (int x = startX4; x < endX4; x++)
                {
                    if (y < _Scene.MapLayout.Length && x < _Scene.MapLayout[y].Length)
                    {
                        if (e.ClipRectangle.IntersectsWith(new Rectangle(x * 128, y * 128, 128, 128)))
                        {
                            if (ShowMap)
                            {
                                if (_Scene.MapLayout[y][x] > 0)
                                {
                                    try
                                    {
                                        e.Graphics.DrawImageUnscaled(Chunks[_Scene.MapLayout[y][x]], x * 128, y * 128);
                                    }
                                    catch (Exception ex)
                                    {
                                        e.Graphics.DrawImageUnscaled(Chunks[0], x * 128, y * 128);
                                    }
                                }
                                else { }
                            }
                            if (ShowCollision)
                            {

                            }
                            if (ShowObjects)
                            {

                            }
                        }
                    }
                }
            }
            if (ShowGrid)
            {
                Pen pen = new Pen(Color.DarkGray);

                if (gridCellSize.Width >= 8 && gridCellSize.Height >= 8)
                {
                    int lft = 0 % gridCellSize.Width;
                    int top = 0 % gridCellSize.Height;

                    for (int i = 0; i <= _Scene.width * 128; ++i)
                    {
                        e.Graphics.DrawLine(pen, lft + i * gridCellSize.Width, 0, lft + i * gridCellSize.Width, _Scene.height * 128);
                    }

                    for (int j = 0; j <= _Scene.height * 128; ++j)
                    {
                        e.Graphics.DrawLine(pen, 0, top + j * gridCellSize.Height, _Scene.width * 128, top + j * gridCellSize.Height);
                    }
                }

                //e.Graphics.TranslateTransform(e.ClipRectangle.X, e.ClipRectangle.Y);
                //e.Graphics.DrawEllipse(pen, -4, -4, 8, 8);
                //e.Graphics.ResetTransform();
            }
            e.Graphics.DrawRectangle(p, new Rectangle(tilePoint.X * 128, tilePoint.Y * 128, 128, 128));
        }

        public void DrawLevel(PaintEventArgs e = null)
        {
            if (PanelMap != null) { PanelMap.Dispose(); }
            if (e == null)
            {
                try
                {
                    Rectangle viewport = new Rectangle(-pnlMap.AutoScrollPosition.X, -pnlMap.AutoScrollPosition.Y, pnlMap.Width, pnlMap.Height);
                    PanelMap = new Bitmap(viewport.Width, viewport.Height);
                    e = new PaintEventArgs(Graphics.FromImage(PanelMap), viewport);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("We've got an error lol");
                }
            }

            pnlMap_Paint(this, e);
            Refresh();
        }

        public void SetLevel()
        {
            LoadChunks();
            //Text = leveltitle;
            AutoScrollMinSize = new Size(_Scene.MapLayout[0].Length * 128, _Scene.MapLayout.Length * 128);
            
        }

        void LoadChunks()
        {
            Chunks.Clear();
            for (int i = 0; i < _tiles1.Height / 128; i++)
            {
                Bitmap b = CropImage((Bitmap)_tiles1, new Rectangle(0, i * 128, 128, 128));
                b.MakeTransparent(Color.FromArgb(255, 0, 0, 0));
                Chunks.Add(b);
                //b.Dispose();
            }
            for (int i = 0; i < _tiles2.Height / 128; i++)
            {
                Bitmap b = CropImage((Bitmap)_tiles2, new Rectangle(0, i * 128, 128, 128));
                b.MakeTransparent(Color.FromArgb(255, 0, 0, 0));
                Chunks.Add(b);
                //b.Dispose();
            }
            for (int i = 0; i < _tiles3.Height / 128; i++)
            {
                Bitmap b = CropImage((Bitmap)_tiles3, new Rectangle(0, i * 128, 128, 128));
                b.MakeTransparent(Color.FromArgb(255, 0, 0, 0));
                Chunks.Add(b);
                //b.Dispose();
            }
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

        void pnlMap_MouseDown(object sender, MouseEventArgs e)
        {
            Point tilePointNew = new Point(e.X / 128, e.Y / 128);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (PlacementMode == 0)
                    {
                        tilePoint = tilePointNew;
                        DrawLevel();
                    }
                    if (PlacementMode == 1)
                    {
                        tilePoint = tilePointNew;
                        SetChunk(tilePoint, (ushort)_ChunkView.selectedChunk);
                        DrawLevel();
                    }
                    break;
                case MouseButtons.Right:
                    if (PlacementMode == 0)
                    {
                        tilePoint = tilePointNew;
                        DrawLevel();
                        int selChunk;

                        selChunk = _Scene.MapLayout[tilePoint.Y][tilePoint.X];
                        _ChunkView.BlocksList.SelectedIndex = selChunk;
                        _ChunkView.BlocksList.Refresh();
                    }
                    if (PlacementMode == 1)
                    {
                        tilePoint = tilePointNew;
                        SetChunk(tilePoint, 0);
                        DrawLevel();
                    }
                    break;
                case MouseButtons.Middle:
                    tilePoint = tilePointNew;
                    DrawLevel();
                    int chunk;

                    chunk = _Scene.MapLayout[tilePoint.Y][tilePoint.X];
                    _ChunkView.BlocksList.SelectedIndex = chunk;
                    _ChunkView.BlocksList.Refresh();
                    break;
            }
        }

        void pnlMap_MouseMove(object sender, MouseEventArgs e)
        {
            Point tilePointNew = new Point(e.X / 128, e.Y / 128);
            _ChunkView.MousePosStatusLabel.Text = "Mouse Position = " + e.X + " X, " + e.Y + " Y";
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (PlacementMode == 0 && tilePoint != tilePointNew)
                    {
                        tilePoint = tilePointNew;
                        DrawLevel();
                    }
                    if (PlacementMode == 1 && tilePoint != tilePointNew)
                    {
                        tilePoint = tilePointNew;
                        SetChunk(tilePoint, (ushort)_ChunkView.selectedChunk);
                        DrawLevel();
                    }
                    break;
                case MouseButtons.Right:
                    if (PlacementMode == 0 && tilePoint != tilePointNew)
                    {
                        tilePoint = tilePointNew;
                        DrawLevel();
                    }
                    if (PlacementMode == 1 && tilePoint != tilePointNew)
                    {
                        tilePoint = tilePointNew;
                        SetChunk(tilePoint, 0);
                        DrawLevel();
                    }
                    break;
            }
        }

        public void SetChunk(Point chunkpoint, ushort NewChunk)
        {
            if (tilePoint.X < _Scene.width && tilePoint.Y < _Scene.height)
            {
                _Scene.MapLayout[tilePoint.Y][tilePoint.X] = NewChunk;
            }
        }

    }

}
