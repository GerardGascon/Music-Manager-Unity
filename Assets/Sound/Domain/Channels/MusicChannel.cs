namespace Sound.Domain.Channels {
	public class MusicChannel : IMusicChannel {
		public IAudioTrack AudioTrack { private set; get; }

		public MusicChannel(IAudioTrack initialTrack) {
			AudioTrack = initialTrack;
		}

		public void Play() { }
		public void Stop() { }
		public void Pause() { }
		public void Unpause() { }
	}
}