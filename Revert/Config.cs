using Configgy;

namespace Revert {
	internal static class Config {
		[Configgable("Freecam")] public static ConfigInputField<float> RegularMovementSpeed = new ConfigInputField<float>(15f);
		[Configgable("Freecam")] public static ConfigInputField<float> ShiftMovementSpeed = new ConfigInputField<float>(10f);
		[Configgable("Freecam")] public static ConfigToggle AllowShiftMovement = new ConfigToggle(true);
	}
}