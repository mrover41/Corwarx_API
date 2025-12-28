using Exiled.CustomRoles.API.Features;
using PlayerRoles;

namespace Corwarx_Project.Features.RoleSystem.BaseClass {
    public abstract class RoleBase : CustomRole {
        virtual public Team Team { get; private set; }
    }
}
