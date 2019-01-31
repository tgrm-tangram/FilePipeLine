using System;
using System.Collections.Generic;
using System.IO;

namespace FilePipeLine
{
    public abstract class BasePackage : IPackage
    {
        protected string tag = null;

        public abstract string[] ReadLine();

        public void SetTag(string tag)
        {
            this.tag = tag;
        }

        public string Tag()
        {
            return tag;
        }
    }

    public class LinePackage : BasePackage
    {
        private string[] line = null;

        public LinePackage(string[] lines)
        {
            this.line = lines;
        }

        public void Set(string[] line)
        {
            this.line = line;
        }

        public override string[] ReadLine()
        {
            return line;
        }
    }
}
