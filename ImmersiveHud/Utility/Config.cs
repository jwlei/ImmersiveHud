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
        public static ConfigEntry<bool> displayRandyQuickSlotsAlways;
        public static ConfigEntry<bool> displayBetterUIFoodAlways;
        public static ConfigEntry<bool> displayCompassAlways;
        public static ConfigEntry<bool> displayTimeAlways;
        public static ConfigEntry<bool> displayAzuQuickSlotsAlways;

        // Compatibility Settings
        public static ConfigEntry<bool> RandyQuickSlotsEnabled;

        public static ConfigEntry<bool> betterUIHPEnabled;
        public static ConfigEntry<bool> betterUIFoodEnabled;
        public static ConfigEntry<bool> betterUIStamEnabled;
        public static ConfigEntry<bool> aedenCompassEnabled;
        public static ConfigEntry<bool> oryxenTimeEnabled;
        public static ConfigEntry<bool> AzuQuickSlotsEnabled;

        // Hud Element - Health
        public static ConfigEntry<bool> displayHealthInInventory;

        public static ConfigEntry<bool> displayHealthWhenHungry;
        public static ConfigEntry<bool> displayHealthOnDamage;
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
            // General
            isEnabled = Config.Bind<bool>("- General -", "Enable Mod", true, "Enable or disable the mod");
            nexusID = Config.Bind<int>("- General -", "NexusID", 2732, "Nexus mod ID for updates");

            // Main Settings
            hideHudKey = Config.Bind<KeyboardShortcut>("- Main Settings -", "hideHudKey", new KeyboardShortcut(KeyCode.H), "Keyboard shortcut or mouse button to hide the hud permanently.");
            hudHiddenOnStart = Config.Bind<bool>("- Main Settings -", "hudHiddenOnStart", false, "Hide the hud when the game is started.");
            hudHiddenNotification = Config.Bind<bool>("- Main Settings -", "hudHiddenNotification", true, "Enable notifications in the top left corner for hiding the hud.");
            hudFadeDuration = Config.Bind<float>("- Main Settings -", "hudFadeDuration", 1f, "How quickly the hud fades in or out.");
            showHudDuration = Config.Bind<float>("- Main Settings -", "showHudDuration", 1f, "How long a hud element should stay up for when it is activated for certain conditions.");
            showHudKey = Config.Bind<KeyboardShortcut>("- Main Settings -", "showHudKey", new KeyboardShortcut(KeyCode.G), "Keyboard shortcut or mouse button to display the hud for a duration.");

            // Compatibility
            RandyQuickSlotsEnabled = Config.Bind<bool>("- Mod Compatibility -", "RandyQuickSlotsEnabled", false, "Enable compatibility for quickslots mod.");
            betterUIHPEnabled = Config.Bind<bool>("- Mod Compatibility -", "betterUIHPEnabled", false, "Enable compatibility for Better UI's custom HP bar.");
            betterUIFoodEnabled = Config.Bind<bool>("- Mod Compatibility -", "betterUIFoodEnabled", false, "Enable compatibility for Better UI's custom food bar.");
            betterUIStamEnabled = Config.Bind<bool>("- Mod Compatibility -", "betterUIStamEnabled", false, "Enable compatibility for Better UI's custom stamina bar.");
            aedenCompassEnabled = Config.Bind<bool>("- Mod Compatibility -", "aedenCompassEnabled", false, "Enable compatibility for aedenthorn's compass mod.");
            oryxenTimeEnabled = Config.Bind<bool>("- Mod Compatibility -", "oryxenTimeEnabled", false, "Enable compatibility for oryxen's display day and time mod.");

            // Crosshair Settings
            useCustomCrosshair = Config.Bind<bool>("- Settings: Crosshair -", "useCustomCrosshair", false, new ConfigDescription("Enable or disable the new crosshair.", null, new ConfigurationManagerAttributes { Order = 1 }));
            useCustomBowCrosshair = Config.Bind<bool>("- Settings: Crosshair -", "useCustomBowCrosshair", false, new ConfigDescription("Enable or disable the new crosshair for the bow draw.", null, new ConfigurationManagerAttributes { Order = 2 }));
            crosshairColor = Config.Bind<Color>("- Settings: Crosshair -", "crosshairColor", Color.white, "Color and transparency of the crosshair.");
            crosshairBowDrawColor = Config.Bind<Color>("- Settings: Crosshair -", "crosshairBowDrawColor", Color.yellow, "Color and transparency of the bow draw crosshair.");
            disableStealthHud = Config.Bind<bool>("- Settings: Crosshair -", "disableStealthHud", false, "Disable the stealth bar and indicator so it doesn't display.");
            displayCrosshairAlways = Config.Bind<bool>("- Settings: Crosshair -", "displayCrosshairAlways", true, "Always display the crosshair, overriding other display crosshair settings.");
            displayBowDrawCrosshair = Config.Bind<bool>("- Settings: Crosshair -", "displayBowDrawCrosshair", true, "Display the bow draw crosshair.");
            displayCrosshairWhenBuilding = Config.Bind<bool>("- Settings: Crosshair -", "displayCrosshairWhenBuilding", true, "Display the crosshair when you have the hammer equipped.");
            displayCrosshairOnActivation = Config.Bind<bool>("- Settings: Crosshair -", "displayCrosshairOnActivation", false, "Display crosshair when hovering over an activatable object.");
            displayCrosshairOnEquipped = Config.Bind<bool>("- Settings: Crosshair -", "displayCrosshairOnEquipped", false, "Display crosshair when an item is equipped in either hand.");
            displayCrosshairOnBowEquipped = Config.Bind<bool>("- Settings: Crosshair -", "displayCrosshairOnBowEquipped", false, "Display crosshair when the bow is equipped.");

            // Display Elements Settings
            displayHealthAlways = Config.Bind<bool>("- Settings: Display -", "displayHealthAlways", false, "Always display the health panel.");
            displayHotKeyBarAlways = Config.Bind<bool>("- Settings: Display -", "displayHotbarAlways", false, "Always display the hotbar.");
            displayForsakenPowerAlways = Config.Bind<bool>("- Settings: Display -", "displayForsakenPowerAlways", false, "Always display the forsaken power.");
            displayStatusEffectsAlways = Config.Bind<bool>("- Settings: Display -", "displayStatusEffectsAlways", false, "Always display status effects.");
            displayStaminaBarAlways = Config.Bind<bool>("- Settings: Display -", "displayStaminaBarAlways", false, "Always display the stamina bar.");
            displayMiniMapAlways = Config.Bind<bool>("- Settings: Display -", "displayMiniMapAlways", false, "Always display the minimap.");
            displayRandyQuickSlotsAlways = Config.Bind<bool>("- Settings: Display -", "displayRandyQuickSlotsAlways", false, "Always display the quick slots (Requires quick slots mod).");
            displayAzuQuickSlotsAlways = Config.Bind<bool>("- Settings: Display -", "displayAzuQuickSlotsAlways", false, "Always display the quick slots (Requires AzuExtendedPlayerInventory).");
            displayBetterUIFoodAlways = Config.Bind<bool>("- Settings: Display -", "displayBetterUIFoodAlways", false, "Always display the food bar (Requires Better UI).");
            displayCompassAlways = Config.Bind<bool>("- Settings: Display -", "displayCompassAlways", false, "Always display the compass (Requires aedenthorn's compass).");
            displayTimeAlways = Config.Bind<bool>("- Settings: Display -", "displayTimeAlways", false, "Always display the time or clock (Requires oryxen's display day and time mod).");
            displayKeyHintsAlways = Config.Bind<bool>("- Settings: Display -", "displayKeyHintsAlways", false, "Always display the key hints.");

            // Display Scenario Settings - Health
            displayHealthOnDamage = Config.Bind<bool>("- Settings: Display - Health -", "displayHealthOnDamage", true, "Display the health panel when you take damage.");
            displayHealthInInventory = Config.Bind<bool>("Display - Health", "displayHealthInInventory", true, "Display your health when in the inventory.");
            displayHealthWhenHungry = Config.Bind<bool>("Display - Health", "displayHealthWhenHungry", false, "Display the health panel when you are hungry.");
            displayHealthWhenEating = Config.Bind<bool>("Display - Health", "displayHealthWhenEating", false, "Display the health panel when you eat food.");
            displayHealthWhenBelow = Config.Bind<bool>("Display - Health", "displayHealthWhenBelow", true, "When you are at or below a certain health percentage, display the health panel.");
            displayHealthWhenFoodBelow = Config.Bind<bool>("Display - Health", "displayHealthWhenFoodBelow", true, "When you are at or below a certain food percentage, display the health panel.");
            healthPercentage = Config.Bind<float>("Display - Health", "healthPercentage", 0.75f, new ConfigDescription("Health percentage at which the health panel should be displayed", new AcceptableValueRange<float>(0f, 1f)));
            showHealthOnKeyPressed = Config.Bind<bool>("Display - Health", "showHealthOnKeyPressed", true, "Show the health panel when the show hud key is pressed.");

            // Display Scenario Settings - Food
            foodHungerAmount = Config.Bind<int>("Display - Food", "foodHungerAmount", 3, new ConfigDescription("The minimum amount of food icons that need to be flashing to be considered hungry.", new AcceptableValueRange<int>(1, 3)));
            foodPercentage = Config.Bind<float>("Display - Food", "foodPercentage", 0.35f, new ConfigDescription("Food percentage at which the food bar, health, or stamina should be displayed.", new AcceptableValueRange<float>(0f, 1f)));
            hungerNotification = Config.Bind<bool>("Display - Food", "hungerNotification", false, "Enable notifications for when you are hungry.");
            hungerNotificationInterval = Config.Bind<int>("Display - Food", "hungerNotificationInterval", 25, new ConfigDescription("How often the notification should display in seconds.", new AcceptableValueRange<int>(5, 180)));
            hungerNotificationOption = Config.Bind<hungerNotificationOptions>("Display - Food", "hungerNotificationOption", hungerNotificationOptions.FoodPercentage, new ConfigDescription("Option to be used for notifications."));
            hungerNotificationText = Config.Bind<string>("Display - Food", "hungerNotificationText", "I'm feeling a bit peckish.", "Message for hunger notification.");
            hungerNotificationType = Config.Bind<notificationTypes>("Display - Food", "hungerNotificationType", notificationTypes.SmallTopLeft, new ConfigDescription("Notification types for the hunger notification."));

            // Display Scenario Settings - Food Bar (Better UI)
            displayFoodBarInInventory = Config.Bind<bool>("Display - Food Bar (Better UI)", "displayBetterUIFoodBarInInventory", true, "Display the food bar when in the inventory.");
            displayFoodBarWhenHungry = Config.Bind<bool>("Display - Food Bar (Better UI)", "displayFoodBarWhenHungry", true, "Display the food bar when you are hungry.");
            displayFoodBarWhenEating = Config.Bind<bool>("Display - Food Bar (Better UI)", "displayFoodBarWhenEating", true, "Display the food bar when you eat food.");
            displayFoodBarWhenBelow = Config.Bind<bool>("Display - Food Bar (Better UI)", "displayFoodBarWhenBelow", true, "When you are at or below a certain food percentage, display the food bar.");
            showFoodBarOnKeyPressed = Config.Bind<bool>("Display - Food Bar (Better UI)", "showFoodBarOnKeyPressed", true, "Display the food bar when the show hud key is pressed.");

            // Display Scenario Settings - Stamina
            displayStaminaBarInInventory = Config.Bind<bool>("Display - Stamina Bar", "displayStaminaBarInInventory", true, "Display the stamina bar when in the inventory.");
            displayStaminaBarOnUse = Config.Bind<bool>("Display - Stamina Bar", "displayStaminaBarOnUse", true, "Display the stamina bar when stamina is used.");
            displayStaminaBarWhenHungry = Config.Bind<bool>("Display - Stamina Bar", "displayStaminaBarWhenHungry", false, "Display the stamina bar when you are hungry.");
            displayStaminaBarWhenEating = Config.Bind<bool>("Display - Stamina Bar", "displayStaminaBarWhenEating", true, "Display the stamina bar when you eat food.");
            displayStaminaBarWhenBelow = Config.Bind<bool>("Display - Stamina Bar", "displayStaminaBarWhenBelow", true, "When you are at or below a certain stamina percentage, display the stamina bar.");
            displayStaminaBarWhenFoodBelow = Config.Bind<bool>("Display - Stamina Bar", "displayStaminaBarWhenFoodBelow", false, "When you are at or below a certain food percentage, display the stamina bar.");
            staminaPercentage = Config.Bind<float>("Display - Stamina Bar", "staminaPercentage", 0.99f, new ConfigDescription("Stamina percentage at which the stamina bar should be displayed.", new AcceptableValueRange<float>(0f, 1f)));
            showStaminaBarOnKeyPressed = Config.Bind<bool>("Display - Stamina Bar", "showStaminaBarOnKeyPressed", true, "Show the stamina bar when the show hud key is pressed.");

            // Display Scenario Settings - Forsaken Power
            displayPowerInInventory = Config.Bind<bool>("Display - Forsaken Power", "displayPowerInInventory", true, "Display the forsaken power when in the inventory.");
            displayPowerOnActivation = Config.Bind<bool>("Display - Forsaken Power", "displayPowerOnActivation", false, "Display the forsaken power when the key to use it is pressed.");
            //displayPowerWhenTimeChanges
            //displayPowerOnReady
            showPowerOnKeyPressed = Config.Bind<bool>("Display - Forsaken Power", "showPowerOnKeyPressed", true, "Show the forsaken power when the show hud key is pressed.");
            showKeyHintsOnKeyPressed = Config.Bind<bool>("Display - Key Hints", "showKeyHintsOnKeyPressed", true, "Show the key hints when the show hud key is pressed.");

            // Display Scenario Settings - Hot Key Bar
            displayHotKeyBarInInventory = Config.Bind<bool>("Display - Hot Key Bar", "displayHotKeyBarInInventory", true, "Display the hot key bar when in the inventory.");
            displayHotKeyBarOnItemSwitch = Config.Bind<bool>("Display - Hot Key Bar", "displayHotKeyBarOnItemSwitch", false, "Display the hot key bar when you press any key for your hot bar items.");
            displayHotKeyBarWhenItemEquipped = Config.Bind<bool>("Display - Hot Key Bar", "displayHotKeyBarWhenItemEquipped", false, "Display the hot key bar when you have an item equipped in either hand.");
            showHotKeyBarOnKeyPressed = Config.Bind<bool>("Display - Hot Key Bar", "showHotKeyBarOnKeyPressed", true, "Show the hot key bar when the show hud key is pressed.");

            // Display Scenario Settings - Status Effects
            displayStatusEffectsInInventory = Config.Bind<bool>("Display - Status Effects", "displayStatusEffectsInInventory", true, "Display status effects when in the inventory.");
            showStatusEffectsOnKeyPressed = Config.Bind<bool>("Display - Status Effects", "showStatusEffectsOnKeyPressed", true, "Show the status effects when the show hud key is pressed.");

            // Display Scenario Settings - MiniMap
            displayMiniMapInInventory = Config.Bind<bool>("Display - MiniMap", "displayMiniMapInInventory", true, "Display the minimap when in the inventory.");
            showMiniMapOnKeyPressed = Config.Bind<bool>("Display - MiniMap", "showMiniMapOnKeyPressed", true, "Show the minimap when the show hud key is pressed.");

            // Display Scenario Settings - Compass
            displayCompassInInventory = Config.Bind<bool>("Display - Compass", "displayCompassInInventory", false, "Display the compass when in the inventory.");
            showCompassOnKeyPressed = Config.Bind<bool>("Display - Compass", "showCompassOnKeyPressed", false, "Show the compass when the show hud key is pressed.");

            // Display Scenario Settings - Clock and Day Time
            displayTimeInInventory = Config.Bind<bool>("Display - Day and Time", "displayTimeInInventory", false, "Display the time when in the inventory.");
            showTimeOnKeyPressed = Config.Bind<bool>("Display - Day and Time", "showTimeOnKeyPressed", false, "Show the time when the show hud key is pressed.");

            // Display Scenario Settings - Quick Slots
            displayQuickSlotsInInventory = Config.Bind<bool>("Display - Quick Slots", "displayQuickSlotsInInventory", false, "Display quick slots when in the inventory.");
            //displayQuickSlotsOnItemSwitch = ImmersiveHud.Bind<bool>("Display - Quick Slots", "displayQuickSlotsOnItemSwitch", false, "Display the quick slots when you press any key for your quick slot items.");
            showQuickSlotsOnKeyPressed = Config.Bind<bool>("Display - Quick Slots", "showQuickSlotsOnKeyPressed", false, "Show the quick slots when the show hud key is pressed.");

            // Crosshair Sprites
        }
    }
}