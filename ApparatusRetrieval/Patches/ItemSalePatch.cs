using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(Terminal), "SetItemSales")]
    public class ItemSalePatch
    {
        private static bool Prefix(Terminal __instance)
        {
            if (__instance.itemSalesPercentages == null || __instance.itemSalesPercentages.Length == 0)
            {
                __instance.InitializeItemSalesPercentages();
            }

            return false;
        }
    }
}

