using System;
using NUnit.Framework;
using Sound.Domain;

namespace Sound.Tests {
	public class MusicDomainTests {
		[Test]
		public void DontPlay_NoSong() {
			MusicManager sut = new();

			Assert.IsNull(sut.CurrentlyPlayingChannel);
		}

		[Test]
		public void PlayNewSong_AddsToCurrentlyPlaying() {
			MusicChannelMock mock = new("potato");
			MusicManager sut = new();

			sut.AddChannel(mock);

			Assert.AreEqual(mock, sut.CurrentlyPlayingChannel);
		}

		[Test]
		public void PlayNewSong_ReplacesPrevious() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);

			Assert.AreEqual(mock2, sut.CurrentlyPlayingChannel);
		}

		[Test]
		public void PlaySameSong_ReceiveException() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);

			Assert.Throws<InvalidOperationException>(() => sut.AddChannel(mock1));
		}

		[Test]
		public void StopOnlySong_NoSong() {
			MusicChannelMock mock1 = new("potato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.RemoveLast();

			Assert.IsNull(sut.CurrentlyPlayingChannel);
		}

		[Test]
		public void StopSong_PreviousPlays() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);
			sut.RemoveLast();

			Assert.AreEqual(mock1, sut.CurrentlyPlayingChannel);
		}

		[Test]
		public void StopAll_RemovesCurrentPlayer() {
			MusicChannelMock mock = new("potato");
			MusicManager sut = new();

			sut.AddChannel(mock);
			sut.StopAllChannels();

			Assert.IsNull(sut.CurrentlyPlayingChannel);
		}

		[Test]
		public void StopAll_RemovesAllPlayers() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);
			sut.StopAllChannels();

			Assert.AreEqual(0, sut.ActiveChannels.Count);
		}

		[Test]
		public void StopSpecific_RemovesThatOne() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);
			sut.StopChannel(mock1);

			Assert.IsFalse(sut.ActiveChannels.Contains(mock1));
		}

		[Test]
		public void StopSpecificLast_UpdatesActiveChannel() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);
			sut.StopChannel(mock2);

			Assert.AreNotEqual(mock2, sut.CurrentlyPlayingChannel);
		}
	}
}