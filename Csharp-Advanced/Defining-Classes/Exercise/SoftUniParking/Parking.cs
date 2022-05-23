using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int enterCapacity)
        {
            Cars = new List<Car>();
            capacity = enterCapacity;
        }
        int capacity;
        List<Car> cars;

        public List<Car> Cars { get; set; }
        public int Count => Cars.Count();
        

        public string AddCar(Car car)
        {
            if (Cars.FirstOrDefault(x => x.RegistrationNumber == car.RegistrationNumber) != null)
                return "Car with that registration number, already exists!";
            else if (this.capacity <= Cars.Count())
                return "Parking is full!";
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string regNumber)
        {
            /* Removes a car with the given registration number. If the provided registration number does not exist returns the message: 
"Car with that registration number, doesn't exist!"
Otherwise, removes the car and returns the message:
"Successfully removed {registrationNumber}"
*/
            if (Cars.Any(x => x.RegistrationNumber == regNumber))
            {
                Cars.RemoveAll(x => x.RegistrationNumber == regNumber);
                return $"Successfully removed {regNumber}";
            }
            else
                return "Car with that registration number, doesn't exist!";

        }

        public Car GetCar(string RegistrationNumber) => Cars.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumber);


        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var item in RegistrationNumbers)
            {
                if (Cars.Any(x => x.RegistrationNumber == item))
                {
                    Car foundCar = Cars.First(x => x.RegistrationNumber == item);
                    Cars.Remove(foundCar);
                }

            }

        }
      

    }
}