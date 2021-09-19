using DoorsExpanded;
using HarmonyLib;
using Verse;

namespace PrisonersDontHaveKeys
{
    [StaticConstructorOnStartup]
    public class DoorsExpandedPatch
    {
        static DoorsExpandedPatch()
        {
            var harmony = new Harmony("Mlie.PrisonersDontHaveKeys.DoorsExpandedPatch");
            var doorsExpandedOpenMethod = typeof(Building_DoorExpanded).GetMethod("PawnCanOpen");

            if (doorsExpandedOpenMethod == null)
            {
                PrisonersDontHaveKeys.LogMessage("Doors Expanded is loaded but failed find its open-function");
                return;
            }

            var postfix = typeof(Building_Door_PawnCanOpen).GetMethod("Postfix");
            if (postfix == null)
            {
                PrisonersDontHaveKeys.LogMessage("Doors Expanded is loaded but failed to fetch the postfix");
                return;
            }

            harmony.Patch(doorsExpandedOpenMethod, null, new HarmonyMethod(postfix));
            PrisonersDontHaveKeys.LogMessage("Doors Expanded is loaded, added patch for it");
        }
    }
}