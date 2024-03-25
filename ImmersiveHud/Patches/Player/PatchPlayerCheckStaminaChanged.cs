using HarmonyLib;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        [HarmonyPatch(typeof(Player), "UseStamina")]
        public static class PatchPlayerCheckStaminaChanged
        {
            private static void Postfix(ref float v)
            {
                if (v == 0.0)
                    return;

                playerUsedStamina = true;
            }
        }
    }
}