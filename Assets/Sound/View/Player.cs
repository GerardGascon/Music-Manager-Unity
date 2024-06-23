using Sound.Domain.Channels;
using Sound.Domain.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Sound.View {
	public class Player : MonoBehaviour {
		[SerializeField] private Button playButton;
		[SerializeField] private Button pauseButton;
		[SerializeField] private Button unpauseButton;
		[SerializeField] private Button stopButton;

		[Space]
		[SerializeField] private Button addChannelButton;
		[SerializeField] private Button removeChannelButton;

		[Space]
		[SerializeField] private AudioSource source1;
		[SerializeField] private AudioSource source2;

		private MusicManager _manager = new();

		private AudioTrack _track1;
		private AudioTrack _track2;

		private MusicChannel _channel1;
		private MusicChannel _channel2;

		private int _added = 0;

		private void Awake() {
			_manager = new MusicManager();

			_track1 = new AudioTrack(source1);
			_track2 = new AudioTrack(source2);

			_channel1 = new MusicChannel(_track1);
			_channel2 = new MusicChannel(_track2);

			_manager.AddChannel(_channel1);

			playButton.onClick.AddListener(Play);
			pauseButton.onClick.AddListener(Pause);
			unpauseButton.onClick.AddListener(Unpause);
			stopButton.onClick.AddListener(Stop);

			addChannelButton.onClick.AddListener(AddChannel);
			removeChannelButton.onClick.AddListener(RemoveChannel);
		}

		private void RemoveChannel() {
			_manager.StopChannel(_manager.CurrentlyPlayingChannel);
		}

		private void AddChannel() {
			_manager.AddChannel(_added++ % 2 == 0 ? _channel2 : _channel1);
		}

		private void Stop() {
			_manager.CurrentlyPlayingChannel.Stop(0, 0);
		}

		private void Pause() {
			_manager.CurrentlyPlayingChannel.Pause(0, 0);
		}

		private void Unpause() {
			_manager.CurrentlyPlayingChannel.Unpause(0, 0);
		}

		private void Play() {
			_manager.CurrentlyPlayingChannel.Play(0, 0);
		}
	}
}