using CommandSystem;
using Corwarx_Project.Features.UpdateInjector.Attributies;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using MEC;
using System;
using System.Linq;
using UnityEngine;

namespace Corwarx_Administration.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class Hivorot : ICommand {
        public string Command => "Huivorot";

        public string[] Aliases => new[] { "hv" };

        public string Description => "Хуиворот предметов";
        
        private static Player player = null;
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            int time = int.Parse(arguments[0]);
            if (arguments.Count != 1) {
                response = "Usage: hv <time>";
                return false;
            }

            player = Player.Get(sender);
            Timing.CallDelayed(time, () => { player = null; });
            response = "Done";
            return true;
        }

        [Update]
        private static void Phys() {
            Log.Debug("I`M UPDATE SUKA");
            if (player == null)
                return;
            foreach (Pickup pickup in Pickup.List.Where(x => Vector3.Distance(x.Transform.position, player.Position) < 10)) {
                Vector3 pos = player.Position - pickup.Position;
                pos.Normalize();
                pos *= 50 * Time.deltaTime;
                pickup.PhysicsModule.Rb.useGravity = false;
                pickup.PhysicsModule.Rb.AddForce(pos);
            }
        }
    }
}
