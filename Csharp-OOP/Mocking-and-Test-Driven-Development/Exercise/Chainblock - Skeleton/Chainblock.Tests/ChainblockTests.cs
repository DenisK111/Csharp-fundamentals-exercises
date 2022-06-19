using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Chainblock.Contracts;
using System.Linq;
using System.Transactions;

namespace Chainblock.Tests
{
    [TestFixture]
    class ChainblockTests
    {
        Mock<ITransaction> mockTransaction;
        Mock<ITransaction> mockTransaction1;
        Mock<ITransaction> mockTransaction2;
        Mock<ITransaction> mockTransaction3;
        ITransaction object1;
        ITransaction object2;
        ITransaction object3;
        ITransaction object4;
        IChainblock chainBlock;
        [SetUp]

        public void SetUp()
        {
            chainBlock = new ChainBlock();
            mockTransaction = new Mock<ITransaction>();

            mockTransaction.SetupProperty(p => p.Id, 1);
            mockTransaction.SetupProperty(p => p.Status, TransactionStatus.Successfull);
            mockTransaction.SetupProperty(p => p.From, "Pesho");
            mockTransaction.SetupProperty(p => p.To, "Gosho");
            mockTransaction.SetupProperty(p => p.Amount, 20);

            mockTransaction1 = new Mock<ITransaction>();
            mockTransaction1.SetupProperty(p => p.Id, 0);
            mockTransaction1.SetupProperty(p => p.Status, TransactionStatus.Failed);
            mockTransaction1.SetupProperty(p => p.From, "Dimi");
            mockTransaction1.SetupProperty(p => p.To, "Miki");
            mockTransaction1.SetupProperty(p => p.Amount, 150);


            mockTransaction2 = new Mock<ITransaction>();
            mockTransaction2.SetupProperty(p => p.Id, -1);
            mockTransaction2.SetupProperty(p => p.Status, TransactionStatus.Successfull);
            mockTransaction2.SetupProperty(p => p.From, "Dimi");
            mockTransaction2.SetupProperty(p => p.To, "Pipi");
            mockTransaction2.SetupProperty(p => p.Amount, 120);


            mockTransaction3 = new Mock<ITransaction>();
            mockTransaction3.SetupProperty(p => p.Id, 2);
            mockTransaction3.SetupProperty(p => p.Status, TransactionStatus.Successfull);
            mockTransaction3.SetupProperty(p => p.From, "Gogi");
            mockTransaction3.SetupProperty(p => p.To, "Gosho");
            mockTransaction3.SetupProperty(p => p.Amount, 100);


            object1 = mockTransaction.Object;
            object2 = mockTransaction1.Object;
            object3 = mockTransaction2.Object;
            object4 = mockTransaction3.Object;

            chainBlock.Add(object1);
            chainBlock.Add(object2);
            chainBlock.Add(object3);


        }

        [Test]

        public void AddWorksCorrectlyPositiveTest()
        {
            chainBlock.Add(object4);
            Assert.AreEqual(4, chainBlock.Count);
            Assert.True(chainBlock.Contains(object4.Id));

        }




        [Test]

        public void ContainsObjectWorksCorrectly()
        {



            Assert.True(chainBlock.Contains(object1));
            Assert.False(chainBlock.Contains(object4));
        }

        [Test]

        public void ContainsIdWorksCorrectly()
        {



            Assert.True(chainBlock.Contains(object1.Id));
            Assert.False(chainBlock.Contains(object4.Id));
        }

        [Test]

        public void ChangeTransactionStatusWorksCorrectlyPositiveTest()
        {
            chainBlock.ChangeTransactionStatus(object1.Id, TransactionStatus.Aborted);


            Assert.AreEqual(TransactionStatus.Aborted, object1.Status); /// Check if this works

        }

        [Test]
        public void ChangeTransactionStatusThrowsExceptionNegativeTest()
        {

            Assert.Throws<ArgumentException>(() => chainBlock.ChangeTransactionStatus(object4.Id, TransactionStatus.Aborted));
        }
        [Test]
        public void RemoveTransactionWorksCorrectlyPositiveTest()
        {
            chainBlock.RemoveTransactionById(object2.Id);
            Assert.AreEqual(2, chainBlock.Count);
            Assert.False(chainBlock.Contains(object2.Id));
            Assert.False(chainBlock.Contains(object2));
        }

        [Test]

        public void RemoveTransactionThrowsExceptionNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => chainBlock.RemoveTransactionById(object4.Id));

        }

        [Test]

        public void GetTransactionByIdWorksCorrectlyPositiveTest()
        {
            var obj = chainBlock.GetById(object2.Id);
            Assert.AreEqual(object2, obj);
        }

        [Test]

        public void GetTransactionByIdThrowsExceptionNegativeTest()
        {

            Assert.Throws<InvalidOperationException>(() => chainBlock.GetById(object4.Id));
        }

        [Test]

        public void GetByTransactionStatusWorksCorrectlyPositiveTest()
        {
            
            var transactions = new List<ITransaction> { object3,object1 };

            var list = chainBlock.GetByTransactionStatus(TransactionStatus.Successfull);
            var intersections = transactions.Intersect(list);
            CollectionAssert.AreEqual(list, transactions);
            Assert.AreEqual(intersections.Count(), list.Count());

        }

        [Test]

        public void GetByTransactionStatusThrowsExcepetionNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => chainBlock.GetByTransactionStatus(TransactionStatus.Aborted));

        }

        [Test]

        public void GetAllSendersWithTransactionStatusWorksCorrectlyPositive()
        {

            var senders = chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            var mockSenders = new List<string>(chainBlock.Where(x => x.Status == TransactionStatus.Successfull).OrderByDescending(x => x.Amount).Select(x => x.From));

            CollectionAssert.AreEqual(mockSenders, senders);

        }

        [Test]
        public void GetAllSendersWithTransactionStatusWorksThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusWorksCorrectlyPositive()
        {

            var receivers = chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            var mockReceivers = new List<string>(chainBlock.Where(x => x.Status == TransactionStatus.Successfull).OrderByDescending(x => x.Amount).Select(x => x.To));

            CollectionAssert.AreEqual(mockReceivers, receivers);

        }

        [Test]
        public void GetAllReceiversWithTransactionStatusWorksThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]

        public void GetAllOrderedByAmountDescendingThenByIdWorksCorrectly()
        {

            var ordered = chainBlock.GetAllOrderedByAmountDescendingThenById();

            var mockOrdered = new List<ITransaction> { object2, object3, object1 };

            CollectionAssert.AreEqual(mockOrdered, ordered);
        }

        [Test]

        public void GetBySenderOrderedByAmountDescendingTestPositive()
        {
            var bySender = chainBlock.GetBySenderOrderedByAmountDescending("Dimi");

            var expected = new List<ITransaction> { object2, object3 };

            CollectionAssert.AreEqual(expected, bySender);

        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => chainBlock.GetBySenderOrderedByAmountDescending("Sisi"));

        }

        [Test]

        public void GetByReceiverOrderedByAmountThenByIdTestPositive()
        {
            chainBlock.Add(object4);
            var byReceived = chainBlock.GetByReceiverOrderedByAmountThenById("Gosho");

            var expected = new List<ITransaction> { object4, object1 };

            CollectionAssert.AreEqual(expected, byReceived);

        }


        [Test]

        public void GetByReceiverOrderedByAmountThenByIdThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => chainBlock.GetByReceiverOrderedByAmountThenById("Sisi"));


        }

        [Test]

        public void GetByTransactionStatusAndMaximumAmountPositiveTest()
        {
            chainBlock.Add(object4);
            var returned = chainBlock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 100);
            var expected = new List<ITransaction> { object4, object1 };
            var returned2 = chainBlock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 200);
            var expected2 = new List<ITransaction>();
            var returned3 = chainBlock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 1);
            var expected3 = new List<ITransaction>();

            CollectionAssert.AreEqual(expected, returned);
            CollectionAssert.AreEqual(expected2, returned2);
            CollectionAssert.AreEqual(expected3, returned3);


        }

        [Test]

        public void GetBySenderAndMinimumAmountDescendingPositiveTest()
        {
            chainBlock.Add(object4);

            var returned = chainBlock.GetBySenderAndMinimumAmountDescending("Dimi", 100);

            var expected = new List<ITransaction> { object2, object3 };

            CollectionAssert.AreEqual(expected, returned);

        }

        [Test]

        public void GetBySenderAndMinimumAmountDescendingThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => chainBlock.GetBySenderAndMinimumAmountDescending("Sisi", 1));
            Assert.Throws<InvalidOperationException>(() => chainBlock.GetBySenderAndMinimumAmountDescending("Dimi", 500));

        }

        [Test]

        public void GetByReceiverAndAmountRangeTestPositive()
        {
            chainBlock.Add(object4);
            var returned = chainBlock.GetByReceiverAndAmountRange("Gosho", 20, 110);
            var expected = new List<ITransaction> { object4, object1 };

        }

        [Test]

        public void GetByReceiverAndAmountRangeThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            chainBlock.GetByReceiverAndAmountRange("Shoso", 20, 110)
            );
            Assert.Throws<InvalidOperationException>(() =>
            chainBlock.GetByReceiverAndAmountRange("Gosho", 0, 20)
            );
            Assert.Throws<InvalidOperationException>(() =>
            chainBlock.GetByReceiverAndAmountRange("Pipi", 119, 120)
            );


        }

        [Test]

        public void GetAllInAmountRangeTestPositive()
        {
            chainBlock.Add(object4);
            var returned = chainBlock.GetAllInAmountRange(20, 150);
            var expected = new List<ITransaction> { object1, object2, object3, object4 };

            CollectionAssert.AreEqual(expected, returned);

            var returned2 = chainBlock.GetAllInAmountRange(1, 2);
            var expected2 = new List<ITransaction>();
            CollectionAssert.AreEqual(expected2, returned2);
        }






    }
}
