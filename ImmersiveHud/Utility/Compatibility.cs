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
            hudElements["MUIMap"].exists = false;
            hudElements["MUI_HPBar"].exists = false;
            hudElements["MUI_StaminaBar"].exists = false;
            hudElements["MUI_EitrBar"].exists = false;
            hudElements["MUI_GuardianPowerBar"].exists = false;
            hudElements["MUI_FoodBar"].exists = false;
            hudElements["food0"].exists = false;
            hudElements["food1"].exists = false;
            hudElements["food2"].exists = false;
        }

        public static void setCompatibility(Transform hud)
        {
            // Compatibility check for BetterUI HP Bar.
            if (BetterUIEnabled.Value && !hudElements["BetterUI_HPBar"].exists && hud.Find("BetterUI_HPBar"))
            {
                hudElements["BetterUI_HPBar"].setElement(hud.Find("BetterUI_HPBar"));
                hudElements["BetterUI_HPBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            // Compatibility check for BetterUI Food Bar.
            if (BetterUIEnabled.Value && !hudElements["BetterUI_FoodBar"].exists && hud.Find("BetterUI_FoodBar"))
            {
                hudElements["BetterUI_FoodBar"].setElement(hud.Find("BetterUI_FoodBar"));
                hudElements["BetterUI_FoodBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            // Compatibility check for BetterUI Stam Bar.
            if (BetterUIEnabled.Value && !hudElements["BetterUI_StaminaBar"].exists && hud.Find("BetterUI_StaminaBar"))
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

            // Compatibility check for Azumatts Minimal UI
            if (AzuMinimalUiEnabled.Value && !hudElements["MUIMap"].exists && hud.Find("MUIMap"))
            {
                hudElements["MUIMap"].setElement(hud.Find("MUIMap"));
                hudElements["MUIMap"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            if (AzuMinimalUiEnabled.Value && !hudElements["MUI_HPBar"].exists && hud.Find("MUI_HPBar"))
            {
                hudElements["MUI_HPBar"].setElement(hud.Find("MUI_HPBar"));
                hudElements["MUI_HPBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            if (AzuMinimalUiEnabled.Value && !hudElements["MUI_StaminaBar"].exists && hud.Find("MUI_StaminaBar"))
            {
                hudElements["MUI_StaminaBar"].setElement(hud.Find("MUI_StaminaBar"));
                hudElements["MUI_StaminaBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            if (AzuMinimalUiEnabled.Value && !hudElements["MUI_EitrBar"].exists && hud.Find("MUI_EitrBar"))
            {
                hudElements["MUI_EitrBar"].setElement(hud.Find("MUI_EitrBar"));
                hudElements["MUI_EitrBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            if (AzuMinimalUiEnabled.Value && !hudElements["MUI_GuardianPowerBar"].exists && hud.Find("MUI_GuardianPowerBar"))
            {
                hudElements["MUI_GuardianPowerBar"].setElement(hud.Find("MUI_GuardianPowerBar"));
                hudElements["MUI_GuardianPowerBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            if (AzuMinimalUiEnabled.Value && !hudElements["MUI_FoodBar"].exists && hud.Find("MUI_FoodBar"))
            {
                hudElements["MUI_FoodBar"].setElement(hud.Find("MUI_FoodBar"));
                hudElements["MUI_FoodBar"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            if (AzuMinimalUiEnabled.Value && !hudElements["food0"].exists && hud.Find("food0"))
            {
                hudElements["food0"].setElement(hud.Find("food0"));
                hudElements["food0"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            if (AzuMinimalUiEnabled.Value && !hudElements["food1"].exists && hud.Find("food1"))
            {
                hudElements["food1"].setElement(hud.Find("food1"));
                hudElements["food1"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }

            if (AzuMinimalUiEnabled.Value && !hudElements["food2"].exists && hud.Find("food2"))
            {
                hudElements["food2"].setElement(hud.Find("food2"));
                hudElements["food2"].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }
        }
    }
}