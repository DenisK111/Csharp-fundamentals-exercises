using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 12143;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
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

            return ChooseCoins(coins, targetSum);

        }
    }




}
