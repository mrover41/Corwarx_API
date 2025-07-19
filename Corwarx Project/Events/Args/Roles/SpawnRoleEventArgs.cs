using Corwarx_Project.Features.RoleSystem.BaseClass;

namespace Corwarx_Project.Events.Args.Roles {
    public class SpawnRoleEventArg {
        public SpawnRoleEventArg(RoleBase role) {
            Role = role;
        }
        public RoleBase Role { get; set; }
    }
}
