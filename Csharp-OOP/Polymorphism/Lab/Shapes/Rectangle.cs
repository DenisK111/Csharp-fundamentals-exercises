using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {

        private double widht;
        private double height;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get { return height; }
            private set { height = value; }
        }

        public double Width
        {
            get { return widht; }
            private set { widht = value; }
        }

        public override double CalculateArea() => Height * Width;



        public override double CalculatePerimeter() => 2 * (Height + Width);

        public override string Draw() => $"{base.Draw()}Rectangle";


    }
}
