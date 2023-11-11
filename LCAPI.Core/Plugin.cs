using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using LCAPI.Core.Patches;
using UnityEngine;
using System.Reflection;
using HarmonyLib.Tools;

namespace LCAPI.Core
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal const int MOD_VERSION = 65536; // Should be high enough that no normal player can play with modded
        internal Harmony _harmony;
        public static bool forceModded { get; private set; }
        public static ManualLogSource Log;

        private void Awake()
        {
            forceModded = true;
            Log = Logger;
            _harmony = new(PluginInfo.PLUGIN_GUID);
            Logger.LogInfo($"LCAPI Core is being loaded!....");

            _harmony.PatchAll(typeof(Plugin).Assembly);
        }

        private void OnDestroy()
        {
            var gameObj = new GameObject("LCAPI");
            DontDestroyOnLoad(gameObj);
            gameObj.AddComponent<ServerAPI>();
        }
    }
}