using System;
namespace FilePipeLine
{
    /** 抽取指定列 */
    public class ExtractColumnProcessor : BaseProcessor
    {
        private readonly int[] indexs;

        public ExtractColumnProcessor(params int[] indexs)
        {
            this.indexs = indexs;
        }

        public override string[] Process(string[] line)
        {
            string[] newLine = new string[indexs.Length];
            for(int i = 0; i < indexs.Length; i++)
            {
                newLine[i] = line[indexs[i]];
            }
            return newLine;
        }
    }
}
