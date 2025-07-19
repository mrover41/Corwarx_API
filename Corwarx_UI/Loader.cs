using Exiled.API.Features;
using Corwarx_Project.Events.Args.Plugin;

namespace Corwarx_UI {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;
        public override void OnEnabled() {
            Corwarx_Project.Events.Handles.Plugin.OnLoadPlugin(new LoadPluginEventArgs("Corwarx_UI"));
            base.OnEnabled();
        }

        public override void OnDisabled() {
            base.OnDisabled();
        }
    }
}
