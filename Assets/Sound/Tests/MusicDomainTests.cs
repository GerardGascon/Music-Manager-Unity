using System;
using NUnit.Framework;
using Sound.Domain;

namespace Sound.Tests {
	public class MusicDomainTests {
		[Test]
		public void DontPlay_NoSong() {
			MusicManager sut = new();

			Assert.IsNull(sut.CurrentlyPlayingMusic);
		}

		[Test]
		public void PlayNewSong_AddsToCurrentlyPlaying() {
			MusicPlayerMock mock = new("potato");
			MusicManager sut = new();

			sut.Play(mock);

			Assert.AreEqual(mock, sut.CurrentlyPlayingMusic);
		}

		[Test]
		public void PlayNewSong_ReplacesPrevious() {
			MusicPlayerMock mock1 = new("potato");
			MusicPlayerMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.Play(mock1);
			sut.Play(mock2);

			Assert.AreEqual(mock2, sut.CurrentlyPlayingMusic);
		}

		[Test]
		public void PlaySameSong_ReceiveException() {
			MusicPlayerMock mock1 = new("potato");
			MusicPlayerMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.Play(mock1);
			sut.Play(mock2);

			Assert.Throws<InvalidOperationException>(() => sut.Play(mock1));
		}

		[Test]
		public void StopOnlySong_NoSong() {
			MusicPlayerMock mock1 = new("potato");
			MusicManager sut = new();

			sut.Play(mock1);
			sut.Stop();

			Assert.IsNull(sut.CurrentlyPlayingMusic);
		}

		[Test]
		public void StopSong_PreviousPlays() {
			MusicPlayerMock mock1 = new("potato");
			MusicPlayerMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.Play(mock1);
			sut.Play(mock2);
			sut.Stop();

			Assert.AreEqual(mock1, sut.CurrentlyPlayingMusic);
		}

		[Test]
		public void StopAll_RemovesCurrentPlayer() {
			MusicPlayerMock mock = new("potato");
			MusicManager sut = new();

			sut.Play(mock);
			sut.StopAll();

			Assert.IsNull(sut.CurrentlyPlayingMusic);
		}

		[Test]
		public void StopAll_RemovesAllPlayers() {
			MusicPlayerMock mock1 = new("potato");
			MusicPlayerMock mock2 = new("potato");
			MusicManager sut = new();

			sut.Play(mock1);
			sut.Play(mock2);
			sut.StopAll();

			Assert.AreEqual(0, sut.ActiveMusic.Count);
		}
	}
}