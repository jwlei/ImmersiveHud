using BepInEx;
using BepInEx.Configuration;
using System.Collections.Generic;
using UnityEngine;

namespace ImmersiveHud
{
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        public static Dictionary<string, HudElement> hudElements;

        public static string[] hudElementNames =
            {
            "healthpanel",
            "staminapanel",
            "GuardianPower",
            "HotKeyBar",
            "StatusEffects",
            "MiniMap",
            "QuickSlotsHotkeyBar",
            "BetterUI_HPBar",
            "BetterUI_FoodBar",
            "BetterUI_StaminaBar",
            "Compass",
            "DayTimePanel",
            "KeyHints",
            "QuickAccessBar",
            };

        public enum notificationTypes
        {
            SmallTopLeft,
            LargeCenter
        }

        public enum hungerNotificationOptions
        {
            FoodHungerAmount,
            FoodPercentage
        }

        public class HudElement
        {
            public Transform element;
            public string elementName;

            public float timeFade;
            public float timeDisplay;
            public float targetAlphaPrev;
            public float targetAlpha;
            public float lastSetAlpha;

            public bool exists = false;
            public bool targetAlphaReached;
            public bool isVisible;

            public HudElement(string name)
            {
                element = null;
                elementName = name;
            }

            public void setElement(Transform e)
            {
                if (e != null)
                {
                    element = e;
                    exists = true;
                }
            }

            public void HudSetTargetAlpha(float alpha)
            {
                // Set the target alpha for the element.
                if (!isVisible)
                    targetAlpha = alpha;
            }

            public void HudCheckLerpDuration(ConfigEntry<float> duration)
            {
                // Check if the element has reached the target alpha.
                if (timeFade >= duration.Value)
                    targetAlphaReached = true;
                else
                    targetAlphaReached = false;
            }

            public void ShowHudForDuration()
            {
                // If the element is not visible, show it for the duration of the set time.
                if (!exists)
                    return;

                targetAlpha = 1;
                timeDisplay = 0;
                isVisible = true;
            }

            public void HudElementCheckDisplayTimer(ConfigEntry<float> duration)
            {                // If the element is visible, check if it has been visible for the set time.
                if (timeDisplay >= duration.Value && isVisible)
                {
                    targetAlpha = 0;
                    isVisible = false;
                }
            }

            public void ResetTimers()
            {
                // Reset timers for fade and display.
                timeFade = 0;
                timeDisplay = 0;
            }

            public static void DebugListOfHudElements(Transform hud)
            {
                foreach (Transform t in hud.GetComponentsInChildren<Transform>(true))
                    Debug.Log(t.name);
            }
        }
    }
}