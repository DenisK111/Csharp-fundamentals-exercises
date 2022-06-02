using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Circle : Shape
    {


        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            private set { radius = value; }
        }

        public override double CalculateArea() => Math.PI * (radius * radius);


        public override double CalculatePerimeter() => 2 * Math.PI * Radius;

        public override string Draw()
        {
            return $"{base.Draw()}Circle";
        }

    }
}
