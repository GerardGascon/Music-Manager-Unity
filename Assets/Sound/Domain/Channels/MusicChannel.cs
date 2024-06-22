using System.Collections.Generic;

namespace Sound.Domain.Channels {
	public class MusicChannel : IMusicChannel {
		public IAudioTrack AudioTrack { private set; get; }

		private readonly Stack<IAudioTrack> _activeTracks = new();

		public MusicChannel(IAudioTrack initialTrack) {
			AudioTrack = initialTrack;
			_activeTracks.Push(initialTrack);
		}

		public void Play() => AudioTrack.Play();
		public void Stop() {
			while (_activeTracks.TryPop(out IAudioTrack track)) {
				track.Stop();
			}
		}

		public void Pause() => AudioTrack.Pause();
		public void Unpause() => AudioTrack.Unpause();

		public void SwitchSong(IAudioTrack newTrack) {
			AudioTrack.Stop();
			newTrack.Play();

			AudioTrack = newTrack;
		}

		public void PlayNew(IAudioTrack newTrack) {
			AudioTrack.Pause();
			AudioTrack = newTrack;
			_activeTracks.Push(newTrack);
		}

		public void StopCurrent() {
			_activeTracks.Pop();
			AudioTrack = _activeTracks.Peek();
			AudioTrack.Unpause();
		}
	}
}