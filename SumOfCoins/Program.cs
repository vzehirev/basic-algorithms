using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    class Program
    {
        static void Main()
        {
            var availableCoins = Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(c => c);
            var change = int.Parse(Console.ReadLine());

            var coins = new Dictionary<int, int>();

            foreach (var coin in availableCoins)
            {
                var numOfCoins = change / coin;
                if (numOfCoins >= 1)
                {
                    coins.Add(coin, numOfCoins);
                    change -= numOfCoins * coin;
                }
            }

            if (change == 0)
            {
                Console.WriteLine($"Number of coins to take: {coins.Sum(x => x.Value)}");
                foreach (var kvp in coins)
                {
                    Console.WriteLine($"{kvp.Value} coin(s) with value {kvp.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
