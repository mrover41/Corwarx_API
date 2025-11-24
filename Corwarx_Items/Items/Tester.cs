using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;


[Exiled.API.Features.Attributes.CustomItem(ItemType.GunCOM18)]
public class Component_Tester : CustomWeapon {
    public override string Description { get; set; } = "Инструмент для разработчика";
    public override float Weight { get; set; } = 2f;
    public override string Name { get; set; } = "Component_Tester";
    public override uint Id { get; set; } = 4970;
    public override ItemType Type { get; set; } = ItemType.GunCOM18;
    public override float Damage { get; set; } = 0;
    public override byte ClipSize { get; set; } = 250;

    protected override void SubscribeEvents() {
        base.SubscribeEvents();
        Exiled.Events.Handlers.Player.Shot += Wapon;
    }

    protected override void UnsubscribeEvents() {
        Exiled.Events.Handlers.Player.Shot -= Wapon;
        base.UnsubscribeEvents();
    }
    void Wapon(ShotEventArgs ev) {
        if (!Check(ev.Item)) {
            return;
        } if (ev.Target != null) {
            ev.CanHurt = false;
            Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 1.5f);
            Ragdoll.CreateAndSpawn(ev.Target.Role.Type, ev.Target.Nickname, "Душа покинула его убегая от парадоксов", ev.Target.Transform.position, ev.Target.Transform.rotation);
        } if (Physics.Linecast(ev.Player.CameraTransform.position, ev.RaycastHit.point, out RaycastHit raycastHit)) {
            Component[] componentsP = raycastHit.transform.GetComponentsInParent<Component>();
            Component[] componentsC = raycastHit.transform.GetComponentsInChildren<Component>();
            //DisplayCore displayCore = DisplayCore.Get(ev.Player.ReferenceHub);
            string cp = "<align=left><size=15>ComponentInParent\n", cc = "<align=right><size=15>ComponentsInChildren\n";

            foreach (Component component in componentsP) {
                cp += $"{component.GetType().Name}\n";
            }

            foreach (Component component in componentsC) {
                cc += $"{component.GetType().Name}\n";
            }

            Log.Info(cp);
            Log.Info("===============================");
            Log.Info(cc);

            //var elementReference_1 = new TimedElemRef<SetElement>();
            //displayCore.SetElemTemp(cp, 900, TimeSpan.FromSeconds(5), elementReference_1);

            //var elementReference_2 = new TimedElemRef<SetElement>();
            //displayCore.SetElemTemp(cc, 900, TimeSpan.FromSeconds(5), elementReference_2);
        }
    }


    public override SpawnProperties SpawnProperties { get; set; } = null;
}