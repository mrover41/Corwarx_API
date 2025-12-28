using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using MEC;
using UnityEngine;

namespace Corwarx_Project.Features.UpdateInjector {
    [LoadModule]
    internal class UpdateInitModule : ModuleBase {
        public override string Name => nameof(UpdateInitModule);

        public override void OnEnable() {
            Timing.CallDelayed(1, () => { new GameObject("Updater").AddComponent<Updater>().Init(); });
            base.OnEnable();
        }

        public override void OnDisable() {
            base.OnDisable();
        }
    }
}
