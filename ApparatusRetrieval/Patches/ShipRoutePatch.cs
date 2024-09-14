using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(StartOfRound), "AllPlayersHaveRevivedClientRpc")]
    public class ShipRoutePatch
    {
        private static void Postfix(StartOfRound __instance)
        {
            int totalLevels = __instance.levels.Length - Plugin.SkippedMoons.Length;
            int level = totalLevels - TimeOfDay.Instance.daysUntilDeadline - 1;

            foreach (int i in Plugin.SkippedMoons)
            {
                if (level >= i) level++;
            }

            if (level == 3) level = 8;

            if (__instance.currentLevelID != level && level != -1)
            {
                __instance.ChangeLevelServerRpc(level, 0);
                __instance.AutoSaveShipData();
            }
        }
    }
}
