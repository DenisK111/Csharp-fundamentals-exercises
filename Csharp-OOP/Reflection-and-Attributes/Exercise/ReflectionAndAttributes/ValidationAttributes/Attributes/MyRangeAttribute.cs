using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ValidationAttributes.Attributes
{
    class MyRangeAttribute : MyValidationAttribute
    {
        int minValue;
        int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            int propValue = (int)obj;

            return propValue >= minValue && propValue <= maxValue;


        }
    }
}
