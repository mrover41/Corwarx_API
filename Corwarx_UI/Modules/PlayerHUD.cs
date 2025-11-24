using Corwarx_Project.Features.HUDSystem.BaseClass;
using Corwarx_Project.Features.HUDSystem.Enums;
using Corwarx_Project.Features.HUDSystem.Structures;
using Corwarx_Project.Features.RoleSystem.Manager;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp079;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Corwarx_UI.Modules {
    public class PlayerHUD : HudBase {
        public override float startPosition { get => 88; }
        public override float offset { get => 15; }

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
            if (Round.IsLobby) {
                ListData data = new ListData(
                    new List<string> {
                    $"◀✅▶ До начала раунда: {(Round.LobbyWaitingTime == -2 ? "Locked" : Round.LobbyWaitingTime.ToString())}",
                },
                true,
                false,
                Align.center,
                40,
                ""
                );
                return data;
            }
            //Log.Debug($"Updating HUD for player {player.Nickname} ({player.UserId})");
            ListData listData = new ListData(
                new List<string> {
                    $"            ◀✅▶ Имя: {player.Nickname}",
                    $"            ◀🚶▶ Роль: {player.Role.Type.GetFullName()}",
                    $"            ◀🙍‍▶ Союзников: {Player.List.Count(x => x.LeadingTeam == player.LeadingTeam && x != player)}",
                    $"            ◀🌐▶ Всего игроков: {Player.List.Count}",
                    $"            ◀🌠▶ Активированно генераторов: {Scp079Recontainer.AllGenerators.Count(x => x.Engaged)}"
                },
                true,
                false,
                Align.left,
                15,
                ""
            );
            if (Warhead.IsInProgress) {
                listData.Hint.Add($"            (💣| Время до взрыва: <color=#ffffff>{Mathf.Round(Warhead.DetonationTimer)} сек.");
            } if (player.GetRoleDescription() != string.Empty) {
                listData.Hint.Add($"            ◀🚶▶ Описание: {player.GetRoleDescription()}");
            }

            return listData;
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
