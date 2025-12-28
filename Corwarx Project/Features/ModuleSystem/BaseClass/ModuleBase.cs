using Exiled.API.Features;

namespace Corwarx_Project.Features.ModuleSystem.BaseClass {
    public abstract class ModuleBase {
        public virtual string Name { get; }
        public virtual int Id { get; internal set; } = -1;
        public virtual string Description { get; } = "No description provided.";
        public bool IsEnabled { get; internal set; } = false;

        protected ModuleBase() {
            if(Name == null || Name.IsEmpty())
                Name = GetType().Name;
        }
        
        public virtual void OnEnable() => Log.Debug($"Module {Name} with ID {Id} enabled.");
        public virtual void OnDisable() => Log.Debug($"Module {Name} with ID {Id} disabled.");
    }
}
