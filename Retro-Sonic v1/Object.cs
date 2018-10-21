using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RetroSonicV1
{
    public class Object
    {

        byte Byte1;
        byte Byte2;
        byte Byte3;
        byte Byte4;
        byte Byte5;

        public Object(BinaryReader reader)
        {
            Byte1 = reader.ReadByte();
            Byte2 = reader.ReadByte();
            Byte3 = reader.ReadByte();
            Byte4 = reader.ReadByte();
            Byte5 = reader.ReadByte();
        }

        public void write(BinaryWriter writer)
        {
            writer.Write(Byte1);
            writer.Write(Byte2);
            writer.Write(Byte3);
            writer.Write(Byte4);
            writer.Write(Byte5);
        }

    }
}
