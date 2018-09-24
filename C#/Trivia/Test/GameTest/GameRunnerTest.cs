using System;
using System.Collections.Generic;
using System.IO;
using Trivia;
using UglyTrivia;
using Xunit;

namespace Test
{
    
    public class GameRunnerTest
    {
        [Fact]
        public void GameRunnerRun()
        {
            var gameRunnerHelper = new GameRunnerHelper();
            for (int i = 0; i < 50; i++)
            {
                var getGameResult = gameRunnerHelper.GetGameResult(i);
                var readResult = gameRunnerHelper.ReadGameResult(i);
                Assert.Equal<string>(getGameResult, readResult);
            }
            
        }
    }

    internal class GameRunnerHelper
    {
        private Dictionary<int, string> _data;
        
        public GameRunnerHelper()
        {
            _data = new Dictionary<int, string>();

        }

        public string ReadGameResult(int key)
        {
            if (_data.ContainsKey(key))
                return _data[key];
            return null;
        }

        public string GetGameResult(int seed)
        {
            string result;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameRunner.Run(new Random(seed));
                _data.Add(seed, sw.ToString());
                result = sw.ToString();
            }
            return result;

        }
    }
}