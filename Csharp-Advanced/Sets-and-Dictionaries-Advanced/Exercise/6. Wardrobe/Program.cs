using System;
using System.Collections.Generic;

namespace _6._Wardrobe
{
    class Program
    {

        /* Create a program that helps you decide what clothes to wear from your wardrobe. You will receive the clothes, which are currently in your wardrobe, sorted by their color in the following format:
"{color} -> {item1},{item2},{item3}…"
If you receive a certain color, which already exists in your wardrobe, just add the clothes to its records. You can also receive repeating items for a certain color and you have to keep their count.
In the end, you will receive a color and a piece of clothing, which you will look for in the wardrobe, separated by a space in the following format:
"{color} {clothing}"
Your task is to print all the items and their count for each color in the following format: 
"{color} clothes:
* {item1} - {count}
* {item2} - {count}
* {item3} - {count}
…
* {itemN} - {count}"
If you find the item you are looking for, you need to print "(found!)" next to it:
"* {itemN} - {count} (found!)"
Input
•	On the first line, you will receive n - the number of lines of clothes, which you will receive.
•	On the next n lines, you will receive the clothes in the format described above.
Output
•	Print the clothes from your wardrobe in the format described above
*/
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothesCatalogues = new Dictionary<string, Dictionary<string, int>>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                var command = Console.ReadLine().Split(" -> ");

                var colour = command[0];

                if (!clothesCatalogues.ContainsKey(colour))
                {
                    clothesCatalogues[colour] = new Dictionary<string, int>();
                }

                string[] clothes = command[1].Split(",",StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in clothes)
                {
                    if (!clothesCatalogues[colour].ContainsKey(item))
                    {
                        clothesCatalogues[colour][item] = 0; 
                    }
                    clothesCatalogues[colour][item] += 1;
                }

            }

            string[] input = Console.ReadLine().Split();

            string desiredColour = input[0];
            string desireditem = input[1];

            foreach (var item in clothesCatalogues)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var clothing in item.Value)
                {
                    Console.Write($"* {clothing.Key} - {clothing.Value}");
                    if (desiredColour==item.Key && desireditem == clothing.Key)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }


        }
    }
}
