using UnityEngine;

namespace Revert {
	internal static class CameraUtilities {
		private static Camera _main;
		public static Camera Main {
			get {
				if (!_main) {
					_main = Camera.main;
				}

				return _main;
			}
		}
	}
}