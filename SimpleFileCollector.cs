namespace FilePipeLine
{
    /** 普通txt文件 */
    public class SimpleFileCollector : BaseCollector
    {
        private static readonly string DEFAULT_SEPARATOR = "\t";
        private string separator = DEFAULT_SEPARATOR;

        public SimpleFileCollector(string searchPattern, params string[] dirs) 
            : base(searchPattern, dirs)
        {
            
        }

        public void SetSeparator(string separator)
        {
            this.separator = separator;
        }

        public override string[] Convert(string line)
        {
            return line?.Split(separator);
        }
    }
}