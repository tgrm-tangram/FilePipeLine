using System;

namespace FilePipeLine
{
    /** 单列文件 */
    public class SingleColumnFileCollector : BaseCollector
    {
        public SingleColumnFileCollector(string searchPattern, params string[] dirs)
            : base(searchPattern, dirs)
        {

        }

        public override string[] Convert(string line)
        {
            return line == null ? null : new string[1] { line };
        }
    }
}
