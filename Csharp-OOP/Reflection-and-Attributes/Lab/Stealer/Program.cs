using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
           // Console.WriteLine(result);


          //  Console.WriteLine(spy.AnalyzeAccessModifiers("Hacker"));

            //Console.WriteLine(spy.RevealPrivateMethods("Hacker"));
            Console.WriteLine(spy.CollectGettersAndSetters("Stealer.Hacker"));



        }
    }
}
