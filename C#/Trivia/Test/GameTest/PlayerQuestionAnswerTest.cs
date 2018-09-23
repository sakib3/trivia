using System;
using System.IO;
using UglyTrivia;
using Xunit;

namespace Test
{
    public class PlayerQuestionAnswerTest
    {
        [Fact]
        public void WhenPlayerInNotInPenaltyBox()
        {
            using (StringWriter sw = new StringWriter())
            {
                var game = new Game();
                game.add("Player");
                game.roll(2);
                Console.SetOut(sw);

                game.wasCorrectlyAnswered();

                Assert.Equal<string>("Answer was corrent!!!!\n" +
                                     "Player now has 1 Gold Coins.\n", sw.ToString());
            }
        }

        [Fact]
        public void WhenPlayerInPenaltyBox()
        {
            using (StringWriter sw = new StringWriter())
            {
                var game = new Game();
                game.add("Player");
                Console.SetOut(sw);

                game.wasCorrectlyAnswered();

                Assert.Equal<string>("Answer was corrent!!!!\n" +
                                     "Player now has 1 Gold Coins.\n", sw.ToString());
            }
        }
    }
}