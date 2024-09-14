using HarmonyLib;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(StartOfRound), "LoadUnlockables")]
    public class UnlockableLoadPatch
    {
        private static void Postfix(StartOfRound __instance)
        {
            for (int i = 0; i < __instance.unlockablesList.unlockables.Count; i++)
            {
                if (__instance.unlockablesList.unlockables[i].unlockableType == 0)
                {
                    __instance.UnlockShipObject(i);
                }
            }
        }
    }
}
