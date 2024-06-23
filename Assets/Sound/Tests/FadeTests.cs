using NUnit.Framework;
using Sound.Domain.Manager;
using Sound.Tests.Mocks;

namespace Sound.Tests {
	public class FadeTests {
		[Test]
		public void StopAll_FadesLastChannel() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("potato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);
			sut.StopAllChannels(1);

			Assert.AreEqual(1, mock2.FadeDurationReceived);
		}

		[Test]
		public void StopAll_DontFadeNonLastChannel() {
			MusicChannelMock mock1 = new("potato");
			MusicChannelMock mock2 = new("potato");
			MusicManager sut = new();

			sut.AddChannel(mock1);
			sut.AddChannel(mock2);
			sut.StopAllChannels(1);

			Assert.AreEqual(0, mock1.FadeDurationReceived);
		}
	}
}