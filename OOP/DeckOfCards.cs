using System;

namespace OOP
{
    internal class DeckOfCards
    {
        class Player
        {
        }

        class Deck
        {
        }

        class Card
        {
            public Rank Rank { get; set; }

            public Suit Suit { get; set; }
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
