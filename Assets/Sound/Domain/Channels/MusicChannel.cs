using System.Collections.Generic;

namespace Sound.Domain.Channels {
	public class MusicChannel : IMusicChannel {
		public IAudioTrack AudioTrack { private set; get; }

		public readonly Stack<IAudioTrack> ActiveTracks = new();

		public MusicChannel(IAudioTrack initialTrack) {
			AudioTrack = initialTrack;
			ActiveTracks.Push(initialTrack);
		}

		public void Play() => AudioTrack.Play();
		public void Stop() {
			AudioTrack = null;
			while (ActiveTracks.TryPop(out IAudioTrack track)) {
				track.Stop();
			}
		}

		public void Pause() => AudioTrack.Pause();
		public void Unpause() => AudioTrack.Unpause();

		public void SwitchSong(IAudioTrack newTrack) {
			AudioTrack.Stop();
			newTrack.Play();

			ActiveTracks.Pop();
			ActiveTracks.Push(newTrack);
			AudioTrack = newTrack;
		}

		public void PlayNew(IAudioTrack newTrack) {
			AudioTrack.Pause();
			AudioTrack = newTrack;
			ActiveTracks.Push(newTrack);
		}

		public void StopCurrent() {
			ActiveTracks.Pop();
			AudioTrack = ActiveTracks.Peek();
			AudioTrack.Unpause();
		}
	}
}