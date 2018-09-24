using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UglyTrivia
{
    public class Game
    {
        private ConsoleWriter _writer = new ConsoleWriter();
        List<string> players = new List<string>();

        int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(createRockQuestion(i));
            }
        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {
            players.Add(playerName);
            places[howManyPlayers()] = 0;
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;

            _writer.WriteLine(playerName + " was added");
            _writer.WriteLine("They are player number " + players.Count);
            return true;
        }


        public int howManyPlayers()
        {
            return players.Count;
        }

        public void roll(int roll)
        {
            _writer.WriteLine(players[currentPlayer] + " is the current player");
            _writer.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    _writer.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                    places[currentPlayer] = places[currentPlayer] + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                    _writer.WriteLine(players[currentPlayer]
                                      + "'s new location is "
                                      + places[currentPlayer]);
                    _writer.WriteLine("The category is " + currentCategory());
                    askQuestion();
                }
                else
                {
                    _writer.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                _writer.WriteLine(players[currentPlayer]
                                  + "'s new location is "
                                  + places[currentPlayer]);
                _writer.WriteLine("The category is " + currentCategory());
                askQuestion();
            }
        }

        private void askQuestion()
        {
            var questions = getQuestionsForCurrentCategory();
            if (questions != null)
                ActionForAskingQuestion(questions);
        }

        private LinkedList<string> getQuestionsForCurrentCategory()
        {
            if (currentCategory() == "Pop")
                return popQuestions;

            if (currentCategory() == "Science")
                return scienceQuestions;

            if (currentCategory() == "Sports")
                return sportsQuestions;

            if (currentCategory() == "Rock")
                return rockQuestions;

            return null;
        }

        private void ActionForAskingQuestion(LinkedList<string> questions)
        {
            _writer.WriteLine(questions.First());
            questions.RemoveFirst();
        }


        private String currentCategory()
        {
            if (places[currentPlayer] == 0) return "Pop";
            if (places[currentPlayer] == 4) return "Pop";
            if (places[currentPlayer] == 8) return "Pop";
            if (places[currentPlayer] == 1) return "Science";
            if (places[currentPlayer] == 5) return "Science";
            if (places[currentPlayer] == 9) return "Science";
            if (places[currentPlayer] == 2) return "Sports";
            if (places[currentPlayer] == 6) return "Sports";
            if (places[currentPlayer] == 10) return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    _writer.WriteLine(getMessageCorrectAnswer());
                    purses[currentPlayer]++;
                    _writer.WriteLine(players[currentPlayer]
                                      + " now has "
                                      + purses[currentPlayer]
                                      + " Gold Coins.");

                    bool winner = didPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;

                    return winner;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;
                    return true;
                }
            }
            else
            {
                _writer.WriteLine(getMessageCorrectAnswer());
                purses[currentPlayer]++;
                _writer.WriteLine(players[currentPlayer]
                                  + " now has "
                                  + purses[currentPlayer]
                                  + " Gold Coins.");

                bool winner = didPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;

                return winner;
            }
        }

        public string getMessageCorrectAnswer()
        {
            return "Answer was correct!!!!";
        }

        public bool wrongAnswer()
        {
            _writer.WriteLine("Question was incorrectly answered");
            _writer.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }
    }
}