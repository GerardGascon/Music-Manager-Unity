namespace Sound.Domain.Channels {
	public interface IMusicChannel {
		void Play();
		void Stop();
		void Pause();
		void Unpause();
	}
}