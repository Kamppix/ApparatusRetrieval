using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(Terminal), "Start")]
    public class ItemPricePatch
    {
        private static void Postfix(Terminal __instance)
        {
            foreach (Item item in __instance.buyableItemsList)
            {
                if (item != null)
                {
                    item.creditsWorth = 0;
                }
            }

            foreach (BuyableVehicle item in __instance.buyableVehicles)
            {
                if (item != null)
                {
                    item.creditsWorth = 0;
                }
            }

            foreach (TerminalNode item in __instance.ShipDecorSelection)
            {
                if (item != null)
                {
                    item.itemCost = 0;
                }
            }
        }
    }
}
