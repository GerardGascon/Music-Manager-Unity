using NUnit.Framework;
using Sound.Domain.Channels;
using Sound.Domain.Manager;
using Sound.Tests.Mocks;

namespace Sound.Tests {
	public class FadeTests {
		[Test]
		public void StopAll_FadesLastChannel() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);
			sut.StopAllChannels(1);

			Assert.AreEqual(1, mock2.FadeDurationReceived);
		}

		[Test]
		public void StopAll_DontFadeNonLastChannel() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("tomato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);
			sut.StopAllChannels(1);

			Assert.AreEqual(0, mock1.FadeDurationReceived);
		}

		[Test]
		public void StopChannel_FadesLastSong() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);
			MusicManager manager = new();

			manager.AddChannel(sut);
			sut.PlayNew(mock2);
			manager.StopChannel(sut, 1);

			Assert.AreEqual(1, mock2.FadeDurationReceived);
		}

		[Test]
		public void StopChannel_DontFadeNonLastSong() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);
			MusicManager manager = new();

			manager.AddChannel(sut);
			sut.PlayNew(mock2);
			manager.StopChannel(sut, 1);

			Assert.AreEqual(0, mock1.FadeDurationReceived);
		}

		[Test]
		public void PauseChannel_FadesLastSong() {
			AudioTrackMock mock1 = new("potato");
			MusicChannel sut = new(mock1);

			sut.Pause(1);

			Assert.AreEqual(1, mock1.FadeDurationReceived);
		}

		[Test]
		public void PauseChannel_DontFadeNonLastSong() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.PlayNew(mock2);
			sut.Pause(1);

			Assert.AreEqual(0, mock1.FadeDurationReceived);
		}

		[Test]
		public void UnpauseChannel_FadesLastSong() {
			AudioTrackMock mock1 = new("potato");
			MusicChannel sut = new(mock1);

			sut.Pause();
			sut.Unpause(1);

			Assert.AreEqual(1, mock1.FadeDurationReceived);
		}

		[Test]
		public void UnpauseChannel_DontFadeNonLastSong() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.PlayNew(mock2);
			sut.Pause();
			sut.Unpause(1);

			Assert.AreEqual(0, mock1.FadeDurationReceived);
		}
	}
}