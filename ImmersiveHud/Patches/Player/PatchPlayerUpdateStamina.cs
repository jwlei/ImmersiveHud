//using HarmonyLib;
//using UnityEngine;

//namespace ImmersiveHud
//{
//    public partial class ImmersiveHud
//    {
//        //[HarmonyPatch(typeof(Hud), "UpdateCrosshair")]
//        //public static class PatchPlayerUpdateStamina
//        //{
//        //    private static void Postfix(Hud __instance, Player player)
//        //    {
//        //        Piece hoveringPiece = player.GetHoveringPiece();
//        //        WearNTear component = hoveringPiece.GetComponent<WearNTear>();

//        //        ZNetView m_nview = component.GetComponent<ZNetView>();

//        //        float num = m_nview.GetZDO().GetFloat(ZDOVars.s_health, component.m_health);
//        //        if (disableCrosshairStamina.Value && component.GetHealthPercentage() < num)
//        //        {
//        //            __instance.m_pieceHealthRoot.gameObject.SetActive(value: false);
//        //            //__instance.m_pieceHealthBar.SetValue(component.GetHealthPercentage());
//        //        }
//        //    }
//        //}
//    }
//}