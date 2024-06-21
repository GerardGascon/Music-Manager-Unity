namespace Sound.Domain.Channels {
	public interface IAudioTrack {
		void Play();
		void Pause();
		void Unpause();
		void Stop();
	}
}