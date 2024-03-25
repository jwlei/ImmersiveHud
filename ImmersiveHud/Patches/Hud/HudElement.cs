using BepInEx;
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
            "KeyHints"
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
            public float timeFade = 0;
            public float timeDisplay = 0;

            public float targetAlphaPrev;
            public float targetAlpha;
            public float lastSetAlpha;

            public bool doesExist = false;
            public bool targetAlphaReached;
            public bool isDisplaying;

            // List of hud elements

            // Notification Types
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
                    doesExist = true;
                }
            }

            public void HudSetTargetAlpha(float alpha)
            {
                if (!isDisplaying)
                    targetAlpha = alpha;
            }

            public void HudCheckLerpDuration()
            {
                if (timeFade >= hudFadeDuration.Value)
                    targetAlphaReached = true;
                else
                    targetAlphaReached = false;
            }

            public void ShowHudForDuration()
            {
                if (!doesExist)
                    return;

                targetAlpha = 1;
                timeDisplay = 0;
                isDisplaying = true;
            }

            public void HudCheckDisplayTimer()
            {
                if (timeDisplay >= showHudDuration.Value && isDisplaying)
                {
                    targetAlpha = 0;
                    isDisplaying = false;
                }
            }

            public void ResetTimers()
            {
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