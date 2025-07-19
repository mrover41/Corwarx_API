using Exiled.API.Features;
using System.Collections.Generic;

namespace Corwarx_Project.Features.RoleSystem.BaseClass {
    public abstract class RoleBase {
        abstract public string Name { get; set; }
        abstract public string Description { get; set; }
        abstract public uint Id { get; set; }
        public List<Player> players { get; set; } = new List<Player>();

        virtual public void Spawn(Player player) => Log.Debug($"Role {Name} with ID {Id} spawned.");
        virtual public void OnEnable() => Log.Debug($"Role {Name} with ID {Id} enabled.");
        virtual public void OnDisable() => Log.Debug($"Role {Name} with ID {Id} disabled.");
    }
}
