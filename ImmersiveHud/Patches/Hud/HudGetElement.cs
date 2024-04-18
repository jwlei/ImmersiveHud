using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        private static string GetHealthbarElement()
        {
            string healthbar;
            if (AzuMinimalUiEnabled.Value && hudElements["MUI_HPBar"].exists)
            {
                healthbar = "MUI_HPBar";
            }
            else if (BetterUIEnabled.Value && hudElements["BetterUI_HPBar"].exists)
            {
                healthbar = "BetterUI_HPBar";
            }
            else
            {
                healthbar = "healthpanel";
            }
            return healthbar;
        }

        private static string GetStaminabarElement()
        {
            string staminabar;
            if (AzuMinimalUiEnabled.Value && hudElements["MUI_StaminaBar"].exists)
            {
                staminabar = "MUI_StaminaBar";
            }
            else if (BetterUIEnabled.Value && hudElements["BetterUI_StaminaBar"].exists)
            {
                staminabar = "BetterUI_StaminaBar";
            }
            else
            {
                staminabar = "staminapanel";
            }

            return staminabar;
        }

        private static string GetQuickslotElement()
        {
            string quickslot;
            if (AzuQuickSlotsEnabled.Value && hudElements["QuickAccessBar"].exists)
            {
                quickslot = "QuickAccessBar";
            }
            else if (RandyQuickSlotsEnabled.Value && hudElements["QuickSlotsHotkeyBar"].exists)
            {
                quickslot = "QuickSlotsHotkeyBar";
            }
            else
            {
                quickslot = "";
            }

            return quickslot;
        }

        private static string GetMinimapElement()
        {
            string minimap;
            if (muiMinimap.Value && hudElements["MUIMap"].exists)
            {
                minimap = "MUIMap";
            }
            else if (hudElements["Minimap"].exists)
            {
                minimap = "Minimap";
            }
            else
            {
                minimap = "";
            }
            return minimap;
        }
    }
}