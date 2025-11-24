using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using MEC;

namespace Corwarx_UI.Modules {
    [LoadModule]
    public class AddHUD : ModuleBase {
        public override string Name => "HUD";

        public override void OnEnable() {
            Timing.CallDelayed(1f, () => {
                //HudLoader.RegisterHUD(new PlayerHUD()); 
                //HudLoader.RegisterHUD(new EventHUD());
            });
            base.OnEnable();
        }
    }
}
