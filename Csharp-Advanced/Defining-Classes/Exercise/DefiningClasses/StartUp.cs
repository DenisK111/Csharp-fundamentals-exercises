using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier();
            //Console.WriteLine(dateModifier.CaclDateDifference(Console.ReadLine(), Console.ReadLine()));

            Console.WriteLine(DateModifier.DaysOfWeek.Monday);

            
        }

       
    }
}
