using System;
namespace FilePipeLine
{
    public class PipeLineException : System.ApplicationException
    {
        public PipeLineException(string message) : base(message)
        {
            
        }
    }
}
