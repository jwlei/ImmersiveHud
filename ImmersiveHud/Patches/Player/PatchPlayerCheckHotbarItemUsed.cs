using HarmonyLib;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        [HarmonyPatch(typeof(Player), "UseHotbarItem")]
        public static class PatchPlayerCheckHotbarItemUsed
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
    }
}