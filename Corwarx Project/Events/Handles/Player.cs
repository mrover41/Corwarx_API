using Corwarx_Project.Events.Args._Player;
using System;

namespace Corwarx_Project.Events.Handles {
    public static class Player {
        public static event Action<PlayerMovingEventArgs> PlayerMoving;
        public static event Action<PlayerMoveEventArgs> PlayerMove;

        public static PlayerMovingEventArgs OnPlayerMoving(PlayerMovingEventArgs args) {
            PlayerMoving?.Invoke(args);
            return args;
        }

        public static PlayerMoveEventArgs OnPlayerMove(PlayerMoveEventArgs args) {
            PlayerMove?.Invoke(args);
            return args;
        }
    }
}
