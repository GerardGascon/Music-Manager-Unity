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
		public void SwitchSong_SwitchesActiveTrackInStack() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.SwitchSong(mock2);

			Assert.AreEqual(mock2, sut.ActiveTracks.Peek());
		}

		[Test]
		public void SwitchSong_RemovesPreviousTrackFromStack() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.SwitchSong(mock2);

			Assert.IsFalse(sut.ActiveTracks.Contains(mock1));
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

		[Test]
		public void StopChannel_StopsAllTracks() {
			AudioTrackMock mock1 = new("potato");
			AudioTrackMock mock2 = new("tomato");
			MusicChannel sut = new(mock1);

			sut.PlayNew(mock2);
			sut.Stop();

			Assert.IsTrue(mock1.StopCallbackReceived);
			Assert.IsTrue(mock2.StopCallbackReceived);
		}

		[Test]
		public void StopChannel_ClearsActiveTrack() {
			AudioTrackMock mock1 = new("potato");
			MusicChannel sut = new(mock1);

			sut.Stop();

			Assert.IsNull(sut.AudioTrack);
		}
	}
}