using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace Corwarx_Gameplay.Modules.Player {
    internal class Bleeding : ModuleBase {
        public override string Name => "Bleeding";

        override public void OnEnable() {
            Exiled.Events.Handlers.Player.Hurt += OnDamage;
            base.OnEnable();
        }

        override public void OnDisable() {
            Exiled.Events.Handlers.Player.Hurt -= OnDamage;
            base.OnDisable();
        }

        void OnDamage(HurtEventArgs ev) {
            if (!ev.DamageHandler.Type.IsWeapon() || ev.Player.IsScp) return;
            if (ev.DamageHandler.Damage >= Loader.Instance.Config.CriticalDamage) { 
                Timing.RunCoroutine(Updater(ev.Player));
            }
        }
        
        IEnumerator<float> Updater(Exiled.API.Features.Player player) {
            float seconds = Time.time;
            player.Broadcast(5, Loader.Instance.Config.BrotcastMessage);
            for (; ; ) {
                if (Time.time - seconds >= Loader.Instance.Config.BleedingTime) yield break;
                player.Hurt(Loader.Instance.Config.Damage, Loader.Instance.Config.Message);
                yield return Timing.WaitForSeconds(1);
            }
        }
    }
}
