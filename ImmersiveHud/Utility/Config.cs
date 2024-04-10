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
        public static ConfigEntry<bool> displayBetterUIFoodAlways;
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
            string sectionGeneral = "- General -";
            string sectionMainSettings = "- Main settings -";
            string sectionDisplayAlways = "- Settings: Display - Always -";
            string sectionDisplayOnKeyPress = "- Settings: Display - On 'Show HUD' key press";
            string sectionCrosshair = "- Crosshair -";

            string sectionDisplayHealth = "- Settings: Display - Health -";
            string sectionDisplayStamina = "- Settings: Display - Stamina -";
            string sectionDisplayFood = "- Settings: Display - Food -";

            string sectionDisplayPower = "- Settings: Display - Forsaken Power -";
            string sectionDisplayHotKeyBar = "- Settings: Display - Hot Key Bar -";
            string sectionDisplayStatusEffects = "- Settings: Display - Status Effects -";
            string sectionDisplayMiniMap = "- Settings: Display - MiniMap -";
            string sectionCompatibility = "- Compatibility -";
            string sectionCompatibilityQuickslots = "- Compatibility: Quickslots -";
            string sectionCompatibilityTime = "- Compatibility: Day and Time -";
            string sectionCompatibilityCompass = "- Compatibility: Compass -";
            string sectionCompatibilityFoodbar = "- Compatibility: Display - Food Bar -";
            string sectionCompatibilityDisplayAlways = "- Compatibility: Display - Always -";
            string sectionMisc = "- Misc -";

            // General
            isEnabled = Config.Bind<bool>(sectionGeneral, "Enable Mod", true, "Enable or disable the mod");
            nexusID = Config.Bind<int>(sectionGeneral, "NexusID", 2732, "Nexus mod ID for updates");

            // Main Settings --------------------------------------------------------------------------------
            hideHudKey = Config.Bind<KeyboardShortcut>(sectionMainSettings, "hideHudKey", new KeyboardShortcut(KeyCode.H), "Keyboard shortcut or mouse button to hide the hud permanently.");
            hudHiddenNotification = Config.Bind<bool>(sectionMainSettings, "hudHiddenNotification", true, "Enable notifications in the top left corner for hiding the hud.");
            hudFadeDuration = Config.Bind<float>(sectionMainSettings, "hudFadeDuration", 1f, "How quickly the hud fades in or out.");
            showHudDuration = Config.Bind<float>(sectionMainSettings, "showHudDuration", 1f, "How long a hud element should stay up for when it is activated for certain conditions.");
            showHudKey = Config.Bind<KeyboardShortcut>(sectionMainSettings, "showHudKey", new KeyboardShortcut(KeyCode.G), "Keyboard shortcut or mouse button to display the hud for a duration.");

            // Always Display Elements Settings --------------------------------------------------------------------------------
            displayHealthAlways = Config.Bind<bool>(sectionDisplayAlways, "Health bar", false, "Always display the health panel.");
            displayStaminaBarAlways = Config.Bind<bool>(sectionDisplayAlways, "Stamina bar", false, "Always display the stamina bar.");
            displayHotKeyBarAlways = Config.Bind<bool>(sectionDisplayAlways, "Hotkey bar", false, "Always display the hotbar.");
            displayForsakenPowerAlways = Config.Bind<bool>(sectionDisplayAlways, "Forsaken power", false, "Always display the forsaken power.");
            displayStatusEffectsAlways = Config.Bind<bool>(sectionDisplayAlways, "Status effects", false, "Always display status effects.");
            displayKeyHintsAlways = Config.Bind<bool>(sectionDisplayAlways, "Key hints", false, "Always display the key hints.");
            displayMiniMapAlways = Config.Bind<bool>(sectionDisplayAlways, "Minimap", false, "Always display the minimap.");
            displayCrosshairAlways = Config.Bind<bool>(sectionDisplayAlways, "Crosshair", true, "Always display the crosshair, overriding other display crosshair settings.");

            // Show on key press --------------------------------------------------------------------------------
            showHealthOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "Health bar", true, "Show the health panel when the show hud key is pressed.");
            showStaminaBarOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "Stamina bar", true, "Show the stamina bar when the show hud key is pressed.");
            showPowerOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "Forsaken power", true, "Show the forsaken power when the show hud key is pressed.");
            showKeyHintsOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "Key hints", true, "Show the key hints when the show hud key is pressed.");
            showHotKeyBarOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "Hotkey bar", true, "Show the hot key bar when the show hud key is pressed.");
            showStatusEffectsOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "Status effects", true, "Show the status effects when the show hud key is pressed.");
            showMiniMapOnKeyPressed = Config.Bind<bool>(sectionDisplayOnKeyPress, "Minimap", true, "Show the minimap when the show hud key is pressed.");

            // Display Scenario Settings - Health --------------------------------------------------------------------------------
            displayHealthOnDamage = Config.Bind<bool>(sectionDisplayHealth, "On damage", true, "Display the health panel when you take damage.");
            displayHealthOnDamageSeparateTimer = Config.Bind<bool>(sectionDisplayHealth, "Use separate timer for 'On damage'", false, "Separate timer for health panel displaying when you take damage.");
            displayHealthOnDamageDuration = Config.Bind<float>(sectionDisplayHealth, "Duration for time for 'On damage'", 1f, "Timer for health panel displaying when you take damage");
            displayHealthInInventory = Config.Bind<bool>(sectionDisplayHealth, "In inventory", true, "Display your health when in the inventory.");
            displayHealthWhenHungry = Config.Bind<bool>(sectionDisplayHealth, "When hungry", false, "Display the health panel when you are hungry.");
            displayHealthWhenEating = Config.Bind<bool>(sectionDisplayHealth, "When eating", false, "Display the health panel when you eat food.");
            displayHealthWhenBelow = Config.Bind<bool>(sectionDisplayHealth, "When below health threshold", true, "When you are at or below a certain health percentage, display the health panel.");
            displayHealthWhenFoodBelow = Config.Bind<bool>(sectionDisplayHealth, "When below food threshold", true, "When you are at or below a certain food percentage, display the health panel.");

            healthPercentage = Config.Bind<float>(sectionDisplayHealth, "Health percentage", 0.75f, new ConfigDescription("Health percentage at which the health panel should be displayed", new AcceptableValueRange<float>(0f, 1f)));

            // Display Scenario Settings - Stamina --------------------------------------------------------------------------------

            displayStaminaBarOnUse = Config.Bind<bool>(sectionDisplayStamina, "On use", true, "Display the stamina bar when stamina is used.");
            displayStaminaBarInInventory = Config.Bind<bool>(sectionDisplayStamina, "In inventory", true, "Display the stamina bar when in the inventory.");
            displayStaminaBarWhenHungry = Config.Bind<bool>(sectionDisplayStamina, "When hungry", false, "Display the stamina bar when you are hungry.");
            displayStaminaBarWhenEating = Config.Bind<bool>(sectionDisplayStamina, "When eating", true, "Display the stamina bar when you eat food.");
            displayStaminaBarWhenBelow = Config.Bind<bool>(sectionDisplayStamina, "When below stamina threshold", true, "When you are at or below a certain stamina percentage, display the stamina bar.");
            displayStaminaBarWhenFoodBelow = Config.Bind<bool>(sectionDisplayStamina, "When below food threshold", false, "When you are at or below a certain food percentage, display the stamina bar.");
            staminaPercentage = Config.Bind<float>(sectionDisplayStamina, "Stamina percentage", 0.99f, new ConfigDescription("Stamina percentage at which the stamina bar should be displayed.", new AcceptableValueRange<float>(0f, 1f)));

            // Display Scenario Settings - Food --------------------------------------------------------------------------------
            foodHungerAmount = Config.Bind<int>(sectionDisplayFood, "foodHungerAmount", 3, new ConfigDescription("The minimum amount of food icons that need to be flashing to be considered hungry.", new AcceptableValueRange<int>(1, 3)));
            foodPercentage = Config.Bind<float>(sectionDisplayFood, "foodPercentage", 0.35f, new ConfigDescription("Food percentage at which the food bar, health, or stamina should be displayed.", new AcceptableValueRange<float>(0f, 1f)));

            // Display Scenario Settings - Forsaken Power --------------------------------------------------------------------------------
            displayPowerInInventory = Config.Bind<bool>(sectionDisplayPower, "In inventory", true, "Display the forsaken power when in the inventory.");
            displayPowerOnActivation = Config.Bind<bool>(sectionDisplayPower, "On activation", false, "Display the forsaken power when the key to use it is pressed.");

            // Display Scenario Settings - Hot Key Bar --------------------------------------------------------------------------------
            displayHotKeyBarInInventory = Config.Bind<bool>(sectionDisplayHotKeyBar, "In inventory", true, "Display the hot key bar when in the inventory.");
            displayHotKeyBarOnItemSwitch = Config.Bind<bool>(sectionDisplayHotKeyBar, "On item switch", false, "Display the hot key bar when you press any key for your hot bar items.");
            displayHotKeyBarWhenItemEquipped = Config.Bind<bool>(sectionDisplayHotKeyBar, "On equipped item", false, "Display the hot key bar when you have an item equipped in either hand.");

            // Display Scenario Settings - Status Effects --------------------------------------------------------------------------------
            displayStatusEffectsInInventory = Config.Bind<bool>(sectionDisplayStatusEffects, "In inventory", true, "Display status effects when in the inventory.");

            // Display Scenario Settings - MiniMap --------------------------------------------------------------------------------
            displayMiniMapInInventory = Config.Bind<bool>(sectionDisplayMiniMap, "displayMiniMapInInventory", true, "Display the minimap when in the inventory.");

            // Crosshair Settings --------------------------------------------------------------------------------
            useCustomCrosshair = Config.Bind<bool>(sectionCrosshair, "useCustomCrosshair", false, new ConfigDescription("Enable or disable the new crosshair.", null, new ConfigurationManagerAttributes { Order = 1 }));
            useCustomBowCrosshair = Config.Bind<bool>(sectionCrosshair, "useCustomBowCrosshair", false, new ConfigDescription("Enable or disable the new crosshair for the bow draw.", null, new ConfigurationManagerAttributes { Order = 2 }));
            crosshairColor = Config.Bind<Color>(sectionCrosshair, "crosshairColor", Color.white, "Color and transparency of the crosshair.");
            crosshairBowDrawColor = Config.Bind<Color>(sectionCrosshair, "crosshairBowDrawColor", Color.yellow, "Color and transparency of the bow draw crosshair.");
            disableStealthHud = Config.Bind<bool>(sectionCrosshair, "disableStealthHud", false, "Disable the stealth bar and indicator so it doesn't display.");
            displayBowDrawCrosshair = Config.Bind<bool>(sectionCrosshair, "displayBowDrawCrosshair", true, "Display the bow draw crosshair.");
            displayCrosshairWhenBuilding = Config.Bind<bool>(sectionCrosshair, "displayCrosshairWhenBuilding", true, "Display the crosshair when you have the hammer equipped.");
            displayCrosshairOnActivation = Config.Bind<bool>(sectionCrosshair, "displayCrosshairOnActivation", false, "Display crosshair when hovering over an activatable object.");
            displayCrosshairOnEquipped = Config.Bind<bool>(sectionCrosshair, "displayCrosshairOnEquipped", false, "Display crosshair when an item is equipped in either hand.");
            displayCrosshairOnBowEquipped = Config.Bind<bool>(sectionCrosshair, "displayCrosshairOnBowEquipped", false, "Display crosshair when the bow is equipped.");

            // Compatibility --------------------------------------------------------------------------------
            AzuMinimalUiEnabled = Config.Bind<bool>(sectionCompatibility, "Minimal UI", false, "Enable compatibility for Azumatt's MinimalUI mod.");
            AzuQuickSlotsEnabled = Config.Bind<bool>(sectionCompatibility, "AzuExtendedPlayerInventory", false, "Enable compatibility for Azumatt's ExtendedPlayerInventory mod.");
            RandyQuickSlotsEnabled = Config.Bind<bool>(sectionCompatibility, "Equipment and Quick Slots", false, "Enable compatibility for quickslots mod.");
            aedenCompassEnabled = Config.Bind<bool>(sectionCompatibility, "Compass", false, "Enable compatibility for aedenthorn's compass mod.");
            BetterUIEnabled = Config.Bind<bool>(sectionCompatibility, "BetterUI", false, "Enable compatibility for Better UI.");
            oryxenTimeEnabled = Config.Bind<bool>(sectionCompatibility, "Display Day and Time in HUD", false, "Enable compatibility for oryxen's display day and time mod.");

            // Display Scenario Settings - Quick Slots --------------------------------------------------------------------------------
            displayQuickSlotsInInventory = Config.Bind<bool>(sectionCompatibilityQuickslots, "In inventory", false, "Display quick slots when in the inventory.");
            showQuickSlotsOnKeyPressed = Config.Bind<bool>(sectionCompatibilityQuickslots, "On key pressed", false, "Show the quick slots when the show hud key is pressed.");
            displayQuickSlotsAlways = Config.Bind<bool>(sectionDisplayAlways, "Always display QuickSlots", false, "Always display the quick slots (Requires 'AzuExtendedInventory' or 'Equipment and Quick Slots').");

            // Display Scenario Settings - Compass --------------------------------------------------------------------------------
            displayCompassInInventory = Config.Bind<bool>(sectionCompatibilityCompass, "In inventory", false, "Display the compass when in the inventory.");
            showCompassOnKeyPressed = Config.Bind<bool>(sectionCompatibilityCompass, "On key pressed", false, "Show the compass when the show hud key is pressed.");
            displayCompassAlways = Config.Bind<bool>(sectionCompatibilityCompass, "Always", false, "Always display the compass (Requires aedenthorn's compass).");

            // Display Scenario Settings - Food Bar (Better UI) --------------------------------------------------------------------------------
            displayFoodBarInInventory = Config.Bind<bool>(sectionCompatibilityFoodbar, "displayBetterUIFoodBarInInventory", true, "Display the food bar when in the inventory.");
            displayFoodBarWhenHungry = Config.Bind<bool>(sectionCompatibilityFoodbar, "displayFoodBarWhenHungry", true, "Display the food bar when you are hungry.");
            displayFoodBarWhenEating = Config.Bind<bool>(sectionCompatibilityFoodbar, "displayFoodBarWhenEating", true, "Display the food bar when you eat food.");
            displayFoodBarWhenBelow = Config.Bind<bool>(sectionCompatibilityFoodbar, "displayFoodBarWhenBelow", true, "When you are at or below a certain food percentage, display the food bar.");
            showFoodBarOnKeyPressed = Config.Bind<bool>(sectionCompatibilityFoodbar, "showFoodBarOnKeyPressed", true, "Display the food bar when the show hud key is pressed.");
            displayBetterUIFoodAlways = Config.Bind<bool>(sectionCompatibilityFoodbar, "displayBetterUIFoodAlways", false, "Always display the food bar (Requires Better UI).");
            hungerNotification = Config.Bind<bool>(sectionCompatibilityFoodbar, "hungerNotification", false, "Enable notifications for when you are hungry.");
            hungerNotificationInterval = Config.Bind<int>(sectionCompatibilityFoodbar, "hungerNotificationInterval", 25, new ConfigDescription("How often the notification should display in seconds.", new AcceptableValueRange<int>(5, 180)));
            hungerNotificationOption = Config.Bind<hungerNotificationOptions>(sectionCompatibilityFoodbar, "hungerNotificationOption", hungerNotificationOptions.FoodPercentage, new ConfigDescription("Option to be used for notifications."));
            hungerNotificationText = Config.Bind<string>(sectionCompatibilityFoodbar, "hungerNotificationText", "I'm feeling a bit peckish.", "Message for hunger notification.");
            hungerNotificationType = Config.Bind<notificationTypes>(sectionCompatibilityFoodbar, "hungerNotificationType", notificationTypes.SmallTopLeft, new ConfigDescription("Notification types for the hunger notification."));

            // Display Scenario Settings - Clock and Day Time --------------------------------------------------------------------------------
            displayTimeInInventory = Config.Bind<bool>(sectionCompatibilityTime, "displayTimeInInventory", false, "Display the time when in the inventory.");
            showTimeOnKeyPressed = Config.Bind<bool>(sectionCompatibilityTime, "showTimeOnKeyPressed", false, "Show the time when the show hud key is pressed.");
            displayTimeAlways = Config.Bind<bool>(sectionCompatibilityTime, "displayTimeAlways", false, "Always display the time or clock (Requires oryxen's display day and time mod).");

            // Misc --------------------------------------------------------------------------------
            hudHiddenOnStart = Config.Bind<bool>(sectionMisc, "hudHiddenOnStart", false, "Hide the hud when the game is started.");
        }
    }
}