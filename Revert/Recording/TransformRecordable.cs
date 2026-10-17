using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;

namespace Revert.Recording {
	public struct TransformRecording {
		public Vector3 position;
		public Vector3 eulerAngles;
		public Vector3 localScale;
	}
	
	public class TransformRecordable : Recordable<TransformRecording> {
		private static ManualLogSource _logger = BepInEx.Logging.Logger.CreateLogSource("Revert TransformRecordable");

		protected override void OnStartRecording() {
			base.OnStartRecording();
			Recordings.Add(new List<TransformRecording>());
		}

		protected override void OnHeartbeat() {
			_logger.LogInfo($"heartbeat {Recordings[RecordingIndex].Count + 1}!");
			
			Recordings[RecordingIndex].Add(new TransformRecording() {
				position = transform.position,
				eulerAngles = transform.eulerAngles,
				localScale = transform.localScale
			});
		}

		protected override void PlayRecordingSegment(int recordingIndex, int partIndex) {
			_logger.LogInfo($"playing segment {recordingIndex}:{partIndex}!");
			
			TransformRecording part = Recordings[recordingIndex][partIndex];
			transform.position = part.position;
			transform.eulerAngles = part.eulerAngles;
			transform.localScale = part.localScale;
		}
	}
}