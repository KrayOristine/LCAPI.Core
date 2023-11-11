using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCAPI.Core.Patches
{
    [HarmonyPatch(typeof(SaveFileUISlot))]
    internal class SaveFileUISlotPatches
    {
        [HarmonyPatch("SetFileToThis")]
        [HarmonyPrefix]
        [HarmonyWrapSafe]
        private static void SetFileToThis_Postfix(SaveFileUISlot __instance)
        {
            GameNetworkManager.Instance.currentSaveFileName = GameNetworkManager.Instance.currentSaveFileName + "_Modded";
        }
    }
}
