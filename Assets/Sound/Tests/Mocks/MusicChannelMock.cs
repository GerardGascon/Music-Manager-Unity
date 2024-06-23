using Sound.Domain.Channels;

namespace Sound.Tests.Mocks {
	public class MusicChannelMock : IMusicChannel {
		private readonly string _name;

		public bool PlayCallbackReceived;
		public bool StopCallbackReceived;
		public bool PauseCallbackReceived;
		public bool UnpauseCallbackReceived;

		public float FadeDurationReceived, FadeDelayReceived;

		public MusicChannelMock(string name) {
			_name = name;
		}

		public void Play(float fadeDuration, float fadeDelay) {
			PlayCallbackReceived = true;
			FadeDurationReceived = fadeDuration;
			FadeDelayReceived = fadeDelay;
		}

		public void Stop(float fadeDuration, float fadeDelay) {
			StopCallbackReceived = true;
			FadeDurationReceived = fadeDuration;
			FadeDelayReceived = fadeDelay;
		}

		public void Pause(float fadeDuration, float fadeDelay) {
			PauseCallbackReceived = true;
			FadeDurationReceived = fadeDuration;
			FadeDelayReceived = fadeDelay;
		}

		public void Unpause(float fadeDuration, float fadeDelay) {
			UnpauseCallbackReceived = true;
			FadeDurationReceived = fadeDuration;
			FadeDelayReceived = fadeDelay;
		}

		public override string ToString() => _name;
	}
}