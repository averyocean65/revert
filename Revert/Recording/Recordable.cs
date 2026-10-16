using UnityEngine;

namespace Revert.Recording {
	public abstract class Recordable : MonoBehaviour {
		protected int RecordingIndex = 0;
		
		private void Awake() {
			RecordingManager.Instance.onStartRecording.AddListener(OnStartRecording);
			RecordingManager.Instance.onEndRecording.AddListener(OnEndRecording);
			RecordingManager.Instance.onHeartbeat.AddListener(OnHeartbeat);
		}

		protected virtual void OnStartRecording() { }

		protected virtual void OnEndRecording() {
			RecordingIndex++;
		}

		protected abstract void OnHeartbeat();
	}
}