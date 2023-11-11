using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LCAPI.Core
{
    internal class ServerAPI : MonoBehaviour
    {
        internal static MenuManager manager;
        private static bool setModded = false;

        public void Update()
        {
            if (!setModded)
            {
                UpdateModVersion();
                return;
            }

            if (manager != null && manager.versionNumberText)
            {
                manager.versionNumberText.text = $"v{GameNetworkManager.Instance.gameVersionNum - Plugin.MOD_VERSION}\nMOD";
            }
        }

        private static void UpdateModVersion()
        {
            if (GameNetworkManager.Instance)
            {
                GameNetworkManager.Instance.gameVersionNum += Plugin.MOD_VERSION;
                setModded = true;
            }
        }
    }
}
