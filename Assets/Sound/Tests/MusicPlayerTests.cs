using NUnit.Framework;
using Sound.Domain;

namespace Sound.Tests {
	public class MusicPlayerTests {
		[Test]
		public void DontPlayNewSong_NoPlayCallback() {
			MusicPlayerMock sut = new("potato");

			Assert.IsFalse(sut.PlayCallbackReceived);
		}

		[Test]
		public void PlayNewSong_ReceivePlayCallback() {
			MusicManager manager = new();
			MusicPlayerMock sut = new("potato");

			manager.Play(sut);

			Assert.IsTrue(sut.PlayCallbackReceived);
		}

		[Test]
		public void DontStopSong_NoStopCallback() {
			MusicManager manager = new();
			MusicPlayerMock sut = new("potato");

			manager.Play(sut);

			Assert.IsFalse(sut.StopCallbackReceived);
		}

		[Test]
		public void StopSong_ReceiveStopCallback() {
			MusicManager manager = new();
			MusicPlayerMock sut = new("potato");

			manager.Play(sut);
			manager.Stop();

			Assert.IsTrue(sut.StopCallbackReceived);
		}

		[Test]
		public void DontPlayNewSong_DontPausePrevious() {
			MusicManager manager = new();
			MusicPlayerMock sut = new("potato");

			manager.Play(sut);

			Assert.IsFalse(sut.PauseCallbackReceived);
		}

		[Test]
		public void PlayNewSong_PausePrevious() {
			MusicManager manager = new();
			MusicPlayerMock sut = new("potato");
			MusicPlayerMock mock = new("tomato");

			manager.Play(sut);
			manager.Play(mock);

			Assert.IsTrue(sut.PauseCallbackReceived);
		}

		[Test]
		public void StopSong_UnpausePrevious() {
			MusicManager manager = new();
			MusicPlayerMock sut = new("potato");
			MusicPlayerMock mock = new("tomato");

			manager.Play(sut);
			manager.Play(mock);
			manager.Stop();

			Assert.IsTrue(sut.UnpauseCallbackReceived);
		}

		[Test]
		public void StopAll_StopCallbackReceived() {
			MusicManager manager = new();
			MusicPlayerMock sut1 = new("potato");
			MusicPlayerMock sut2 = new("tomato");

			manager.Play(sut1);
			manager.Play(sut2);
			manager.StopAll();

			Assert.IsTrue(sut1.StopCallbackReceived);
			Assert.IsTrue(sut2.StopCallbackReceived);
		}
	}
}