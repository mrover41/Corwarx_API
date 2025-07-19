using Corwarx_Project.Features.Components.SCP049Components;
using Exiled.API.Features;
using PlayerRoles;

namespace Corwarx_Project.Extensions {
    public static class SCP049Extensions {
        public static SCP049Component GetSCP049Component(this Player player) {
            if (player.Role != RoleTypeId.Scp049) return null;
            if (player.GameObject.TryGetComponent(out SCP049Component obj))
                return obj;
            return null;
        }
    }
}
