using System;
using System.Collections.Generic;

namespace FilePipeLine
{
   
    public class SingleLinePipeLine : BasePipeLine
    {
        public SingleLinePipeLine(ICollector collector, IOutputer outputer, List<IProcessor> processors) 
            : base(collector, outputer, processors, TransmitModel.LINE)
        {
        }

        public override IOutputer Run()
        {
            string name = null;

            outputer.Start();
            collector.Collect((line, isEnd, fileName) =>
            {
                string[] array = line;
                bool isSkip = false;
                string tag = null;

                if (fileName != name)
                {
                    if (name != null)
                    {
                        outputer.FileEnd(name);
                    }
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
                    if (processor is ITagEditor tagEditor)
                    {
                        tag = tagEditor.Tag();
                    }
                }

                if (!isSkip && array != null)
                {
                    IPackage package = new LinePackage(array);
                    package.SetTag(tag);
                    outputer.Output(package, name);
                }
            });

            if (name != null)
            {
                outputer.FileEnd(name);
            }
            outputer.Finish();

            return outputer;
        }
    }

}
