namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class CarManagerTests
    {
        Car car;
        string make;
        string model;
        double fuelConsumption;
        double fuelCapacity;
        [SetUp]
        public void SetUp()
        {
            make = "Mazda";
            model = "2";
            fuelConsumption = 10;
            fuelCapacity = 30;
            make = "Mazda";
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            
        }



        [Test]

        public void TestConstructor()
        {
            var newCar = CreateCar(make, model, fuelConsumption, fuelCapacity);
            Assert.That(newCar, Is.Not.EqualTo(null));
            Assert.That(newCar, Is.AssignableTo(typeof(Car)));
            Assert.That(newCar.FuelAmount, Is.EqualTo(0));
           
        }

        [Test]

        public void TestThatFuelToRefuelLessThanOrEqualToZeroThrowsException()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.Throws<ArgumentException>(() => car.Refuel(-1));

        }

        [TestCase(10)]
        [TestCase(60)]

        public void TestThatFuelToRefuelAddsFuelAmmountCorrectly(double fuelAmmount)
        {
            
            var currentFuel = car.FuelAmount;
            car.Refuel(fuelAmmount);

            Assert.That((currentFuel + fuelAmmount > car.FuelCapacity) ? car.FuelCapacity : currentFuel+fuelAmmount , Is.EqualTo(car.FuelAmount));
        }

        [Test]

        public void TestThatNotEngouhFuelResultsInAnException()
        {
            double distanceToDrive = 10000;
            var currFuel = car.FuelAmount;
            Assert.Throws<InvalidOperationException>(() => car.Drive(distanceToDrive));
            Assert.AreEqual(currFuel, car.FuelAmount);

        }

        [Test]
        public void TestThatFuelIsSubstractedCorrectlyWhenDriving()
        {
            double distanceToDrive = 100;

            car.Refuel(100);
            var fuelConsumed = (distanceToDrive / 100) * car.FuelConsumption;
            var currFuel = car.FuelAmount - fuelConsumed;
            car.Drive(distanceToDrive);


            Assert.That(currFuel, Is.EqualTo(car.FuelAmount));

        }



        
        

        [Test]
        public void TestIfMakeSetterThrowsExceptionWithInvalidValues()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, model, fuelConsumption, fuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car("", model, fuelConsumption, fuelCapacity));

        }

        [Test]
        public void TestIfModelSetterThrowsExceptionWithInvalidValues()
        {
            Assert.Throws<ArgumentException>(() => new Car(make, null, fuelConsumption, fuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car(make, "", fuelConsumption, fuelCapacity));

        }

        [Test]
        public void TestIfFuelConsumptionSetterThrowsExceptionWithInvalidValues()
        {

            Assert.Throws<ArgumentException>(() => new Car(make, model, 0, fuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car(make, model, -1, fuelCapacity));
        }

        [Test]
        public void TestIfFuelCapacitySetterThrowsExceptionWithInvalidValues()
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, 0));
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, -1));

        }
        public void TestIfModelGetterWorksCorrectly()
        {
            Assert.AreEqual(model, car.Model);
            
        }
        [Test]
        public void TestIfMakeGetterWorksCorrectly()
        {
            Assert.AreEqual(make, car.Make);

        }
        [Test]
        public void TestIfFuelConsumptionGetterWorksCorrectly()
        {
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);

        }
        [Test]
        public void TestIfFuelCapacityGetterWorksCorrectly()
        {

            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }


        private Car CreateCar(string make, string model, double fuelConsumption, double fuelCapacity) => new Car(make, model, fuelConsumption, fuelCapacity);
    }
}