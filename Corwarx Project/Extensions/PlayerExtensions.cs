using Corwarx_Project.Features.Components.PlayerComponents;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using InventorySystem.Items.Pickups;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Corwarx_Project.Extensions {
    public static class PlayerExtensions {
        public static PlayerMovement GetPlayerMovement(this Player pl) {
            if (pl.GameObject.TryGetComponent(out PlayerMovement obj))
                return obj;
            return null;
        }
       

        public static bool PickUpKeyCard(this Player player, float dist = 4) {
            if (UnityEngine.Physics.Linecast(player.CameraTransform.position, player.CameraTransform.position + player.CameraTransform.forward * dist, out RaycastHit hit)) { 
                Log.Info($"Hit: {hit.collider.gameObject.name}");
                ItemPickupBase pickup = hit.collider.gameObject.GetComponentInParent<ItemPickupBase>();
                if (pickup != null) { 
                    if (Pickup.Get(pickup).Type.IsKeycard()) {
                        player.AddItem(Pickup.Get(pickup));
                        GameObject.Destroy(pickup.gameObject);
                        return true;
                    }
                }
            }
            return false;
        }

        public static Player GetFromView(this Player owner, float lenght) {
            if (!Physics.Raycast(owner.CameraTransform.position, owner.CameraTransform.forward, out var hit, lenght)) return null;

            return Player.Get(hit.transform.GetComponentInParent<ReferenceHub>());
        }

        public static string ToShortString(this Player pl) => pl is null || pl.IsHost ? "Server" : $"{pl.Nickname} ({pl.Id}|{pl.UserId})";
        public static List<Player> FindNearby(this Player pl, float distance) => Player.List.Where(x => Vector3.Distance(pl.Position, x.Position) <= distance && x != pl).ToList();
    }
}
