using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(Terminal), "ParsePlayerSentence")]
    public class PurchasePatch
    {
        private static void Postfix(TerminalNode __result)
        {
            if (__result.buyVehicleIndex != -1 || __result.shipUnlockableID != -1)
            {
                __result.itemCost = 0;
            }
            else if (__result.buyRerouteToMoon != -1)
            {
                __result.itemCost = 1;
            }
        }
    }
}
