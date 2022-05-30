namespace Person
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
           Child child = new Child(System.Console.ReadLine(), int.Parse(Console.ReadLine()));
            Console.WriteLine(child);

        }
    }
}