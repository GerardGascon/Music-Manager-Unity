using Sound.Domain.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Sound.View {
	public class Player : MonoBehaviour {
		[SerializeField] private Button playButton;
		[SerializeField] private Button pauseButton;
		[SerializeField] private Button stopButton;

		[Space]
		[SerializeField] private Button addChannelButton;
		[SerializeField] private Button removeChannelButton;

		private MusicManager _manager = new();

		private void Awake() {
			_manager = new MusicManager();

			playButton.onClick.AddListener(Play);
			pauseButton.onClick.AddListener(Pause);
			stopButton.onClick.AddListener(Stop);

			addChannelButton.onClick.AddListener(AddChannel);
			removeChannelButton.onClick.AddListener(RemoveChannel);
		}

		private void RemoveChannel() { }

		private void AddChannel() { }

		private void Stop() { }

		private void Pause() { }

		private void Play() { }
	}
}