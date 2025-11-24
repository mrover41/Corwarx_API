using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.Manager;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace Corwarx_Project.Modules {
    [LoadModule]
    internal class SpawnRoles : ModuleBase {
        public override string Name => "Role spawner";

        public override void OnEnable() {
            Exiled.Events.Handlers.Player.Verified += OnVerified;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.Verified -= OnVerified;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            base.OnDisable();
        }

        private void OnVerified(VerifiedEventArgs ev) { 
            if (Round.IsStarted) return;
            if (RoleManager.AssignRoles.ContainsValue(RoleManager.GetRole(2))) return;
            ev.Player.AddRole(2);
        }

        private void OnRoundStarted() {
            RoleManager.SpawnAllRoles();
        }
    }
}
