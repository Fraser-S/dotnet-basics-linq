using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithLinq
{
    class Program
    {

        static IEnumerable<string> Suits()
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
            

            var startingDeck = from suit in Suits()
                               from rank in Ranks()
                               select new { Suit = suit, Rank = rank };

           foreach (var card in startingDeck)
           {
                Console.WriteLine(card);
           }
        }
    }
}
