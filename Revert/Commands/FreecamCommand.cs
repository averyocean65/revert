using GameConsole;

namespace Revert.Commands {
	public class FreecamCommand : ICommand {
		public string Name { get; } = "Freecam Mode";
		public string Description { get; } = "Enables freecam mode and spawns a dummy player";
		public string Command { get; } = "freecam";
		
		public void Execute(Console con, string[] args) {
			FreecamManager.Toggle();
		}
	}
}