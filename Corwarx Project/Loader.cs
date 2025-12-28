using Corwarx_Project.Features.ModuleSystem.Manager;
using Exiled.API.Features;
using HarmonyLib;
using System.Reflection;
using Plugin = Corwarx_Project.Events.Handles.Plugin;

namespace Corwarx_Project.Core {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;
        public string PluginName => typeof(Loader).Namespace;

        internal static Harmony _harmony;
        internal EventHandler EventHandler = new EventHandler();

        public override void OnEnabled() {
            Plugin.OnLoadPlugin(new Events.Args.Plugin.LoadPluginEventArgs(PluginName));
            _harmony = new Harmony("com.corwarx.core");
            _harmony.PatchAll();

            RegisterEvents(); 

            ModuleManager.RegisterModules(Assembly.GetExecutingAssembly());

            //RueI.RueIMain.EnsureInit();

            Log.Send("\n Plugin CORWAX CORE is running!\n Creator: Mr_Over41\n Made for: Me :3\n oo-ee-oo", Discord.LogLevel.Info, System.ConsoleColor.Yellow);
            Log.Info($"Plugin {PluginName} started");
            base.OnEnabled();
        }

        public override void OnDisabled() {
            _harmony.UnpatchAll();
            ModuleManager.DisableAllModules();
            UnRegisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents() {
            EventHandler.RegisterEvents();
            Exiled.Events.Handlers.Player.Verified += EventHandler.OnPlayerVerifed;
        }

        private void UnRegisterEvents() {
            EventHandler.UnRegisterEvents();
            Exiled.Events.Handlers.Player.Verified -= EventHandler.OnPlayerVerifed;
        }
    }
}
