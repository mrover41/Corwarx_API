using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;

namespace Corwarx_Administration.Modules {
    [LoadModule]
    internal class WarnSystem : ModuleBase {
        public override string Name => "Warn system";

        public override void OnEnable() {
            base.OnEnable();
        }

        public override void OnDisable() {
            base.OnDisable();
        }
    }
}
