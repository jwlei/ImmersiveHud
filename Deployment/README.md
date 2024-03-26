Continuation/Mistlands port of Manfredo52's ImmersiveHud until the author updates the mod again

Please report any bugs here https://github.com/jwlei/ImmersiveHud/issues

## Features:﻿
Enable or disable your hud elements with the press of a dedicated key that you can set in the options. When the key is pressed, the hud
will be hidden permanently.
How quickly the hud elements fade in and out can be controlled in the settings.
Show the hud by pressing a key to show it for a specific amount of time,
that can be changed. Which hud elements that are affected by this can be chosen.
You can set whether or not the hud should be hidden when the game starts.
Edit settings related to the crosshair such as its color and using a new
crosshair style for normal gameplay and when the bow is being drawn. Crosshair styles can be replaced with your own images (however not all images may be suitable) and turning on or off custom crosshairs requires a relog.
Control when the crosshair should show for different scenarios such as when
equipping an item, using a bow, or looking at an activatable object.
Conditional display settings. Hud elements can display on certain conditions such
as when your health is below a certain percentage, when you switch items on your hot bar, or display at all times. More options to display hud elements when you are hungry as well.
Each hud element has its own set of settings that you can mess around with!


## Installation:
- Install BepInEx
- Install Enhanced BepInEx Configuration Manager
- Then install using Vortex or manually placing ImmersiveHud.dll file and ImmersiveHud folder into BepinEx/plugins folder.


## Compatibility
I cannot ensure compatibility for every mod out there however this mod was made with other UI-related mods in mind so the goal is to keep
compatibility for those mods. For enabling compatibility options, look at the mod compatibility section in the configuration! Feel free to report any compatibility issues with other UI mods.

- Better UI (Compatible)
﻿- Custom UI (Compatible)
﻿- Equipment and Quick Slots (Compatible)


## Settings
General
EnableMod: Enable or disable the mod.
NexusID: Nexus mod ID for updates.

Main
hideHudKey: Keyboard shortcut or mouse button to permanently hide the hud.
hideHudOnStart: Hide the hud when the game starts.
hudHiddenNotification: Enable notifications in the top left corner for hiding the hud.
hudFadeDuration: How quickly the hud fades in and out.
showHudDuration: How long a hud element should stay up for on pressing the show hud key.
showHudKey: Keyboard shortcut or mouse button to display the hud elements affected.

Compatibility
quickSlotsEnabled: Enable compatibility for equipment and quickslots mod.
betterUIHPEnabled: Enable compatibility for Better UI's custom HP bar.
betterUIFoodEnabled: Enable compatibility for Better UI's custom food bar.
betterUIStamEnabled: Enable compatibility for Better UI's custom stamina bar.
aedenCompassEnabled: Enable compatibility for Aedenthorn's compass mod.
oryxenTimeEnabled: Enable compatibility for oryxen's display day and time compass mod.

Crosshair
useCustomCrosshair: Enable or disable the new crosshair.
useCustomBowCrosshair: Enable or disable the new crosshair for the bow draw.
crosshairColor: Color and transparency of the crosshair.
crosshairBowDrawColor: Color and transparency of the bow draw crosshair.
disableStealthHud: Disable the stealth bar and indicator so it doesn't display.
displayCrosshairAlways: Always display the crosshair, overriding other display crosshair settings.
displayBowDrawCrosshair: Display the bow draw crosshair.
displayCrosshairOnActivation: Display crosshair when hovering over an activatable object.
displayCrosshairOnEquipped: Display crosshair when an item is equipped in either hand.
displayCrosshairOnBowEquipped: Display crosshair when the bow is equipped.

Display Settings - In the actual configuration, each hud element has its own settings.
displayAlways: Always display the hud element.
displayInInventory: Display the hud element when you are in your inventory.
showOnKeyPressed: Show the hud element when you press the showHud key.

Display - Health
displayHealthWhenHungry: Display the health panel when you are hungry.
displayHealthWhenEating: Display the health panel when you eat food.
displayHealthWhenBelow: When you are at or below a certain health percentage, display the health panel.
displayHealthWhenFoodBelow: When you are at or below a certain food percentage, display the health panel.
healthPercentage: Health percentage at which the health panel should be displayed.

Display - Food
foodHungerAmount: The minimum amount of food icons that need to be flashing to be considered hungry.
foodPercentage: Food percentage at which the food bar, health, or stamina should be displayed.
hungerNotification: Enable notifications for when you are hungry.
hungerNotificationInterval: How often the notification should display in seconds.
hungerNotificationOption: Option to be used for notifications.
hungerNotificationText: Message for hunger notification.
hungerNotificationType: Notification types for the hunger notification.

Display - Food Bar (Better UI)
displayFoodBarWhenHungry: Display the food bar when you are hungry.
displayFoodBarWhenEating: Display the food bar when you eat food.
displayFoodBarWhenBelow: When you are at or below a certain food percentage, display the food bar..

Display - Forsaken Power
displayPowerOnActivation: Display the forsaken power when the key to use it is pressed.

Display - Hot Key Bar
displayHotKeyBarOnItemSwitch: Display the hot key bar when you press any key for your hot bar items.

Display - Status Effects
See "Display Settings"

Display - Stamina
displayStaminaBarOnUse: Display the stamina bar when stamina is used.
displayStaminaBarWhenHungry: Display the stamina bar when you are hungry.
displayStaminaBarWhenEating: Display the stamina bar when you eat food.
displayStaminaBarWhenBelow: When you are at or below a certain stamina percentage, display the stamina bar.
displayStaminaBarWhenFoodBelow: When you are at or below a certain food percentage, display the stamina bar.
staminaPercentage: Stamina percentage at which the stamina bar should be displayed.

Display - Mini Map
See "Display Settings"

Display - Compass (Aedenthorn's Compass)
See "Display Settings"

Display - Quick Slots
See "Display Settings"