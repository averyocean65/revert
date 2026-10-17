using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revert.Recording {
	public abstract class Recordable<T> : MonoBehaviour {
		protected int RecordingIndex = 0;
		protected List<List<T>> Recordings;
			
		private void Awake() {
			Recordings = new List<List<T>>();
			
			RecordingManager.Instance.onStartRecording += OnStartRecording;
			RecordingManager.Instance.onEndRecording += OnEndRecording;
			RecordingManager.Instance.onHeartbeat += OnHeartbeat;
			
			RecordingManager.Instance.onStartReplay += recordingIndex => {
				StartCoroutine(IPlayBackRecording(recordingIndex));
			};
		}

		protected virtual void OnStartRecording() { }

		protected virtual void OnEndRecording() {
			RecordingIndex++;
		}

		protected abstract void OnHeartbeat();
		protected abstract void PlayRecordingSegment(int recordingIndex, int partIndex);

		private IEnumerator IPlayBackRecording(int recordingIndex) {
			if (recordingIndex < 0 || recordingIndex >= Recordings.Count) {
				yield break;
			}
			
			for (int i = 0; i < Recordings[recordingIndex].Count; i++) {
				PlayRecordingSegment(recordingIndex, i);
				yield return new WaitForSeconds(RecordingManager.HeartbeatWait);
			}
		}
	}
}