using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB), "KillPlayerClientRpc")]
    public class PlayerDeathPatch
    {
        private static void Postfix(PlayerControllerB __instance)
        {
            if (Plugin.BoolConfig["InstantWipe"].Value)
            {
                if (__instance.isPlayerDead)
                {
                    PlayerControllerB localPlayer = StartOfRound.Instance.localPlayerController;
                    if (!localPlayer.isPlayerDead) localPlayer.KillPlayer(Vector3.zero, spawnBody: true, CauseOfDeath.Unknown, 1);
                }
            }
        }
    }
}
