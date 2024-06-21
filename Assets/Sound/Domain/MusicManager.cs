using System;
using System.Collections.Generic;

namespace Sound.Domain {
	public class MusicManager {
		public IMusicChannel CurrentlyPlayingChannel { private set; get; }
		public readonly Stack<IMusicChannel> ActiveChannels = new();

		public void AddChannel(IMusicChannel musicChannel) {
			if (ActiveChannels.Contains(musicChannel))
				throw new InvalidOperationException("This music player is already in the stack.");

			CurrentlyPlayingChannel?.Pause();

			ActiveChannels.Push(musicChannel);
			CurrentlyPlayingChannel = ActiveChannels.Peek();

			musicChannel.Play();
		}

		public void RemoveLast() {
			IMusicChannel channel = ActiveChannels.Pop();
			channel.Stop();

			CurrentlyPlayingChannel = ActiveChannels.Count > 0 ? ActiveChannels.Peek() : null;

			CurrentlyPlayingChannel?.Unpause();
		}

		public void StopAllChannels() {
			CurrentlyPlayingChannel = null;

			while (ActiveChannels.TryPop(out IMusicChannel player))
				player.Stop();
		}
	}
}