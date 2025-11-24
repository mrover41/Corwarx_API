/*using Corwarx_Project.Features.HUDSystem.Structures;
using Exiled.API.Features;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Corwarx_Project.Features.HUDSystem.BaseClass {
    public abstract class HudBase : HudUpdater {
        public List<Player> Players;
        private Dictionary<Player, List<TimedElemRef<SetElement>>> timedElemRefs = new Dictionary<Player, List<TimedElemRef<SetElement>>>();
        private string hashCode;
        public abstract float startPosition { get; }
        public abstract float offset { get; }

        public override void OnEnable() {
            Players = GetPlayer();
            base.OnEnable();
        }

        public override void Tick() {
            //Log.Debug($"Tick {GetType().Name} with {Players.Count} players [BEGIN]");
            try { 
                foreach (Player player in Players) {
                    if (player == null) {
                        Players.Remove(player);
                        continue;
                    }
                    if (!timedElemRefs.ContainsKey(player)) timedElemRefs.Add(player, new List<TimedElemRef<SetElement>>());
                    ListData Hint = UpdateHUD(player);
                    if (Hint.Hint == null) continue;
                    string currentHashCode = string.Join("\n", Hint.Hint);
                    if (hashCode == currentHashCode) return;
                    if (player.ReferenceHub == null) continue;
                    DisplayCore displayCore = DisplayCore.Get(player.ReferenceHub);

                    foreach (TimedElemRef<SetElement> timedElemRef in timedElemRefs[player]) {
                        if (timedElemRef != null) {
                            displayCore.RemoveReference(timedElemRef);
                        }
                    }

                    timedElemRefs[player].Clear();

                    float currentOffset = startPosition;
                    foreach (string h in Hint.Hint) {
                        TimedElemRef<SetElement> timedElemRef = new TimedElemRef<SetElement>();
                        timedElemRefs[player].Add(timedElemRef);
                        displayCore.SetElementOrNew(timedElemRef, Hint.AutoStile ? $"<align={Hint.Align}><size={Hint.Size}><b><color={player.Role.Color.ToHex()}> {h} </b></size></color></align>" : h, currentOffset);
                        currentOffset -= offset;
                    }
                    displayCore.Update();
                    hashCode = currentHashCode;
                    //Log.Debug($"Updated HUD for {player.Nickname} with hash code {hashCode}");
                }
            } catch (System.Exception ex) {
                Log.Error($"Error updating HUD: {ex.Message}\n{ex.StackTrace}");
            }
            //Log.Debug($"Tick {GetType().Name} with {Players.Count} players");
        }

        public void ClearAll(Player player) {
            DisplayCore displayCore = DisplayCore.Get(player.ReferenceHub);
            foreach (TimedElemRef<SetElement> timedElemRef in timedElemRefs[player]) {
                if (timedElemRef != null) {
                    displayCore.RemoveReference(timedElemRef);
                }
            }
            displayCore.Update();
        }

        public override void OnDisable() {
            base.OnDisable();
        }

        public abstract ListData UpdateHUD(Player player);
        public abstract List<Player> GetPlayer();
    }
}
*/