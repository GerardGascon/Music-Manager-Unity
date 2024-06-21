namespace Sound.Domain {
	public interface IMusicChannel {
		void Play();
		void Stop();
		void Pause();
		void Unpause();
	}
}