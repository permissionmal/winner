using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winner
{
    public class Player
    {
        private static Random random = new Random();
        public string Name { get; }
        public int Wins { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
        public Player(string playerName)
        {
            Name = playerName;
            for (int i = 0; i < 52; i++)
            {
                Card card = new Card(4, 13, i);
                Cards.Add(card);
            }
            Cards = Shuffle(Cards);
        }

        public static List<Card> Shuffle(List<Card> deck)
        {
            List<Card> shuffled = new List<Card>(deck);
            for (int i = shuffled.Count - 1; i > 0; i--)
            {
                int randomNumber = random.Next(i + 1);
                if (randomNumber != i)
                {
                    Card cardRandom = shuffled[randomNumber];
                    shuffled[randomNumber] = shuffled[i];
                    shuffled[i] = cardRandom;
                }
            }
            return shuffled;
        }
    }
    
}
