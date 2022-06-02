using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ISmartphone smartPhone = new Smartphone();
            IPhone phone = new StationaryPhone();

            foreach (var number in phones)
            {
                if (number.Any(x=>x<'0' || x>'9'))
                {
                    Console.WriteLine("Invalid number!");
                }

                else if (number.Length == 10)
                {
                    smartPhone.Call(number);
                }

                else
                {
                    phone.Call(number);
                }
            }

            foreach (var url in websites)
            {
                if (url.Any(x => x >= '0' && x <= '9'))
                {
                    Console.WriteLine("Invalid URL!");
                }

                else
                {
                    smartPhone.Browse(url);
                }
            }

        }
    }
}
