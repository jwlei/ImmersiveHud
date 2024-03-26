﻿using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace ImmersiveHud
{
    [HarmonyPatch]
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        public static float targetStealthHudAlpha;
        public static GuiBar playerStealthBar;
        public static GameObject playerStealthIndicator;
        public static GameObject playerStealthIndicatorTargeted;
        public static GameObject playerStealthIndicatorAlert;

        // Player Data
        public static float playerTotalFoodValue;

        public static float playerCurrentFoodValue;
        public static float playerFoodPercentage;
        public static int playerHungerCount;

        // Character States
        public static bool characterEquippedItem;

        public static bool characterEquippedBow;
        public static bool isLookingAtActivatable;
        public static bool playerUsedStamina;
        public static bool playerAteFood;
        public static bool playerUsedHotBarItem;
        public static bool playerUsedQuickSlotsItem;
        public static bool playerHasItemEquipped;
        public static bool playerTookDamage;

        private static void CheckPlayerEquippedWeapon(ItemDrop.ItemData playerEquippedWeapon)
        {
            if (playerEquippedWeapon != null && (playerEquippedWeapon.m_shared.m_itemType == ItemDrop.ItemData.ItemType.Bow))
            {
                characterEquippedBow = true;
                characterEquippedItem = false;
            }
            else if (playerEquippedWeapon != null)
            {
                characterEquippedBow = false;
                characterEquippedItem = true;
            }
            else
            {
                characterEquippedItem = false;
                characterEquippedBow = false;
            }
        }
    }
}