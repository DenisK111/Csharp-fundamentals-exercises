using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Singleton
{
    class SingletonContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals;
        private static SingletonContainer instance;
        private static object lockObject = new object();
        private SingletonContainer()
        {
            Console.WriteLine("Initialising...");

            capitals = new Dictionary<string, int>();
        }

        public static SingletonContainer Instance
        {
            get
            {
                if (instance == null)
                {

                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonContainer();
                        }
                    }

                }


                return instance;

            }
        }

        public int GetPopulation(string name)
        {
            if (!capitals.ContainsKey(name))
            {
                throw new ArgumentException("capital name not found");
            }

            return capitals[name];
        }

        public void Add(string name, int ammount)
        {

            if (!capitals.ContainsKey(name))
            {
                capitals[name] = ammount;
            }
        }

        

    }
}
