/*namespace Corwarx_Project.Patchs {
    [HarmonyPatch(typeof(NineTailedFoxAnnouncer), nameof(NineTailedFoxAnnouncer.AnnounceScpTermination))]
    internal class ScpCassiePatch {
        private static bool Prefix(ReferenceHub scp, DamageHandlerBase hit) {
            Player.TryGet(scp, out Player ply);
            if (ply.IsNPC) {
                return false;
            }
            return true;
        }
    }
}*/
