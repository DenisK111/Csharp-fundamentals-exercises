using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class HackerRank
    {
        public static void AbsolutePermutation()
        {

            List<List<int>> results = new ();
            var numQueries = Utils.ReadInt();
            for (int i = 0; i < numQueries; i++)
            {
                var input = Utils.ReadIntArray();
                var n = input[0];
                var k = input[1];
                results.Add(AbsolutePermutation(n, k));
            }

            results.ForEach(res => Utils.PrintEnumerable(res));
            

            List<int> AbsolutePermutation(int n, int k)
            {
                var nArray = Enumerable.Range(1, n).ToList();
                List<int> minPermutation = Enumerable.Repeat(0,n).ToList();
                Perm(nArray, 0, nArray.Count - 1);
                return minPermutation[0] > 0 ? minPermutation : [-1];

                void Perm(List<int> input,int start, int end)
                {
                    if (start == end)
                    {                     
                        if (IsAbsolute(input, k) && (minPermutation[0] == 0 || CompareLists(input, minPermutation) < 0))
                        {
                            FillList(minPermutation, input);
                        }                                                 
                    }
                    else
                    {
                        for (int i = start; i <= end; i++)
                        {
                            Swap(start, i,input);
                            Perm(input, start + 1, end);
                            Swap(start, i,input);
                        }
                    }
                }
                void FillList(List<int> list, List<int> source)
                {
                    for (int i = 0; i < source.Count; i++)
                    {
                        list[i] = source[i];
                    }
                }

                void Swap(int i1, int i2, List<int> list)
                {
                    var temp = list[i1];
                    list[i1] = list[i2];
                    list[i2] = temp;
                }

                bool IsAbsolute(IEnumerable<int> array, int k) => array.Select((el, i) => Math.Abs(el - (i + 1))).All(el => el == k);

                int CompareLists(List<int> input, List<int> list)
                {
                    var list1Length = input.Count;
                    var list2Length = list.Count;

                    (int length, List<int> list) smallerList = list1Length < list2Length ?
                        (list1Length, input) :
                        (list2Length, list);

                    for (int i = 0; i < smallerList.length; i++)
                    {
                        var diff = input[i] - list[i];
                        if (diff != 0) return diff;
                    }

                    return list1Length == list2Length ? 0 : -1;

                }
            }

            
        }
    }
}
