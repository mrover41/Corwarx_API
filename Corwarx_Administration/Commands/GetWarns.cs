using CommandSystem;
using Corwarx_Administration.WarnSystem;
using Exiled.API.Features;
using System;
using System.Text;

namespace Corwarx_Administration.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class GetWarn : ICommand {
        public string Command => "GetWarn";

        public string[] Aliases => new[] { "wg" };

        public string Description => "Get warn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            StringBuilder sb = new StringBuilder();
            if (arguments.Count != 1) { 
                response = "Usage: GetWarn <playerSteamID>";
                return false;
            }
            WarnManager.GetWarns(arguments[0]).ForEach(warn => {
                sb.AppendLine($"ID: {warn.ID}, Nickname: {warn.Nickname}, Message: {warn.Message}");
            });
            response = sb.ToString();
            return true;
        }
    }

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class GetWarnPID : ICommand {
        public string Command => "GetWarnPID";

        public string[] Aliases => new[] { "wgi" };

        public string Description => "Get warn plID";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            StringBuilder sb = new StringBuilder();
            if (arguments.Count != 1) { 
                response = "Usage: GetWarn <playerPlayerID>";
                return false;
            }
            Player player = Player.Get(arguments[0]);
            WarnManager.GetWarns(player.UserId.ToString()).ForEach(warn => {
                sb.AppendLine($"ID: {warn.ID}, Nickname: {warn.Nickname}, Message: {warn.Message}");
            });
            response = sb.ToString();
            return true;
        }
    }
}
