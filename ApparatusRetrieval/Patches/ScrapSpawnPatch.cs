using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(RoundManager), "SpawnScrapInLevel")]
    public class ScrapSpawnPatch
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
