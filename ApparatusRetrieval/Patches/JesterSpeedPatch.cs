using HarmonyLib;
using UnityEngine;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(JesterAI), "Update")]
    public class JesterSpeedPatch
    {
        private static void Postfix(JesterAI __instance)
        {
            if (__instance.currentBehaviourStateIndex == 2 && !(__instance.inKillAnimation || __instance.stunNormalizedTimer > 0f))
            {
                __instance.agent.speed = Mathf.Min(__instance.agent.speed, 3f);
            }
        }
    }
}
