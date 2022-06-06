using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidPerson
{
    class Person
    {
        string firstName;
        string lastName;
        int age;
        const int MINAGE = 0;
        const int MAXAGE = 150;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {

            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("first name cannot be empty or whitespace");
                }

                if (ContainsSpecialCharaceterOrNumber(value))
                {
                    throw new InvalidPersonNameException("first name cannot contain special characters or numbers");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("last name cannot be empty or whitespace");
                }

                if (ContainsSpecialCharaceterOrNumber(value))
                {
                    throw new InvalidPersonNameException("last name cannot contain special characters or numbers");
                }

                lastName = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value<MINAGE || value>MAXAGE)
                {
                    throw new ArgumentOutOfRangeException("value",$"age must be between {MINAGE} and {MAXAGE}");
                }

                age = value;
            }
        }

        private bool ContainsSpecialCharaceterOrNumber(string input)
        {
            Regex regex = new Regex(@"[^a-zA-Z]");

            return regex.IsMatch(input);


        }

    }
}
