using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        public bool IsMatch(IShape shape)
        {
            if (shape is Rectangle)
                return true;

            return false;
        }

        
    }
}
