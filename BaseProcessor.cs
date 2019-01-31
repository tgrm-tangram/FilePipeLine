using System;
namespace FilePipeLine
{
    public abstract class BaseProcessor : IProcessor
    {
        public bool Filter(string[] line)
        {
            return false;
        }

        public abstract string[] Process(string[] line);
    }
}
