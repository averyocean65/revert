using System.Collections.Generic;
using UnityEngine;

namespace Revert.Recording {
	public class TransformRecordable : Recordable {
		struct TransformRecording {
			public Vector3 position;
			public Vector3 eulerAngles;
			public Vector3 localScale;
		}

		private List<List<TransformRecording>> _recordings = new List<List<TransformRecording>>();

		protected override void OnStartRecording() {
			base.OnStartRecording();
			_recordings.Add(new List<TransformRecording>());
		}

		protected override void OnHeartbeat() {
			_recordings[RecordingIndex].Add(new TransformRecording() {
				position = transform.position,
				eulerAngles = transform.eulerAngles,
				localScale = transform.localScale
			});
		}

		protected override void PlayRecordingSegment(int recordingIndex, int partIndex) {
			TransformRecording part = _recordings[recordingIndex][partIndex];
			transform.position = part.position;
			transform.eulerAngles = part.eulerAngles;
			transform.localScale = part.localScale;
		}
	}
}