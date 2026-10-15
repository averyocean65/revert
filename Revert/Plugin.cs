using BepInEx;
using Revert.Commands;
using UnityEngine;

namespace Revert {
	[BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
	internal class Plugin : BaseUnityPlugin {
		private static class PluginInfo {
			public const string GUID = "com.averyocean65.revert";
			public const string NAME = "Revert";
			public const string VERSION = "0.1.0";
		}

		private void Start() {
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			DontDestroyOnLoad(gameObject);
			
			CommandsManager.RegisterAll();
		}
	}
}