using System;
using System.IO;

namespace FilePipeLine
{
    public abstract class BaseCollector : ICollector
    {
        private readonly string[] dirs;
        private readonly string searchPattern;
        private Action<string[], bool, string> listener;


        protected BaseCollector(string searchPattern, params string[] dirs)
        {
            this.dirs = dirs;
            this.searchPattern = searchPattern;
        }

        public void Collect(Action<string[], bool, string> listener)
        {
            if (dirs == null || dirs.Length == 0)
            {
                throw new PipeLineException("目标文件夹不能为空");
            }

            this.listener = listener ?? throw new PipeLineException("listener 不能为空");

            foreach(string dir in dirs)
            {
                TraverseDir(dir);
            }
        }

        private void TraverseDir(string dir)
        {
            string[] files = Directory.GetFiles(dir, searchPattern, SearchOption.AllDirectories);
            foreach (string f in files)
            {
                SingleFile(f);
                listener(null, true, f);
            }
        }

        protected void SingleFile(string file)
        {
            StreamReader sr = new StreamReader(file);
            string line = null;
            while((line = sr.ReadLine()) != null)
            {
                listener(Convert(line), false, file);
            }
            sr.Close();
        }

        public abstract string[] Convert(string line);

    }
}
