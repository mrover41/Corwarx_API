using CommandSystem;
using Corwarx_Project.Features.RoleSystem.Manager;
using Exiled.API.Features;
using System;
using System.Linq;

namespace Corwarx_Roles.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class Take : ICommand {
        public string Command => "set_role";

        public string[] Aliases => new[] { "r" };

        public string Description => "SetRole";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            Player player = Player.Get(sender);
            RoleManager.AddRole(player, 2);
            player.SpawnRole(2);
            response = $"Done";
            return true;
        }
    }
}
