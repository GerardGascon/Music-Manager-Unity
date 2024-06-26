using NUnit.Framework;
using Sound.Domain.Manager;
using Sound.Tests.Mocks;

namespace Sound.Tests {
	public class MusicPlayerTests {
		[Test]
		public void DontPlayNewSong_NoPlayCallback() {
			MusicChannelMock sut = new("potato");

			Assert.IsFalse(sut.PlayCallbackReceived);
		}

		[Test]
		public void PlayNewSong_ReceivePlayCallback() {
			MusicManager manager = new();
			MusicChannelMock sut = new("potato");

			manager.AddChannel(sut);

			Assert.IsTrue(sut.PlayCallbackReceived);
		}

		[Test]
		public void DontStopSong_NoStopCallback() {
			MusicManager manager = new();
			MusicChannelMock sut = new("potato");

			manager.AddChannel(sut);

			Assert.IsFalse(sut.StopCallbackReceived);
		}

		[Test]
		public void StopSong_ReceiveStopCallback() {
			MusicManager manager = new();
			MusicChannelMock sut = new("potato");

			manager.AddChannel(sut);
			manager.StopChannel(sut);

			Assert.IsTrue(sut.StopCallbackReceived);
		}

		[Test]
		public void DontPlayNewSong_DontPausePrevious() {
			MusicManager manager = new();
			MusicChannelMock sut = new("potato");

			manager.AddChannel(sut);

			Assert.IsFalse(sut.PauseCallbackReceived);
		}

		[Test]
		public void PlayNewSong_PausePrevious() {
			MusicManager manager = new();
			MusicChannelMock sut = new("potato");
			MusicChannelMock mock = new("tomato");

			manager.AddChannel(sut);
			manager.AddChannel(mock);

			Assert.IsTrue(sut.PauseCallbackReceived);
		}

		[Test]
		public void StopLastSong_UnpausePrevious() {
			MusicManager manager = new();
			MusicChannelMock sut = new("potato");
			MusicChannelMock mock = new("tomato");

			manager.AddChannel(sut);
			manager.AddChannel(mock);
			manager.StopChannel(mock);

			Assert.IsTrue(sut.UnpauseCallbackReceived);
		}

		[Test]
		public void StopAll_StopCallbackReceived() {
			MusicManager manager = new();
			MusicChannelMock sut1 = new("potato");
			MusicChannelMock sut2 = new("tomato");

			manager.AddChannel(sut1);
			manager.AddChannel(sut2);
			manager.StopAllChannels();

			Assert.IsTrue(sut1.StopCallbackReceived);
			Assert.IsTrue(sut2.StopCallbackReceived);
		}
	}
}