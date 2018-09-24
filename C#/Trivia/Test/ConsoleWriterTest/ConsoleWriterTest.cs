using System;
using System.IO;
using UglyTrivia;
using Xunit;

namespace Test
{
    public class ConsoleWriterTest
    {
        [Fact]
        public void ShouldWriteToConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                var wriconsoleWriter = new ConsoleWriter();
                Console.SetOut(sw);
                
                wriconsoleWriter.WriteLine("Hello World");

                Assert.Equal<string>("Hello World\n", sw.ToString());
            }
        }
    }
}