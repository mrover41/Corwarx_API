using Corwarx_Project.Features.HUDSystem.Components;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using MEC;

namespace Corwarx_UI.Modules {
    public class AddHUD : ModuleBase {
        public override string Name => "HUD";

        public override void OnEnable() {
            Timing.CallDelayed(1f, () => {
                HudLoader.RegisterHUD(new PlayerHUD()); 
                HudLoader.RegisterHUD(new EventHUD());
            });
            base.OnEnable();
        }
    }
}
