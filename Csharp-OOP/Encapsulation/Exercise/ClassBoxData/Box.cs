using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ClassBoxData
{
   public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
           private set {

                Validate(value, nameof(this.Length));

                length = value; }
        }

        

        public double Width
        {
            get { return width; }
           private set {
                Validate(value, nameof(this.Width));
                width= value; }
        }

        

        public double Height
        {
            get { return height; }
            private set {
                Validate(value, nameof(this.Height));
                height = value; }
        }

        public double SurfaceArea()
        {
            //2lw + 2lh + 2wh
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        public double LateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            return 2 * length * height + 2 * width * height;
        }

        public double Volume()
        {


            return length * width * height;
        }

        private void Validate(double value, string name)
        {
            if (value<0)
            {
                throw new ArgumentException($"{name} cannot be zero or negative.");
            }

        }

    }
}
