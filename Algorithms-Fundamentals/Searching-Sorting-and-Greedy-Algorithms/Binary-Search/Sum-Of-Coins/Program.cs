

using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(x=>x));
        var targetSum = int.Parse(Console.ReadLine());
        var usedCoins = new Dictionary<int, int>();
        var numOfCoins = 0;

        while (targetSum>0 && availableCoins.Count > 0)
        {
            var currCoin = availableCoins.Dequeue();
            var count = targetSum / currCoin;
            
            if (count == 0)
            {
                continue;
            }
            numOfCoins += count;
            targetSum %= currCoin;
            usedCoins.Add(currCoin, count);

        }

        if (targetSum != 0)
        {
            Console.WriteLine("Error");


        }

        else
        {
            Console.WriteLine($"Number of coins to take: {numOfCoins}");
            foreach (var kvp in usedCoins)
            {
                Console.WriteLine($"{kvp.Value} coin(s) with value {kvp.Key}");
            }
        }


        //var selectedCoins = ChooseCoins(availableCoins, targetSum);

        //if (selectedCoins.Sum(x=> x.Key * x.Value) != targetSum)
        //{
        //    Console.WriteLine("Error");
        //    return;
        //}
        //
        //Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        //foreach (var selectedCoin in selectedCoins.OrderByDescending(x=>x.Key))
        //{
        //    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        //}
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        if (targetSum == 0)
        {
            return new Dictionary<int, int>();
        }


        if (coins[coins.Count - 1] <= targetSum)
        {
            var dict = ChooseCoins(coins, targetSum - coins[coins.Count - 1]);
            if (!dict.ContainsKey(coins[coins.Count - 1]))
            {
                dict[coins[coins.Count - 1]] = 0;
            }

            dict[coins[coins.Count - 1]]++;
            return dict;
        }
        else
        {

            var newCoins = new int[coins.Count - 1];
            Array.Copy((int[])coins, 0, newCoins, 0, coins.Count - 1);
            coins = newCoins;
            if (coins.Count == 0)
            {
                return new Dictionary<int, int>();
            }

            return ChooseCoins(coins, targetSum);

        }
    }




}
