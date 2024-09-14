using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(RoundManager), "GenerateNewLevelClientRpc")]
    public class GenerateLevelPatch
    {
        private static void Prefix(RoundManager __instance, ref int levelID)
        {
            if (Plugin.MapSizes.Count == 0)
            {
                foreach (SelectableLevel l in StartOfRound.Instance.levels)
                {
                    Plugin.MapSizes.Add(l.levelID, l.factorySizeMultiplier);
                }
            }

            SelectableLevel level = __instance.currentLevel;

            level.dungeonFlowTypes = StartOfRound.Instance.levels[0].dungeonFlowTypes;
            level.dungeonFlowTypes[0].rarity = 1;
            level.dungeonFlowTypes[1].rarity = 0;
            level.dungeonFlowTypes[2].rarity = 0;
            level.factorySizeMultiplier = Plugin.MapSizes[levelID] * Plugin.FloatConfig["MapSizeMultiplier"].Value;
            level.DaySpeedMultiplier = Plugin.FloatConfig["DaySpeedMultiplier"].Value;

            foreach (SpawnableEnemyWithRarity enemy in level.Enemies) enemy.enemyType.PowerLevel = 0;
            foreach (SpawnableEnemyWithRarity enemy in level.OutsideEnemies) enemy.enemyType.PowerLevel = 0;
        }
    }
}
