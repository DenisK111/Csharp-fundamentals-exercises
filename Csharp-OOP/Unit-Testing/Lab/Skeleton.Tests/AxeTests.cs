using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int attackPoints;
        private int durabilityPoints;
        private int dummyHealth;
        private int dummyExp;
        private Axe axe;
        private Dummy dummy;

        private void Attack()
        {
            axe.Attack(dummy);
            durabilityPoints--;

        }

        [SetUp]
        public void SetUp()
        {
            attackPoints = 10;
            durabilityPoints = 1;
            dummyHealth = 10;
            dummyExp = 10;
            dummy = new Dummy(dummyHealth, dummyExp);
            axe = new Axe(attackPoints, durabilityPoints);

        }

        [Test]
        public void Test_If_Axe_Looses_Durability_After_Each_Attack()
        {

            Attack();

            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints, "Axe durability doesn't change after attack");
        }

        [Test]

        public void Test_If_Attack_Throws_Exception_If_Duarability_Equal_To_Zero()
        {
            Attack();
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Attack doesn't throw exception if attacking with 0 durability");
        }

        [Test]
        public void Test_If_Attack_Throws_Exception_If_Duarability_Less_Than_Zero()
        {

            axe = new Axe(10, -5);
            
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Attack doesn't throw exception if attacking with negative durability");


        }
        [Test]
        public void Test_If_Durability_Is_Unchanged_After_Attack_If_Duarability_Below_Or_Equal_To_Zero()
        {

            Attack();
            Assert.That(durabilityPoints, Is.EqualTo(axe.DurabilityPoints), "durability decreases after attacking with a broken axe");
        }


    }
}