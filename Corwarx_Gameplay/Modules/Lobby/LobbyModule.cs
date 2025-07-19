using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System.Linq;
using UnityEngine;

namespace Corwarx_Gameplay.Modules.Lobby {
    internal class LobbyModule : ModuleBase {
        public override string Name => "Lobby";

        public override void OnEnable() {
            //Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.Verified += OnVerified;
            base.OnEnable();
        }

        public override void OnDisable() {
            //Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.Verified -= OnVerified;
            base.OnDisable();
        }

        private void OnWaitingForPlayers() {
            GameObject.Find("StartRound").transform.localScale = Vector3.zero;
        }

        private void OnVerified(VerifiedEventArgs ev) {
            if (!Round.IsLobby) return;
            ev.Player.Role.Set(RoleTypeId.Tutorial);
            ev.Player.Position = Room.List.First(x => x.Type == RoomType.EzIntercom).Position + 
                new Vector3(Loader.Instance.Config.x, Loader.Instance.Config.y, Loader.Instance.Config.z);
        }

        private void OnRoundStarted() {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        }
    }
}
