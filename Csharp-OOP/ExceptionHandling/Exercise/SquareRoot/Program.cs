using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            try
            {

                bool parsed = int.TryParse(n, out int result);

                if (!parsed)
                {
                    throw new FormatException("Invalid number");
                }

                else if (result < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid number");
                }

                Console.WriteLine(Math.Sqrt(result)); 
            }
            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
            }

            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);

            }

            finally
            {

                Console.WriteLine("Goodbye.");
            }
        }
    }
}
