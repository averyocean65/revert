using GameConsole;

namespace Revert.Commands {
	public class ReplayRecordingCommand : ICommand {
		public string Name { get; } = "Replay Recording";
		public string Description { get; } = "Plays back the most recent recording";
		public string Command { get; } = "replay";
		
		public void Execute(Console con, string[] args) {
			throw new System.NotImplementedException();
		}
	}
}