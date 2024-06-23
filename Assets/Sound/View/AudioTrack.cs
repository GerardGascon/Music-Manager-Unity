using Sound.Domain.Channels;
using UnityEngine;

namespace Sound.View {
	public class AudioTrack : IAudioTrack {
		private readonly AudioSource _audioSource;

		public AudioTrack(AudioSource source) => _audioSource = source;

		public void Play(float fadeDuration, float fadeDelay) => _audioSource.Play();
		public void Pause(float fadeDuration, float fadeDelay) => _audioSource.Pause();
		public void Unpause(float fadeDuration, float fadeDelay) => _audioSource.UnPause();
		public void Stop(float fadeDuration, float fadeDelay) => _audioSource.Stop();
	}
}