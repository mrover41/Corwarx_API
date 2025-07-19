using Exiled.API.Interfaces;

namespace Corwarx_UI {
    public class Config : IConfig {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
    }
}
