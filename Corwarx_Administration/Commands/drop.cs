using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using System;

namespace Corwarx_Administration.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class Drop : ICommand {
        public string Command => "Drop";

        public string[] Aliases => new[] { "drop" };

        public string Description => "Drop items";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            int id = int.Parse(arguments[0]);
            int count = int.Parse(arguments[1]);
            if (arguments.Count != 2) {
                response = "Usage: Drop <Item ID> <Count>";
                return false;
            }
            for (int i = 0; i < count; i++)
                Pickup.CreateAndSpawn((ItemType)id, Player.Get(sender).Position);
            response = "Done";
            return true;
        }
    }
}
