﻿using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace ImmersiveHud
{
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        [HarmonyPatch(typeof(Hud), "Update")]
        public static class PatchCompatibilityIdentification
        {
            private static void Postfix(Hud __instance)
            {
                Transform hudRoot = __instance.transform.Find("hudroot");

                DebugListOfMissingElements(hudRoot, Input.GetKeyDown(compatibilityIdHotkey.Value.MainKey));
                DebugListOfHudElements(hudRoot, Input.GetKeyDown(listAllElementsHotkey.Value.MainKey));
            }
        }
    }
}