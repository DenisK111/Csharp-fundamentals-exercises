using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuples
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            
            Box<object> box = new Box<object>(); 
            for (int i = 0; i < 3; i++)
            {
            var input = Console.ReadLine().Split();
                if (i == 0)
                {

                    

                string item1 = input[0] + " " + input[1];

                string item2 = input[2];


                var city = new string[input.Length - 3];

                for (int i1 = 3; i1 <= input.GetUpperBound(0); i1++)
                {
                    city[i1 - 3] = input[i1];
                }
                string item3 = String.Join(" ", city);


                    box.Add(new Threeuples<string, string, string>(item1, item2, item3));

                }

                else 
                {
                    if (i==1)
                    {
                        bool value = input[2] == "drunk" ? true : false;
                        box.Add( new Threeuples<string, int, bool>(input[0], int.Parse(input[1]), value));
                    }
                    else
                    {
                        box.Add(new Threeuples<string, double, string>(input[0], double.Parse(input[1]), input[2]));
                    }
                }

                

            }

            for (int i = 0; i < box.Count; i++)
            {
                Console.WriteLine(box[i]);
            }



        }

     
    }
}
