using System;
using System.Collections.Generic;

namespace Sound.Domain {
	public class MusicManager {
		public IMusicPlayer CurrentlyPlayingMusic { private set; get; }
		public readonly Stack<IMusicPlayer> ActiveMusic = new();

		public void Play(IMusicPlayer musicPlayer) {
			if (ActiveMusic.Contains(musicPlayer))
				throw new InvalidOperationException("This music player is already in the stack.");

			CurrentlyPlayingMusic?.Pause();

			ActiveMusic.Push(musicPlayer);
			CurrentlyPlayingMusic = ActiveMusic.Peek();

			musicPlayer.Play();
		}

		public void Stop() {
			IMusicPlayer player = ActiveMusic.Pop();
			player.Stop();

			CurrentlyPlayingMusic = ActiveMusic.Count > 0 ? ActiveMusic.Peek() : null;

			CurrentlyPlayingMusic?.Unpause();
		}

		public void StopAll() {
			CurrentlyPlayingMusic = null;

			while (ActiveMusic.TryPop(out IMusicPlayer player))
				player.Stop();
		}
	}
}