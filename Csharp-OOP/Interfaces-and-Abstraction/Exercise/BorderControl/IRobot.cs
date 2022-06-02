using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    interface IRobot : IIdentifiable
    {
        public string Model { get; set; }
    }
}
