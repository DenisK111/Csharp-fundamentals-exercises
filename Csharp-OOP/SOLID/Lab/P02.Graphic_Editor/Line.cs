using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Line : IShape
    {
        public bool IsMatch(IShape shape)
        {
            if (shape is Line)
            {
                return true;
            }

            return false;
        }
    }
}
