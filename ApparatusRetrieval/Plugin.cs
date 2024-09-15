using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;

namespace ApparatusRetrieval
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static Harmony? Harmony { get; set; }

        internal static Dictionary<int, float> MapSizes = new();
        internal static int[] SkippedMoons = { 8, 11 };

        internal static Dictionary<String, ConfigEntry<float>> FloatConfig = new Dictionary<String, ConfigEntry<float>>();
        internal static Dictionary<String, ConfigEntry<bool>> BoolConfig = new Dictionary<String, ConfigEntry<bool>>();

        private void Awake()
        {
            Logger = base.Logger;
            Instance = this;

            Patch();
            AddConfig();

            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
        }

        internal static void Patch()
        {
            Harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);

            Logger.LogDebug("Patching...");

            Harmony.PatchAll();

            Logger.LogDebug("Finished patching!");
        }

        internal static void Unpatch()
        {
            Logger.LogDebug("Unpatching...");

            Harmony?.UnpatchSelf();

            Logger.LogDebug("Finished unpatching!");
        }

        private void AddConfig()
        {
            FloatConfig.Add("MapSizeMultiplier", Config.Bind(
                "Difficulty",
                "MapSizeMultiplier",
                1.0f,
                "Size multiplier for map generation. Minimum value: 1")
            );
            FloatConfig.Add("DaySpeedMultiplier", Config.Bind(
               "Difficulty",
               "DaySpeedMultiplier",
               1.0f,
               "Speed multiplier for daytime progression.")
            );
            /*
            BoolConfig.Add("EnableWeather", Config.Bind(
               "Difficulty",
               "EnableWeather",
               false,
               "Enables or disables random weather conditions.")
            );
            */
            BoolConfig.Add("InstantWipe", Config.Bind(
               "Difficulty",
               "InstantWipe",
               false,
               "Every employee dies when one of you does.")
            );
            /*
            BoolConfig.Add("Hardcore", Config.Bind(
               "Difficulty",
               "Hardcore",
               false,
               "The run is reset when you fail to retrieve the apparatus even once.")
            );
            */
        }
    }
}
