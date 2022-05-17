using System;
using System.Collections.Generic;

namespace _8.SoftUni_party
{
    class Program
    {
        static void Main(string[] args)
        {
            var vipGuests = new HashSet<string>();
            var regGuests = new HashSet<string>();
            bool partyOver = false;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    while (true)
                    {
                        input = Console.ReadLine();

                        if (input == "END")
                        {
                            partyOver = true;
                            break;
                        }
                        vipGuests.Remove(input);
                        regGuests.Remove(input);

                    }

                }

                if (partyOver)
                {
                    break;
                }

                if (input[0] >= '0' && input[0] <= '9')
                {
                    vipGuests.Add(input);
                }

                else
                {
                    regGuests.Add(input);
                }
            }
            Console.WriteLine(vipGuests.Count+regGuests.Count);
            if (vipGuests.Count>0)
            {
                Console.WriteLine(String.Join("\n",vipGuests));
            }
            if (regGuests.Count > 0)
            {
                Console.WriteLine(String.Join("\n", regGuests));
            }
        }
    }
}
