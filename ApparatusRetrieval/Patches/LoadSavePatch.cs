using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(StartOfRound), "SetTimeAndPlanetToSavedSettings")]
    public class LoadSavePatch
    {
        private static void Prefix(StartOfRound __instance)
        {
            TimeOfDay.Instance.quotaVariables.startingQuota = 1;
            TimeOfDay.Instance.quotaVariables.deadlineDaysAmount = __instance.levels.Length - Plugin.SkippedMoons.Length - 1;
            TimeOfDay.Instance.quotaVariables.startingCredits = 0;

            int defaultPlanet = 0;
            foreach (int skip in Plugin.SkippedMoons)
            {
                if (defaultPlanet == skip) defaultPlanet++;
            }
            __instance.defaultPlanet = defaultPlanet;
        }
    }
}
