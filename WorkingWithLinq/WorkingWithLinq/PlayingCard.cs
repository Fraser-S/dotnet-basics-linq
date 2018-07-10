using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithLinq
{
    class PlayingCard
    {
        public Suit CardSuit { get; }
        public Rank CardRank { get; }

        public PlayingCard(Suit suit, Rank rank)
        {
            this.CardSuit = suit;
            this.CardRank = rank;
        }

        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }
    }
}
