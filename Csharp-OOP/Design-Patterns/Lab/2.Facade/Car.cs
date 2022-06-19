using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Facade
{
    public class Car
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int NumberOfDoors { get; set; }


        public override string ToString()
        {
            return $"Type: {Type}, Color: {Color}, City: {City}, Number of doors: {NumberOfDoors}, at address: {Address}";
        }
    }
}
