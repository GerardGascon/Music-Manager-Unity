using NUnit.Framework;
using Sound.Domain.Channels;

namespace Sound.Tests {
	public class MusicChannelTests {
		[Test]
		public void SwitchSong_ChangesSong() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.SwitchSong(mock2);

			Assert.AreEqual(mock2, sut.AudioTrack);
		}

		[Test]
		public void SwitchSong_PreviousReceivesStopCall() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.SwitchSong(mock2);

			Assert.IsTrue(mock1.StopCallbackReceived);
		}
	}
}