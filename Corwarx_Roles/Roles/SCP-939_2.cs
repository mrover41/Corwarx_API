using Corwarx_Project.Features.RoleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.Manager;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace Corwarx_Project.Roles {
    internal class SCP_939_2 : RoleBase {
        public override string Name { get; set; } = "SCP-939-2";
        public override string Description { get; set; } = "A variant of SCP-939";
        public override uint Id { get; set; } = 2;

        public override void OnEnable() {
            Exiled.Events.Handlers.Player.Hurt += OnDamage;
            Exiled.Events.Handlers.Player.ChangingRole += OnPlayerChangeRole;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.Hurt -= OnDamage;
            Exiled.Events.Handlers.Player.ChangingRole -= OnPlayerChangeRole;
            base.OnDisable();
        }

        public override void Spawn(Player player) {
            player.Role.Set(RoleTypeId.Scp939);
            base.Spawn(player);
        }

        private void OnDamage(HurtEventArgs ev) {
            if (!players.Contains(ev.Player)) return;
            ev.DamageHandler.Damage = 15;
        }

        private void OnPlayerChangeRole(ChangingRoleEventArgs ev) {
            if (ev.NewRole == RoleTypeId.Scp939) return;
            RoleManager.RemoveRole(ev.Player, Id);
        }
    }
}
