using Corwarx_Project.Features.RoleSystem.BaseClass;

namespace Corwarx_Project.Events.Args.Roles {
    public class SpawningRoleEventArg {
        public SpawningRoleEventArg(RoleBase role) {
            Role = role;
            IsAllowed = true;
        }
        public RoleBase Role { get; set; }
        public bool IsAllowed { get; set; } = true;
    }
}
