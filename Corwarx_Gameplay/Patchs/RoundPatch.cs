using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles;

namespace Corwarx_Gameplay.Patchs {
    [HarmonyPatch(typeof(CharacterClassManager), nameof(CharacterClassManager.ForceRoundStart))]
    internal static class RoundStartPatch {
        [HarmonyPrefix]
        private static bool Prefix() {
            foreach (Player player in Player.List) {
                player.Role.Set(RoleTypeId.None);
            }
            return true;
        }
    }
}