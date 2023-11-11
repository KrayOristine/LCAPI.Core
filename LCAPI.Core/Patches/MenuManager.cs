using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCAPI.Core.Patches
{
    [HarmonyPatch(typeof(MenuManager))]
    internal class MenuManagerPatches
    {
        [HarmonyPatch("Awake")]
        [HarmonyPrefix]
        [HarmonyWrapSafe]
        public static bool Awake_Prefix(MenuManager __instance)
        {
            ServerAPI.manager = __instance;
            return true;
        }
    }
}
