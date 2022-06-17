namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System;
    using ExtendedDatabase;
    using System.Linq;

    [TestFixture]


    public class DatabaseTests
    {

        Database database;

        [SetUp]

        public void SetUp()
        {

            database = new Database(new Person(15, "John"), new Person(16, "Mai"), new Person(20, "Sydney"), new Person(30, "Melo"));

        }

        [TestCase(15, "Ivan")]

        public void TestAddExceptionThrownIfIdExists(long id, string name)
        {
            Person person = new Person(id, name);

            Assert.Throws<InvalidOperationException>(() => database.Add(person), "Not throwing exception when adding duplicate ID's");

        }

        [TestCase(3, "John")]

        public void TestAddExceptionThrownIfUserNameExists(long id, string name)
        {
            Person person = new Person(id, name);

            Assert.Throws<InvalidOperationException>(() => database.Add(person), "Not throwing exception when adding duplicate UserNames");
        }

        [TestCase(25, "Mors")]
        public void TestIfAddingMemberToAFullDatabaseThrowsInvalidOperationExceptionAndDoesNotIncreaseCount(int id, string name)
        {
            var fullDatabase = new Database(new Person[] { new Person(1, "a"), new Person(2, "b"), new Person(3, "c"), new Person(4, "d"), new Person(5, "e"), new Person(6, "f"), new Person(7, "g"), new Person(8, "h"), new Person(9, "i"), new Person(10, "j"), new Person(11, "k"), new Person(12, "l"), new Person(13, "p"), new Person(14, "m"), new Person(15, "n"), new Person(16, "o") });
            Person person = new Person(id, name);
            var currentCount = fullDatabase.Count;
            Assert.Throws<InvalidOperationException>(() => fullDatabase.Add(person), "Adding an element to a full collection does not throw an exception");
            Assert.AreEqual(currentCount, fullDatabase.Count, "Adding element to full data base changes count");
        }

        [TestCase(5, "Ivan")]

        public void Test_If_Add_Increases_Count_With_Less_Than_16_Members(int id, string name)
        {
            var person = CreatePerson(id, name);
            var currCount = database.Count;
            database.Add(person);
            currCount++;
            Assert.AreEqual(currCount, database.Count, "Adding member does not increase count");
        }

        [TestCase(5, "Ivan")]
        public void Test_If_Add_Adds_Member(int id, string name)
        {
            var person = CreatePerson(id, name);
            database.Add(person);
            Assert.AreEqual(database.FindById(person.Id), person, "Add element to end of database does not work");
        }



        [Test]

        public void TestCount()
        {
            var count = 4;
            Assert.That(count, Is.EqualTo(database.Count), "Count does not work correctly");

        }

        [Test]

        public void TestIfRemoveRemovesItemFromDataBase()
        {

            var expected = database.FindById(30);
            Assert.That(expected, Is.Not.EqualTo(null));
            database.Remove();
            Assert.Throws<InvalidOperationException>(() => database.FindById(30));
        }

        [Test]
        public void Test_If_Remove_Operation_Throws_InvalidOperationException_If_Collection_Is_Empty_And_Does_Not_Decrease_Count()
        {
            var dataBase = new Database();
            Assert.Throws<InvalidOperationException>(() => dataBase.Remove());
            Assert.That(0, Is.EqualTo(dataBase.Count));
        }

        [Test]
        public void Test_If_Test_If_Remove_Operation_Decreases_Count_If_Collection_Is_Not_Empty()
        {
            var currCount = database.Count;
            database.Remove();
            currCount--;
            Assert.That(currCount, Is.EqualTo(database.Count));

        }

        /* •	FindByUsername
o	If no user is present by this username, InvalidOperationException is thrown.
o	If the username parameter is null, ArgumentNullException is thrown
o	Arguments are all CaseSensitive
*/
        [TestCase(10, "Gogi")]
        public void FindByUserNameNonExistingUserNameThrowsException(int id, string username)
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));
        }
        [Test]
        public void FindByUserNameWithNullOrEmptyParameterThrowsException()
        {

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(""));

        }

        [TestCase(10, "Gogi")]
        public void FindByUserNameFindsCorrectUser(int id, string name)
        {
            var person = CreatePerson(id, name);
            database.Add(person);
            Assert.That(person, Is.EqualTo(database.FindByUsername(name)));

        }

        [TestCase(10, "Gogi")]

        public void FindByIdFindsCorrectUser(int id, string name)
        {
            var person = CreatePerson(id, name);
            database.Add(person);
            Assert.That(person, Is.EqualTo(database.FindById(id)));

        }

        [TestCase(190, "Jimmy")]

        public void FindByIdNonExistingIdThrowsInvalidOperationException(int id, string name)
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(190));

        }

        [TestCase(-10, "Mumi")]

        public void FindByNegativeIdThrowsException(int id, string name)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }
        /* o	If no user is present by this id, InvalidOperationException is thrown
o	If negative ids are found, ArgumentOutOfRangeException is thrown
*/
        
        [Test]
        public void TestConstructor()
        {
            var constructorArg = new Person[] { new Person(1, "a"), new Person(2, "b"), new Person(3, "c"), new Person(4, "d"), new Person(5, "e"), new Person(6, "f"), new Person(7, "g"), new Person(8, "h"), new Person(9, "i"), new Person(10, "j"), new Person(11, "k"), new Person(12, "l"), new Person(13, "p"), new Person(14, "m"), new Person(15, "n"), new Person(16, "o"),new Person(17,"z") };
            var expected = database;
            Assert.Throws<ArgumentException>(() => new Database(constructorArg),"Collection takes more than 16 entries.");
            var newDataBase = new Database(new Person(15, "John"), new Person(16, "Mai"), new Person(20, "Sydney"), new Person(30, "Melo"));
            Assert.That(expected.Count, Is.EqualTo(newDataBase.Count));


            Assert.That(expected.FindById(15).UserName, Is.EqualTo(newDataBase.FindById(15).UserName));
            Assert.That(expected.FindById(16).UserName, Is.EqualTo(newDataBase.FindById(16).UserName));
            Assert.That(expected.FindByUsername("Mai").Id, Is.EqualTo(newDataBase.FindByUsername("Mai").Id));
            Assert.That(expected.FindByUsername("Sydney").Id, Is.EqualTo(newDataBase.FindByUsername("Sydney").Id));
            



        }
















        private Person CreatePerson(int id, string name) => new Person(id, name);


    }
}
