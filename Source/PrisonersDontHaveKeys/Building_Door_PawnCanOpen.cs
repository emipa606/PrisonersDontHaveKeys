using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PrisonersDontHaveKeys;

[HarmonyPatch(typeof(Building_Door), nameof(Building_Door.PawnCanOpen))]
public class Building_Door_PawnCanOpen
{
    public static void Postfix(Pawn p, ref bool __result)
    {
        if (!__result)
        {
            return;
        }

        var settings = PrisonersDontHaveKeysMod.Instance?.Settings;
        if (settings == null)
        {
            return;
        }

        if (settings.AppliesForPrisoners && p.IsPrisonerOfColony)
        {
            if (!PrisonBreakUtility.IsPrisonBreaking(p))
            {
                return;
            }

            __result = settings.OwnDoor && p.GetRoom().IsPrisonCell;
            return;
        }

        if (settings.AppliesForSlaves && p.IsSlaveOfColony)
        {
            if (!SlaveRebellionUtility.IsRebelling(p))
            {
                return;
            }

            __result = settings.OwnDoor &&
                       p.GetRoom().ContainedBeds.Any(bed => bed.ForSlaves);
            return;
        }

        if (settings.AppliesForAnomalies && p.IsEntity)
        {
            __result = false;
        }
    }
}