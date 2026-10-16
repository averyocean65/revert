using UnityEngine;

namespace Revert.Recording {
	public abstract class Recordable : MonoBehaviour {
		protected int RecordingIndex = 0;
		
		private void Awake() {
			RecordingManager.Instance.onStartRecording += OnStartRecording;
			RecordingManager.Instance.onEndRecording += OnEndRecording;
			RecordingManager.Instance.onHeartbeat += OnHeartbeat;
			
			RecordingManager.Instance.onStartReplay += (recordingIndex => {
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