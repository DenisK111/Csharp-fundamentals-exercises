using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> listOfStudents = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Student student = new Student(input[0], int.Parse(input[1]));
                listOfStudents.Add(student);
            }

            string condition = Console.ReadLine();
            int ageForCondiotion = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<int, bool> filter = Filter(condition, ageForCondiotion);
            Action<Student> print = Print(format);
            listOfStudents.Where(x => filter(x.Age)).ToList().ForEach(x => print(x));

        }

        static Func<int, bool> Filter(string condition, int ageForConditions)
        {

            switch (condition)
            {
                case "younger": return x => x < ageForConditions;

                case "older": return x => x >= ageForConditions;
                default:
                    return null;

            }

        }

        static Action<Student> Print(string format)
        {

            switch (format)
            {
                case "name": return student => Console.WriteLine(student.Name);
                case "age": return student => Console.WriteLine(student.Age);
                case "name age": return student => Console.WriteLine($"{student.Name} - {student.Age}");
                default:
                    return null;

            }
        }


    }

    class Student
    {
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
