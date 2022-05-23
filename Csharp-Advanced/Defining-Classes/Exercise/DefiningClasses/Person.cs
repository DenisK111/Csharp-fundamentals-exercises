using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;

        }
        public Person(int age) : this()
        {
            Age = age;
            
        }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public int Age { get; set; }
        public string Name { get; set; }
    }
}
