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

        if (PrisonersDontHaveKeysMod.Instance.Settings.AppliesForPrisoners && p.IsPrisonerOfColony)
        {
            if (!PrisonBreakUtility.IsPrisonBreaking(p))
            {
                return;
            }

            __result = PrisonersDontHaveKeysMod.Instance.Settings.OwnDoor && p.GetRoom().IsPrisonCell;
            return;
        }

        if (PrisonersDontHaveKeysMod.Instance.Settings.AppliesForSlaves && p.IsSlaveOfColony)
        {
            if (!SlaveRebellionUtility.IsRebelling(p))
            {
                return;
            }

            __result = PrisonersDontHaveKeysMod.Instance.Settings.OwnDoor &&
                       p.GetRoom().ContainedBeds.Any(bed => bed.ForSlaves);
            return;
        }

        if (PrisonersDontHaveKeysMod.Instance.Settings.AppliesForAnomalies && p.IsEntity)
        {
            __result = false;
        }
    }
}