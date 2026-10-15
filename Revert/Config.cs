using Configgy;
using UnityEngine;

namespace Revert {
	internal static class Config {
		[Configgable("Freecam")] public static ConfigInputField<float> RegularMovementSpeed = new ConfigInputField<float>(15f);
		[Configgable("Freecam")] public static ConfigInputField<float> ShiftMovementSpeed = new ConfigInputField<float>(10f);
		
		[Configgable("Freecam")] public static ConfigVector2 MouseSensitivity = new ConfigVector2(new Vector2(100, 100));
		[Configgable("Freecam")] public static ConfigToggle InvertMouseY = new ConfigToggle(false);
		
		[Configgable("Freecam")] public static ConfigToggle AllowShiftMovement = new ConfigToggle(true);
	}
}