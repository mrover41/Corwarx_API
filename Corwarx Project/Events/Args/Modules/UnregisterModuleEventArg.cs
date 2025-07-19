using Corwarx_Project.Features.ModuleSystem.BaseClass;

namespace Corwarx_Project.Events.Args.Modules {
    public class UnregisterModuleEventArg {
        public UnregisterModuleEventArg(ModuleBase module) {
            Module = module;
        }

        public ModuleBase Module { get; private set; }
    }
}
