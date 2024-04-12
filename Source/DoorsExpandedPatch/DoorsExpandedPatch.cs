using DoorsExpanded;
using HarmonyLib;
using Verse;

namespace PrisonersDontHaveKeys;

[StaticConstructorOnStartup]
public class DoorsExpandedPatch
{
    static DoorsExpandedPatch()
    {
        var doorsExpandedOpenMethod =
            typeof(Building_DoorExpanded).GetMethod(nameof(Building_DoorExpanded.PawnCanOpen));

        if (doorsExpandedOpenMethod == null)
        {
            PrisonersDontHaveKeys.LogMessage("Doors Expanded is loaded but failed find its open-function");
            return;
        }

        var postfix = typeof(Building_Door_PawnCanOpen).GetMethod(nameof(Building_Door_PawnCanOpen.Postfix));
        if (postfix == null)
        {
            PrisonersDontHaveKeys.LogMessage("Doors Expanded is loaded but failed to fetch the postfix");
            return;
        }

        new Harmony("Mlie.PrisonersDontHaveKeys.DoorsExpandedPatch").Patch(doorsExpandedOpenMethod, null,
            new HarmonyMethod(postfix));
        PrisonersDontHaveKeys.LogMessage("Doors Expanded is loaded, added patch for it");
    }
}