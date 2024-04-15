using HarmonyLib;
using UnityEngine;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        [HarmonyPatch(typeof(Hud), "UpdateStamina")]
        public static class PatchPlayerUpdateStamina
        {
            private static void Postfix(Hud __instance, float dt)
            {
                if (disableCrosshairStamina.Value)
                {
                    __instance.m_staminaBar2Root.gameObject.SetActive(false);

                    //hudElements["staminapanel"].element.gameObject.SetActive(true);
                    //__instance.m_staminaAnimator.SetBool("Visible", true);
                }
            }
        }
    }
}