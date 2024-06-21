using Sound.Domain.Channels;

namespace Sound.Tests {
	public class AudioTrackMock : IAudioTrack {
		private readonly string _name;

		public AudioTrackMock(string name) {
			_name = name;
		}

		public void Play() { }
		public void Pause() { }
		public void Unpause() { }
		public void Stop() { }

		public override string ToString() {
			return _name;
		}
	}
}