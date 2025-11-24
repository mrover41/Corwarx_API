using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp096;
using PlayerRoles;

namespace Corwarx_Gameplay.Modules.SCP_096 {
    [LoadModule]
    internal class SCP_096Update : ModuleBase {
        public override string Name => "SCP096Update";

        public override void OnEnable() {
            Log.Debug($"[SCP_096Update] Enabled module: {Name} (ID: {Id})");
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
            Exiled.Events.Handlers.Scp096.CalmingDown += SCP096Enraging;
            base.OnEnable();
        }

        public override void OnDisable() {
            Log.Debug($"[SCP_096Update] Disabled module: {Name} (ID: {Id})");
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
            Exiled.Events.Handlers.Scp096.CalmingDown -= SCP096Enraging;
            base.OnDisable();
        }

        private void OnChangingRole(Exiled.Events.EventArgs.Player.ChangingRoleEventArgs ev) {
            Log.Debug($"[SCP_096Update] Handling role change for {ev.Player.Nickname} ({ev.Player.Role}) → {ev.NewRole}");

            if (ev.NewRole == RoleTypeId.Scp096) {
                ev.Player.Health = 50000;
                ev.Player.MaxHealth = 50000;
                Log.Debug($"[SCP_096Update] Player {ev.Player.Nickname} has become SCP-096.");
            }
        }

        private void OnSCP096Attack(TryingNotToCryEventArgs ev) {
            //ev.IsAllowed = false;
        }

        private void SCP096Enraging(CalmingDownEventArgs ev) {
            if (ev.Scp096.Targets.Count > 0)
                ev.IsAllowed = false;
        }
    }
}
