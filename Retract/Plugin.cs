using BepInEx;

namespace MyMod {
	[BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
	public class Plugin : BaseUnityPlugin {
		private static class PluginInfo {
			public const string GUID = "com.averyocean65.revert";
			public const string NAME = "Revert";
			public const string VERSION = "0.1.0";
		}

		private void Start() {
			Logger.LogInfo("Hello, World!");
		}
	}
}