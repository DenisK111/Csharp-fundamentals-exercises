namespace FightingArena.Tests
{

    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase("Pesho", 20, 40)]
        [TestCase("Pesho", 1, 0)]
        [TestCase("Pesho", int.MaxValue, int.MaxValue)]

        public void WarriorCtrPositiveTest(string name, int damage, int hp)
        {

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase("", int.MaxValue, int.MaxValue)]
        [TestCase(null, 1, 0)]
        [TestCase(" ", 30, 15)]
        [TestCase("Pesho", 0, int.MaxValue)]
        [TestCase("Gogi", -1, 0)]
        [TestCase(" d ", 20, int.MinValue)]

        public void WarriorCtorShouldThrowExceptionNegativeTest(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));

        }
        [TestCaseSource("WarriorAttackTestCaseSourcePositive")]
        public void WarriorAttackMethodShouldWorkCorrectlyPositiveTest(Warrior[] warriors, int expectedHpAttacker, int expectedHpDefender)
        {
            var attacker = warriors[0];
            var defender = warriors[1];

            attacker.Attack(defender);

            Assert.AreEqual(expectedHpAttacker, attacker.HP);
            Assert.AreEqual(expectedHpDefender, defender.HP);

        }
        [TestCaseSource("WarriorAttackTestCaseSourceNegative")]
        public void WarriorAttackShouldThrowExceptionNegativeTest(Warrior attacker,Warrior defender)
        {
            

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));

        }

        public static IEnumerable<TestCaseData> WarriorAttackTestCaseSourcePositive()
        {

            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData
                (

                    new Warrior[]
                    {
                        new Warrior("John",40,32),
                        new Warrior("Mack",31,int.MaxValue)
                    }
                    ,1
                    ,int.MaxValue-40

                ),
                new TestCaseData
                (
                    new Warrior[]
                    {
                        new Warrior("Ivan",50,40),
                        new Warrior("Ma Ck",40,31)
                    }
                    ,0
                    ,0


                    )


            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> WarriorAttackTestCaseSourceNegative()
        {

            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData
                (

                   
                        new Warrior("John",40,30),
                        new Warrior("Mack",31,int.MaxValue)
                   


                ),
                new TestCaseData
                (
                    
                        new Warrior("Ivan",50,40),
                        new Warrior("Ma Ck",40,0)
                    



                ),
                new TestCaseData
                (
                    
                        new Warrior("Ivan",50,40),
                        new Warrior("Ma Ck",50,35)
                    



                ),
                new TestCaseData
                (
                    
                        new Warrior("Ivan",1,39),
                        new Warrior("Ma Ck",40,31)
                    

                )


            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }


    }
}