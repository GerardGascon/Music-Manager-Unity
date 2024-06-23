using Sound.Domain.Channels;

namespace Sound.Tests.Mocks {
	public class AudioTrackMock : IAudioTrack {
		private readonly string _name;

		public bool PlayCallbackReceived;
		public bool StopCallbackReceived;
		public bool PauseCallbackReceived;
		public bool UnpauseCallbackReceived;

		public AudioTrackMock(string name) {
			_name = name;
		}

		public void Play(float fadeDuration, float fadeDelay) {
			PlayCallbackReceived = true;
		}

		public void Stop(float fadeDuration, float fadeDelay) {
			StopCallbackReceived = true;
		}

		public void Pause(float fadeDuration, float fadeDelay) {
			PauseCallbackReceived = true;
		}

		public void Unpause(float fadeDuration, float fadeDelay) {
			UnpauseCallbackReceived = true;
		}

		public override string ToString() {
			return _name;
		}
	}
}