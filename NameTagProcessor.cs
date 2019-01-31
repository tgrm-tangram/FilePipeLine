using System;
namespace FilePipeLine
{
    public class NameTagProcessor : BaseProcessor , ITagEditor
    {
        private string tag;
        public NameTagProcessor()
        {
        }

        public override string[] Process(string[] line)
        {
            string name = line[0];
            int length = name.Length;
            switch(length)
            {
                case 2:
                    tag = "two";
                    break;
                case 3:
                    tag = "three";
                    break;
                case 4:
                    tag = "four";
                    break;
                default:
                    tag = "other";
                    break;
            }
            return line;
        }

        public string Tag()
        {
            return tag;
        }
    }
}
