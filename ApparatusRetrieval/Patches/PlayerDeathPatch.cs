using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB), "KillPlayer")]
    public class PlayerDeathPatch
    {
        private static void Postfix()
        {
            if (Plugin.BoolConfig["InstantWipe"].Value)
            {
                foreach (PlayerControllerB player in StartOfRound.Instance.allPlayerScripts)
                {
                    if (player.isPlayerControlled && !player.isPlayerDead) player.KillPlayer(Vector3.zero);
                }
            }
        }
    }
}
