using System;
using System.Collections.Generic;
using System.Text;

namespace winner
{
    public class Card
	{
		private int I;
        public static readonly String[] Face = { "*", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private static readonly String[] Suit = { "*", "D", "C", "H", "S" };
		public int RankI { get { return I % 13; } }
		private byte cardSuit;
		private byte cardsFace;

        public override String ToString()
        {
            return (Face[cardsFace] + Suit[cardSuit]);
        }

        public Card(int suit, int face, int i)
        {
            I = i;
            if (face == 1)
                cardsFace = 13;
            else
                cardsFace = (byte)face;
            cardSuit = (byte)suit;
        }
    }
}

