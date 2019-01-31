using System;
using System.Collections.Generic;

namespace FilePipeLine
{
    public class PipeLineBuilder : IBuilder
    {
        private static readonly TransmitModel DEFAULT_MODEL = TransmitModel.LINE;

        private List<IProcessor> list = new List<IProcessor>();
        private ICollector collector;
        private IOutputer outputer;
        private TransmitModel model = DEFAULT_MODEL;

        public IBuilder Assemble(IProcessor processor)
        {
            list.Add(processor);
            return this;
        }

        public IPipeLine Build()
        {
            switch (model)
            {
                case TransmitModel.LINE:
                    return new SingleLinePipeLine(collector, outputer, list);
                default:
                    return null;
            }
        }

        public IBuilder Model(TransmitModel model)
        {
            this.model = model;
            return this;
        }

        public IBuilder SetCollector(ICollector collector)
        {
            this.collector = collector;
            return this;
        }

        public IBuilder SetOutputer(IOutputer outputer)
        {
            this.outputer = outputer;
            return this;
        }
    }
}
