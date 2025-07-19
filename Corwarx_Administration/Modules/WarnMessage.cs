using Corwarx_Project.Events.Args.Administration;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Features;

namespace Corwarx_Administration.Modules {
    internal class WarnMessage : ModuleBase {
        public override string Name => "Warn message";

        public override void OnEnable() {
            Corwarx_Project.Events.Handles.Administration.AddWarnEvent += OnWarnAdded;
            base.OnEnable();
        }

        public override void OnDisable() {
            Corwarx_Project.Events.Handles.Administration.AddWarnEvent -= OnWarnAdded;
            base.OnDisable();
        }

        void OnWarnAdded(AddWarnEventArg ev) {
            Player player = Player.Get(ev.PlayerID);
            player.Broadcast(5, $"<color=#ff0000>Вам выданно предупреждение по причине:<color=#ff7700><b> {ev.Message}</b></color>");
        }
    }
}
