// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	using FestivalManager.Entities;
   
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void Validate_Constructor()
	    {
			Stage stage = new Stage();

			Assert.True(stage != null);

			Assert.True(stage.Performers != null);
		}

        [Test]

		public void AddPerformer_WorksCorrectly()
        {
			Stage stage = new Stage();
			var performer = new Performer("dd", "ff", 20);
			stage.AddPerformer(performer);

			Assert.AreEqual(1, stage.Performers.Count);
			Assert.True(stage.Performers.Contains(performer));

        }

        [Test]
		public void AddPerformer_ThrowsException()
        {

			Stage stage = new Stage();
			var performer = new Performer("dd", "ff", 20);
			stage.AddPerformer(performer);
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("dd", "22", 17)));
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
		}
        [Test]
		public void AddSong_WorksCorrectly()
		{
			Stage stage = new Stage();
			var performer = new Performer("dd", "ff", 20);
			stage.AddSong(new Song("adwa", new TimeSpan(0, 1, 50)));

			Assert.DoesNotThrow(() => stage.AddSong(new Song("adwa", new TimeSpan(0, 1, 50))));

			Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("lala",new TimeSpan(0,0,40))));
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));

			

		}
        [Test]
		public void AddSongToPerformer_WorksCorrectly()
        {

			var stage = new Stage();
			var performer = new Performer("dd", "ff", 20);
			var song = new Song("adwa", new TimeSpan(0, 1, 50));

			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.AreEqual($"adwa (01:50) will be performed by dd ff",stage.AddSongToPerformer(song.Name, performer.FullName));
				

			

		}

        [Test]

		 public void AddSongToPerformer_ThrowsArgumentException()
		{

			var stage = new Stage();
			var performer = new Performer("dd", "ff", 20);
			var song = new Song("adwa", new TimeSpan(0, 1, 50));

		stage.AddPerformer(performer);
			stage.AddSong(song);
			//Assert.AreEqual($"adwa (1:50) will be performed by dd ff", stage.AddSongToPerformer(song.Name, performer.FullName));
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, "Pesho"));
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Lalala", performer.FullName));



		}
		[Test]
		public void AddSongToPeformerThrowsException()
        {
			var stage = new Stage();
			var performer = new Performer("dd", "ff", 20);
			var song = new Song("adwa", new TimeSpan(0, 1, 50));

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null,performer.FullName));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(song.Name,null));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null,null));

		}

        [Test]

		public void Play_WorksCorrectly()
        {

			var stage = new Stage();
			var performer = new Performer("dd", "ff", 20);
			var performer1 = new Performer("aa", "ff", 20);
			//var performer2 = new Performer("dd", "ff", 20);
			var song1 = new Song("adwa", new TimeSpan(0, 1, 50));
			var song2 = new Song("love", new TimeSpan(0, 2, 50));
			var song3 = new Song("beach", new TimeSpan(0, 3, 50));

			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddSong(song3);
			stage.AddPerformer(performer);
			stage.AddPerformer(performer1);

			stage.AddSongToPerformer(song1.Name, performer.FullName);
			stage.AddSongToPerformer(song2.Name, performer.FullName);
			stage.AddSongToPerformer(song3.Name, performer1.FullName);


			Assert.AreEqual("2 performers played 3 songs", stage.Play());

		}



	}
}