using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace Revert.Recording {
	public class RecordingManager : MonoSingleton<RecordingManager> {
		private const float HEARTBEAT_WAIT = 0.1f;
		
		public UnityEvent onStartRecording;
		public UnityEvent onEndRecording;
		public UnityEvent onHeartbeat;
		
		private bool _isRecording;
		
		public void BeginRecording() {
			if (_isRecording) {
				return;
			}
			
			_isRecording = true;
			onStartRecording.Invoke();

			StartCoroutine(IRecordingHeartbeats());
		}

		public void EndRecording() {
			if (!_isRecording) {
				return;
			}

			_isRecording = false;
			onEndRecording.Invoke();
			
			StopAllCoroutines();
		}

		IEnumerator IRecordingHeartbeats() {
			onHeartbeat.Invoke();
			yield return new WaitForSeconds(HEARTBEAT_WAIT);
			StartCoroutine(IRecordingHeartbeats());
		}
	}
}