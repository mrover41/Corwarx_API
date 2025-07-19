using Exiled.API.Features;
using UnityEngine;
namespace Corwarx_Project.Features.Components.PlayerComponents {
    public class PlayerMovement : MonoBehaviour {
        public Vector3 PrevPosition { get; private set; }
        private Player _player;
        private void Start() {
            _player = Player.Get(this.gameObject);
            PrevPosition = _player.Position;
        }

        private void FixedUpdate() {
            if (_player is null) return;
            if (_player.Position != PrevPosition) {
                
                if (!Corwarx_Project.Events.Handles.Player.OnPlayerMoving(new Events.Args._Player.PlayerMovingEventArgs(_player, _player.Position)).isAlloved) {
                    _player.Position = PrevPosition;
                } else { 
                    PrevPosition = _player.Position; Corwarx_Project.Events.Handles.Player.OnPlayerMove(new Events.Args._Player.PlayerMoveEventArgs(_player, _player.Position));
                }
            }
        }
    }
}
