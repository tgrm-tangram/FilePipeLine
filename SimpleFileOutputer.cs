using System;
using System.IO;

namespace FilePipeLine
{
    /** 简单文件输出 */
    public class SimpleFileOutputer : BaseOutputer
    {
        private readonly string fileName;
        private StreamWriter streamWriter;

        public SimpleFileOutputer(string dir, string fileName) : base(dir)
        {
            this.fileName = fileName;
        }

        public SimpleFileOutputer(string dir, string fileName, string separator) : base(dir, separator)
        {
            this.fileName = fileName;
        }

        public override void Start()
        {
            streamWriter = new StreamWriter(dirInfo.FullName + Path.DirectorySeparatorChar + fileName);
        }

        public override void FileStart(string fileName)
        {

        }

        public override void Output(IPackage package, string fileName)
        {
            string[] line = null;
            while((line = package.ReadLine()) != null)
            {
                string str = String.Join(separator, line);
                streamWriter.WriteLine(str);
            }
        }

        public override void FileEnd(string fileName)
        {

        }

        public override void Finish()
        {
            streamWriter.Close();
        }
    }
}
