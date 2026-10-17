using System;
using System.Collections;
using UnityEngine;

namespace Revert.Recording {
	public class RecordingManager : MonoSingleton<RecordingManager> {
		public const float HeartbeatWait = 0.05f;

		public int CurrentRecordingIndex { get; private set; }
		public bool IsRecording { get; private set; }
		
		public Action onStartRecording;
		public Action onEndRecording;
		public Action onHeartbeat;
		
		public Action<int> onStartReplay;

		private GameObject _testCube;
		private Follow _testFollow;
		
		public void BeginRecording() {
			if (IsRecording) {
				return;
			}
			
			IsRecording = true;

			#region Testing
			
			if (!_testCube) {
				_testCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				_testFollow = _testCube.AddComponent<Follow>(); // according to the decomp, if the target isn't set it's the player
				_testCube.AddComponent<TransformRecordable>();
			}

			_testFollow.enabled = true;
#endregion

			if (onStartRecording != null) {
				onStartRecording.Invoke();
			}
			
			StartCoroutine(IRecordingHeartbeats());
		}

		public void EndRecording() {
			if (!IsRecording) {
				return;
			}

			IsRecording = false;

			if (onEndRecording != null) {
				onEndRecording.Invoke();
			}

			if (_testFollow) {
				_testFollow.enabled = false;
			}

			StopAllCoroutines();
			CurrentRecordingIndex++;
		}

		public void ReplayRecording(int recordingIndex) {
			if (onStartReplay != null) {
				onStartReplay.Invoke(recordingIndex);
			}
		}

		IEnumerator IRecordingHeartbeats() {
			if (onHeartbeat != null) {
				onHeartbeat.Invoke();
			}
			
			yield return new WaitForSeconds(HeartbeatWait);
			StartCoroutine(IRecordingHeartbeats());
		}
	}
}