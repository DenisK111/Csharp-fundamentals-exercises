using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int dummyHealth;
        private int dummyExp;
        private int attackValue;

        [SetUp]

        public void SetUp()
        {
            attackValue = 10;
            dummyHealth = 10;
            dummyExp = 15;
            dummy = new Dummy(dummyHealth, dummyExp);
        }
        [Test]
        public void Dummy_Loses_Health_If_Attacked()
        {           

            dummy.TakeAttack(attackValue);

            Assert.AreEqual(dummyHealth-attackValue,dummy.Health,"Health is not reduced after being attacked");

        }

        [Test]

        public void Dead_Dummy_Throws_An_Exception_If_Attacked() 
        {
            dummy.TakeAttack(attackValue);

            Assert.Throws<InvalidOperationException>(()=>dummy.TakeAttack(10),"Dead dummy doesn't throw an exception if attacked");

        }

        [Test]
        public void Dead_Dummy_Can_Give_Xp()
        {
            dummy.TakeAttack(attackValue);
            int expReceived = 0;
            expReceived += dummy.GiveExperience();
            Assert.AreEqual(dummyExp, expReceived,"Dead dummy does not give Exp.");


        }

        [Test]

        public void Alive_Dummy_Cannnot_Give_Xp()
        {
            
            int expReceived = 0;
            Assert.Throws<InvalidOperationException>(()=>  expReceived += dummy.GiveExperience(), "Alive dummy should throw Invalid Operation Exception if called to give Exp.");
            Assert.AreEqual(0, expReceived, "Alive dummy gives Exp.");


        }


    }
}