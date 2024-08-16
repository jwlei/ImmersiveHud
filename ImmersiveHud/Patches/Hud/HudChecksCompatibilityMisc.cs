using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        private static void CheckCompass()
        {
            if (aedenCompassEnabled.Value && hudElements["Compass"].exists)
            {
                if (displayCompassAlways.Value || (displayCompassInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["Compass"].targetAlpha = 1;

                    if (!displayCompassInInventory.Value && InventoryGui.IsVisible())
                        hudElements["Compass"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["Compass"].HudSetTargetAlpha(0);
                }
            }
        }

        private static void CheckDayTime()
        {
            // Day and Time Display
            if (oryxenTimeEnabled.Value && hudElements["DayTimePanel"].exists)
            {
                if (displayTimeAlways.Value || (displayTimeInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["DayTimePanel"].targetAlpha = 1;

                    if (!displayTimeInInventory.Value && InventoryGui.IsVisible())
                        hudElements["DayTimePanel"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["DayTimePanel"].HudSetTargetAlpha(0);
                }
            }

            if (MyLittleUIEnabled.Value && hudElements["MLUI_Clock"].exists)
            {
                if (displayTimeAlways.Value || (displayTimeInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["MLUI_Clock"].targetAlpha = 1;

                    if (!displayTimeInInventory.Value && InventoryGui.IsVisible())
                        hudElements["MLUI_Clock"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["MLUI_Clock"].HudSetTargetAlpha(0);
                }
            }
            
        }

        private static void CheckRandyQuickSlots()
        {
            // QuickSlots Display
            if (RandyQuickSlotsEnabled.Value && hudElements["QuickSlotsHotkeyBar"].exists)
            {
                if (displayQuickSlotsAlways.Value || (displayQuickSlotsInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["QuickSlotsHotkeyBar"].targetAlpha = 1;

                    if (!displayQuickSlotsInInventory.Value && InventoryGui.IsVisible())
                        hudElements["QuickSlotsHotkeyBar"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["QuickSlotsHotkeyBar"].HudSetTargetAlpha(0);
                }
            }
        }

        private static void CheckAzuQuickSlots()
        {
            // QuickSlots Display
            if (AzuQuickSlotsEnabled.Value && hudElements["QuickAccessBar"].exists)
            {
                if (displayQuickSlotsAlways.Value || (displayQuickSlotsInInventory.Value && InventoryGui.IsVisible()))
                {
                    hudElements["QuickAccessBar"].targetAlpha = 1;

                    if (!displayQuickSlotsInInventory.Value && InventoryGui.IsVisible())
                        hudElements["QuickAccessBar"].HudSetTargetAlpha(0);
                }
                else
                {
                    hudElements["QuickAccessBar"].HudSetTargetAlpha(0);
                }
            }
        }
    }
}