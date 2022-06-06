using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            Person person = new Person("d", "Petrov", 190);

            }
            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
            }

            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine(ex.Message);
            }

            catch (InvalidPersonNameException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
