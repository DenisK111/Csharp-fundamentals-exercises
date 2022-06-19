using System;
using System.Collections.Generic;

namespace _3.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Bread twelveGrainBread = new TwelveGrain();
            Bread whiteBread = new White();

            List<Bread> list = new List<Bread>();

            list.Add(twelveGrainBread);
            list.Add(whiteBread);

            list.ForEach(x => x.Make());
        }
    }
}
