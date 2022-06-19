using System;

namespace _1.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonContainer.Instance.Add("London", 5000);
            
            Console.WriteLine(SingletonContainer.Instance.GetPopulation("London"));
        }
    }
}
