using UnityEngine;

namespace Revert.Freecam {
	public static class FreecamManager {
		public static bool IsEnabled { get; private set; } = false;
		private static Camera _freecamCamera;
		
		public static void Toggle() {
			Toggle(!IsEnabled);
		}

		private static void InitializeCamera() {
			if (!_freecamCamera) {
				GameObject cameraOwner = new GameObject("Revert Freecam");
				cameraOwner.AddComponent<FreecamController>();
				cameraOwner.AddComponent<FreecamLooker>();
				
				_freecamCamera = cameraOwner.AddComponent<Camera>();
				_freecamCamera.cullingMask = CameraUtilities.Main.cullingMask;
			}
			
			_freecamCamera.gameObject.SetActive(IsEnabled);
			
			_freecamCamera.transform.position = CameraUtilities.Main.transform.position;
			_freecamCamera.transform.rotation = CameraUtilities.Main.transform.rotation;
			_freecamCamera.fieldOfView = CameraUtilities.Main.fieldOfView;
		}
		
		public static void Toggle(bool state) {
			if (!AUU.SceneUtils.IsInLevel()) {
				Debug.LogError("You can only use the freecam command in a level!");
				return;
			}
			
			IsEnabled = state;
			
			InitializeCamera();
			NewMovement.Instance.gameObject.SetActive(!IsEnabled);
		}
	}
}