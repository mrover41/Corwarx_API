using Corwarx_Project.Features.HUDSystem.BaseClass;
using Corwarx_Project.Features.HUDSystem.Structures;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Corwarx_UI.Modules {
    internal class EventHUD : HudBase {
        public override float startPosition { get => 88; }

        public override float offset { get => 15; }

        private List<string> events = new List<string>();

        public override List<Player> GetPlayer() {
            return Player.List.Where(x => x.Role.Type.IsHuman() && !x.IsHost && !x.IsNPC).ToList();
        }

        public override void OnEnable() {
            Log.Info("PlayerHUD enabled");
            Exiled.Events.Handlers.Player.ChangingRole += HumanRole;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.ChangingRole -= HumanRole;
            base.OnDisable();
        }

        public override ListData UpdateHUD(Player player) {
            events.Clear();

            if (Round.IsLocked) {
                events.Add("◀🔒▶ Раунд заблокирован");
            }

            if (Warhead.LeverStatus) { 
                events.Add($"◀🔧▶ Статус Боеголовки: <color=#00ff00>Активированно</color>");
            }

            if (Warhead.IsInProgress) {
                events.Add($"(💣| Время до взрыва: <color=#ffffff>{Mathf.Round(Warhead.DetonationTimer)} сек.");
            }

            return new ListData {
                Hint = events,
                Align = Corwarx_Project.Features.HUDSystem.Enums.Align.right,
                AutoStile = false,
                OverrideColor = false,
                Size = 40,
                Hex = "",
            };
        }

        private void HumanRole(ChangingRoleEventArgs ev) {
            if ((ev.NewRole.IsHuman() || ev.NewRole.IsScp()) && !ev.Player.IsHost && !ev.Player.IsNPC) {
                Players.Add(ev.Player);
            } else if (!ev.Player.IsHost && !ev.Player.IsNPC) {
                ClearAll(ev.Player);
                Players.Remove(ev.Player);
            }
        }
    }
}
