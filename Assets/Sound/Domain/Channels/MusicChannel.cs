namespace Sound.Domain.Channels {
	public class MusicChannel : IMusicChannel {
		public IAudioTrack AudioTrack { private set; get; }

		public MusicChannel(IAudioTrack initialTrack) {
			AudioTrack = initialTrack;
		}

		public void Play() => AudioTrack.Play();
		public void Stop() => AudioTrack.Stop();
		public void Pause() => AudioTrack.Pause();
		public void Unpause() => AudioTrack.Unpause();

		public void SwitchSong(IAudioTrack newTrack) {
			AudioTrack.Stop();
			newTrack.Play();

			AudioTrack = newTrack;
		}
	}
}