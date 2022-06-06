using System;
using System.Collections.Generic;

namespace Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double numInvalidCast = System.Convert.ToDouble(new List<int>());
                double numBadType = System.Convert.ToDouble("adawd");

            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException Caught");
                throw ex;

            }

            catch (InvalidCastException ex)
            {

                Console.WriteLine("InvalidCast Exception Caught");

            }

            finally
            {
                Console.WriteLine("Finally");
            
            }
            
            

        }
    }
}
