using System;
using System.Collections.Generic;
using System.Linq;

namespace Word_Cruncher
{
    internal class Program
    {
        public static string target;
        public static LinkedList<string> usedWords;
        public static Dictionary<int, List<string>> wordsByIndex;
        public static Dictionary<string, int> wordsByCount;
       
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ").ToList();
            target = Console.ReadLine();
            usedWords = new LinkedList<string>();
            wordsByIndex = new Dictionary<int, List<string>>();
            wordsByCount = new Dictionary<string, int>();
            foreach (var word in words)
            {


                var idx = target.IndexOf(word);

                if (idx == -1)
                {
                    continue;
                }

                if (wordsByCount.ContainsKey(word))
                {
                    wordsByCount[word]++;
                    continue; 
                }

                wordsByCount[word] = 1;
                while (idx!=-1)
                {
                    if (!wordsByIndex.ContainsKey(idx))

                    {
                        wordsByIndex[idx] = new List<string>();

                    }

                    wordsByIndex[idx].Add(word);
                    idx=target.IndexOf(word,idx+1);
                }

            }

            GenSolutions(0);

        }

        private static void GenSolutions(int idx)
        {

            if (idx == target.Length)
            {
                Console.WriteLine(string.Join(" ",usedWords));
                return;
            }

            if (!wordsByIndex.ContainsKey(idx))
            {
                return;
            }

            foreach (var word in wordsByIndex[idx])
            {
                if (wordsByCount[word] == 0)
                {
                    continue;
                }

                wordsByCount[word]--;
                usedWords.AddLast(word);
                GenSolutions(idx + word.Length);
                wordsByCount[word]++;
                usedWords.RemoveLast();
            }

        }
    }
}
