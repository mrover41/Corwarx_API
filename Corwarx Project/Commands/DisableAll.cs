using CommandSystem;
using Corwarx_Project.Core;
using System;

namespace Corwarx_Project.Commands {
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    internal class DisableAll : ICommand {
        public string Command => "DisablePlugin";

        public string[] Aliases => new string[] { };

        public string Description => "disable all";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            Loader.Instance.OnDisabled();

            response = "Done";
            return true;
        }
    }
}
