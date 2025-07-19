using System;

namespace Corwarx_Project.Events.Handles {
    public static class Plugin {
        public static event Action<Args.Plugin.LoadPluginEventArgs> LoadPlugin;
        public static event Action<Args.Plugin.UnLoadPluginEventArgs> UnLoadPlugin;
        public static Args.Plugin.LoadPluginEventArgs OnLoadPlugin(Args.Plugin.LoadPluginEventArgs args) {
            LoadPlugin?.Invoke(args);
            return args;
        }
        public static Args.Plugin.UnLoadPluginEventArgs OnUnLoadPlugin(Args.Plugin.UnLoadPluginEventArgs args) {
            UnLoadPlugin?.Invoke(args);
            return args;
        }
    }
}
