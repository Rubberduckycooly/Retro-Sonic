using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RetroSonicV2
{
    public class til
    {

        public til(BinaryReader reader)
        {
            for (int i = 0; i < 71; ++i)
            {
                ushort tile;
                tile = (ushort)(reader.ReadByte() << 8);
                tile |= reader.ReadByte();
            }
        }

    }
}
