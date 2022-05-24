using System;
using System.Collections.Generic;

namespace GenericScale
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new EqualityScale<string>("4","5").AreEqual()); 
        }
    }
}
