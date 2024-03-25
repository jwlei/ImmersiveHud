using HarmonyLib;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        [HarmonyPatch(typeof(Player), "Update")]
        public static class PatchPlayerCheckBowEquipped
        {
            private static void Prefix(Player __instance)
            {
                if (!__instance) return;

                ItemDrop.ItemData playerEquippedWeapon = __instance.GetCurrentWeapon();

                CheckPlayerEquippedWeapon(playerEquippedWeapon);
            }
        }
    }
}