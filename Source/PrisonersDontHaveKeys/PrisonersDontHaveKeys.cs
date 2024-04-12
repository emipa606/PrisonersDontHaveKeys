using System.Reflection;
using HarmonyLib;
using Verse;

namespace PrisonersDontHaveKeys;

[StaticConstructorOnStartup]
public class PrisonersDontHaveKeys
{
    static PrisonersDontHaveKeys()
    {
        new Harmony("Mlie.PrisonersDontHaveKeys").PatchAll(Assembly.GetExecutingAssembly());
    }


    public static void LogMessage(string message, bool forced = false, bool warning = false)
    {
        if (warning)
        {
            Log.Warning($"[PrisonersDontHaveKeys]: {message}");
            return;
        }

        if (!forced && !PrisonersDontHaveKeysMod.instance.Settings.VerboseLogging)
        {
            return;
        }

        Log.Message($"[PrisonersDontHaveKeys!]: {message}");
    }
}