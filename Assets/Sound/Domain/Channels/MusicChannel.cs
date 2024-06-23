using System.Collections.Generic;

namespace Sound.Domain.Channels {
	public class MusicChannel : IMusicChannel {
		internal readonly Stack<IAudioTrack> ActiveTracks = new();
		public IAudioTrack AudioTrack => ActiveTracks.TryPeek(out IAudioTrack track) ? track : null;

		public MusicChannel(IAudioTrack initialTrack) {
			ActiveTracks.Push(initialTrack);
		}

		public void Play() => AudioTrack.Play();
		public void Stop() {
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
		}

		public void PlayNew(IAudioTrack newTrack) {
			AudioTrack.Pause();
			ActiveTracks.Push(newTrack);
		}

		public void StopCurrent() {
			ActiveTracks.Pop();
			AudioTrack.Unpause();
		}
	}
}