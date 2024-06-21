using System;
using System.Collections.Generic;

namespace Sound.Domain {
	public class MusicManager {
		public IMusicChannel CurrentlyPlayingChannel { private set; get; }
		public readonly List<IMusicChannel> ActiveChannels = new();

		public void AddChannel(IMusicChannel musicChannel) {
			if (ActiveChannels.Contains(musicChannel))
				throw new InvalidOperationException("This music player is already in the stack.");

			CurrentlyPlayingChannel?.Pause();

			ActiveChannels.Add(musicChannel);
			CurrentlyPlayingChannel = ActiveChannels[^1];

			musicChannel.Play();
		}

		public void RemoveLast() {
			IMusicChannel channel = CurrentlyPlayingChannel;
			ActiveChannels.RemoveAt(ActiveChannels.Count - 1);
			channel.Stop();

			CurrentlyPlayingChannel = ActiveChannels.Count > 0 ? ActiveChannels[^1] : null;

			CurrentlyPlayingChannel?.Unpause();
		}

		public void StopChannel(IMusicChannel musicChannel) {
			ActiveChannels.Remove(musicChannel);
			CurrentlyPlayingChannel = ActiveChannels.Count > 0 ? ActiveChannels[^1] : null;
		}

		public void StopAllChannels() {
			CurrentlyPlayingChannel = null;

			while (ActiveChannels.Count > 0) {
				ActiveChannels[0].Stop();
				ActiveChannels.RemoveAt(0);
			}
		}
	}
}