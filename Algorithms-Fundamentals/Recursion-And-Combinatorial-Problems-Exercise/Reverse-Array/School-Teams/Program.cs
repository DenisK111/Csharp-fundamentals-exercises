using System;
using System.Collections.Generic;
using System.Text;

namespace School_Teams
{
    internal class Program
    {

        static string[] elementsGirls;
        static string[] elementsBoys;
        static string[] combinationsGirls;
        static string[] combinationsBoys;
        static List<string> girlsCombos;
        static List<string> boysCombos;
       
        static int kGirls = 3;
        static int kBoys = 2;
        
        static void Main(string[] args)
        {


            girlsCombos = new List<string>();
            boysCombos = new List<string>();
            elementsGirls = Console.ReadLine().Split(", ");
            elementsBoys = Console.ReadLine().Split(", ");
            combinationsGirls = new string[kGirls];
            combinationsBoys = new string[kBoys];
          
            Combinate(0, 0);
            CombinateBoys(0, 0);

            foreach (var combo in girlsCombos)
            {
                foreach (var boysCombo in boysCombos)
                {
                    Console.WriteLine(combo + ", " + boysCombo);
                }
            }
            
        }
        private static void Combinate(int index, int start)
        {
            if (index >= combinationsGirls.Length)
            {
                girlsCombos.Add(string.Join(", ", combinationsGirls));
                return; 
            }

            for (int i = start; i < elementsGirls.Length; i++)
            {


                combinationsGirls[index] = elementsGirls[i];
                Combinate(index + 1, i + 1);

            }

           
        }

        private static void CombinateBoys(int index, int start)
        {
            if (index >= combinationsBoys.Length)
            {
                boysCombos.Add(string.Join(", ", combinationsBoys));
                return;
            }

            for (int i = start; i < elementsBoys.Length; i++)
            {


                combinationsBoys[index] = elementsBoys[i];
                CombinateBoys(index + 1, i + 1);

            }

            
        }
    }
}
