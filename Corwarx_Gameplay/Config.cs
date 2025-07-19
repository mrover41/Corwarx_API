using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Corwarx_Gameplay {
    public class Config : IConfig {
        [Description("Plugin Config")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        [Description("Bleeding Config")]
        public uint Damage { get; set; } = 10;
        public uint BleedingTime { get; set; } = 10;
        public uint CriticalDamage { get; set; } = 5;
        public string Message { get; set; } = "You are bleeding!";
        public string BrotcastMessage { get; set; } = "You are bleeding!";
        [Description("Lobby config")]
        public float x, y, z;
    }
}
