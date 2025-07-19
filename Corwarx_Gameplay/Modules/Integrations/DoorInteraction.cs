using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
using Interactables.Interobjects.DoorButtons;
using Interactables.Interobjects.DoorUtils;
using UnityEngine;

namespace Corwarx_Gameplay.Modules.Integrations {
    internal class DoorInteraction : ModuleBase {
        public override string Name => "Door Interaction";

        private float lTime = 5f;

        public override void OnEnable() {
            Exiled.Events.Handlers.Player.Shot += Shoot;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.Shot += Shoot;
            base.OnDisable();
        }

        void Shoot(ShotEventArgs ev) {
            if (!Physics.Raycast(ev.Player.CameraTransform.position, (ev.RaycastHit.point - ev.Player.CameraTransform.position).normalized, out RaycastHit raycastHit, 70f)) return; //~(1 << 1 | 1 << 13 | 1 << 16 | 1 << 28)
            if (raycastHit.transform.gameObject.GetComponentInParent<BasicDoorButton>() is BasicDoorButton button) {
                Door door = Door.Get(button.GetComponentInParent<DoorVariant>());
                if (!door.IsKeycardDoor && !door.IsLocked && !door.IsElevator) {
                    door.IsOpen = !door.IsOpen; door.Lock(lTime, Exiled.API.Enums.DoorLockType.AdminCommand);
                    ev.Player.ShowHitMarker(0.5f);
                }
            }
        }
    }
}
