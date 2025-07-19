using CommandSystem;
using Corwarx_Administration.WarnSystem;
using Exiled.API.Features;
using System;

namespace Corwarx_Administration.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class ClearWarn : ICommand {
        public string Command => "ClearWarn";

        public string[] Aliases => new[] { "wc" };

        public string Description => "Clear warn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            if (arguments.Count != 1) {
                response = "Usage: ClearWarn <playerSteamID>";
                return false;
            }
            WarnManager.ClearWarns(arguments[0]);
            response = "+--------------------\n" +
                       $"| Warns cleared for {arguments[0]}\n" +
                       "+--------------------";
            return true;
        }
    }

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class ClearWarnID : ICommand {
        public string Command => "ClearWarnID";

        public string[] Aliases => new[] { "wci" };

        public string Description => "Get warn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            if (arguments.Count != 1) {
                response = "Usage: ClearWarnID <playerID>";
                return false;
            }
            WarnManager.ClearWarns(Player.Get(arguments[0]).UserId);
            response = "+--------------------\n" +
                       $"| Warns cleared for {arguments[0]}\n" +
                       "+--------------------";
            return true;
        }
    }
}
