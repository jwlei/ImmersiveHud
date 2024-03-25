using UnityEngine;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        private static bool isMiniMapActive;
        private static float fadeDuration = 0.5f;
        private static float notificationTimer = 0f;
        private static bool hudHidden;

        public static void HudUpdateTransparency(HudElement hudElement)
        {
            float lerpedAlpha;
            lerpedAlpha = Mathf.Lerp(hudElement.lastSetAlpha, hudElement.targetAlpha, hudElement.timeFade / hudFadeDuration.Value);

            if (hudElement.elementName == "MiniMap")
            {
                hudElement.element.GetComponent<Minimap>().m_mapImageSmall.CrossFadeAlpha(hudElement.targetAlpha, hudElement.timeFade, false);
            }
            hudElement.lastSetAlpha = lerpedAlpha;
            hudElement.element.GetComponent<CanvasGroup>().alpha = lerpedAlpha;
        }

        public static void GetPlayerState(Transform hud, Player player)
        {
            Minimap playerMap = hud.Find("MiniMap").GetComponent<Minimap>();
            bool prevState = isMiniMapActive;

            isMiniMapActive = playerMap.m_smallRoot.activeSelf;

            // Reset timer when changing map modes.
            if (prevState != isMiniMapActive)
                hudElements["MiniMap"].timeFade = 0;

            GetPlayerTotalFoodValue(player);

            ItemDrop.ItemData playerEquippedWeapon = player.GetCurrentWeapon();

            if (playerEquippedWeapon != null)
                playerHasItemEquipped = true;
            else
                playerHasItemEquipped = false;
        }

        public static void GetPlayerTotalFoodValue(Player player)
        {
            playerTotalFoodValue = playerCurrentFoodValue = playerHungerCount = 0;

            foreach (Player.Food food in player.GetFoods())
            {
                playerTotalFoodValue += food.m_item.m_shared.m_food;
                playerCurrentFoodValue += food.m_health;

                if (food.CanEatAgain())
                    playerHungerCount++;
            }

            playerFoodPercentage = playerCurrentFoodValue / playerTotalFoodValue;
        }

        public static void HudSetValues(bool pressedHideKey, bool pressedShowKey)
        {
            Player player = Player.m_localPlayer;

            // Store previous target alpha for timer reset.
            foreach (string name in hudElementNames)
            {
                if (hudElements[name].element != null)
                    hudElements[name].targetAlphaPrev = hudElements[name].targetAlpha;
            }

            CheckPressedHideKey(pressedHideKey);
            CheckHungerNotification();

            if (hudHidden)
            {
                foreach (string name in hudElementNames)
                    hudElements[name].targetAlpha = 0;
                if (isMiniMapActive)
                {
                    CheckMinimapActive();
                }
            }
            else if (pressedShowKey)
            {
                CheckIfElementShouldShow();
            }
            else
            {
                CheckHealthDisplay(player);
                CheckFoodBar();
                CheckStaminaBar(player);
                CheckForsakenPower();
                CheckHotbar();
                CheckStatusEffect();
                CheckMinimap();
                CheckCompass();
                CheckDayTime();
                CheckQuickSlots();
            }

            // Reset timer when the target alpha changed.
            foreach (string name in hudElementNames)
            {
                hudElements[name].HudCheckDisplayTimer();

                if (!hudElements[name].doesExist || hudElements[name].element == null)
                    continue;

                if (hudElements[name].targetAlphaPrev != hudElements[name].targetAlpha)
                    hudElements[name].timeFade = 0;
            }

            playerUsedHotBarItem = false;
            playerUsedStamina = false;
            playerAteFood = false;
        }

        private static void ForceVanillaStaminabar(Hud __instance)
        {
            // FIX: vanilla stam bar when eating food.
            if (!hudElements["BetterUI_StaminaBar"].doesExist)
            {
                hudElements["staminapanel"].element.gameObject.SetActive(true);
                __instance.m_staminaAnimator.SetBool("Visible", true);
            }
        }

        private static void HudElementAddCanvasGroup(Transform hudRoot)
        {
            // Add CanvasGroup to each hud element on awake.
            foreach (string name in hudElementNames)
            {
                hudElements.Add(name, new HudElement(name));

                if (hudRoot.Find(name) == null)
                    continue;

                hudElements[name].setElement(hudRoot.Find(name));
                hudElements[name].element.GetComponent<RectTransform>().gameObject.AddComponent<CanvasGroup>();
            }
        }

        private static void HudAddCanvasGroupStealth()
        {
            playerStealthBar.transform.gameObject.AddComponent<CanvasGroup>();
            playerStealthIndicator.transform.gameObject.AddComponent<CanvasGroup>();
            playerStealthIndicatorTargeted.transform.gameObject.AddComponent<CanvasGroup>();
            playerStealthIndicatorAlert.transform.gameObject.AddComponent<CanvasGroup>();
        }

        private static void HudSetValueCrosshair(Hud __instance)
        {
            playerCrosshair = __instance.m_crosshair;
            playerBowCrosshair = __instance.m_crosshairBow;
        }

        private static void HudSetValuesStealth(Hud __instance)
        {
            playerStealthBar = __instance.m_stealthBar;
            playerStealthIndicator = __instance.m_hidden;
            playerStealthIndicatorTargeted = __instance.m_targeted;
            playerStealthIndicatorAlert = __instance.m_targetedAlert;
        }
    }
}