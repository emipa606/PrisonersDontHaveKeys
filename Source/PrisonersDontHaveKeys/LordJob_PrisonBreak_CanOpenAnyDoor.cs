using HarmonyLib;
using RimWorld;

namespace PrisonersDontHaveKeys
{
    [HarmonyPatch(typeof(LordJob_PrisonBreak), "CanOpenAnyDoor")]
    public class LordJob_PrisonBreak_CanOpenAnyDoor
    {
        [HarmonyPostfix]
        public static void Postfix(ref bool __result)
        {
            if (PrisonersDontHaveKeysMod.instance.Settings.OwnDoor)
            {
                return;
            }

            __result = false;
        }
    }
}