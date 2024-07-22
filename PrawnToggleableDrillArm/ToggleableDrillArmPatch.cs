using HarmonyLib;

namespace PrawnToggleableDrillArm
{
    [HarmonyPatch]
    static class ToggleableDrillArmPatch
    {
        public static bool IsUsingDrillArm = false;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ExosuitDrillArm), "IExosuitArm.OnUseUp")]
        public static bool ExosuitDrillArm_OnUseUp_Prefix()
        {
            if (Plugin.ModConfig.IsEnabled == false)
            {
                return true;
            }

            // When the "return" is "false", the original method, OnUseUp(), will not be executed.
            return !IsUsingDrillArm;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ExosuitDrillArm), "IExosuitArm.OnUseDown")]
        public static void ExosuitDrillArm_OnUseDown_Postfix()
        {
            IsUsingDrillArm = !IsUsingDrillArm;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Exosuit), "OnPilotModeBegin")]
        public static void Exosuit_OnPilotModeBegin_Postfix()
        {
            IsUsingDrillArm = false;
        }
    }
}
