using System;
using System.IO;
using UglyTrivia;
using Xunit;

namespace Test
{
    public class PlayerInfoTest
    {
        [Fact]
        public void ShowNothingWhenGameIsCreated()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var game = new Game();

                Assert.Equal("", sw.ToString());
            }
        }

        [Fact]
        public void ShowPlayerNameAndNumberWhenPlayerIsAdded()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var game = new Game();

                game.add("Player");

                Assert.Equal("Player was added\n" +
                             "They are player number 1\n", sw.ToString());
            }
        }

        //[Fact(Skip = "Flaky")]
        [Fact]
        public void ShowTwoPlayersNamesAndNumbersWhenAdded()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var game = new Game();

                game.add("Max");
                game.add("Jems");

                Assert.Equal("Max was added\n" +
                             "They are player number 1\n" +
                             "Jems was added\n" +
                             "They are player number 2\n", sw.ToString());
            }
        }
    }
}