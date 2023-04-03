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
                    "\nexit - закончить брать карты и просмотреть взятые." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case "take":
                        player.GetCards(deck);
                        break;

                    case "exit":
                        Console.WriteLine("Вы показываете свои собранные карты...");
                        isNeededCard = false;
                        break;

                    default:
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }

            player.ShowDeck();
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

        class Player
        {
            private List<Card> _cards = new List<Card>();

            public void GetCards(Deck deck)
            {
                if (deck.TakeCard() is Card takenCard)
                {
                    _cards.Add(takenCard);
                    Console.WriteLine("Вы взяли карту из колоды.");
                }
            }

            public void ShowDeck()
            {
                foreach (var card in _cards)
                {
                    Console.WriteLine(card.Rank + "|" + card.Suit);
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

                foreach(Rank rank in rankValues)
                {
                    foreach (Suit suit in suitValues)
                    {
                        _cards.Add(new Card(rank, suit));
                    }
                }
            }

            public Card TakeCard()
            {
                if (_cards.Count == 0)
                {
                    Console.WriteLine("Карт в колоде больше нет.");
                }
                else
                {
                    Random random = new Random();
                    int minCardIndex = 0;
                    int maxCardIndex = _cards.Count;

                    bool isNotTookCard = true;
                    while (isNotTookCard)
                    {
                        int cardIndex = random.Next(minCardIndex, maxCardIndex);
                        if (_cards[cardIndex] is Card takenCard)
                        {
                            _cards.Remove(_cards[cardIndex]);
                            return takenCard;
                        }
                    }
                }

                return null;
            }
        }

        class Card
        {
            public Card(Rank rank, Suit suit)
            {
                Rank = rank;
                Suit = suit;
            }

            public Rank Rank { get; private set; }
            public Suit Suit { get; private set; }
        }
    }
}
