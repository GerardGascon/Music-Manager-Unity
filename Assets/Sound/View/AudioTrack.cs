using Sound.Domain.Channels;
using UnityEngine;

namespace Sound.View {
	public class AudioTrack : IAudioTrack {
		private readonly AudioSource _audioSource;

		public AudioTrack(AudioSource source) => _audioSource = source;

		public void Play() => _audioSource.Play();
		public void Pause() => _audioSource.Pause();
		public void Unpause() => _audioSource.UnPause();
		public void Stop() => _audioSource.Stop();
	}
}