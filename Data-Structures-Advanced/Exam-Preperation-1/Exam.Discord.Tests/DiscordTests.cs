using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Exam.Discord.Tests
{
    public class DiscordTests
    {
        private IDiscord _discord;

        private Message GetRandomMessage()
        {
            Random random = new Random();

            return new Message(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000),
                Guid.NewGuid().ToString());
        }

        [SetUp]
        public void Setup()
        {
            this._discord = new Discord();
        }

        // Correctness Tests

        [Test]
        [Category("Correctness")]
        public void TestSendMessage_ShouldSuccessfullySendMessage()
        {
            this._discord.SendMessage(this.GetRandomMessage());
            this._discord.SendMessage(this.GetRandomMessage());

            Assert.AreEqual(2, this._discord.Count);
        }

        [Test]
        [Category("Correctness")]
        public void TestContains_WithExistentMessage_ShouldReturnTrue()
        {
            Message randomMessage = this.GetRandomMessage();

            this._discord.SendMessage(randomMessage);

            Assert.IsTrue(this._discord.Contains(randomMessage));
        }

        [Test]
        [Category("Correctness")]
        public void TestCount_With5Messages_ShouldReturn5()
        {
            this._discord.SendMessage(this.GetRandomMessage());
            this._discord.SendMessage(this.GetRandomMessage());
            this._discord.SendMessage(this.GetRandomMessage());
            this._discord.SendMessage(this.GetRandomMessage());
            this._discord.SendMessage(this.GetRandomMessage());

            Assert.AreEqual(5, this._discord.Count);
        }

        [Test]
        [Category("Correctness")]
        public void TestCount_WithEmpty_ShouldReturnZero()
        {
            Assert.AreEqual(0, this._discord.Count);
        }

        [Test]
        [Category("Correctness")]
        public void TestGetMessage_WithCorrectMessage_ShouldReturnMessage()
        {
            Message message = this.GetRandomMessage();

            this._discord.SendMessage(message);

            Message received = this._discord.GetMessage(message.Id);

            Assert.AreEqual(message, received);
        }

        [Test]
        [Category("Correctness")]
        public void TestGetMessage_WithNonexistentMessage_ShouldThrowException()
        {
            Message message = this.GetRandomMessage();

            this._discord.SendMessage(message);

            Assert.Throws<ArgumentException>(() => this._discord.GetMessage(this.GetRandomMessage().Id));
        }

        [Test]
        [Category("Correctness")]
        public void TestGetMessagesOrderedByMultiCriteria_WithCorrectData_ShouldReturnCorrectResults()
        {
            Message Message = new Message("asd", "bsd", 4000, "test");
            Message Message2 = new Message("dsd", "esd", 5000, "test");
            Message Message3 = new Message("hsd", "isd", 6000, "test2");
            Message Message4 = new Message("ksd", "test", 4000, "test2");
            Message Message5 = new Message("nsd", "osd", 8000, "test2");

            this._discord.SendMessage(Message);
            this._discord.SendMessage(Message2);
            this._discord.SendMessage(Message3);
            this._discord.SendMessage(Message4);
            this._discord.SendMessage(Message5);

            this._discord.ReactToMessage(Message.Id, "laugh");
            this._discord.ReactToMessage(Message.Id, "laugh");

            this._discord.ReactToMessage(Message2.Id, "thumbsup");
            this._discord.ReactToMessage(Message2.Id, "lol");
            this._discord.ReactToMessage(Message2.Id, "lol");

            this._discord.ReactToMessage(Message3.Id, "lol");
            this._discord.ReactToMessage(Message3.Id, "lol");
            this._discord.ReactToMessage(Message3.Id, "lol");

            this._discord.ReactToMessage(Message4.Id, "laugh");
            this._discord.ReactToMessage(Message4.Id, "laugh");

            List<Message> list = this._discord.GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent().ToList();

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(Message2, list[0]);
            Assert.AreEqual(Message3, list[1]);
            Assert.AreEqual(Message, list[2]);
            Assert.AreEqual(Message4, list[3]);
            Assert.AreEqual(Message5, list[4]);
        }

        // Performance Tests

        [Test]
        [Category("Performance")]
        public void TestSendMessage_With100000Results_ShouldPassQuickly()
        {
            int count = 100000;

            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

            for (int i = 0; i < count; i++)
            {
                this._discord.SendMessage(new Message(i + "", "Title" + i, i * 100, "Channel" + i));
            }

            stopwatch.Stop();

            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 150);
        }
    }
}