using Exiled.API.Features;
using Corwarx_Project.Features.RoleSystem.Manager;
using Corwarx_Project.Roles;
using Corwarx_Project.Features.ModuleSystem.Manager;
using Corwarx_Project.Modules;
using Exiled.Events;
using Corwarx_Project.Events.Handles;

namespace Corwarx_Roles {
    public class Loader : Plugin<Config> {
        public override void OnEnabled() {
            Plugin.OnLoadPlugin(new Corwarx_Project.Events.Args.Plugin.LoadPluginEventArgs("Corwarx_Gameplay"));

            RoleManager.RegisterRole(new SCP_966());
            RoleManager.RegisterRole(new SCP_939_2());
            ModuleManager.RegisterModule(new SpawnRoles());

            Log.Info("Corwarx_Roles plugin has been enabled and test role registered.");
            base.OnEnabled();
        }

        override public void OnDisabled() {
            RoleManager.UnregisterAllRoles();
            base.OnDisabled();
        }

        /*void AddTestRole() {
            foreach (Player player in Player.List) {
                RoleManager.AddRole(Player.List.First(), 1);
            }
            RoleManager.SpawnAllRoles();
        }*/
    }
}
