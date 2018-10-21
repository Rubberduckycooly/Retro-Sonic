using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RetroSonicV1
{
    public class crv
    {
        public byte[] HeaderBytes;
        public byte[] angles;

        public crv(BinaryReader reader, bool HasHeader)
        {
            int count = (int)reader.BaseStream.Length;
            angles = new byte[count];
            if (!HasHeader)
            {
                HeaderBytes = reader.ReadBytes(3);

                for (int i = 0; i < count - 3; i++)
                {
                    angles[i] = reader.ReadByte();
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    angles[i] = reader.ReadByte();
                }
            }
        }

        public void Write(BinaryWriter writer, bool HasHeader)
        {
            if (!HasHeader)
            {
                writer.Write(angles);
            }
            else
            {
                writer.Write(HeaderBytes);
                writer.Write(angles);
            }
        }
    }
}
