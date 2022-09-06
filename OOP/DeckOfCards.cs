using System;
using System.Collections.Generic;

namespace OOP
{
    internal class DeckOfCards
    {
        /*static void Main(string[] args)
        {
            Player player = new Player();
            Deck deck = new Deck();

            player.GetCards(deck);

            deck.ShowDeck();
            player.ShowDeck();
        }*/

        class Player
        {
            List<Card> cards = new List<Card>();

            public void GetCards(Deck deck)
            {
                cards.Add(deck.TakeCard());
            }

            public void ShowDeck()
            {
                foreach (var card in cards)
                {
                    Console.WriteLine(card.GetRank() + "|" + card.GetSuit());
                }
            }
        }

        class Deck
        {
            List<Card> cards = new List<Card>();

            public Deck()
            {
                var rankValues = Enum.GetValues(typeof(Rank));
                var suitValues = Enum.GetValues(typeof(Suit));

                foreach(var rank in rankValues)
                {
                    foreach (var suit in suitValues)
                    {
                        cards.Add(new Card(rank.ToString(), suit.ToString()));
                    }
                }
            }

            public Card TakeCard()
            {
                Random random = new Random();
                int minCardIndex = 0;
                int maxCardIndex = 54;

                bool isNotTookCard = true;
                while (isNotTookCard)
                {
                    int cardIndex = random.Next(minCardIndex, maxCardIndex);
                    if (cards[cardIndex] is null == false)
                    {
                        Card takenCard = cards[cardIndex];
                        cards.Remove(cards[cardIndex]);
                        return takenCard;
                    }
                }

                return null;
            }

            public void ShowDeck()
            {
                foreach (var card in cards)
                {
                    Console.WriteLine(card.GetRank() + "|" + card.GetSuit());
                }
            }
        }

        class Card
        {
            string rank;
            string suit;

            public Card(string rank, string suit)
            {
                this.rank = rank;
                this.suit = suit;
            }

            public string GetRank()
            {
                return rank;
            }

            public string GetSuit()
            {
                return suit;
            }
        }

        enum Rank
        {
            Rank_2,
            Rank_3,
            Rank_4,
            Rank_5,
            Rank_6,
            Rank_7,
            Rank_8,
            Rank_9,
            Rank_10,
            Jack,
            Queen,
            King,
            Ace,
        }

        enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades,
        }
    }
}
