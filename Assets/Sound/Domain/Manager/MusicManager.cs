using System;
using System.Collections.Generic;
using Sound.Domain.Channels;

namespace Sound.Domain.Manager {
	public class MusicManager {
		internal readonly List<IMusicChannel> ActiveChannels = new();
		public IMusicChannel CurrentlyPlayingChannel => ActiveChannels.Count > 0 ? ActiveChannels[^1] : null;

		public void AddChannel(IMusicChannel musicChannel, float fadeDuration = 0f, float delay = 0f) {
			if (ActiveChannels.Contains(musicChannel))
				throw new InvalidOperationException("This music player is already in the stack.");

			CurrentlyPlayingChannel?.Pause(fadeDuration, delay);

			ActiveChannels.Add(musicChannel);

			musicChannel.Play(fadeDuration, delay);
		}

		public void StopChannel(IMusicChannel musicChannel, float fadeDuration = 0f, float delay = 0f) {
			bool isLast = musicChannel == ActiveChannels[^1];

			ActiveChannels.Remove(musicChannel);
			musicChannel.Stop(fadeDuration, delay);

			if(isLast)
				CurrentlyPlayingChannel?.Unpause(fadeDuration, delay);
		}

		public void StopAllChannels(float fadeDuration = 0f, float delay = 0f) {
			while (ActiveChannels.Count > 0) {
				ActiveChannels[0].Stop(fadeDuration, delay);
				ActiveChannels.RemoveAt(0);
			}
		}
	}
}