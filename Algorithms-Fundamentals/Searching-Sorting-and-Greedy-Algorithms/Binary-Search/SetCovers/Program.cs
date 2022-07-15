using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        int[] universe = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int numOfSets = int.Parse(Console.ReadLine());
        int[][] sets = new int[numOfSets][];
        for (int i = 0; i < numOfSets; i++)
        {
            sets[i] = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        }

       

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (int[] set in selectedSets)
        {
            Console.WriteLine($"{string.Join(", ", set)}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> selectedSets = new List<int[]>();

        while (universe.Count > 0)
        {
            int[] longestSet = sets.OrderByDescending(x => x.Count(s => universe.Contains(s))).FirstOrDefault();
            selectedSets.Add(longestSet);
            sets.Remove(longestSet);
            universe = universe.Where(x => !longestSet.Contains(x)).ToList();
        }

        return selectedSets;
    }
}
