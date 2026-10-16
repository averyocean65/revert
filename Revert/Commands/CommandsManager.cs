using GameConsole;

namespace Revert.Commands {
	internal static class CommandsManager {
		public static void RegisterAll() {
			Console.Instance.RegisterCommands(new ICommand[] {
				new FreecamCommand(),
				new ReplayRecordingCommand()
			});
		}
	}
}