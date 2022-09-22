using System;
using System.Collections.Generic;

namespace OOP
{
    internal class DeckOfCards
    {
        static void Main(string[] args)
        {
            bool isNeededCard = true;
            Player player = new Player();
            Deck deck = new Deck();

            while (isNeededCard)
            {
                Console.WriteLine("Колода карта");
                Console.Write("\nВы можете:" +
                    "\n\ntake - взять еще карту." +
                    "\nend - закончить брать карты и просмотреть взятые." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case "take":
                        player.GetCards(deck);
                        break;

                    case "end":
                        isNeededCard = false;
                        break;

                    default:
                        break;
                }

                Console.Clear();
            }

            player.ShowDeck();
        }

        class Player
        {
            private List<Card> _cards = new List<Card>();

            public void GetCards(Deck deck)
            {
                _cards.Add(deck.TakeCard());
            }

            public void ShowDeck()
            {
                foreach (var card in _cards)
                {
                    Console.WriteLine(card.GetRank() + "|" + card.GetSuit());
                }
            }
        }

        class Deck
        {
            private List<Card> _cards = new List<Card>();

            public Deck()
            {
                var rankValues = Enum.GetValues(typeof(Rank));
                var suitValues = Enum.GetValues(typeof(Suit));

                foreach(var rank in rankValues)
                {
                    foreach (var suit in suitValues)
                    {
                        _cards.Add(new Card(rank.ToString(), suit.ToString()));
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
                    if (_cards[cardIndex] is null == false)
                    {
                        Card takenCard = _cards[cardIndex];
                        _cards.Remove(_cards[cardIndex]);
                        return takenCard;
                    }
                }

                return null;
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
