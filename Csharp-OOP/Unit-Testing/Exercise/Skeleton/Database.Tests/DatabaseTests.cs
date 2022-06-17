namespace Database.Tests
{
    using NUnit.Framework;
    using System;


    /* You are provided with a simple class – Database, which stores integers.The constructor receives an array of numbers, which is added into a private field.The database has the functionality to add, remove and fetch all stored items.Your task is to test the class. In other words, write tests, so you are sure its methods are working as intended.
Constraints
•	Storing array's capacity must be exactly 16 integers
o If the size of the array is not 16 integers long, InvalidOperationException is thrown
•	The "Add()" operation, should add an element at the next free cell(just like a stack)
o If there are 16 elements in the Database and try to add 17th, InvalidOperationException is thrown
•	The "Remove()" operation, should support only removing an element at the last index(just like a stack)
o If you try to remove an element from an empty Database, InvalidOperationException is thrown
•	Constructors should take integers only, and store them in the array
•	The "Fetch()" method should return the elements as an array
For better understanding, check the provided skeleton.
Hint
Do not forget to test the constructor(s). They are methods too!
*/
    [TestFixture]


    public class DatabaseTests
    {

        Database emptyDatabase;
        Database fullDatabase;
        Database oneItemDatabase;
        Database arrayDataBase;
        [SetUp]


        public void SetUp()
        {
            emptyDatabase = new Database();
            fullDatabase = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            oneItemDatabase = new Database(1);
            arrayDataBase = new Database(new int[] { 2, 5, 1 });
        }


        [TestCase()]
        [TestCase(new int[] { 2, 5, 1 })]
        [TestCase(1)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Test_Constructor(params int[] cases)
        {
            Database testBase = new Database(cases);
            Assert.AreEqual(cases.Length, testBase.Count);



        }

        [TestCase(5)]

        public void Test_If_Add_Increases_Count_With_Less_Than_16_Members(int value)
        {
            var currCount = emptyDatabase.Count;
            emptyDatabase.Add(value);
            currCount++;
            Assert.AreEqual(currCount, emptyDatabase.Count, "Adding member does not increase count");
        }

        [TestCase(5)]
        public void Test_If_Add_Adds_Member_At_The_End_Of_The_Array(int value)
        {
            oneItemDatabase.Add(value);
            Assert.AreEqual(oneItemDatabase.Fetch()[oneItemDatabase.Count - 1], value, "Add element to end of database does not work");
        }

        [TestCase(5)]

        public void Test_If_Adding_Member_To_A_Full_Database_Throws_InvalidOperationException_And_Does_Not_Increase_Count(int value)
        {
            var currentCount = fullDatabase.Count;
            Assert.Throws<InvalidOperationException>(() => fullDatabase.Add(value), "Adding an element to a full collection does not throw an exception");
            Assert.AreEqual(currentCount, fullDatabase.Count, "Adding element to full data base changes count");
        }

        [Test]
        public void Test_If_Remove_Operation_Removes_Last_Element_Of_Collection()
        {
            var expected = new int[] { 2, 5 };
            var currSecondToLastElement = arrayDataBase.Fetch()[arrayDataBase.Count - 2];
            var currCount = arrayDataBase.Count;
            arrayDataBase.Remove();
            Assert.That(currSecondToLastElement, Is.EqualTo(arrayDataBase.Fetch()[arrayDataBase.Count - 1]));
            Assert.That(currCount - 1, Is.EqualTo(arrayDataBase.Count));
            for (int i = 0; i < arrayDataBase.Count; i++)
            {
                Assert.That(expected[i], Is.EqualTo(arrayDataBase.Fetch()[i]));
            }
        }

        [Test]
        public void Test_If_Remove_Operation_Throws_InvalidOperationException_If_Collection_Is_Empty_And_Does_Not_Decrease_Count()
        {

            Assert.Throws<InvalidOperationException>(() => emptyDatabase.Remove());
            Assert.That(0, Is.EqualTo(emptyDatabase.Count));
        }

        [Test]
        public void Test_If_Test_If_Remove_Operation_Decreases_Count_If_Collection_Is_Not_Empty()
        {
            var currCount = arrayDataBase.Count;
            arrayDataBase.Remove();
            currCount--;
            Assert.That(currCount, Is.EqualTo(arrayDataBase.Count));

        }

        [Test]
        public void Fetch_Works_Correctly()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var fetched = fullDatabase.Fetch();
            Assert.That(expected.Length, Is.EqualTo(fetched.Length));
            Assert.That(fetched.GetType(), Is.EqualTo(typeof(Int32[])));
            for (int i = 0; i < fullDatabase.Count; i++)
            {
                Assert.That(expected[i], Is.EqualTo(fetched[i]));
            }

        }






    }
}
