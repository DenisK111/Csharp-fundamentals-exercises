using System.Collections.Generic;
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {

        public Book(string title,int year,params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            int temp = this.Year.CompareTo(other.Year);

            if (temp == 0)
            {
                temp = this.Title.CompareTo(other.Title);
            }

            return temp;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }

    }
}