using CommandSystem;
using Exiled.API.Extensions;
using Exiled.API.Features;
using MEC;
using System;

namespace Corwarx_Administration.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class LoadSchene : ICommand {
        public string Command => "LoadSchene";

        public string[] Aliases => new string[] { "ls" };

        public string Description => "ахалай-махалай";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            int playerID = int.Parse(arguments[0]);

            Player player = Player.Get(playerID);

            player?.SendFakeSceneLoading(Exiled.API.Enums.ScenesType.MainMenuRemastered);

            Timing.CallDelayed(5, () => { player?.SendFakeSceneLoading(Exiled.API.Enums.ScenesType.PreLoader); });

            response = "Done";
            return true;
        }
    }
}
