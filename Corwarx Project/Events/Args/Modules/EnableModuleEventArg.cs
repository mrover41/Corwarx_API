using Corwarx_Project.Features.ModuleSystem.BaseClass;

namespace Corwarx_Project.Events.Args.Modules {
    public class EnableModuleEventArg {
        public EnableModuleEventArg(ModuleBase module) {
            Module = module;
            IsAllowed = true;
        }
        public ModuleBase Module { get; private set; }
        public bool IsAllowed { get; set; }
    }
}
