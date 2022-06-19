using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Facade
{
   public class CarBuilderFacade
    {

        public CarBuilderFacade()
        {
            Car = new Car();
        }
        protected Car Car { get; set; }

        public Car Build() => this.Car;

        public CarAddressBuilder Built => new CarAddressBuilder(Car);
        public CarInfoBuilder Info => new CarInfoBuilder(Car);
    }
}
