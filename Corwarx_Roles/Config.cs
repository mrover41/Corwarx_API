using Exiled.API.Interfaces;

namespace Corwarx_Roles {
    public class Config : IConfig {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
    }
}
