using System;
using System.IO;
using System.Threading;
using Trivia;
using UglyTrivia;
using Xunit;

namespace Test
{
    public partial class GameCategoryTest
    {
        [Fact]
        public void ShowCategoryPop()
        {
            var rolls = new[] {0, 4, 8};
            foreach (var roll in rolls)
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    var game = new Game();

                    game.add("Player");
                    game.roll(roll);

                    Assert.Equal<string>("Player was added\n" +
                                         "They are player number 1\n" +
                                         "Player is the current player\n" +
                                         $"They have rolled a {roll}\n" +
                                         $"Player's new location is {roll}\n" +
                                         "The category is Pop\n" +
                                         $"Pop Question 0\n", sw.ToString());
                }

                Thread.Sleep(100);
            }
        }

        [Fact]
        public void ShowCategoryScience()
        {
            var rolls = new[] {1, 5, 9};
            foreach (var roll in rolls)
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    var game = new Game();

                    game.add("Player");
                    game.roll(roll);

                    Assert.Equal<string>("Player was added\n" +
                                         "They are player number 1\n" +
                                         "Player is the current player\n" +
                                         $"They have rolled a {roll}\n" +
                                         $"Player's new location is {roll}\n" +
                                         "The category is Science\n" +
                                         $"Science Question 0\n", sw.ToString());
                }

                Thread.Sleep(100);
            }
        }

        [Fact]
        public void ShowCategorySports()
        {
            var rolls = new[] {2, 6, 10};
            foreach (var roll in rolls)
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    var game = new Game();

                    game.add("Player");
                    game.roll(roll);

                    Assert.Equal<string>("Player was added\n" +
                                         "They are player number 1\n" +
                                         "Player is the current player\n" +
                                         $"They have rolled a {roll}\n" +
                                         $"Player's new location is {roll}\n" +
                                         "The category is Sports\n" +
                                         $"Sports Question 0\n", sw.ToString());
                }

                Thread.Sleep(100);
            }
        }

        [Fact]
        public void ShowRollRock()
        {
            var rolls = new[] {3, 7};
            foreach (var roll in rolls)
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    var game = new Game();

                    game.add("Player");
                    game.roll(roll);

                    Assert.Equal<string>("Player was added\n" +
                                         "They are player number 1\n" +
                                         "Player is the current player\n" +
                                         $"They have rolled a {roll}\n" +
                                         $"Player's new location is {roll}\n" +
                                         "The category is Rock\n" +
                                         $"Rock Question 0\n", sw.ToString());
                }

                Thread.Sleep(100);
            }
        }
    }
}