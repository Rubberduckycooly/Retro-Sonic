using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RetroSonicV1
{
    public class Configuration
    {

        public byte byte1;
        public byte byte2;
        public byte byte3;
        public byte byte4;

        public Configuration(BinaryReader reader)
        {
            byte1 = reader.ReadByte();
            byte2 = reader.ReadByte();
            byte3 = reader.ReadByte();
            byte4 = reader.ReadByte();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(byte1);
            writer.Write(byte2);
            writer.Write(byte3);
            writer.Write(byte4);
        }

    }
}
