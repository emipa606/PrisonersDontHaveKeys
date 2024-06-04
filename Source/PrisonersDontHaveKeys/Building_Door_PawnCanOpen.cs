using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PrisonersDontHaveKeys;

[HarmonyPatch(typeof(Building_Door), nameof(Building_Door.PawnCanOpen))]
public class Building_Door_PawnCanOpen
{
    [HarmonyPostfix]
    public static void Postfix(Pawn p, ref bool __result)
    {
        if (!__result)
        {
            return;
        }

        if (PrisonersDontHaveKeysMod.instance.Settings.AppliesForPrisoners && p.IsPrisonerOfColony)
        {
            if (!PrisonBreakUtility.IsPrisonBreaking(p))
            {
                return;
            }

            __result = PrisonersDontHaveKeysMod.instance.Settings.OwnDoor && p.GetRoom().IsPrisonCell;
            return;
        }

        if (PrisonersDontHaveKeysMod.instance.Settings.AppliesForSlaves && p.IsSlaveOfColony)
        {
            if (!SlaveRebellionUtility.IsRebelling(p))
            {
                return;
            }

            __result = PrisonersDontHaveKeysMod.instance.Settings.OwnDoor &&
                       p.GetRoom().ContainedBeds.Any(bed => bed.ForSlaves);
            return;
        }

        if (PrisonersDontHaveKeysMod.instance.Settings.AppliesForAnomalies && p.IsEntity)
        {
            __result = false;
        }
    }
}