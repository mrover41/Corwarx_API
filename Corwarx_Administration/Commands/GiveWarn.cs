using CommandSystem;
using Corwarx_Administration.WarnSystem;
using Exiled.API.Features;
using System;

namespace Corwarx_Administration.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class AddWarn : ICommand {
        public string Command => "AddWarn";

        public string[] Aliases => new[] { "w" };

        public string Description => "Add warn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            if (arguments.Count < 2) { 
                response = "Usage: AddWarn <playerID> <reason>";
                return false;
            }
            Player player = Player.Get(arguments[0]);
            WarnManager.AddWarn(player.UserId.ToString(), arguments[1], player.Nickname, player.Id, out response);
            return true;
        }
    }
}
