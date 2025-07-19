using Exiled.API.Features;
using HarmonyLib;
using UnityEngine;

namespace Corwarx_Gameplay.Patchs {
    [HarmonyPatch(typeof(PlayerRoles.Voice.Intercom), nameof(PlayerRoles.Voice.Intercom.Update))]
    internal static class IntercomPatch {
        [HarmonyPrefix]
        private static bool OnUpdate(PlayerRoles.Voice.Intercom __instance) {
            if (!Round.IsLobby) return true;
            Exiled.API.Features.Intercom.DisplayText = $"<size=200><color=#{HColor(0.5f)}> ◀✅▶ До начала раунда: {(Round.LobbyWaitingTime == -2 ? "неизвестно" : Round.LobbyWaitingTime.ToString())}\n" +
                $"Количество игроков: {Player.List.Count} </color></size>";
            return true;
        }

        private static string HColor(float speed, bool pingPong = false) {
            float t = Mathf.PingPong(Time.time * speed, 1f);

            Color startColor = Color.red;
            Color endColor = Color.blue;

            Color lerpedColor;
            if (pingPong) {
                lerpedColor = Color.Lerp(startColor, endColor, t); 
            } else {
                lerpedColor = HSVLerp(Time.time * speed);
            }

            return ColorUtility.ToHtmlStringRGB(lerpedColor);
        }

        private static Color HSVLerp(float t) {
            float hue = Mathf.Repeat(t, 1f); // 0..1
            return Color.HSVToRGB(hue, 1f, 1f);
        }
    }
}