using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;
using BepInEx;
using UnityEngine;
using Steamworks;
using Steamworks.Data;
using HarmonyLib;
using HarmonyLib.Tools;

namespace LCAPI.Core.Patches
{
    [HarmonyPatch(typeof(GameNetworkManager))]
    internal class GameNetworkManagerPatches
    {
        [HarmonyPatch("SteamMatchmaking_OnLobbyCreated")]
        [HarmonyPrefix]
        [HarmonyWrapSafe]
        private static bool SteamMatchmaking_OnLobbyCreated_Prefix(GameNetworkManager __instance, Result result, Lobby lobby)
        {
            if (result != Result.OK)
            {
                Debug.LogError(string.Format("Couldn't create lobby {0}!", result), __instance);
                Plugin.Log.LogError(string.Format("Couldn't create lobby {0}!", result));
                return false;
            }

            __instance.lobbyHostSettings.lobbyName = $"[MODDED] {__instance.lobbyHostSettings.lobbyName}";
            Plugin.Log.LogInfo("Server pre-setup sucess");
            return true;
        }

        [HarmonyPatch("Start")]
        [HarmonyPrefix]
        [HarmonyWrapSafe]
        private static void Start_Postfix(GameNetworkManager __instance)
        {
            __instance.currentSaveFileName += "_Modded";
        }

        //! Post-pone until the game support rich presence
        /*
        [HarmonyPatch("SetSteamFriendGrouping")]
        [HarmonyPostfix]
        [HarmonyWrapSafe]
        private static bool SetSteamFriendGrouping_Postfix(GameNetworkManager __instance, string groupName, int groupSize, string steamDisplay)
        {
            SteamFriends.ClearRichPresence();
            SteamFriends.SetRichPresence("")
        }
        */
    }
}
