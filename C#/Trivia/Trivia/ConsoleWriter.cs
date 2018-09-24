using System;

namespace UglyTrivia
{
    public class ConsoleWriter: Iwriter
    {
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}