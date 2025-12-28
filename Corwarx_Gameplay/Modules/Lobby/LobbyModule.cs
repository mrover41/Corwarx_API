using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using UnityEngine;

namespace Corwarx_Gameplay.Modules.Lobby {
    [LoadModule]
    internal class LobbyModule : ModuleBase {
        public override void OnEnable() {
            Log.Info("Module");

            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.Verified += OnVerified;
            base.OnEnable();
        }
        
        public override void OnDisable() {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.Verified -= OnVerified;
            base.OnDisable();
        }

        private void OnWaitingForPlayers() {
            GameObject.Find("StartRound").transform.localScale = Vector3.zero;
        }

        private void OnVerified(VerifiedEventArgs ev) {
            if (!Round.IsLobby) 
                return;
            ev.Player.Role.Set(RoleTypeId.Tutorial);
            ev.Player.Teleport(RoomType.EzIntercom);
        }

        private void OnRoundStarted() {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        }
    }
}
