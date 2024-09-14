using HarmonyLib;
using System;
using UnityEngine;

namespace ApparatusRetrieval.Patches
{
    [HarmonyPatch(typeof(StartOfRound), "PassTimeToNextDay")]
    public class PassTimePatch
    {
        private static bool Prefix(StartOfRound __instance)
        {
            if (__instance.isChallengeFile)
            {
                TimeOfDay.Instance.globalTime = 100f;
                __instance.SetMapScreenInfoToCurrentLevel();
                return false;
            }
            
            if (__instance.scrapCollectedLastRound == 0)
            {
                if (Plugin.BoolConfig["Hardcore"].Value)
                {
                    TimeOfDay.Instance.timeUntilDeadline = TimeOfDay.Instance.quotaVariables.deadlineDaysAmount * TimeOfDay.Instance.totalTime;
                    RoundManager.Instance.DespawnPropsAtEndOfRound(true);
                }
                else
                {
                    TimeOfDay.Instance.timeUntilDeadline = TimeOfDay.Instance.timeUntilDeadline - TimeOfDay.Instance.timeUntilDeadline % TimeOfDay.Instance.totalTime;
                }
            }

            TimeOfDay.Instance.timeUntilDeadline = TimeOfDay.Instance.timeUntilDeadline - Math.Abs(TimeOfDay.Instance.timeUntilDeadline) % TimeOfDay.Instance.totalTime + 1;

            TimeOfDay.Instance.OnDayChanged();
            TimeOfDay.Instance.globalTime = 100f;
            TimeOfDay.Instance.UpdateProfitQuotaCurrentTime();

            if (__instance.currentLevel.planetHasTime)
            {
                HUDManager.Instance.DisplayDaysLeft((int)Mathf.Floor(TimeOfDay.Instance.timeUntilDeadline / TimeOfDay.Instance.totalTime));
            }
            __instance.SetMapScreenInfoToCurrentLevel();
            if (TimeOfDay.Instance.timeUntilDeadline > 0f && TimeOfDay.Instance.daysUntilDeadline <= 0 && TimeOfDay.Instance.timesFulfilledQuota <= 0)
            {
                __instance.StartCoroutine(__instance.playDaysLeftAlertSFXDelayed());
            }

            return false;
        }
    }
}
