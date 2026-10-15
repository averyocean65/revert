using BepInEx;

namespace MyMod {
	[BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
	public class Plugin : BaseUnityPlugin {
		private static class PluginInfo {
			public const string GUID = "com.my.mod";
			public const string NAME = "My Mod";
			public const string VERSION = "1.0.0";
		}

		private void Start() {
			Logger.LogInfo("Hello, World!");
		}
	}
}