using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Pickups;
using UnityEngine;

namespace Corwarx_Gameplay.Modules.Integrations {
    internal class ItemIntegration : ModuleBase {
        public override string Name => "Item Integration";

        public override void OnEnable() {
            Exiled.Events.Handlers.Player.Shot += Interact;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.Shot += Interact;
            base.OnDisable();
        }

        void Interact(ShotEventArgs ev) {
            if (Physics.Linecast(ev.Player.CameraTransform.position, ev.RaycastHit.point, out RaycastHit hitInfo)) {
                if (hitInfo.transform.TryGetComponent(out ItemPickupBase itemPickupBase)) {
                    Pickup pickup = Pickup.Get(hitInfo.transform.gameObject);
                    Vector3 d = pickup.Position - ev.Player.CameraTransform.position;
                    d.Normalize();
                    switch (pickup.Type) {
                        case ItemType.GrenadeFlash:
                            pickup.Destroy();
                            Map.Explode(pickup.Position, Exiled.API.Enums.ProjectileType.Flashbang, pickup.PreviousOwner);
                            break;
                        case ItemType.GrenadeHE:
                            pickup.Destroy();
                            Map.Explode(pickup.Position, Exiled.API.Enums.ProjectileType.FragGrenade, pickup.PreviousOwner);
                            break;
                        default:
                            pickup.Rigidbody.AddForceAtPosition(d * 200, hitInfo.point);
                            break;
                    }
                    ev.Player.ShowHitMarker(0.5f);
                }
            }
        }
    }
}
