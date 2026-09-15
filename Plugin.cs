using BepInEx;
using calamity.Compat;
using UnityEngine;

namespace calamity;

[BepInPlugin(Constants.PluginGuid, Constants.PluginName, Constants.PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        Logging.SetupLogging();
        Logging.Log("Loading calamity...");
        GorillaTagger.OnPlayerSpawned(OnPlayerAwake);
    }

    private void OnPlayerAwake()
    {
        CompatHelper.SetupCompatLayer();
    }
}