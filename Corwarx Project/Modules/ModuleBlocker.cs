/*using Corwarx_Project.Core;
using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Events.Args.Modules;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Features;

namespace Corwarx_Project.Modules {
    [LoadModule]
    internal class ModuleBlocker : ModuleBase {
        public override string Name => "Module Blocker";

        public override void OnEnable() {
            Corwarx_Project.Events.Handles.Module.EnableModuleEvent += OnModuleEnable;
            base.OnEnable();
        }

        public override void OnDisable() {
            Corwarx_Project.Events.Handles.Module.EnableModuleEvent -= OnModuleEnable;
            base.OnDisable();
        }

        private void OnModuleEnable(EnableModuleEventArg ev) {
            if (!Loader.Instance.Config.BlackListModules.Contains(ev.Module.Name)) return;
            if (!Loader.Instance.Config.BlackListModulesNameof.Contains(nameof(ev.Module))) return;
            ev.IsAllowed = false;

            Log.Debug($"Module {ev.Module.Name} is blocked from being enabled by the Module System.");
        }
    }
}
*/