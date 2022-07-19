using System;
using System.Collections.Generic;
using System.Text;

namespace winner
{
	public class Deck
	{
		private const int cardsPack = 52;
		private Card[] cards;
		private int currentCard;
		private Random? randomNumber;
		public Deck()
		{
			cards = new Card[cardsPack];
			int i = 0;
			for (int suit = 1; suit <= 4; suit++)
				for (int face = 1; face <= 13; face++)
					cards[i++] = new Card(suit, face, i);
			currentCard = 0;
		}

		public void Shuffle(int n)
		{
			int i, j;
			randomNumber = new Random();
			for (int k = 0; k < n; k++)
			{
				i = (int)(randomNumber.Next(cardsPack));
				j = (int)(randomNumber.Next(cardsPack));
				Card card = cards[i];
				cards[i] = cards[j];
				cards[j] = card;
			}

			currentCard = 0;
		}

		public Card CardsDeal()
		{
			if (currentCard < cardsPack)
				return (cards[currentCard++]);
			else
				return (null);
		}
	}
}
