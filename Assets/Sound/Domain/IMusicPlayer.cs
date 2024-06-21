namespace Sound.Domain {
	public interface IMusicPlayer {
		void Play();
		void Stop();
		void Pause();
		void Unpause();
	}
}