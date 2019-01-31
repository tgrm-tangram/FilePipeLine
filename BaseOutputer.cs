using System;
using System.IO;

namespace FilePipeLine
{
    public abstract class BaseOutputer : IOutputer
    {
        protected static readonly string DEFAULT_SEPARATOR = "\t";
        protected readonly string separator = DEFAULT_SEPARATOR;
        protected readonly DirectoryInfo dirInfo;

        protected BaseOutputer(string dir)
        {
            if (!Directory.Exists(dir))
            {
                this.dirInfo = Directory.CreateDirectory(dir);
            } 
            else
            {
                this.dirInfo = new DirectoryInfo(dir);
            }
        }

        protected BaseOutputer(string dir, string separator) : this(dir)
        {
            this.separator = separator;
        }

        public abstract void FileEnd(string fileName);
        public abstract void FileStart(string fileName);
        public abstract void Finish();
        public abstract void Output(IPackage package, string fileName);
        public abstract void Start();
    }
}
