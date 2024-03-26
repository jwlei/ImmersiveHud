using HarmonyLib;
using System;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        [HarmonyPatch(typeof(Character), nameof(Character.Damage))]
        public static class PatchPlayerCheckDamaged
        {
            private static void Prefix(Character __instance, HitData hit)
            {
                if (__instance is Player && (hit.GetTotalDamage() > 0f))
                {
                    playerTookDamage = true;
                }
            }
        }
    }
}