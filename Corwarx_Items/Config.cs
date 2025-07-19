using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Corwarx_Items {
    public class Config : IConfig {
        [Description("Plugin config")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        [Description("SCP049Cuffer config")]
        public float SCP049CufferDistance { get; set; } = 2f;

        [Description("Tactical armor config")]
        public string TacticalArmorSchematic { get; set; } = "Напишите полный путь к схематике вместо этого текста";
        public string TacticalArmorSchematicName { get; set; } = "tactical_armor";
        public float px { get; set; } = 0;
        public float py { get; set; } = 0;
        public float pz { get; set; } = 0;
        public float rx { get; set; } = 0;
        public float ry { get; set; } = 0;
        public float rz { get; set; } = 0;
    }
}
