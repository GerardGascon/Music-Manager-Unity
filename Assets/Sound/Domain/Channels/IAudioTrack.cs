namespace Sound.Domain.Channels {
	public interface IAudioTrack {
		void Play(float fadeDuration, float fadeDelay);
		void Pause(float fadeDuration, float fadeDelay);
		void Unpause(float fadeDuration, float fadeDelay);
		void Stop(float fadeDuration, float fadeDelay);
	}
}