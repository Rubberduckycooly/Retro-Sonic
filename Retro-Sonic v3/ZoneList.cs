﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RetroSonicV3
{
    //*.mdf Files
    public class ZoneList
    {
        public class Level
        {
            public string StageName;
            public string StageFolder;
            public string ActNo;
            public string Unknown;

            public Level(StreamReader reader)
            {
                char buf = 'n';

                while (buf != '^')
                {
                    buf = (char)reader.Read();
                    if (buf == '^') { break; }
                    else
                    {
                        StageName = StageName + buf;
                    }
                }
                buf = 'n';
                while (buf != '^')
                {
                    buf = (char)reader.Read();
                    if (buf == '^') { break; }
                    else
                    {
                        StageFolder = StageFolder + buf;
                    }
                }
                buf = 'n';
                while (buf != '^')
                {
                    buf = (char)reader.Read();
                    if (buf == '^') { break; }
                    else
                    {
                        ActNo = ActNo + buf;
                    }
                }
                buf = 'n';
                while (buf != '^')
                {
                    buf = (char)reader.Read();
                    if (buf == '^') { break; }
                    else
                    {
                        Unknown = Unknown + buf;
                    }
                }
                buf = 'n';
                reader.ReadLine();

            }

            public void write(StreamWriter writer)
            {
                for (int i = 0; i < StageName.Length; i++)
                {
                    writer.Write(StageName[i]);
                }
                writer.Write('^');
                for (int i = 0; i < StageFolder.Length; i++)
                {
                    writer.Write(StageFolder[i]);
                }
                writer.Write('^');
                for (int i = 0; i < ActNo.Length; i++)
                {
                    writer.Write(ActNo[i]);
                }
                writer.Write('^');
                for (int i = 0; i < Unknown.Length; i++)
                {
                    writer.Write(Unknown[i]);
                }
                writer.Write('^');
                writer.WriteLine();

            }

        }

        public List<Level> Stages = new List<Level>();

        public ZoneList(string filename) : this(new StreamReader(File.OpenRead(filename)))
        {

        }

        public ZoneList(System.IO.Stream stream) : this(new StreamReader(stream))
        {

        }

        public ZoneList(StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                Stages.Add(new Level(reader));
            }
        }

        public void Write(string filename)
        {
            using (StreamWriter writer = new StreamWriter(File.OpenRead(filename)))
                this.Write(writer);
        }

        public void Write(System.IO.Stream stream)
        {
                this.Write(stream);
        }

        internal void Write(StreamWriter writer)
        {
            for (int i = 0; i < Stages.Count; i++)
            {
                Stages[i].write(writer);
            }
        }
    }
}
