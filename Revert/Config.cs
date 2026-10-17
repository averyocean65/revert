using Configgy;
using UnityEngine;

namespace Revert {
	internal static class Config {
		[Configgable("Freecam")] public static ConfigInputField<float> RegularMovementSpeed = new ConfigInputField<float>(15f);
		[Configgable("Freecam")] public static ConfigInputField<float> ShiftMovementSpeed = new ConfigInputField<float>(10f);
		
		[Configgable("Freecam")] public static ConfigVector2 MouseSensitivity = new ConfigVector2(new Vector2(5f, 5f));
		[Configgable("Freecam")] public static ConfigToggle InvertMouseY = new ConfigToggle(false);
		
		[Configgable("Freecam")] public static ConfigToggle AllowShiftMovement = new ConfigToggle(true);

		[Configgable("Input")] public static ConfigKeybind RecordingKeybind = new ConfigKeybind(KeyCode.F5);

		[Configgable("Recording")] public static ConfigInputField<float> HeartbeatWait = new ConfigInputField<float>(0.1f);
	}
}