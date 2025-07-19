using Corwarx_Project.Events.Args.Roles;
using System;

namespace Corwarx_Project.Events.Handles {
    public static class Roles {
        public static event Action<SpawningRoleEventArg> SpawningRole;
        public static event Action<SpawnRoleEventArg> SpawnRole;
        public static event Action<SpawningAllRolesEventArg> SpawningAllRoles;
        public static event Action<SpawnAllRolesEventArg> SpawnAllRoles;

        public static SpawningAllRolesEventArg OnSpawningAllRoles(SpawningAllRolesEventArg args) {
            SpawningAllRoles?.Invoke(args);
            return args;
        }
        public static SpawnAllRolesEventArg OnSpawnAllRoles(SpawnAllRolesEventArg args) {
            SpawnAllRoles?.Invoke(args);
            return args;
        }
        public static SpawningRoleEventArg OnSpawningRole(SpawningRoleEventArg args) {
            SpawningRole?.Invoke(args);
            return args;
        }
        public static SpawnRoleEventArg OnSpawnRole(SpawnRoleEventArg args) {
            SpawnRole?.Invoke(args);
            return args;
        }
    }
}
