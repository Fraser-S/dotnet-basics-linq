using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithLinq
{
    class Program
    {

        public static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }

        static void Main(string[] args)
        {
            var startingDeck = (from suit in Suits().LogQuery("Suit Generation")
                               from rank in Ranks().LogQuery("Rank Generation")
                               select new {suit, rank}).LogQuery("Starting Deck")
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
