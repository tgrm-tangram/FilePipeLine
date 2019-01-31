using System;

namespace FilePipeLine
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PipeLineBuilder builder = new PipeLineBuilder();
            builder.SetCollector(new SimpleFileCollector("*.txt", @"/Users/wanglx/Desktop/target"))
                .SetOutputer(new SimpleFileOutputer(@"/Users/wanglx/Desktop/out", "output.txt"))
                .Assemble(new ExtractColumnProcessor(0, 1, 3))
                .Model(TransmitModel.LINE)
                .Build()
                .Run();
        }
    }
}
