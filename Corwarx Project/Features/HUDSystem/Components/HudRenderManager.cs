using Corwarx_Project.Features.HUDSystem.BaseClass;
using MEC;
using System.Collections.Generic;

namespace Corwarx_Project.Features.HUDSystem.Components {
    public static class HudLoader {
        public static void RegisterHUD(HudUpdater hudUpdater) { 
            hudUpdater.OnEnable();
            Timing.RunCoroutine(enumerator(hudUpdater));
        }

        static IEnumerator<float> enumerator(HudUpdater hudUpdater) { 
            for (; ; ) { 
                hudUpdater.Tick();
                yield return Timing.WaitForOneFrame; 
            } 
        }
    }
}
