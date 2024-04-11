using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace ImmersiveHud
{
    public partial class ImmersiveHud : BaseUnityPlugin
    {
        // General
        public static ConfigEntry<bool> isEnabled;

        public static ConfigEntry<int> nexusID;

        // Main Settings
        public static ConfigEntry<KeyboardShortcut> hideHudKey;

        public static ConfigEntry<KeyboardShortcut> showHudKey;

        public static ConfigEntry<bool> hudHiddenNotification;
        public static ConfigEntry<bool> hudHiddenOnStart;
        public static ConfigEntry<float> hudFadeDuration;
        public static ConfigEntry<float> showHudDuration;
        public static ConfigEntry<float> displayHealthOnDamageDuration;

        // Crosshair Settings
        public static ConfigEntry<bool> useCustomCrosshair;

        public static ConfigEntry<bool> useCustomBowCrosshair;
        public static ConfigEntry<Color> crosshairColor;
        public static ConfigEntry<Color> crosshairBowDrawColor;
        public static ConfigEntry<bool> disableStealthHud;
        public static ConfigEntry<bool> displayCrosshairAlways;
        public static ConfigEntry<bool> displayCrosshairWhenBuilding;
        public static ConfigEntry<bool> displayCrosshairOnActivation;
        public static ConfigEntry<bool> displayCrosshairOnEquipped;
        public static ConfigEntry<bool> displayCrosshairOnBowEquipped;
        public static ConfigEntry<bool> displayBowDrawCrosshair;

        // Hud Element Settings
        public static ConfigEntry<bool> displayHealthAlways;

        public static ConfigEntry<bool> displayKeyHintsAlways;
        public static ConfigEntry<bool> displayHotKeyBarAlways;
        public static ConfigEntry<bool> displayForsakenPowerAlways;
        public static ConfigEntry<bool> displayStatusEffectsAlways;
        public static ConfigEntry<bool> displayStaminaBarAlways;
        public static ConfigEntry<bool> displayMiniMapAlways;
        public static ConfigEntry<bool> displayQuickSlotsAlways;
        public static ConfigEntry<bool> displayFoodBarAlways;
        public static ConfigEntry<bool> displayCompassAlways;
        public static ConfigEntry<bool> displayTimeAlways;

        // Compatibility Settings
        public static ConfigEntry<bool> RandyQuickSlotsEnabled;

        public static ConfigEntry<bool> BetterUIEnabled;
        public static ConfigEntry<bool> aedenCompassEnabled;
        public static ConfigEntry<bool> oryxenTimeEnabled;
        public static ConfigEntry<bool> AzuQuickSlotsEnabled;
        public static ConfigEntry<bool> AzuMinimalUiEnabled;

        // Hud Element - Health
        public static ConfigEntry<bool> displayHealthInInventory;

        public static ConfigEntry<bool> displayHealthWhenHungry;
        public static ConfigEntry<bool> displayHealthOnDamage;
        public static ConfigEntry<bool> displayHealthOnDamageSeparateTimer;
        public static ConfigEntry<bool> displayHealthWhenEating;
        public static ConfigEntry<bool> displayHealthWhenBelow;
        public static ConfigEntry<bool> displayHealthWhenFoodBelow;
        public static ConfigEntry<float> healthPercentage;
        public static ConfigEntry<bool> showHealthOnKeyPressed;

        // Hud Element - Food
        public static ConfigEntry<int> foodHungerAmount;

        public static ConfigEntry<float> foodPercentage;
        public static ConfigEntry<bool> hungerNotification;
        public static ConfigEntry<int> hungerNotificationInterval;
        public static ConfigEntry<hungerNotificationOptions> hungerNotificationOption;
        public static ConfigEntry<string> hungerNotificationText;
        public static ConfigEntry<notificationTypes> hungerNotificationType;

        // Hud Element - Food Bar (Better UI)
        public static ConfigEntry<bool> displayFoodBarInInventory;

        public static ConfigEntry<bool> displayFoodBarWhenHungry;
        public static ConfigEntry<bool> displayFoodBarWhenEating;
        public static ConfigEntry<bool> displayFoodBarWhenBelow;
        public static ConfigEntry<bool> showFoodBarOnKeyPressed;

        // Hud Element - Stamina Bar
        public static ConfigEntry<bool> displayStaminaBarInInventory;

        public static ConfigEntry<bool> displayStaminaBarOnUse;
        public static ConfigEntry<bool> displayStaminaBarWhenHungry;
        public static ConfigEntry<bool> displayStaminaBarWhenEating;
        public static ConfigEntry<bool> displayStaminaBarWhenBelow;
        public static ConfigEntry<bool> displayStaminaBarWhenFoodBelow;
        public static ConfigEntry<float> staminaPercentage;
        public static ConfigEntry<bool> showStaminaBarOnKeyPressed;

        // Hud Element - Forsaken Power
        public static ConfigEntry<bool> displayPowerInInventory;

        public static ConfigEntry<bool> displayPowerOnActivation;
        public static ConfigEntry<bool> displayPowerWhenTimeChanges;
        public static ConfigEntry<bool> displayPowerOnReady;
        public static ConfigEntry<float> powerTimeChangeInterval;
        public static ConfigEntry<bool> showPowerOnKeyPressed;

        // Hud Element - Hot Key Bar
        public static ConfigEntry<bool> displayHotKeyBarInInventory;

        public static ConfigEntry<bool> displayHotKeyBarOnItemSwitch;
        public static ConfigEntry<bool> displayHotKeyBarWhenItemEquipped;
        public static ConfigEntry<bool> showHotKeyBarOnKeyPressed;

        // Hud Element - Status Effects
        public static ConfigEntry<bool> displayStatusEffectsInInventory;

        public static ConfigEntry<bool> showStatusEffectsOnKeyPressed;

        // Hud Element - Mini Map
        public static ConfigEntry<bool> displayMiniMapInInventory;

        public static ConfigEntry<bool> showMiniMapOnKeyPressed;

        // Hud Element - Compass
        public static ConfigEntry<bool> displayCompassInInventory;

        public static ConfigEntry<bool> showCompassOnKeyPressed;

        // Hud Element - Day and Time
        public static ConfigEntry<bool> displayTimeInInventory;

        public static ConfigEntry<bool> showTimeOnKeyPressed;

        // Hud Element - Quick Slots
        public static ConfigEntry<bool> displayQuickSlotsInInventory;

        //public static ConfigEntry<bool> displayQuickSlotsOnItemSwitch;
        public static ConfigEntry<bool> showQuickSlotsOnKeyPressed;

        public static ConfigEntry<bool> showKeyHintsOnKeyPressed;

        // -- HUDELEMENTS

        private void LoadConfig()
        {
            string sectionGeneral = "1.0 - General";
            // General
            isEnabled = Config.Bind<bool>(sectionGeneral, "Enable Mod", true, "Enable or disable the mod");
            nexusID = Config.Bind<int>(sectionGeneral, "NexusID", 2732, "Nexus mod ID for updates");

            string sectionMainSettings = "1.1 - Main settings";
            // Main Settings --------------------------------------------------------------------------------
            showHudKey = Config.Bind<KeyboardShortcut>(sectionMainSettings, "1. Show HUD", new KeyboardShortcut(KeyCode.G), "Keyboard shortcut or mouse button to display the hud for a duration.");
            hideHudKey = Config.Bind<KeyboardShortcut>(sectionMainSettings, "2. Hide HUD", new KeyboardShortcut(KeyCode.H), "Keyboard shortcut or mouse button to hide the hud permanently.");
            hudHiddenNotification = Config.Bind<bool>(sectionMainSettings, "3. Enable notification for HUD Hide-Show", true, "Enable notifications in the top left corner for hiding the hud.");
            hudFadeDuration = Config.Bind<float>(sectionMainSettings, "4. HUD fade duration", 1f, "How quickly the hud fades in or out.");
            showHudDuration = Config.Bind<float>(sectionMainSettings, "5. HUD shown duration", 1f, "How long a hud element should stay up for when it is activated for certain conditions.");

            string sectionDisplayAlways = "2.0 - Always display";
            // Always Display Elements Settings --------------------------------------------------------------------------------
            displayHealthAlways = Config.Bind<bool>(sectionDisplayAlways, "1. Health bar", false, "Always display the health panel.");
            displayStaminaBarAlways = Config.Bind<bool>(sectionDisplayAlways, "2. Stamina bar", false, "Always display the stamina bar.");
            displayHotKeyBarAlways = Config.Bind<bool>(sectionDisplayAlways, "3. Hotkey bar", false, "Always display the hotbar.");
            displayForsakenPowerAlways = Config.Bind<bool>(sectionDisplayAlways, "4. Forsaken power", false, "Always display the forsaken power.");
            displayStatusEffectsAlways = Config.Bind<bool>(sectionDisplayAlways, "5. Status effects", false, "Always display status effects.");
            displayKeyHintsAlways = Config.Bind<bool>(sectionDisplayAlways, "6. Key hints", false, "Always display the key hints.");
            displayMiniMapAlways = Config.Bind<bool>(sectionDisplayAlways, "7. Minimap", false, "Always display the minimap.");
            displayCrosshairAlways = Config.Bind<bool>(sectionDisplayAlways, "8. Crosshair", true, "Always display the crosshair, overriding other display crosshair settings.");

            string sectionDisplayOnKeyPress = "2.1 - Show on hotkey press";
            // Show on key press --------------------------------------------------------------------------------
            showHealthOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "1. Health bar", true, "Show the health panel when the show hud key is pressed.");
            showStaminaBarOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "2. Stamina bar", true, "Show the stamina bar when the show hud key is pressed.");
            showPowerOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "3. Forsaken power", true, "Show the forsaken power when the show hud key is pressed.");
            showKeyHintsOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "4. Key hints", true, "Show the key hints when the show hud key is pressed.");
            showHotKeyBarOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "5. Hotkey bar", true, "Show the hot key bar when the show hud key is pressed.");
            showStatusEffectsOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "6. Status effects", true, "Show the status effects when the show hud key is pressed.");
            showMiniMapOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "7. Minimap", true, "Show the minimap when the show hud key is pressed.");

            string sectionDisplayHealth = "3.0 - Healthbar";
            // Display Scenario Settings - Health --------------------------------------------------------------------------------
            displayHealthOnDamage = Config.Bind<bool>(sectionDisplayHealth, "1. On damage", true, "Display the health panel when you take damage.");
            displayHealthOnDamageSeparateTimer = Config.Bind<bool>(sectionDisplayHealth, "2. Use separate timer for On damage", false, "Separate timer for health panel displaying when you take damage.");
            displayHealthOnDamageDuration = Config.Bind<float>(sectionDisplayHealth, "3. Duration for time for On damage", 1f, "Timer for health panel displaying when you take damage");
            displayHealthInInventory = Config.Bind<bool>(sectionDisplayHealth, "4. In inventory", true, "Display your health when in the inventory.");
            displayHealthWhenHungry = Config.Bind<bool>(sectionDisplayHealth, "5. When hungry", false, "Display the health panel when you are hungry.");
            displayHealthWhenEating = Config.Bind<bool>(sectionDisplayHealth, "6. When eating", false, "Display the health panel when you eat food.");
            displayHealthWhenBelow = Config.Bind<bool>(sectionDisplayHealth, "7.1 When below health threshold", true, "When you are at or below a certain health percentage, display the health panel.");
            displayHealthWhenFoodBelow = Config.Bind<bool>(sectionDisplayHealth, "7.2 When below food threshold", true, "When you are at or below a certain food percentage, display the health panel.");
            healthPercentage = Config.Bind<float>(sectionDisplayHealth, "7.3 Health percentage", 0.75f, new ConfigDescription("Health percentage at which the health panel should be displayed", new AcceptableValueRange<float>(0f, 1f)));

            string sectionDisplayStamina = "3.1 - Staminabar";
            // Display Scenario Settings - Stamina --------------------------------------------------------------------------------
            displayStaminaBarOnUse = Config.Bind<bool>(sectionDisplayStamina, "1. On use", true, "Display the stamina bar when stamina is used, overrides stamina percentage.");
            staminaPercentage = Config.Bind<float>(sectionDisplayStamina, "1.1 Stamina percentage", 0.99f, new ConfigDescription("Stamina percentage at which the stamina bar should be displayed.", new AcceptableValueRange<float>(0f, 1f)));
            displayStaminaBarInInventory = Config.Bind<bool>(sectionDisplayStamina, "2. In inventory", true, "Display the stamina bar when in the inventory.");
            displayStaminaBarWhenHungry = Config.Bind<bool>(sectionDisplayStamina, "3. When hungry", false, "Display the stamina bar when you are hungry.");
            displayStaminaBarWhenEating = Config.Bind<bool>(sectionDisplayStamina, "4. When eating", true, "Display the stamina bar when you eat food.");
            displayStaminaBarWhenBelow = Config.Bind<bool>(sectionDisplayStamina, "5. When below stamina threshold", true, "When you are at or below a certain stamina percentage, display the stamina bar.");
            displayStaminaBarWhenFoodBelow = Config.Bind<bool>(sectionDisplayStamina, "6. When below food threshold", false, "When you are at or below a certain food percentage, display the stamina bar.");

            string sectionDisplayHotKeyBar = "3.2 - Hotkey bar";
            // Display Scenario Settings - Hot Key Bar --------------------------------------------------------------------------------
            displayHotKeyBarInInventory = Config.Bind<bool>(sectionDisplayHotKeyBar, "1. In inventory", true, "Display the hot key bar when in the inventory.");
            displayHotKeyBarOnItemSwitch = Config.Bind<bool>(sectionDisplayHotKeyBar, "2. On item switch", false, "Display the hot key bar when you press any key for your hot bar items.");
            displayHotKeyBarWhenItemEquipped = Config.Bind<bool>(sectionDisplayHotKeyBar, "3. On equipped item", false, "Display the hot key bar when you have an item equipped in either hand.");

            string sectionDisplayStatusEffects = "3.3 - Status Effects";
            // Display Scenario Settings - Status Effects --------------------------------------------------------------------------------
            displayStatusEffectsInInventory = Config.Bind<bool>(sectionDisplayStatusEffects, "1. In inventory", true, "Display status effects when in the inventory.");

            string sectionDisplayPower = "3.4 - Forsaken Power";
            // Display Scenario Settings - Forsaken Power --------------------------------------------------------------------------------
            displayPowerInInventory = Config.Bind<bool>(sectionDisplayPower, "1. In inventory", true, "Display the forsaken power when in the inventory.");
            displayPowerOnActivation = Config.Bind<bool>(sectionDisplayPower, "2. On activation", false, "Display the forsaken power when the key to use it is pressed.");

            string sectionDisplayMiniMap = "3.5 Minimap";
            // Display Scenario Settings - MiniMap --------------------------------------------------------------------------------
            displayMiniMapInInventory = Config.Bind<bool>(sectionDisplayMiniMap, "1. In inventory", true, "Display the minimap when in the inventory.");

            string sectionCrosshair = "3.6 Crosshair";
            // Crosshair Settings --------------------------------------------------------------------------------
            useCustomCrosshair = Config.Bind<bool>(sectionCrosshair, "1. Use custom crosshair", false, new ConfigDescription("Enable or disable the new crosshair.", null, new ConfigurationManagerAttributes { Order = 1 }));
            useCustomBowCrosshair = Config.Bind<bool>(sectionCrosshair, "1.1 Use custom Bow crosshair", false, new ConfigDescription("Enable or disable the new crosshair for the bow draw.", null, new ConfigurationManagerAttributes { Order = 2 }));
            crosshairColor = Config.Bind<Color>(sectionCrosshair, "2. Color", Color.white, "Color and transparency of the crosshair.");
            crosshairBowDrawColor = Config.Bind<Color>(sectionCrosshair, "2.1 Bow Draw crosshair color", Color.yellow, "Color and transparency of the bow draw crosshair.");
            displayBowDrawCrosshair = Config.Bind<bool>(sectionCrosshair, "3. Show bow draw crosshair", true, "Display the bow draw crosshair.");
            displayCrosshairWhenBuilding = Config.Bind<bool>(sectionCrosshair, "4. Show  while building", true, "Display the crosshair when you have the hammer equipped.");
            displayCrosshairOnActivation = Config.Bind<bool>(sectionCrosshair, "5. Show  on object-hover", false, "Display crosshair when hovering over an activatable object.");
            displayCrosshairOnEquipped = Config.Bind<bool>(sectionCrosshair, "6. Show on equipped item", false, "Display crosshair when an item is equipped in either hand.");
            displayCrosshairOnBowEquipped = Config.Bind<bool>(sectionCrosshair, "7. Show on equipped bow", false, "Display crosshair when the bow is equipped.");
            disableStealthHud = Config.Bind<bool>(sectionCrosshair, "8. Disable stealth hud", false, "Disable the stealth bar and indicator so it doesn't display.");

            string sectionCompatibility = "4.0 - Compatibility";
            // Compatibility --------------------------------------------------------------------------------
            AzuMinimalUiEnabled = Config.Bind<bool>(sectionCompatibility, "1. Minimal UI", false, "Enable compatibility for Azumatt's MinimalUI mod.");
            AzuQuickSlotsEnabled = Config.Bind<bool>(sectionCompatibility, "2. AzuExtendedPlayerInventory", false, "Enable compatibility for Azumatt's ExtendedPlayerInventory mod.");
            RandyQuickSlotsEnabled = Config.Bind<bool>(sectionCompatibility, "3. Equipment and Quick Slots", false, "Enable compatibility for quickslots mod.");
            aedenCompassEnabled = Config.Bind<bool>(sectionCompatibility, "4. Compass", false, "Enable compatibility for aedenthorn's compass mod.");
            BetterUIEnabled = Config.Bind<bool>(sectionCompatibility, "5. BetterUI", false, "Enable compatibility for Better UI.");
            oryxenTimeEnabled = Config.Bind<bool>(sectionCompatibility, "6. Display Day and Time in HUD", false, "Enable compatibility for oryxen's display day and time mod.");

            string sectionCompatibilityQuickslots = "4.1 - Compatibility: Quickslots";
            // Display Scenario Settings - Quick Slots --------------------------------------------------------------------------------
            displayQuickSlotsInInventory = Config.Bind<bool>(sectionCompatibilityQuickslots, "1. In inventory", false, "Display quick slots when in the inventory.");
            showQuickSlotsOnKeyPressed = Config.Bind<bool>(sectionCompatibilityQuickslots, "2. On key pressed", false, "Show the quick slots when the show hud key is pressed.");
            displayQuickSlotsAlways = Config.Bind<bool>(sectionCompatibilityQuickslots, "3. Always display", false, "Always display the quick slots (Requires [AzuExtendedInventory] or [Equipment and Quick Slots]).");

            string sectionCompatibilityTime = "4.2 - Compatibility: Day and Time";
            // Display Scenario Settings - Clock and Day Time --------------------------------------------------------------------------------
            displayTimeInInventory = Config.Bind<bool>(sectionCompatibilityTime, "1. In inventory", false, "Display the time when in the inventory.");
            showTimeOnKeyPressed = Config.Bind<bool>(sectionCompatibilityTime, "2. On key pressed", false, "Show the time when the show hud key is pressed.");
            displayTimeAlways = Config.Bind<bool>(sectionCompatibilityTime, "3. Always display", false, "Always display the time or clock (Requires oryxen's display day and time mod).");

            string sectionCompatibilityCompass = "4.3 - Compatibility: Compass";
            // Display Scenario Settings - Compass --------------------------------------------------------------------------------
            displayCompassInInventory = Config.Bind<bool>(sectionCompatibilityCompass, "1. In inventory", false, "Display the compass when in the inventory.");
            showCompassOnKeyPressed = Config.Bind<bool>(sectionCompatibilityCompass, "2. On key pressed", false, "Show the compass when the show hud key is pressed.");
            displayCompassAlways = Config.Bind<bool>(sectionCompatibilityCompass, "3. Always", false, "Always display the compass (Requires aedenthorn's compass).");

            string sectionCompatibilityFoodbar = "4.4 - Compatibility: Food bar";
            // Display Scenario Settings - Food Bar (Better UI) --------------------------------------------------------------------------------
            displayFoodBarAlways = Config.Bind<bool>(sectionCompatibilityFoodbar, "1. Show always", false, "Always display the food bar (Requires Better UI or MinimalUI).");
            showFoodBarOnKeyPressed = Config.Bind<bool>(sectionCompatibilityFoodbar, "2. On Show HUD hotkey", true, "Display the food bar when the show hud key is pressed.");

            displayFoodBarInInventory = Config.Bind<bool>(sectionCompatibilityFoodbar, "3. In inventory", true, "Display the food bar when in the inventory.");
            displayFoodBarWhenHungry = Config.Bind<bool>(sectionCompatibilityFoodbar, "4. When hungry", true, "Display the food bar when you are hungry.");
            displayFoodBarWhenEating = Config.Bind<bool>(sectionCompatibilityFoodbar, "5. When eating", true, "Display the food bar when you eat food.");
            displayFoodBarWhenBelow = Config.Bind<bool>(sectionCompatibilityFoodbar, "6. When below threshold", true, "When you are at or below a certain food percentage, display the food bar.");
            foodHungerAmount = Config.Bind<int>(sectionCompatibilityFoodbar, "6.1 Hunger threshold", 3, new ConfigDescription("The minimum amount of food icons that need to be flashing to be considered hungry.", new AcceptableValueRange<int>(1, 3)));
            foodPercentage = Config.Bind<float>(sectionCompatibilityFoodbar, "6.2 Food threshold", 0.35f, new ConfigDescription("Food percentage at which the food bar, health, or stamina should be displayed.", new AcceptableValueRange<float>(0f, 1f)));
            hungerNotification = Config.Bind<bool>(sectionCompatibilityFoodbar, "hungerNotification", false, "Enable notifications for when you are hungry.");
            hungerNotificationInterval = Config.Bind<int>(sectionCompatibilityFoodbar, "hungerNotificationInterval", 25, new ConfigDescription("How often the notification should display in seconds.", new AcceptableValueRange<int>(5, 180)));
            hungerNotificationOption = Config.Bind<hungerNotificationOptions>(sectionCompatibilityFoodbar, "hungerNotificationOption", hungerNotificationOptions.FoodPercentage, new ConfigDescription("Option to be used for notifications."));
            hungerNotificationText = Config.Bind<string>(sectionCompatibilityFoodbar, "hungerNotificationText", "I'm feeling a bit peckish.", "Message for hunger notification.");
            hungerNotificationType = Config.Bind<notificationTypes>(sectionCompatibilityFoodbar, "hungerNotificationType", notificationTypes.SmallTopLeft, new ConfigDescription("Notification types for the hunger notification."));

            string sectionMisc = "9.0 - Misc";
            // Misc --------------------------------------------------------------------------------
            hudHiddenOnStart = Config.Bind<bool>(sectionMisc, "Hide HUD on start", false, "Hide the hud when the game is started.");
        }
    }
}