using Sound.Domain;
using Sound.Domain.Channels;

namespace Sound.Tests {
	public class MusicChannelMock : IMusicChannel {
		private readonly string _name;

		public bool PlayCallbackReceived;
		public bool StopCallbackReceived;
		public bool PauseCallbackReceived;
		public bool UnpauseCallbackReceived;

		public MusicChannelMock(string name) {
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