using System.Collections.Generic;

namespace Sound.Domain.Channels {
	public class MusicChannel : IMusicChannel {
		internal readonly Stack<IAudioTrack> ActiveTracks = new();
		public IAudioTrack AudioTrack => ActiveTracks.TryPeek(out IAudioTrack track) ? track : null;

		public MusicChannel(IAudioTrack initialTrack) {
			ActiveTracks.Push(initialTrack);
		}

		public void Play(float fadeDuration = 0f, float fadeDelay = 0f) => AudioTrack.Play(fadeDuration, fadeDelay);
		public void Stop(float fadeDuration = 0f, float fadeDelay = 0f) {
			while (ActiveTracks.TryPop(out IAudioTrack track)) {
				track.Stop(fadeDuration, fadeDelay);
			}
		}

		public void Pause(float fadeDuration = 0f, float fadeDelay = 0f) => AudioTrack.Pause(fadeDuration, fadeDelay);
		public void Unpause(float fadeDuration = 0f, float fadeDelay = 0f) => AudioTrack.Unpause(fadeDuration, fadeDelay);

		public void SwitchSong(IAudioTrack newTrack, float fadeDuration = 0f, float fadeDelay = 0f) {
			AudioTrack.Stop(fadeDuration, fadeDelay);
			newTrack.Play(fadeDuration, fadeDelay);

			ActiveTracks.Pop();
			ActiveTracks.Push(newTrack);
		}

		public void PlayNew(IAudioTrack newTrack, float fadeDuration = 0f, float fadeDelay = 0f) {
			AudioTrack.Pause(fadeDuration, fadeDelay);
			ActiveTracks.Push(newTrack);
		}

		public void StopCurrent(float fadeDuration = 0f, float fadeDelay = 0f) {
			ActiveTracks.Pop();
			AudioTrack.Unpause(fadeDuration, fadeDelay);
		}
	}
}