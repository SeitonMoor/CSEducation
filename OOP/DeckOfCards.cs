﻿using System;
using System.Collections.Generic;

namespace OOP
{
    internal class DeckOfCards
    {
        static void Main(string[] args)
        {   
            Croupier croupier = new Croupier();
            Gambler player = new Gambler();
            Deck deck = new Deck();

            croupier.StartGame(player, deck);

            player.ShowTakenCards();
        }
    }

    enum Rank
    {
        Rank2,
        Rank3,
        Rank4,
        Rank5,
        Rank6,
        Rank7,
        Rank8,
        Rank9,
        Rank10,
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

    class Gambler
    {
        private List<Card> _cards = new List<Card>();

        public void TakeCard(Card takenCard)
        {
            _cards.Add(takenCard);
            Console.WriteLine("Вы взяли карту из колоды.");
        }

        public void ShowTakenCards()
        {
            foreach (var card in _cards)
            {
                Console.WriteLine(card.Rank + "|" + card.Suit);
            }
        }
    }

    class Croupier
    {
        public void StartGame(Gambler player, Deck deck)
        {
            const string TakeCommand = "take";
            const string ExitCommand = "exit";

            bool isNeededCard = true;
            deck.CreateNewDeck();

            while (isNeededCard)
            {
                Console.WriteLine("Колода карта");
                Console.Write("\nВы можете:" +
                    $"\n\n{TakeCommand} - взять еще карту." +
                    $"\n{ExitCommand} - закончить брать карты и просмотреть взятые." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case TakeCommand:
                        PullOutCard(player, deck);
                        break;

                    case ExitCommand:
                        Console.WriteLine("Вы показываете свои собранные карты...");
                        isNeededCard = false;
                        break;

                    default:
                        Console.WriteLine("Вы ничего не делаете.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void PullOutCard(Gambler player, Deck deck)
        {
            Card givenCard = deck.GiveCard();

            if (givenCard is null == false)
            {
                player.TakeCard(givenCard);
            }
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public Card GiveCard()
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
                    if (_cards[cardIndex] is Card givenCard)
                    {
                        _cards.Remove(_cards[cardIndex]);

                        return givenCard;
                    }
                }
            }

            return null;
        }

        public void CreateNewDeck()
        {
            Array rankValues = Enum.GetValues(typeof(Rank));
            Array suitValues = Enum.GetValues(typeof(Suit));

            foreach (Rank rank in rankValues)
            {
                foreach (Suit suit in suitValues)
                {
                    _cards.Add(new Card(rank, suit));
                }
            }
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
