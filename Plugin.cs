using BepInEx;
using calamity.Compat;
using JetBrains.Annotations;

namespace calamity;

[BepInPlugin(Constants.PluginGuid, Constants.PluginName, Constants.PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    [UsedImplicitly]
    private void Awake()
    {
        Logging.SetupLogging();
        Logging.Log("Loading calamity...");
        GorillaTagger.OnPlayerSpawned(OnPlayerAwake);
    }

    private void OnPlayerAwake()
    {
    }
}