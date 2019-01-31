using System;
using System.Collections.Generic;

namespace FilePipeLine
{
    public class LinesPipeLine : BasePipeLine
    {
        public LinesPipeLine(ICollector collector, IOutputer outputer, List<IProcessor> processors) 
        : base(collector, outputer, processors, TransmitModel.LINES)
        {
        }

        public override IOutputer Run()
        {
            string name = null;
            List<string[]> list = new List<string[]>();
           
            outputer.Start();
            collector.Collect((line, isEnd, fileName) =>
            {
                string[] array = line;
                bool isSkip = false;

                if (fileName != name)
                {
                    Output(name, list);
                    name = fileName;
                    outputer.FileStart(name);
                }

                foreach (IProcessor processor in processors)
                {
                    if (array == null || processor.Filter(array))
                    {
                        isSkip = true;
                        break;
                    }
                    array = processor.Process(array);
                }

                if (!isSkip && array != null)
                {
                    list.Add(array);
                }
            });

            Output(name, list);
            outputer.Finish();

            return outputer;
        }

        private void Output(string name, List<string[]> list)
        {
            if (name != null)
            {
                IPackage package = new LinePackage(list);
                outputer.Output(package, name);
                outputer.FileEnd(name);
            }
        }
    }
}
