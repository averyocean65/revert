using System;
using UnityEngine;

namespace Revert.Freecam {
	public class FreecamLooker : MonoSingleton<FreecamLooker> {
		private Vector2 _mouseDelta = Vector2.zero;
		private Vector2 _rotation = Vector2.zero;

		private void OnEnable() {
			_mouseDelta = Vector2.zero;
			_rotation = Vector2.zero;
		}

		private void Update() {
			if (OptionsManager.Instance.paused) {
				return;
			}

			_mouseDelta = InputManager.Instance.InputSource.Look.ReadValue<Vector2>();

			_rotation.y += _mouseDelta.x * Config.MouseSensitivity.Value.x;
			_rotation.x += _mouseDelta.y * Config.MouseSensitivity.Value.y * (Config.InvertMouseY.Value ? 1.0f : -1.0f);

			_rotation.x = Mathf.Clamp(_rotation.x, -90f, 90f);
			transform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, 0);
		}
	}
}