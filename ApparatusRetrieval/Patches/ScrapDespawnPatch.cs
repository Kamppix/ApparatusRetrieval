using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(RoundManager), "DespawnPropsAtEndOfRound")]
    public class ScrapDespawnPatch
    {
        private static void Prefix()
        {
            if (!Plugin.BoolConfig["Hardcore"].Value) StartOfRound.Instance.allPlayersDead = false;
            else StartOfRound.Instance.allPlayersDead = StartOfRound.Instance.scrapCollectedLastRound == 0;
        }
    }
}
