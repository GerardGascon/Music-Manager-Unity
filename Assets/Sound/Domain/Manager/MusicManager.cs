using System;
using System.Collections.Generic;
using Sound.Domain.Channels;

namespace Sound.Domain.Manager {
	public class MusicManager {
		internal readonly List<IMusicChannel> ActiveChannels = new();
		public IMusicChannel CurrentlyPlayingChannel => ActiveChannels.Count > 0 ? ActiveChannels[^1] : null;

		public void AddChannel(IMusicChannel musicChannel) {
			if (ActiveChannels.Contains(musicChannel))
				throw new InvalidOperationException("This music player is already in the stack.");

			CurrentlyPlayingChannel?.Pause();

			ActiveChannels.Add(musicChannel);

			musicChannel.Play();
		}

		public void StopChannel(IMusicChannel musicChannel) {
			bool isLast = musicChannel == ActiveChannels[^1];

			ActiveChannels.Remove(musicChannel);
			musicChannel.Stop();

			if(isLast)
				CurrentlyPlayingChannel?.Unpause();
		}

		public void StopAllChannels() {
			while (ActiveChannels.Count > 0) {
				ActiveChannels[0].Stop();
				ActiveChannels.RemoveAt(0);
			}
		}
	}
}