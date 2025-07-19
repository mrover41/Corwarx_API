using Corwarx_Project.Features.RoleSystem.BaseClass;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using PlayerRoles.Visibility;
using UnityEngine;

namespace Corwarx_Project.Roles {
    internal class SCP_966 : RoleBase {
        public override string Name { get; set; } = "SCP-966 - Безсонник";
        public override string Description { get; set; } = "SCP-966 - Безсонник, существо, способное вызывать бессонницу у людей. Его присутствие вызывает сильную усталость и сонливость у жертв, что делает их уязвимыми к атакам SCP-966.";
        public override uint Id { get; set; } = 3;

        public override void OnEnable() {
            Exiled.Events.Handlers.Player.Hurt += OnDamage;
            //Exiled.Events.Handlers.Player.ChangingRole += OnPlayerChangeRole;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.Hurt -= OnDamage;
            //Exiled.Events.Handlers.Player.ChangingRole -= OnPlayerChangeRole;
            base.OnDisable();
        }

        public override void Spawn(Player player) {
            Log.Debug($"[SCP-966] Spawned role: {Name} (ID: {Id})");
            player.Role.Set(RoleTypeId.Scp0492);
            player.Scale = new Vector3(0.5f, 0.5f, 0.5f);
            player.MaxHealth = 3000;
            player.Health = 3000;
            base.Spawn(player);
        }

        void OnDamage(HurtEventArgs ev) {
            if (!players.Contains(ev.Player)) return;
            ev.DamageHandler.Damage = 12;
        }

        void OnPlayerChangeRole(ChangingRoleEventArgs ev) {
            /*if (ev.Player.IsHuman) {
                foreach (Player player in players) {
                    
                }
            } else {
                foreach (Player player in players) {

                }
            }*/
        }
    }
}
