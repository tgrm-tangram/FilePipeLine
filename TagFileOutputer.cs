using System;
using System.IO;
using System.Collections.Generic;

namespace FilePipeLine
{
    public class TagFileOutputer : BaseOutputer
    {
        private Dictionary<string, StreamWriter> dict;

        public override void Start()
        {
            dict = new Dictionary<string, StreamWriter>();
        }

        public TagFileOutputer(string dir) : base(dir)
        {

        }

        public override void FileEnd(string fileName)
        {
        }

        public override void FileStart(string fileName)
        {
        }

        public override void Finish()
        {
            if (dict == null) return;

            foreach (StreamWriter sw in dict.Values)
            {
                sw.Close();
            }
        }

        public override void Output(IPackage package, string fileName)
        {
            string tag = package.Tag();
            if (!dict.ContainsKey(package.Tag()))
            {
                dict.Add(tag, new StreamWriter(dirInfo.FullName + Path.DirectorySeparatorChar + tag));
            }

            StreamWriter stream = dict.GetValueOrDefault(tag);
            string[] line = package.ReadLine();
            if (line != null)
            {
                string str = String.Join(separator, line);
                stream.WriteLine(str);
            }
        }
    }
}
