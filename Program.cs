using System;

namespace FilePipeLine
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PipeLineBuilder builder = new PipeLineBuilder();
            builder.SetCollector(new SingleColumnFileCollector("*.txt", @"/Users/wanglx/Desktop/target"))
                .SetOutputer(new TagFileOutputer(@"/Users/wanglx/Desktop/out"))
                .Assemble(new NameTagProcessor())
                .Build()
                .Run();
        }
    }
}
