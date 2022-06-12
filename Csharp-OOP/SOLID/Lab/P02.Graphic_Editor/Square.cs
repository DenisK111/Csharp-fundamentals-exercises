using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        public bool IsMatch(IShape shape)
        {
            if (shape is Square)
                return true;

            return false;
        }
    }
}
