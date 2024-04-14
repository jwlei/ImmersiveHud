using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ImmersiveHud
{
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        [HarmonyPatch(typeof(Hud), "Awake")]
        public static class PatchCompatibilityIdentification
        {
            private static void Postfix(Transform __instance)
            {
                DebugListOfHudElements(__instance, Input.GetKeyDown(compatibilityIdHotkey.Value.MainKey));
            }
        }
    }
}