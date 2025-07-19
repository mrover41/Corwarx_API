using Corwarx_Project.Features.ModuleSystem.Manager;
using Corwarx_Project.Features.RoleSystem.Manager;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using HarmonyLib;
using Plugin = Corwarx_Project.Events.Handles.Plugin;

namespace Corwarx_Project.Core {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;
        public string PluginName => typeof(Loader).Namespace;
        internal static Harmony _harmony;
        internal EventHandler EventHandler = new EventHandler();

        public override void OnEnabled() {
            Exiled.Events.Handlers.Player.Left += OnDisconnect;

            Plugin.OnLoadPlugin(new Events.Args.Plugin.LoadPluginEventArgs(PluginName));
            _harmony = new Harmony("com.corwarx.core");
            _harmony.PatchAll();
            ModuleManager.RegisterModule(new Modules.MonoLoad());
            ModuleManager.RegisterModule(new Modules.AddHUD());

            RueI.RueIMain.EnsureInit();

            Log.Warn("\n Plugin CORWAX CORE is running! \n Creator: Mr_Over41 \n Made for: Corwax \n oo-ee-oo");
            Log.Info($"Plugin {PluginName} started");
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled() {
            Exiled.Events.Handlers.Player.Left -= OnDisconnect;

            _harmony.UnpatchAll();
            ModuleManager.DisableAllModules();
            UnRegisterEvents();
            base.OnDisabled();
        }

        private void OnDisconnect(LeftEventArgs ev) { 
            if (!ev.Player.TryGetRoleBase(out Features.RoleSystem.BaseClass.RoleBase roleBase) || roleBase == null) return;
            RoleManager.RemoveRole(ev.Player, roleBase.Id);
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
