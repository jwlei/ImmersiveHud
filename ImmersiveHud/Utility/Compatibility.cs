using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace ImmersiveHud
{
    [HarmonyPatch]
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        public static void setCompatibilityInit()
        {
            hudElements["BetterUI_HPBar"].doesExist = false;
            hudElements["BetterUI_FoodBar"].doesExist = false;
            hudElements["BetterUI_StaminaBar"].doesExist = false;
            hudElements["Compass"].doesExist = false;
            hudElements["QuickSlotsHotkeyBar"].doesExist = false;
        }

        public static void setCompatibility(Transform hud)
        {
            // Compatibility check for BetterUI HP Bar.
            if (betterUIHPEnabled.Value && !hudElements["BetterUI_HPBar"].doesExist)
            {
                if (hud.Find("BetterUI_HPBar"))
                {
                    hudElements["BetterUI_HPBar"].setElement(hud.Find("BetterUI_HPBar"));
                    hudElements["BetterUI_HPBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
                }
            }

            // Compatibility check for BetterUI Food Bar.
            if (betterUIFoodEnabled.Value && !hudElements["BetterUI_FoodBar"].doesExist)
            {
                if (hud.Find("BetterUI_FoodBar"))
                {
                    hudElements["BetterUI_FoodBar"].setElement(hud.Find("BetterUI_FoodBar"));
                    hudElements["BetterUI_FoodBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
                }
            }

            // Compatibility check for BetterUI Stam Bar.
            if (betterUIStamEnabled.Value && !hudElements["BetterUI_StaminaBar"].doesExist)
            {
                if (hud.Find("BetterUI_StaminaBar"))
                {
                    hudElements["BetterUI_StaminaBar"].setElement(hud.Find("BetterUI_StaminaBar"));
                    hudElements["BetterUI_StaminaBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
                }
            }

            // Compatibility check for Compass.
            if (aedenCompassEnabled.Value && !hudElements["Compass"].doesExist)
            {
                if (hud.Find("Compass"))
                {
                    hudElements["Compass"].setElement(hud.Find("Compass"));
                    hudElements["Compass"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
                }
            }

            // Compatibility check for Display Day and Time.
            if (oryxenTimeEnabled.Value && !hudElements["DayTimePanel"].doesExist)
            {
                if (hud.Find("DayTimePanel"))
                {
                    hudElements["DayTimePanel"].setElement(hud.Find("DayTimePanel"));
                    hudElements["DayTimePanel"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
                }
            }

            // Compatibility check for Quick Slots.
            if (quickSlotsEnabled.Value && !hudElements["QuickSlotsHotkeyBar"].doesExist)
            {
                if (hud.Find("QuickSlotsHotkeyBar"))
                {
                    hudElements["QuickSlotsHotkeyBar"].setElement(hud.Find("QuickSlotsHotkeyBar"));
                    hudElements["QuickSlotsHotkeyBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
                }
            }
        }
    }
}