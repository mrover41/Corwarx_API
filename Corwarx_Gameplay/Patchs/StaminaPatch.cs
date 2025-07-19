using Exiled.API.Features;
using HarmonyLib;
using InventorySystem;

namespace Corwarx_Project.Patchs {
    [HarmonyPatch(typeof(Inventory), nameof(Inventory.StaminaUsageMultiplier), MethodType.Getter)]
    internal class StaminaUsageMultiplierPatch {
        public static bool Prefix(Inventory __instance, ref float __result) {
            if (Round.IsLobby) {
                __result = 0f;
                return false;
            }
            return true;
        }
    }
}
