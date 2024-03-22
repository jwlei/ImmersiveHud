using UnityEngine;
using HarmonyLib;
using System.Reflection;

namespace ImmersiveHud
{
    [HarmonyPatch(typeof(Player), "Update")]
    public class PlayerUpdatePatch : ImmersiveHud
    {
        private static void Prefix(Player __instance)
        {
            if (!__instance) return;

            ItemDrop.ItemData playerEquippedWeapon = __instance.GetCurrentWeapon();

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

    [HarmonyPatch(typeof(Player), "UseStamina")]
    public class PlayerUseStaminaPatch : ImmersiveHud
    {
        private static void Postfix(ref float v)
        {
            if (v == 0.0)
                return;

            playerUsedStamina = true;
        }
    }

    [HarmonyPatch(typeof(Player), "UseHotbarItem")]
    public class PlayerUseHotbarItemPatch : ImmersiveHud
    {
        private static void Postfix(int index)
        {
            Player localPlayer = Player.m_localPlayer;

            ItemDrop.ItemData itemAt = localPlayer.GetInventory().GetItemAt(index - 1, 0);

            if (itemAt == null)
                return;

            playerUsedHotBarItem = true;
        }
    }

    [HarmonyPatch]
    public class PlayerUpdateFoodPatch : ImmersiveHud
    {
        private static MethodBase TargetMethod()
        {
            return typeof(Player).GetMethod("UpdateFood", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        private static void Postfix(ref float dt, ref bool forceUpdate)
        {
            if (dt == 0 && forceUpdate)
                playerAteFood = true;
            else
                playerAteFood = false;
        }
    }
}