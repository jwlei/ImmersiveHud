using BepInEx;
using HarmonyLib;

namespace ImmersiveHud
{
    [BepInPlugin(MID, modName, pluginVersion)]
    [BepInProcess("valheim.exe")]
    [BepInProcess("valheim_server.exe")]
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        private const string MID = "jwlei.ImmersiveHud";
        private const string modName = "Immersive Hud";
        private const string pluginVersion = "1.3.1";

        private void Awake()
        {
            var harmony = new Harmony(MID);
            LoadConfig();

            if (!isEnabled.Value)
            {
                Logger.LogInfo("Immersive Hud is disabled in the mod config");
                harmony.UnpatchSelf();
                return;
            }
            harmony.PatchAll();
        }

        private void OnDestroy()
        {
            var harmony = new Harmony(MID);
            harmony.UnpatchSelf();
        }
    }

    // TODO: Fix minimalui health bar color
    // Fix foodbar hide option
}