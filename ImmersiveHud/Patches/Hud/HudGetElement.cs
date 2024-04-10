using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmersiveHud
{
    public partial class ImmersiveHud
    {
        private static string GetHealthbarElement()
        {
            string elementName;
            if (AzuMinimalUiEnabled.Value && hudElements["MUI_HPBar"].exists)
            {
                elementName = "MUI_HPBar";
            }
            else if (BetterUIEnabled.Value && hudElements["BetterUI_HPBar"].exists)
            {
                elementName = "BetterUI_HPBar";
            }
            else
            {
                elementName = "healthpanel";
            }

            return elementName;
        }

        private static string GetStaminabarElement()
        {
            string elementName;
            if (AzuMinimalUiEnabled.Value && hudElements["MUI_StaminaBar"].exists)
            {
                elementName = "MUI_StaminaBar";
            }
            else if (BetterUIEnabled.Value && hudElements["BetterUI_StaminaBar"].exists)
            {
                elementName = "BetterUI_StaminaBar";
            }
            else
            {
                elementName = "staminapanel";
            }

            return elementName;
        }

        private static string GetQuickslotElement()
        {
            string elementName;
            if (AzuQuickSlotsEnabled.Value && hudElements["QuickAccessBar"].exists)
            {
                elementName = "QuickAccessBar";
            }
            else if (RandyQuickSlotsEnabled.Value && hudElements["QuickSlotsHotkeyBar"].exists)
            {
                elementName = "QuickSlotsHotkeyBar";
            }
            else
            {
                elementName = "";
            }

            return elementName;
        }
    }
}