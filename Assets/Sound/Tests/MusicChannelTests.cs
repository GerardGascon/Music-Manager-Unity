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

		[Test]
		public void SwitchSong_NewReceivesPlayCall() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.SwitchSong(mock2);

			Assert.IsTrue(mock2.PlayCallbackReceived);
		}

		[Test]
		public void PlayNewSong_ChangesCurrentTrack() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.PlayNew(mock2);

			Assert.AreEqual(mock2, sut.AudioTrack);
		}

		[Test]
		public void PlayNewSong_PausePrevious() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.PlayNew(mock2);

			Assert.IsTrue(mock1.PauseCallbackReceived);
		}

		[Test]
		public void StopNewSong_UnpausePrevious() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.PlayNew(mock2);
			sut.StopCurrent();

			Assert.IsTrue(mock1.UnpauseCallbackReceived);
		}
	}
}