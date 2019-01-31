using System;
using System.Collections.Generic;

namespace FilePipeLine
{
    public abstract class BasePipeLine : IPipeLine
    {
        protected readonly List<IProcessor> processors = new List<IProcessor>();
        protected readonly ICollector collector;
        protected readonly IOutputer outputer;
        protected readonly TransmitModel model;

        protected BasePipeLine(ICollector collector, IOutputer outputer, List<IProcessor> processors, TransmitModel model)
        {
            this.processors = processors;
            this.collector = collector;
            this.outputer = outputer;
            this.model = model;
        }

        public abstract IOutputer Run();
    }
}
