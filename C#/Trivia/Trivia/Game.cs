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
            _writer.WriteLine(getCurrentPlayer() + " is the current player");
            _writer.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    _writer.WriteLine(getCurrentPlayer() + " is getting out of the penalty box");
                    
                    places[currentPlayer] = getCurrentPlaceForCurrentPlayer() + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = getCurrentPlaceForCurrentPlayer() - 12;

                    _writer.WriteLine(getCurrentPlayer()
                                      + "'s new location is "
                                      + getCurrentPlaceForCurrentPlayer());
                    _writer.WriteLine(getCurrentCategoryMessage());
                    askQuestion();
                }
                else
                {
                    _writer.WriteLine(getCurrentPlayer() + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                places[currentPlayer] = getCurrentPlaceForCurrentPlayer() + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = getCurrentPlaceForCurrentPlayer() - 12;

                _writer.WriteLine(getCurrentPlayer()
                                  + "'s new location is "
                                  + getCurrentPlaceForCurrentPlayer());
                _writer.WriteLine(getCurrentCategoryMessage());
                askQuestion();
            }
        }

        

        private int getCurrentPlaceForCurrentPlayer()
        {
            return places[currentPlayer];
        }

        private string getCurrentPlayer()
        {
            return players[currentPlayer];
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
            if (getCurrentPlaceForCurrentPlayer() == 0) return "Pop";
            if (getCurrentPlaceForCurrentPlayer() == 4) return "Pop";
            if (getCurrentPlaceForCurrentPlayer() == 8) return "Pop";
            if (getCurrentPlaceForCurrentPlayer() == 1) return "Science";
            if (getCurrentPlaceForCurrentPlayer() == 5) return "Science";
            if (getCurrentPlaceForCurrentPlayer() == 9) return "Science";
            if (getCurrentPlaceForCurrentPlayer() == 2) return "Sports";
            if (getCurrentPlaceForCurrentPlayer() == 6) return "Sports";
            if (getCurrentPlaceForCurrentPlayer() == 10) return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
      
            if (isCurrentUserIsOutsideOfPenaltyBox()) 
                return wasCorrectlyAnsweredForCurrentUserOutsideOfPenaltyBox();
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;

        }

        private bool isCurrentUserIsOutsideOfPenaltyBox()
        {
            return !inPenaltyBox[currentPlayer] || isGettingOutOfPenaltyBox;
        }

        private bool wasCorrectlyAnsweredForCurrentUserOutsideOfPenaltyBox()
        {
            _writer.WriteLine(getMessageCorrectAnswer());
            purses[currentPlayer]++;
            _writer.WriteLine(getCurrentPlayer()
                              + " now has "
                              + purses[currentPlayer]
                              + " Gold Coins.");

            bool winner = didPlayerWin();
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;

            return winner;
        }

        public string getMessageCorrectAnswer()
        {
            return "Answer was correct!!!!";
        }
        
        private string getCurrentCategoryMessage()
        {
            return "The category is " + currentCategory();
        }

        public bool wrongAnswer()
        {
            _writer.WriteLine("Question was incorrectly answered");
            _writer.WriteLine(getCurrentPlayer() + " was sent to the penalty box");
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