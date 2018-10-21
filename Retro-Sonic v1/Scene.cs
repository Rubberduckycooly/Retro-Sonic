using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RetroSonicV1
{
    public class Scene
    {

        public ushort[][] MapLayout;
        public List<Object> Objects = new List<Object>();

        public Scene(BinaryReader reader)
        {
            MapLayout = new ushort[10][];
            for (int i = 0; i < 10; i++)
            {
                MapLayout[i] = new ushort[78];
            }

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 78; x++)
                {
                    MapLayout[y][x] = (ushort)(reader.ReadByte() << 8);
                    MapLayout[y][x] |= reader.ReadByte();
                }
            }

            var fileStream = reader.BaseStream as FileStream;
            string itmname = fileStream.Name;

            itmname = itmname.Replace(Path.GetExtension(itmname), ".itm");

            reader = new BinaryReader(File.Open(itmname, FileMode.Open));

            for (int i = 0; i < 301; i++)
            {
                Objects.Add(new Object(reader));
            }

        }

    }

    public class MapLayout
    {
        public ushort[][] mapLayout;
        public MapLayout(BinaryReader reader)
        {
            mapLayout = new ushort[10][];
            for (int i = 0; i < 10; i++)
            {
                mapLayout[i] = new ushort[78];
            }

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 78; x++)
                {
                    mapLayout[y][x] = (ushort)(reader.ReadByte() << 8);
                    mapLayout[y][x] |= reader.ReadByte();
                }
            }
        }

    }

    public class ObjectLayout
    {
        public byte UnknownByte1;
        public List<Object> Objects = new List<Object>();

        public ObjectLayout(BinaryReader reader)
        {
            for (int i = 0; i < 301; i++)
            {
                Objects.Add(new Object(reader));
            }
            if (reader.BaseStream.Length == 1506) UnknownByte1 = reader.ReadByte();
        }

    }
}
