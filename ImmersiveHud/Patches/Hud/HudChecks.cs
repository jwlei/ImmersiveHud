using BepInEx;
using BepInEx.Logging;
using HarmonyLib.Tools;
using UnityEngine;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        private static void CheckHungerNotification()
        {
            // Hunger notification
            if (hungerNotification.Value && ((hungerNotificationOption.Value == hungerNotificationOptions.FoodHungerAmount && playerHungerCount >= foodHungerAmount.Value) || (hungerNotificationOption.Value == hungerNotificationOptions.FoodPercentage && playerFoodPercentage <= foodPercentage.Value)))
            {
                notificationTimer += Time.deltaTime;

                if ((int)notificationTimer % hungerNotificationInterval.Value == 0)
                {
                    switch (hungerNotificationType.Value)
                    {
                        case notificationTypes.SmallTopLeft:
                            MessageHud.instance.ShowMessage(MessageHud.MessageType.TopLeft, hungerNotificationText.Value);
                            break;

                        case notificationTypes.LargeCenter:
                            MessageHud.instance.ShowMessage(MessageHud.MessageType.Center, hungerNotificationText.Value);
                            break;

                        default:
                            break;
                    }
                    notificationTimer = 1;
                }
            }
        }

        private static void CheckPressedHideKey(bool pressedHideKey)
        {
            if (pressedHideKey)
            {
                hudHidden = !hudHidden;

                // Hud hidden notification
                if (hudHiddenNotification.Value)
                {
                    if (hudHidden)
                        MessageHud.instance.ShowMessage(MessageHud.MessageType.TopLeft, "Hud is hidden.");
                    else
                        MessageHud.instance.ShowMessage(MessageHud.MessageType.TopLeft, "Hud is visible.");
                }
                foreach (string name in hudElementNames)
                    hudElements[name].ResetTimers();
            }
        }

        private static void CheckMinimapActive()
        {
            if (isMiniMapActive)
                hudElements["MiniMap"].targetAlpha = 0;
            else
                hudElements["MiniMap"].targetAlpha = 1;
        }

        private static void CheckIfElementShouldShow()
        {
            // Health
            if (showHealthOnKeyPressed.Value)
            {
                hudElements["healthpanel"].ShowHudForDuration();
                hudElements["BetterUI_HPBar"].ShowHudForDuration();
            }

            // Food Bar
            if (showFoodBarOnKeyPressed.Value)
                hudElements["BetterUI_FoodBar"].ShowHudForDuration();

            // Stamina
            if (showStaminaBarOnKeyPressed.Value)
            {
                hudElements["staminapanel"].ShowHudForDuration();
                hudElements["BetterUI_StaminaBar"].ShowHudForDuration();
            }

            // Forsaken Power
            if (showPowerOnKeyPressed.Value)
                hudElements["GuardianPower"].ShowHudForDuration();

            // Hot Key Bar
            if (showHotKeyBarOnKeyPressed.Value)
                hudElements["HotKeyBar"].ShowHudForDuration();

            // Status Effects
            if (showStatusEffectsOnKeyPressed.Value)
                hudElements["StatusEffects"].ShowHudForDuration();

            // Mini Map
            if (showMiniMapOnKeyPressed.Value)
                hudElements["MiniMap"].ShowHudForDuration();

            // Compass
            if (showCompassOnKeyPressed.Value)
                hudElements["Compass"].ShowHudForDuration();

            // Day and Time
            if (showTimeOnKeyPressed.Value && oryxenTimeEnabled.Value)
                hudElements["DayTimePanel"].ShowHudForDuration();

            // Quick Slots
            if (showQuickSlotsOnKeyPressed.Value)
            {
                hudElements["QuickSlotsHotkeyBar"].ShowHudForDuration();
                hudElements["QuickAccessBar"].ShowHudForDuration();
            }

            // Key Hints
            if (showKeyHintsOnKeyPressed.Value)
                hudElements["KeyHints"].ShowHudForDuration();
        }

        private static void CheckHealthDisplay(Player player)
        {
            // Health Display
            if (displayHealthAlways.Value || (displayHealthInInventory.Value && InventoryGui.IsVisible()))
            {
                hudElements["healthpanel"].targetAlpha = 1;
                hudElements["BetterUI_HPBar"].targetAlpha = 1;

                if (!displayHealthInInventory.Value && InventoryGui.IsVisible())
                {
                    hudElements["healthpanel"].HudSetTargetAlpha(0);
                    hudElements["BetterUI_HPBar"].HudSetTargetAlpha(0);
                }
            }
            else if ((displayHealthWhenEating.Value && playerAteFood) || (displayHealthOnDamage.Value && playerTookDamage))
            {
                hudElements["healthpanel"].ShowHudForDuration();
                hudElements["BetterUI_HPBar"].ShowHudForDuration();
            }
            else if (
                    // Display health panel when below a given percentage
                    (displayHealthWhenBelow.Value && player.GetHealthPercentage() <= healthPercentage.Value) ||
                    (displayHealthWhenFoodBelow.Value && playerFoodPercentage <= foodPercentage.Value) ||
                    (displayHealthWhenHungry.Value && playerHungerCount >= foodHungerAmount.Value)
                    )
            {
                hudElements["healthpanel"].HudSetTargetAlpha(1);
                hudElements["BetterUI_HPBar"].HudSetTargetAlpha(1);
            }
            else
            {
                hudElements["healthpanel"].HudSetTargetAlpha(0);
                hudElements["BetterUI_HPBar"].HudSetTargetAlpha(0);
            }
        }

        private static void CheckFoodBar()
        {
            // Food Bar Display
            if (displayBetterUIFoodAlways.Value || (displayFoodBarInInventory.Value && InventoryGui.IsVisible()))
            {
                hudElements["BetterUI_FoodBar"].targetAlpha = 1;

                if (!displayFoodBarInInventory.Value && InventoryGui.IsVisible())
                    hudElements["BetterUI_FoodBar"].HudSetTargetAlpha(0);
            }
            else
            {
                if (betterUIFoodEnabled.Value && hudElements["BetterUI_FoodBar"].exists)
                {
                    // Display food bar when eating food
                    if (displayFoodBarWhenEating.Value && playerAteFood)
                        hudElements["BetterUI_FoodBar"].ShowHudForDuration();

                    // Display food bar when below a given percentage.
                    if (displayFoodBarWhenBelow.Value && playerFoodPercentage <= foodPercentage.Value)
                    {
                        hudElements["BetterUI_FoodBar"].HudSetTargetAlpha(1);
                    }
                    else if (displayFoodBarWhenHungry.Value && playerHungerCount >= foodHungerAmount.Value)
                    {
                        hudElements["BetterUI_FoodBar"].HudSetTargetAlpha(1);
                    }
                    else
                    {
                        hudElements["BetterUI_FoodBar"].HudSetTargetAlpha(0);
                    }
                }
            }
        }

        private static void CheckStaminaBar(Player player)
        {
            // Stamina Bar Display
            if (displayStaminaBarAlways.Value || (displayStaminaBarInInventory.Value && InventoryGui.IsVisible()))
            {
                hudElements["staminapanel"].targetAlpha = 1;
                hudElements["BetterUI_StaminaBar"].targetAlpha = 1;

                if (!displayStaminaBarInInventory.Value && InventoryGui.IsVisible())
                {
                    hudElements["staminapanel"].HudSetTargetAlpha(0);
                    hudElements["BetterUI_StaminaBar"].HudSetTargetAlpha(0);
                }
            }
            else
            {
                // Display stamina bar when stamina is used
                if (displayStaminaBarOnUse.Value && playerUsedStamina)
                {
                    hudElements["staminapanel"].ShowHudForDuration();
                    hudElements["BetterUI_StaminaBar"].ShowHudForDuration();
                }

                // Display stamina bar when eating food
                if (displayStaminaBarWhenEating.Value && playerAteFood)
                {
                    hudElements["staminapanel"].ShowHudForDuration();
                    hudElements["BetterUI_StaminaBar"].ShowHudForDuration();
                }

                // Display stamina bar when below a given percentage.
                if (
                    (displayStaminaBarWhenBelow.Value && player.GetStaminaPercentage() <= staminaPercentage.Value) ||
                    (displayStaminaBarWhenFoodBelow.Value && playerFoodPercentage <= foodPercentage.Value) ||
                    (displayStaminaBarWhenHungry.Value && playerHungerCount >= foodHungerAmount.Value)
                   )
                {
                    hudElements["staminapanel"].HudSetTargetAlpha(1);
                    hudElements["BetterUI_StaminaBar"].HudSetTargetAlpha(1);
                }
                else
                {
                    hudElements["staminapanel"].HudSetTargetAlpha(0);
                    hudElements["BetterUI_StaminaBar"].HudSetTargetAlpha(0);
                }
            }
        }

        private static void CheckForsakenPower()
        {
            // Forsaken Power Display
            if (displayForsakenPowerAlways.Value || (displayPowerInInventory.Value && InventoryGui.IsVisible()))
            {
                hudElements["GuardianPower"].targetAlpha = 1;

                if (!displayPowerInInventory.Value && InventoryGui.IsVisible())
                    hudElements["GuardianPower"].HudSetTargetAlpha(0);
            }
            else
            {
                // Show the forsaken power for a duration when the key is pressed.
                if (displayPowerOnActivation.Value && (ZInput.GetButtonDown("GPower") || ZInput.GetButtonDown("JoyGPower")))
                    hudElements["GuardianPower"].ShowHudForDuration();

                hudElements["GuardianPower"].HudSetTargetAlpha(0);
            }
        }

        private static void CheckHotbar()
        {
            // Hot Key Bar Display
            if (displayHotKeyBarAlways.Value || (displayHotKeyBarInInventory.Value && InventoryGui.IsVisible()))
            {
                hudElements["HotKeyBar"].targetAlpha = 1;

                if (!displayHotKeyBarInInventory.Value && InventoryGui.IsVisible())
                    hudElements["HotKeyBar"].HudSetTargetAlpha(0);
            }
            else
            {
                // Display on item switch/use
                if (displayHotKeyBarOnItemSwitch.Value && playerUsedHotBarItem)
                    hudElements["HotKeyBar"].ShowHudForDuration();
                else if (displayHotKeyBarWhenItemEquipped.Value && playerHasItemEquipped)
                    hudElements["HotKeyBar"].HudSetTargetAlpha(1);
                else
                    hudElements["HotKeyBar"].HudSetTargetAlpha(0);
            }
        }

        private static void CheckStatusEffect()
        {
            // Status Effects Display
            if (displayStatusEffectsAlways.Value || (displayStatusEffectsInInventory.Value && InventoryGui.IsVisible()))
            {
                hudElements["StatusEffects"].targetAlpha = 1;

                if (!displayStatusEffectsInInventory.Value && InventoryGui.IsVisible())
                    hudElements["StatusEffects"].HudSetTargetAlpha(0);
            }
            else
            {
                hudElements["StatusEffects"].HudSetTargetAlpha(0);
            }
        }

        private static void CheckMinimap()
        {
            // Mini Map Display
            if (displayMiniMapAlways.Value || (displayMiniMapInInventory.Value && InventoryGui.IsVisible()) || !isMiniMapActive)
            {
                hudElements["MiniMap"].targetAlpha = 1;

                if (!displayMiniMapInInventory.Value && InventoryGui.IsVisible())
                    hudElements["MiniMap"].HudSetTargetAlpha(0);
            }
            else
            {
                hudElements["MiniMap"].HudSetTargetAlpha(0);
            }
        }

        private static void CheckCompass()
        {
            if (aedenCompassEnabled.Value && hudElements["Compass"].exists)
            {
                if (displayCompassAlways.Value || (displayCompassInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["Compass"].targetAlpha = 1;

                    if (!displayCompassInInventory.Value && InventoryGui.IsVisible())
                        hudElements["Compass"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["Compass"].HudSetTargetAlpha(0);
                }
            }
        }

        private static void CheckDayTime()
        {
            // Day and Time Display
            if (oryxenTimeEnabled.Value && hudElements["DayTimePanel"].exists)
            {
                if (displayTimeAlways.Value || (displayTimeInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["DayTimePanel"].targetAlpha = 1;

                    if (!displayTimeInInventory.Value && InventoryGui.IsVisible())
                        hudElements["DayTimePanel"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["DayTimePanel"].HudSetTargetAlpha(0);
                }
            }
        }

        private static void CheckKeyHints()
        {
            if (displayKeyHintsAlways.Value && hudElements["KeyHints"].exists)
            {
                hudElements["KeyHints"].targetAlpha = 1;
            }
            else
            {
                hudElements["KeyHints"].HudSetTargetAlpha(0);
            }
        }

        private static void CheckQuickSlots()
        {
            CheckRandyQuickSlots();
            CheckAzuQuickSlots();
        }

        private static void CheckRandyQuickSlots()
        {
            // QuickSlots Display
            if (RandyQuickSlotsEnabled.Value && hudElements["QuickSlotsHotkeyBar"].exists)
            {
                if (displayRandyQuickSlotsAlways.Value || (displayQuickSlotsInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["QuickSlotsHotkeyBar"].targetAlpha = 1;

                    if (!displayQuickSlotsInInventory.Value && InventoryGui.IsVisible())
                        hudElements["QuickSlotsHotkeyBar"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["QuickSlotsHotkeyBar"].HudSetTargetAlpha(0);
                }
            }
        }

        private static void CheckAzuQuickSlots()
        {
            // QuickSlots Display
            if (AzuQuickSlotsEnabled.Value && hudElements["QuickAccessBar"].exists)
            {
                if (displayAzuQuickSlotsAlways.Value || (displayQuickSlotsInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["QuickAccessBar"].targetAlpha = 1;

                    if (!displayQuickSlotsInInventory.Value && InventoryGui.IsVisible())
                        hudElements["QuickAccessBar"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["QuickAccessBar"].HudSetTargetAlpha(0);
                }
            }
        }
    }
}