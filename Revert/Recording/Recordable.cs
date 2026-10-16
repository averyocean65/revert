using UnityEngine;

namespace Revert.Recording {
	public abstract class Recordable : MonoBehaviour {
		protected int RecordingIndex = 0;
		
		private void Awake() {
			RecordingManager.Instance.onStartRecording.AddListener(OnStartRecording);
			RecordingManager.Instance.onEndRecording.AddListener(OnEndRecording);
			RecordingManager.Instance.onHeartbeat.AddListener(OnHeartbeat);
			
			RecordingManager.Instance.onStartReplay.AddListener(recordingIndex => {
				PlayRecordingSegment(recordingIndex, 0);
			});
		}

		protected virtual void OnStartRecording() { }

		protected virtual void OnEndRecording() {
			RecordingIndex++;
		}

		protected abstract void OnHeartbeat();
		protected abstract void PlayRecordingSegment(int recordingIndex, int partIndex);
	}
}