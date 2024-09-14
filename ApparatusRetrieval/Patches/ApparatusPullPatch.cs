using HarmonyLib;

namespace QuotaScalingMoons.Patches
{
    [HarmonyPatch(typeof(LungProp), "DisconnectFromMachinery")]
    public class ApparatusPullPatch
    {
        private static void Prefix(LungProp __instance)
        {
            __instance.SetScrapValue(1);
        }
    }
}
