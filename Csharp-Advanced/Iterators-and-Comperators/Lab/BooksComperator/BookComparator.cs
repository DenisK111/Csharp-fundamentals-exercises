using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x,  Book y)
        {
            int temp = x.Title.CompareTo(y.Title);

            if (temp == 0)
            {
               temp = y.Year.CompareTo(x.Year);
            }

            return temp;
        }
    }
}
