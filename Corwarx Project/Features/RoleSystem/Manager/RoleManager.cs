using Exiled.API.Features;
using System.Collections.Generic;
using System.Linq;
using Corwarx_Project.Events.Handles;
using Corwarx_Project.Features.RoleSystem.BaseClass;

namespace Corwarx_Project.Features.RoleSystem.Manager {
    public static class RoleManager {
        public static List<BaseClass.RoleBase> AllowedRoles { get; private set; } = new List<BaseClass.RoleBase>();
        public static Dictionary<Exiled.API.Features.Player, RoleBase> SpawnedRoles { get; private set; } = new Dictionary<Exiled.API.Features.Player, RoleBase>();
        public static Dictionary<Exiled.API.Features.Player, RoleBase> AssignRoles { get; private set; } = new Dictionary<Exiled.API.Features.Player, RoleBase>();
        private static Dictionary<Exiled.API.Features.Player, string> PlayerDescription = new Dictionary<Exiled.API.Features.Player, string>();

        public static void AddRole(this Exiled.API.Features.Player player, uint ID) { 
            RoleBase role = AllowedRoles.Where(x => x.Id == ID).FirstOrDefault();
            if (role == null) return;
            role.players.Add(player);
            AssignRoles.Add(player, role);
        }

        public static void RemoveRole(this Exiled.API.Features.Player player, uint ID)  {
            BaseClass.RoleBase role = AllowedRoles.Where(x => x.Id == ID).FirstOrDefault();
            if (role != null) {
                role.players.Remove(player);
                if (SpawnedRoles.ContainsKey(player)) {
                    SpawnedRoles.Remove(player);
                    AssignRoles.Remove(player);
                }
                if (PlayerDescription.ContainsKey(player)) {
                    PlayerDescription.Remove(player);
                }
            }
        }

        public static void SpawnRole(this Exiled.API.Features.Player player, uint ID) {
            BaseClass.RoleBase role = AllowedRoles.Where(x => x.Id == ID).FirstOrDefault();
            if (role != null) {
                if (!Roles.OnSpawningRole(new Events.Args.Roles.SpawningRoleEventArg(role)).IsAllowed) return;
                if (!role.players.Contains(player)) return;
                PlayerDescription.Add(player, role.Description);
                role.Spawn(player);
                SpawnedRoles.Add(player, role);
                Roles.OnSpawnRole(new Events.Args.Roles.SpawnRoleEventArg(role));
            }
        }

        public static void SpawnRole(this Exiled.API.Features.Player player, RoleBase role) {
            if (role != null) {
                if (!AllowedRoles.Contains(role)) return;
                if (!Roles.OnSpawningRole(new Events.Args.Roles.SpawningRoleEventArg(role)).IsAllowed) return;
                if (!role.players.Contains(player)) return;
                role.Spawn(player);
                SpawnedRoles.Add(player, role);
                PlayerDescription.Add(player, role.Description);
                Roles.OnSpawnRole(new Events.Args.Roles.SpawnRoleEventArg(role));
            }
        }

        public static void SpawnAllRoles() {
            if (!Roles.OnSpawningAllRoles(new Events.Args.Roles.SpawningAllRolesEventArg()).IsAllowed) return;
            foreach (Exiled.API.Features.Player pl in AssignRoles.Keys) {
                BaseClass.RoleBase role = AssignRoles[pl];
                foreach (Exiled.API.Features.Player player in role.players) {
                    if (player != null && player.IsAlive) {
                        role.Spawn(player);
                        Log.Debug($"Role {role.Name} with ID {role.Id} spawned for player {player.Nickname}.");
                    } else {
                        Log.Error($"Player {player?.Nickname ?? "null"} is not alive or does not exist, skipping spawn for role {role.Name}.");
                    }
                }
            }
            Roles.OnSpawnAllRoles(new Events.Args.Roles.SpawnAllRolesEventArg());
        }

        public static void RegisterRole(BaseClass.RoleBase role) {
            if (role != null && !AllowedRoles.Contains(role)) {
                AllowedRoles.Add(role);
                role.OnEnable();
                Log.Debug($"Role {role.Name} with ID {role.Id} registered.");
            } else {
                Log.Error($"Role {role.Name} with ID {role.Id} is null or already registered.");
            }
        }

        public static void UnregisterRole(BaseClass.RoleBase role)   {
            if (role != null && AllowedRoles.Contains(role)) {
                role.OnDisable();
                AllowedRoles.Remove(role);
                Log.Debug($"Role {role.Name} with ID {role.Id} unregistered.");
            } else {
                Log.Error($"Role {role.Name} with ID {role.Id} is null or not registered.");
            }
        }

        public static void UnregisterAllRoles() {
            foreach (BaseClass.RoleBase role in AllowedRoles) {
                role.OnDisable();
                Log.Debug($"Role {role.Name} with ID {role.Id} unregistered.");
            }
            AllowedRoles.Clear();
        }

        public static RoleBase GetRole(int ID) {
            return AllowedRoles.Find(x => x.Id == ID);
        }

        public static bool TryGetRoleBase(this Exiled.API.Features.Player player, out RoleBase roleBase) {
            SpawnedRoles.TryGetValue(player, out RoleBase role);
            roleBase = role;
            return role != null;
        }

        public static string GetRoleDescription(this Exiled.API.Features.Player player) { 
            return PlayerDescription.TryGetValue(player, out string description) ? description : string.Empty;
        }

        public static RoleBase GetSpawnedRole(this Exiled.API.Features.Player player) {
            return SpawnedRoles.TryGetValue(player, out RoleBase role) ? role : null;
        }
        
        public static RoleBase GetAssignRole(this Exiled.API.Features.Player player) {
            return AssignRoles.TryGetValue(player, out RoleBase role) ? role : null;
        }
    }
}
