using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {

        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius { get;  }
        public bool IsMatch(IShape shape)
        {
            if (shape is Circle)
                return true;

            return false;
        }
    }
}
