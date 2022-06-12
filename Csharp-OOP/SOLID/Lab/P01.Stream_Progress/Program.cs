using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            StreamProgressInfo progress = new StreamProgressInfo(new Jpeg("Doc",100,20));

            Console.WriteLine(progress.CalculateCurrentPercent());


        }
    }
}
