using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace Revert.Recording {
	public class RecordingManager : MonoSingleton<RecordingManager> {
		private const float HEARTBEAT_WAIT = 0.1f;

		public int CurrentRecordingIndex { get; private set; }
		
		public UnityEvent onStartRecording;
		public UnityEvent onEndRecording;
		public UnityEvent onHeartbeat;
		
		public UnityEvent<int> onStartReplay;
		
		private bool _isRecording;

		private GameObject _testCube;
		private TransformRecordable _testRecordable;
		
		public void BeginRecording() {
			if (_isRecording) {
				return;
			}
			
			_isRecording = true;
			onStartRecording.Invoke();

#region Testing

			if (!_testCube) {
				_testCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				Follow follow = _testCube.AddComponent<Follow>(); // according to the decomp, if the target isn't set it's the player
				_testRecordable = _testCube.AddComponent<TransformRecordable>();
			}
			
#endregion

			StartCoroutine(IRecordingHeartbeats());
			CurrentRecordingIndex++;
		}

		public void EndRecording() {
			if (!_isRecording) {
				return;
			}

			_isRecording = false;
			onEndRecording.Invoke();
			
			StopAllCoroutines();
		}

		public void StartReplayRecording(int recordingIndex) {
			onStartReplay.Invoke(recordingIndex);
		}

		IEnumerator IRecordingHeartbeats() {
			onHeartbeat.Invoke();
			yield return new WaitForSeconds(HEARTBEAT_WAIT);
			StartCoroutine(IRecordingHeartbeats());
		}
	}
}