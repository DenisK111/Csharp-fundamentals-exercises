using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int CaclDateDifference(string data1, string data2)
        {
            int[] dateToGet = data1.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int year = dateToGet[0];
            int month = dateToGet[1];
            int date = dateToGet[2];
            DateTime date1 = new DateTime(year, month, date);
            int[] dateToGet2 = data2.Split().Select(int.Parse).ToArray();
            year = dateToGet2[0];
            month = dateToGet2[1];
            date = dateToGet2[2];
            DateTime date2 = new DateTime(year, month, date);
            var diff = date2.Subtract(date1);
            return Math.Abs(diff.Days);
        }
            public enum DaysOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday

        }

    }

}


