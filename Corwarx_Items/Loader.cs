using Corwarx_Items.Items;
using Corwarx_Project.Events.Handles;
using Exiled.API.Features;

namespace Corwarx_Items {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;

        public override void OnEnabled() {
            Plugin.OnLoadPlugin(new Corwarx_Project.Events.Args.Plugin.LoadPluginEventArgs("Corwarx_Items"));
            Trangulizer.RegisterItems();
            base.OnEnabled();
        }

        public override void OnDisabled() {
            Trangulizer.UnregisterItems();
            base.OnDisabled();
        }
    }
}
