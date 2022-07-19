using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using winner;

namespace winner
{
    public class winner
    {
        public List<string> Win { get; set; } = new List<string>();

        public string AllWinners => String.Join(' ', this.Win);
        public static void Main()
        {
            Player player1 = new Player("Name1");
            Player player2 = new Player("Name2");
            Player player3 = new Player("Name3");
            Player player4 = new Player("Name4");
            Player player5 = new Player("Name5");
            var playerName = "";
            string? winner = "";
            int points = 0;

            Deck deck = new();
            deck.Shuffle(100);
            List<string>[] player = new List<string>[5];
            for (int number = 0; number < 5; number++)
                player[number] = new List<string>();
            for (int i = 0; i < 5; i++)
                for (int n = 0; n < 5; n++)
                    player[n].Add(deck.CardsDeal().ToString());

            bool play = true;
            while (play)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (player1.Cards[i].RankI >= player2.Cards[i].RankI && player1.Cards[i].RankI >= player3.Cards[i].RankI &&
                        player1.Cards[i].RankI >= player4.Cards[i].RankI && player1.Cards[i].RankI >= player5.Cards[i].RankI)
                    {
                        player1.Wins++;
                    }
                    else if (player2.Cards[i].RankI >= player1.Cards[i].RankI && player2.Cards[i].RankI >= player3.Cards[i].RankI &&
                             player2.Cards[i].RankI >= player4.Cards[i].RankI && player2.Cards[i].RankI >= player5.Cards[i].RankI)
                    {
                        player2.Wins++;
                    }
                    else if (player3.Cards[i].RankI >= player2.Cards[i].RankI && player3.Cards[i].RankI >= player1.Cards[i].RankI &&
                             player3.Cards[i].RankI >= player4.Cards[i].RankI && player3.Cards[i].RankI >= player5.Cards[i].RankI)
                    {
                        player3.Wins++;
                    }
                    else if (player4.Cards[i].RankI > player1.Cards[i].RankI && player4.Cards[i].RankI >= player2.Cards[i].RankI &&
                             player4.Cards[i].RankI > player3.Cards[i].RankI && player4.Cards[i].RankI > player5.Cards[i].RankI)
                    {
                        player4.Wins++;
                    }
                    else if (player5.Cards[i].RankI >= player1.Cards[i].RankI && player5.Cards[i].RankI >= player2.Cards[i].RankI &&
                             player5.Cards[i].RankI >= player3.Cards[i].RankI && player5.Cards[i].RankI >= player4.Cards[i].RankI)
                    {
                        player5.Wins++;
                    }

                    playerName = "Name" + (i + 1);
                    List<string> sortedList = player[i].OrderBy(x => PadNumbers(x)).OrderBy(v => FaceValue(v)).ToList();
                    Console.WriteLine(playerName + ":" + string.Join(",", sortedList));
                }



                if (player1.Wins >= player2.Wins && player1.Wins >= player3.Wins && player1.Wins >= player4.Wins && player1.Wins >= player5.Wins)
                {
                    winner += ",Name1";
                    points =  (player1.Wins);
                }
                if (player2.Wins >= player1.Wins && player2.Wins >= player3.Wins &&player2.Wins >= player4.Wins && player2.Wins >= player5.Wins)
                {
                    winner += ",Name2";
                    points = (player2.Wins);

                }
                if (player3.Wins >= player2.Wins && player3.Wins >= player1.Wins &&player3.Wins >= player4.Wins && player3.Wins >= player5.Wins)
                {
                    winner += ",Name3";
                    points = (player3.Wins);

                }
                if (player4.Wins > player1.Wins && player4.Wins >= player2.Wins && player4.Wins > player3.Wins && player4.Wins > player5.Wins)
                {
                    winner += ",Name4";
                    points = (player4.Wins);
                }
                if (player5.Wins >= player1.Wins && player5.Wins >= player2.Wins && player5.Wins >= player3.Wins && player5.Wins >= player4.Wins)
                {
                    winner += ",Name5 ";
                    points = (player5.Wins);
                }
               
                string replacement = "";
                string myWinner = replacement + winner.Substring(1);
                int winnersPoints = points;

                Console.WriteLine("Winners Results" + ": \n" + myWinner + ": " + winnersPoints);
                play = false;
            }
        }

        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(2, '0'));
        }

        public static int FaceValue(string input)
        {
            return input.Substring(0, 1) == "A" ? 1 : input.Substring(0, 1) == "K" ? 13 : input.Substring(0, 1) == "Q" ? 12 : input.Substring(0, 1) == "J" ? 11 : 0;
        }      
    }
}
