using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace ImmersiveHud
{
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        [HarmonyPatch]
        public static class PatchPlayerCheckFoodEaten
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
}