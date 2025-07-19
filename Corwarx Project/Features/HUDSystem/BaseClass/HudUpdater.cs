using UnityEngine;
namespace Corwarx_Project.Features.HUDSystem.BaseClass {
    public abstract class HudUpdater {
        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
        public abstract void Tick();
    }
}
