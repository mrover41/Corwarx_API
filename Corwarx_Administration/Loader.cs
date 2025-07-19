using Corwarx_Project.Core;
using Corwarx_Project.Events.Handles;
using Corwarx_Project.Features.ModuleSystem.Manager;
using Exiled.API.Features;
using Exiled.Events;

namespace Corwarx_Administration {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public override string Name => "Corwarx_Administration";
        public Loader() => Instance = this;
        public override void OnEnabled() {
            Plugin.OnLoadPlugin(new Corwarx_Project.Events.Args.Plugin.LoadPluginEventArgs("Corwarx_Admin"));

            ModuleManager.RegisterModule(new Modules.WarnSystem());
            ModuleManager.RegisterModule(new Modules.WarnMessage());
            base.OnEnabled();
        }

        public override void OnDisabled() {
            base.OnDisabled();
        }
    }
}
