using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(RedLocustBees), "Start")]
    public class BeesStartPatch
    {
        private static void Postfix(RedLocustBees __instance)
        {
            __instance.hive.SetScrapValue(0);
        }
    }
}
