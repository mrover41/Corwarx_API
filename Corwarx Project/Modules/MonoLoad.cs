using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.Components.PlayerComponents;
using Corwarx_Project.Features.Components.SCP049Components;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using UnityEngine;

namespace Corwarx_Project.Modules {
    [LoadModule]
    internal class MonoLoad : ModuleBase {
        public override string Name => "Mono Loader";

        public override void OnEnable() {
            Log.Debug($"[MonoLoad] Enabled module: {Name} (ID: {Id})");
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
            base.OnEnable();
        }

        public override void OnDisable() {
            Log.Debug($"[MonoLoad] Disabled module: {Name} (ID: {Id})");
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
            base.OnDisable();
        }

        private void OnChangingRole(ChangingRoleEventArgs ev) {
            Log.Debug($"[MonoLoad] Handling role change for {ev.Player.Nickname} ({ev.Player.Role}) → {ev.NewRole}");

            RemoveComponent<PlayerMovement>(ev.Player);
            RemoveComponent<SCP049Component>(ev.Player);

            if (ev.NewRole.IsHuman()) {
                AddComponent<PlayerMovement>(ev.Player);
            }
            else if (ev.NewRole == RoleTypeId.Scp049) {
                AddComponent<SCP049Component>(ev.Player);
            }
        }

        private void AddComponent<T>(Player player) where T : Component {
            Component added = player.GameObject.AddComponent<T>();
            Log.Debug($"[MonoLoad] Added component: {typeof(T).Name} to {player.Nickname}");
        }


        private void RemoveComponent<T>(Player player) where T : Component {
            if (player.GameObject.TryGetComponent(out T existing)) {
                Object.Destroy(existing);
                Log.Debug($"[MonoLoad] Removed component: {typeof(T).Name} from {player.Nickname}");
            }
        }
    }
}
