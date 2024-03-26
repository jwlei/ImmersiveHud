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
            hudElements["BetterUI_HPBar"].exists = false;
            hudElements["BetterUI_FoodBar"].exists = false;
            hudElements["BetterUI_StaminaBar"].exists = false;
            hudElements["Compass"].exists = false;
            hudElements["QuickSlotsHotkeyBar"].exists = false;
            hudElements["QuickAccessBar"].exists = false;
        }

        public static void setCompatibility(Transform hud)
        {
            // Compatibility check for BetterUI HP Bar.
            if (betterUIHPEnabled.Value && !hudElements["BetterUI_HPBar"].exists && hud.Find("BetterUI_HPBar"))
            {
                hudElements["BetterUI_HPBar"].setElement(hud.Find("BetterUI_HPBar"));
                hudElements["BetterUI_HPBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            // Compatibility check for BetterUI Food Bar.
            if (betterUIFoodEnabled.Value && !hudElements["BetterUI_FoodBar"].exists && hud.Find("BetterUI_FoodBar"))
            {
                hudElements["BetterUI_FoodBar"].setElement(hud.Find("BetterUI_FoodBar"));
                hudElements["BetterUI_FoodBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            // Compatibility check for BetterUI Stam Bar.
            if (betterUIStamEnabled.Value && !hudElements["BetterUI_StaminaBar"].exists && hud.Find("BetterUI_StaminaBar"))
            {
                hudElements["BetterUI_StaminaBar"].setElement(hud.Find("BetterUI_StaminaBar"));
                hudElements["BetterUI_StaminaBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            // Compatibility check for Compass.
            if (aedenCompassEnabled.Value && !hudElements["Compass"].exists && hud.Find("Compass"))
            {
                hudElements["Compass"].setElement(hud.Find("Compass"));
                hudElements["Compass"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            // Compatibility check for Display Day and Time.
            if (oryxenTimeEnabled.Value && !hudElements["DayTimePanel"].exists && hud.Find("DayTimePanel"))
            {
                hudElements["DayTimePanel"].setElement(hud.Find("DayTimePanel"));
                hudElements["DayTimePanel"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            // Compatibility check for Quick Slots.
            if (RandyQuickSlotsEnabled.Value && !hudElements["QuickSlotsHotkeyBar"].exists && hud.Find("QuickSlotsHotkeyBar"))
            {
                hudElements["QuickSlotsHotkeyBar"].setElement(hud.Find("QuickSlotsHotkeyBar"));
                hudElements["QuickSlotsHotkeyBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            // Compatibility check for AzumatQuickSlot.
            if (AzuQuickSlotsEnabled.Value && !hudElements["QuickAccessBar"].exists && hud.Find("QuickAccessBar"))
            {
                hudElements["QuickAccessBar"].setElement(hud.Find("QuickAccessBar"));
                hudElements["QuickAccessBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }
        }
    }
}