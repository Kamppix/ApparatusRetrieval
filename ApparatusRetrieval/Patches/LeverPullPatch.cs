using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(StartMatchLever), "BeginHoldingInteractOnLever")]
    public class LeverPullPatch
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
