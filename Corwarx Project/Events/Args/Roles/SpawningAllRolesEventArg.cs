namespace Corwarx_Project.Events.Args.Roles {
    public class SpawningAllRolesEventArg {
        public SpawningAllRolesEventArg() {
            IsAllowed = true;
        }
        public bool IsAllowed { get; set; }
    }
}
