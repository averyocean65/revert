using BepInEx;
using Configgy;
using Revert.Commands;
using Revert.Recording;
using UnityEngine;

namespace Revert {
	[BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
	[BepInDependency("Hydraxous.ULTRAKILL.Configgy", BepInDependency.DependencyFlags.HardDependency)]
	internal class Plugin : BaseUnityPlugin {
		private static class PluginInfo {
			public const string GUID = "com.averyocean65.revert";
			public const string NAME = "Revert";
			public const string VERSION = "0.1.0";
		}

		private ConfigBuilder _config;

		private void Awake() {
			_config = new ConfigBuilder(PluginInfo.GUID, PluginInfo.NAME);
			_config.BuildAll();
		}

		private void Start() {
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			DontDestroyOnLoad(gameObject);
			
			CommandsManager.RegisterAll();

			GameObject recordingManager = new GameObject("Revert Recording Manager");
			recordingManager.AddComponent<RecordingManager>();
		}

		private void Update() {
			if (Input.GetKeyDown(Revert.Config.RecordingKeybind.Value)) {
				if (RecordingManager.Instance.IsRecording) {
					RecordingManager.Instance.EndRecording();
				}
				else {
					RecordingManager.Instance.BeginRecording();
				}
			}
		}
	}
}