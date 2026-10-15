using UnityEngine;

namespace Revert.Freecam {
	public class FreecamController : MonoSingleton<FreecamController> {
		private Vector2 _movementInput;
		private readonly float _regularMovementSpeed = 10.0f;
		private readonly float _slowMovementSpeed = 7.5f;

		private float _speed;
		
		private void Update() {
			if (InputManager.Instance == null) {
				return;
			}

			if (Config.AllowShiftMovement.Value) {
				_speed = InputManager.Instance.InputSource.Dodge.IsPressed
					? Config.ShiftMovementSpeed.Value
					: Config.RegularMovementSpeed.Value;
			}
			else {
				_speed = Config.RegularMovementSpeed.Value;
			}

			if (InputManager.Instance.InputSource.Jump.IsPressed) {
				transform.position += transform.up * _speed * Time.deltaTime;
			}
			
			if (InputManager.Instance.InputSource.Slide.IsPressed) {
				transform.position -= transform.up * _speed * Time.deltaTime;
			}

			_movementInput = InputManager.Instance.InputSource.Move.ReadValue<Vector2>();
			Vector3 movementVector = transform.right * _movementInput.x + transform.forward * _movementInput.y;
			
			transform.position += movementVector * _speed * Time.deltaTime;
		}

		private void OnGUI() {
			if (!gameObject.activeInHierarchy) {
				return;
			}
			
			GUILayout.Label($"Movement: {_movementInput.x} : {_movementInput.y}");
		}
	}
}