using Corwarx_Project.Extensions;
using Corwarx_Project.Features.Components.SCP049Components;
using CustomItems.API;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace Corwarx_Items.Items {
    [CustomItem(ItemType.Medkit)]
    internal class SCP049Cuffer : Exiled.CustomItems.API.Features.CustomItem {
        public override string Name { get; set; } = "SCP-049 Cuffer";
        public override string Description { get; set; } = "An item used to cuff SCP-049.";
        public override uint Id { get; set; } = 2;
        public override float Weight { get; set; } = 5;
        public override SpawnProperties SpawnProperties { get; set; } = null;
        public override ItemType Type { get; set; } = ItemType.Medkit;

        protected override void SubscribeEvents() {
            Log.Debug($"SCP049Cuffer: Subscribing to UsingItem event for {Name} ({Id})");
            Exiled.Events.Handlers.Player.UsingItem += OnUsing;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents() {
            Log.Debug($"SCP049Cuffer: Unsubscribing from UsingItem event for {Name} ({Id})");
            Exiled.Events.Handlers.Player.UsingItem -= OnUsing;
            base.UnsubscribeEvents();
        }

        private void OnUsing(UsingItemEventArgs ev) {
            if (!Check(ev.Item)) return;
            Player player = ev.Player.GetFromView(Loader.Instance.Config.SCP049CufferDistance);
            Log.Debug($"SCP049Cuffer: {ev.Player.Nickname} ({ev.Player.UserId}) is using SCP049 Cuffer on {player?.Nickname} ({player?.UserId})");
            if (player is null) return;
            if (player.Role.Type != RoleTypeId.Scp049) return;
            SCP049Component scp049 = player.GetSCP049Component();
            scp049.Stats = Corwarx_Project.Enums.SCP049Stats.Cuffed;
            ev.IsAllowed = false;
            Log.Debug($"SCP049Cuffer: {ev.Player.Nickname} ({ev.Player.UserId}) has cuffed {player.Nickname} ({player.UserId}) with SCP049 Cuffer.");
        }
    }
}
