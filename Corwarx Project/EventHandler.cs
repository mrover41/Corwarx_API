using Corwarx_Project.Events.Args.Administration;
using Corwarx_Project.Events.Args.Modules;
using Corwarx_Project.Events.Args.Plugin;
using Corwarx_Project.Events.Args.Roles;
using Corwarx_Project.Events.Handles;
using Corwarx_Project.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace Corwarx_Project {
    internal class EventHandler {
        public void OnPlayerVerifed(VerifiedEventArgs ev) {
            Log.Debug($"Connected: {ev.Player.ToShortString()}");
        }

        public void RegisterEvents() {
            Roles.SpawnAllRoles += OnSpawnAllRoles;
            Roles.SpawnRole += OnSpawnRole;

            Plugin.LoadPlugin += OnLodadPlugin;
            Plugin.UnLoadPlugin += OnUnLoadPlugin;

            Module.RegModuleEvent += OnRegModule;
            Module.EnabledModuleEvent += OnEnabledModule;
            Module.DisableModuleEvent += OnDisableModule;
            Module.UnregisterModuleEvent += OnUnregisterModule;

            Administration.AddWarnEvent += OnAddWarn;
        }

        public void UnRegisterEvents() {
            Roles.SpawnAllRoles -= OnSpawnAllRoles;
            Roles.SpawnRole -= OnSpawnRole;

            Plugin.LoadPlugin -= OnLodadPlugin;
            Plugin.UnLoadPlugin -= OnUnLoadPlugin;

            Module.RegModuleEvent -= OnRegModule;
            Module.EnabledModuleEvent -= OnEnabledModule;
            Module.DisableModuleEvent -= OnDisableModule;
            Module.UnregisterModuleEvent -= OnUnregisterModule;

            Administration.AddWarnEvent -= OnAddWarn;
        }

        private void OnSpawnAllRoles(SpawnAllRolesEventArg ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Spawning all roles");
        }

        private void OnSpawnRole(SpawnRoleEventArg ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Spawning role: {ev.Role.Name}");
        }

        private void OnLodadPlugin(LoadPluginEventArgs ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Loading plugin: {ev.Name}");
        }

        private void OnUnLoadPlugin(UnLoadPluginEventArgs ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Unloading plugin: {ev.Name}");
        }

        private void OnRegModule(RegModuleEventArg ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Registering module: {ev.Module.Name}");
        }

        private void OnEnabledModule(EnabledModuleEventArg ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Enabled module: {ev.Module.Name}");
        }

        private void OnDisableModule(DisableModuleEventArg ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Disabling module: {ev.Module.Name}");
        }

        private void OnUnregisterModule(UnregisterModuleEventArg ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Unregistering module: {ev.Module.Name}");
        }

        private void OnAddWarn(AddWarnEventArg ev) {
            Log.Debug("===EVENT===");
            Log.Debug($"Adding warn: {ev.Message} to player: {ev.PlayerID} / {ev.SteamID}");
        }
    }
}
