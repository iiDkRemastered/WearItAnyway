using BepInEx;
using Photon.Pun;
using System;
using UnityEngine;

namespace WearItAnyway
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Awake()
        {
            AntiIAuth.AntiIAuthProtection.Initialize(this);
            HarmonyPatches.ApplyHarmonyPatches();
        }

        private bool inRoom = false;

        void Update()
        {
            if (PhotonNetwork.InRoom && !inRoom)
            {
                CustomProperty.SetCustomNetworkProperty();
                inRoom = true;
            }
            else if (!PhotonNetwork.InRoom && inRoom)
            {
                inRoom = false;
            }
        }
    }
}
