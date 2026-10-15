using UnityEngine;

namespace Revert.Freecam {
	public class FreecamController : MonoSingleton<FreecamController> {
		private Vector2 _movementInput;
		
		private void Update() {
			if (InputManager.Instance == null) {
				return;
			}
			
			_movementInput = InputManager.Instance.InputSource.Move.ReadValue<Vector2>();
		}

		private void OnGUI() {
			if (!gameObject.activeInHierarchy) {
				return;
			}
			
			GUILayout.Label($"Movement: {_movementInput.x} : {_movementInput.y}");
		}
	}
}