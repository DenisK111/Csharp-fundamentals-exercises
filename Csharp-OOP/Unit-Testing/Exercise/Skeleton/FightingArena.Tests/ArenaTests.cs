namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]

        public void SetUp()
        {

            arena = new Arena();
        }

        [Test]

        public void ConstructorIsWorking()
        {
            

            Assert.That(arena.Warriors, Is.Not.EqualTo(null));
            Assert.That(arena, Is.Not.EqualTo(null));

        }

        [TestCaseSource("WarriorEnrollTestCaseSourcePositive")]

        public void WarriorEnrollShouldWorkCorrectly(int count,params Warrior[] warriors) 
        {

            foreach (var warrior in warriors)
            {
                arena.Enroll(warrior);
            }

            Assert.AreEqual(count, arena.Count);
            Assert.True(arena.Warriors.Any(x => x.Name == warriors[0].Name));
            Assert.True(arena.Warriors.Any(x => x.Name == warriors[count-1].Name));
        
        }
        [TestCaseSource("WarriorEnrollTestCaseSourceNegative")]
        public void WarriorEnrollShouldThrowExceptionNegativeTest(Warrior duplicateWarrior,params Warrior[] warriors)
        {
            foreach (var item in warriors)
            {
                arena.Enroll(item);
            }

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(duplicateWarrior));

        }

        [TestCase("John","Mick",10,10,false)]
        [TestCase("Jim","Sam",20,int.MaxValue-40,false)]
        [TestCase("Jim","Stork",20,0,false)]
        [TestCase("Bam","Ram",1,15,true)]
        public void FightShouldWorkCorrectlyPositiveTest(string attacker,string defender, int expectedHPAttacker,int expectedHPDefender,bool throwsExeption )
        {
            arena.Enroll(new Warrior("John", 30, 40));
            arena.Enroll(new Warrior("Mick", 30, 40));
            arena.Enroll(new Warrior("Jim", 40, 40));
            arena.Enroll(new Warrior("Stork", 20, 40));
            arena.Enroll(new Warrior("Sam", 20, int.MaxValue));
            arena.Enroll(new Warrior("Bam", 20, 1));
            arena.Enroll(new Warrior("Ram", 20, 15));

            if (throwsExeption)
            {
                Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));
            }

            else
            {
            arena.Fight(attacker, defender);

            }

            Assert.That(arena.Warriors.First(x => x.Name == attacker).HP, Is.EqualTo(expectedHPAttacker));
            Assert.That(arena.Warriors.First(x => x.Name == defender).HP, Is.EqualTo(expectedHPDefender));
            


        }

        [TestCase("John", "adwad", "adwad")]
        [TestCase("Jim", "sad", "sad")]
        [TestCase("awd", "Stork", "awd")]
        [TestCase(null, "Ram", null)]

        public void FightShouldThrowExceptionNegativeTest(string attacker, string defender, string nameToBeThrown)
        {
            arena.Enroll(new Warrior("John", 30, 40));
            arena.Enroll(new Warrior("Mick", 30, 40));
            arena.Enroll(new Warrior("Jim", 40, 40));
            arena.Enroll(new Warrior("Stork", 20, 40));
            arena.Enroll(new Warrior("Sam", 20, int.MaxValue));
            arena.Enroll(new Warrior("Bam", 20, 1));
            arena.Enroll(new Warrior("Ram", 20, 15));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));
            Assert.That(() => arena.Fight(attacker, defender), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {nameToBeThrown} enrolled for the fights!"));

        }
        public static IEnumerable<TestCaseData> WarriorEnrollTestCaseSourceNegative()
        {

            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData
                (
                    new Warrior("Ivan",30,40),
                    new Warrior[]
                    {
                        new Warrior("John",40,32),
                        new Warrior("Ivan",31,int.MaxValue)
                    }





                ),
                new TestCaseData
                (
                    new Warrior("  - ",40,32),
                    new Warrior[]
                    {
                        new Warrior("John",50,40),
                        new Warrior("  - ",40,31),
                        new Warrior("Ivan",35,30)
                        
                    }




                    )


            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> WarriorEnrollTestCaseSourcePositive()
        {

            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData
                (
                    2,
                    new Warrior[]
                    {
                        new Warrior("John",40,32),
                        new Warrior("Mack",31,int.MaxValue)
                    }
                    
                    

                ),
                new TestCaseData
                (   
                    3,
                    new Warrior[]
                    {
                        new Warrior("Ivan",50,40),
                        new Warrior("Ma Ck",40,31),
                        new Warrior("KFK",40,32)
                    }
                    
                    


                    )


            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }
    }
}
