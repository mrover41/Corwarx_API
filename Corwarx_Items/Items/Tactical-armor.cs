/*using Exiled.API.Features.Spawn;
using Exiled.API.Features;
using System.Collections.Generic;

namespace Corwarx_Items.Items {
    internal class Tactical_armor : Exiled.CustomItems.API.Features.CustomItem {
        public override uint Id { get; set; } = 1;
        public override string Name { get; set; } = "Tactical Armor";
        public override string Description { get; set; } = "A tactical armor that provides protection against various threats.";
        public override float Weight { get; set; } = 50;
        public override SpawnProperties SpawnProperties { get; set; } = null;

        MapEditorReborn.API.Features.Objects.SchematicObject schematic = null;
        List<Player> players = new List<Player>();

        protected override void SubscribeEvents() {
            Exiled.Events.Handlers.Player.ChangedItem += OnSelect;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents() {
            Exiled.Events.Handlers.Player.ChangedItem -= OnSelect;
            base.UnsubscribeEvents();
        }

        private void OnSelect(Exiled.Events.EventArgs.Player.ChangedItemEventArgs ev) {
            if (Check(ev.Item)) {
                players.Add(ev.Player);
                if (schematic != null) return;
                MapEditorReborn.API.Features.Serializable.SchematicObjectDataList t = new MapEditorReborn.API.Features.Serializable.SchematicObjectDataList();
                t.Path = Loader.Instance.Config.TacticalArmorSchematic;
                schematic =
                MapEditorReborn.API.Features.ObjectSpawner.SpawnSchematic(
                    Loader.Instance.Config.TacticalArmorSchematicName,
                    ev.Player.Position,
                    ev.Player.Rotation,
                    new UnityEngine.Vector3(1, 1, 1),
                    t
                );
                schematic.gameObject.transform.SetParent(ev.Player.GameObject.transform, true);
                schematic.gameObject.transform.localPosition = new UnityEngine.Vector3(
                    Loader.Instance.Config.px,
                    Loader.Instance.Config.py,
                    Loader.Instance.Config.pz
                );
                schematic.gameObject.transform.localRotation = UnityEngine.Quaternion.Euler(
                    Loader.Instance.Config.rx,
                    Loader.Instance.Config.ry,
                    Loader.Instance.Config.rz
                );
            } else if (schematic != null && players.Contains(ev.Player)) {
                schematic.Destroy();
                schematic = null;
                players.Remove(ev.Player);
            }
        }
    }
}
*/