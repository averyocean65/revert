using GameConsole;
using Revert.Recording;

namespace Revert.Commands {
	public class ReplayRecordingCommand : ICommand {
		public string Name { get; } = "Replay Recording";
		public string Description { get; } = "Plays back any given recording";
		public string Command { get; } = "replay";
		
		public void Execute(Console con, string[] args) {
			int index;
			if (args.Length < 1) {
				index = RecordingManager.Instance.CurrentRecordingIndex;
			} else if (!int.TryParse(args[0], out index)) {
				return;
			}
			
			RecordingManager.Instance.ReplayRecording(index);
		}
	}
}