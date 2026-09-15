using BepInEx.Logging;
using StackTrace = System.Diagnostics.StackTrace;
using Logger = BepInEx.Logging.Logger;

namespace calamity.Compat;

public static class Logging
{
    private static ManualLogSource _logger;

    public static void SetupLogging()
    {
        if (_logger != null)
        {
            return;
        }

        _logger = Logger.CreateLogSource("calamity");
    }

    public static void Log(string log)
    {
        var caller = GetCaller();
        _logger.Log($"[calamity:{caller.Type}:{caller.Method}(..)] {log}");
    }

    public static void LogDebug(string log)
    {
        var caller = GetCaller();
        _logger.LogDebug($"[calamity:{caller.Type}:{caller.Method}(..)] {log}");
    }

    public static void LogWarning(string log)
    {
        var caller = GetCaller();
        _logger.LogWarning($"[calamity:{caller.Type}:{caller.Method}(..)] {log}");
    }

    public static void LogError(string log)
    {
        var caller = GetCaller();
        _logger.LogError($"[calamity:{caller.Type}:{caller.Method}(..)] {log}");
    }

    private static (string Type, string Method) GetCaller()
    {
        var frame = new StackTrace(true).GetFrame(2);
        var method = frame?.GetMethod();

        return (
            method?.DeclaringType?.Name ?? "Unknown",
            method?.Name ?? "Unknown");
    }
}