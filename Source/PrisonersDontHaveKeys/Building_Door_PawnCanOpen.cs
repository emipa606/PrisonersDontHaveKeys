using HarmonyLib;
using RimWorld;
using Verse;

namespace PrisonersDontHaveKeys
{
    [HarmonyPatch(typeof(Building_Door), "PawnCanOpen")]
    public class Building_Door_PawnCanOpen
    {
        [HarmonyPostfix]
        public static void Postfix(Pawn p, ref bool __result)
        {
            if (!__result)
            {
                return;
            }

            if (!p.IsPrisonerOfColony)
            {
                return;
            }

            if (!PrisonersDontHaveKeysMod.instance.Settings.OwnDoor)
            {
                return;
            }

            __result = p.GetRoom().isPrisonCell;
        }
    }
}