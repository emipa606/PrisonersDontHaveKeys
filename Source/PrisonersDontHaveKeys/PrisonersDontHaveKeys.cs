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
}