using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithLinq
{
    public enum Suit
    {
        clubs,
        diamonds,
        hearts,
        spades
    }

    public enum Rank {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    class Program
    {
        static IEnumerable<Suit> Suits() => Enum.GetValues(typeof(Suit)) as IEnumerable<Suit>;

        static IEnumerable<Rank> Ranks() => Enum.GetValues(typeof(Rank)) as IEnumerable<Rank>;

        static void Main(string[] args)
        {
            var startingDeck = (from suit in Suits().LogQuery("Suit Generation")
                               from rank in Ranks().LogQuery("Rank Generation")
                               select new PlayingCard(suit, rank)).LogQuery("Starting Deck")
                               .ToArray();

            foreach (var card in startingDeck)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();

            var times = 0;
            var shuffledDeck = startingDeck;

            do
            {
                /*shuffledDeck = shuffledDeck.Take(26)
                    .LogQuery("Top Half")
                    .InterleaveSequenceWith(shuffledDeck.Skip(26).LogQuery("Bottom Half"))
                    .LogQuery("Shuffle");*/

                shuffledDeck = shuffledDeck.Skip(26)
                    .LogQuery("Bottom Half")
                    .InterleaveSequenceWith(shuffledDeck.Take(26).LogQuery("Top Half"))
                    .LogQuery("Shuffle")
                    .ToArray();

                foreach (var card in shuffledDeck)
                {
                    Console.WriteLine(card);
                }

                Console.WriteLine();
                times++;
            } while (!startingDeck.SequenceEquals(shuffledDeck));

            Console.WriteLine(times);     
        }
    }
}
