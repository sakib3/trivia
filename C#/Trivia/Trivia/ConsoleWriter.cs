using System;

namespace UglyTrivia
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}