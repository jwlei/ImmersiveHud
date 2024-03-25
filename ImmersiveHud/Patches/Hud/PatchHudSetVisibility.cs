﻿using UnityEngine;
using HarmonyLib;
using BepInEx;

namespace ImmersiveHud
{
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        [HarmonyPatch(typeof(Hud), "Update")]
        public static class PatchHudSetVisibility
        {
            private static void Postfix(Hud __instance)
            {
                Player player = Player.m_localPlayer;

                // Check if the player is in the game and if the Hud instance exists.
                if (!isEnabled.Value || !player || !__instance)
                    return;

                Transform hudRoot = __instance.transform.Find("hudroot");

                GetPlayerState(hudRoot, player);
                setCompatibility(hudRoot);
                HudSetValues(Input.GetKeyDown(hideHudKey.Value.MainKey), Input.GetKey(showHudKey.Value.MainKey));

                // Set vanilla stamina bar to always be active so hiding and showing works properly
                ForceVanillaStaminabar(__instance);

                foreach (string name in hudElementNames)
                {
                    if (!hudElements[name].doesExist || hudElements[name].element == null)
                        continue;

                    hudElements[name].HudCheckLerpDuration();

                    if (!hudElements[name].targetAlphaReached)
                    {
                        hudElements[name].timeFade += Time.deltaTime;
                        HudUpdateTransparency(hudElements[name]);
                    }
                    else
                    {
                        hudElements[name].timeDisplay += Time.deltaTime;
                    }
                }
            }
        }
    }
}