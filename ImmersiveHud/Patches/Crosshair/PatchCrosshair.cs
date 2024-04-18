using HarmonyLib;
using BepInEx;

namespace ImmersiveHud
{
    [HarmonyPatch]
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        [HarmonyPatch(typeof(Hud), "UpdateCrosshair")]
        public static class PatchCrosshair
        {
            private static void Postfix(Player player, float bowDrawPercentage)
            {
                SetCrosshairValues(player);
                SetStealthHudValues();

                UpdateCrosshairHudElement(bowDrawPercentage);
                UpdateStealthHudElement();

                //RemovePieceHealthBar();
            }
        }
    }
}