using UnityEngine;

namespace Corwarx_Project.Events.Args._Player {
    public class PlayerMoveEventArgs {
        public PlayerMoveEventArgs(Exiled.API.Features.Player player, Vector3 position) {
            Player = player;
            Position = position;
        }

        public Exiled.API.Features.Player Player { get; }
        public Vector3 Position { get; }
    }
}
