using Sound.Domain;

namespace Sound.Tests {
	public class MusicPlayerMock : IMusicPlayer {
		private readonly string _name;

		public bool PlayCallbackReceived;
		public bool StopCallbackReceived;
		public bool PauseCallbackReceived;
		public bool UnpauseCallbackReceived;

		public MusicPlayerMock(string name) {
			_name = name;
		}

		public void Play() {
			PlayCallbackReceived = true;
		}

		public void Stop() {
			StopCallbackReceived = true;
		}

		public void Pause() {
			PauseCallbackReceived = true;
		}

		public void Unpause() {
			UnpauseCallbackReceived = true;
		}

		public override string ToString() => _name;
	}
}