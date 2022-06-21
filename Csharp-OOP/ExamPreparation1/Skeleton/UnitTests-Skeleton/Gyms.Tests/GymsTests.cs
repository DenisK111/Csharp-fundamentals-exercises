using NUnit.Framework;
using System;

namespace Gyms.Tests
{

    [TestFixture]
    public class GymsTests
    {
        [Test]

        public void Constructor_Is_Working()
        {
            Gym gym = new Gym("TestGym", 20);

            Assert.That(gym.Name, Is.EqualTo("TestGym"));
            Assert.That(gym.Capacity, Is.EqualTo(20));



        }

        [Test]

        public void Name_Throws_Exception_WithInvalidData()
        {



            Assert.Throws<ArgumentNullException>(() => new Gym("", 20));
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 20));

        }

        [Test]

        public void Capacity_ThrowsExeption_WithInvalidData()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Test", -1));

        }

        [Test]

        public void Adds_Works_Correctly()
        {

            Gym gym = new Gym("Test", 20);
            gym.AddAthlete(new Athlete("Pesho"));

            Assert.AreEqual(1, gym.Count);

        }

        [Test]

        public void Adds_Throws_Exception()
        {

            var gym = new Gym("Test", 1);
            gym.AddAthlete(new Athlete("Pesho"));

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Pesho")));
        }

        [Test]

        public void Remove_Works_Correctly()
        {
            Gym gym = new Gym("Test", 30);

            gym.AddAthlete(new Athlete("Pesho"));
            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Bosho"));
            gym.AddAthlete(new Athlete("Losho"));

            gym.RemoveAthlete("Losho");

            Assert.AreEqual(3, gym.Count);


        }

        [Test]

        public void Remove_Throws_Exception()
        {
            Gym gym = new Gym("Test", 30);

            gym.AddAthlete(new Athlete("Pesho"));
            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Bosho"));
            gym.AddAthlete(new Athlete("Losho"));

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Mosho"));



        }

        [Test]

        public void InjureAthlete_WorksCorectly()
        {
            Gym gym = new Gym("Test", 30);
            var toBeInjured = new Athlete("Losho");
            gym.AddAthlete(new Athlete("Pesho"));
            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Bosho"));
            gym.AddAthlete(toBeInjured);

            gym.InjureAthlete("Losho");

            Assert.True(toBeInjured.IsInjured);
            Assert.True(gym.InjureAthlete("Pesho").IsInjured);
        }

        [Test]

        public void Injure_Throws_Exception()
        {
            Gym gym = new Gym("Test", 30);

            gym.AddAthlete(new Athlete("Pesho"));
            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Bosho"));
            gym.AddAthlete(new Athlete("Losho"));

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Mosho"));

        }

        [Test]

        public void Report_Works_Corretly()
        {
            var expected = $"Active athletes at Test: Gosho, Bosho";
            Gym gym = new Gym("Test", 30);
            var toBeInjured = new Athlete("Losho");
            gym.AddAthlete(new Athlete("Pesho"));
            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Bosho"));
            gym.AddAthlete(toBeInjured);

            gym.InjureAthlete("Losho");
            gym.InjureAthlete("Pesho");

            Assert.AreEqual(expected, gym.Report());



        }
    }
}
