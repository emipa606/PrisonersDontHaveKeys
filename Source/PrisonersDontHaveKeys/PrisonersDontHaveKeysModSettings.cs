using Verse;

namespace PrisonersDontHaveKeys
{
    /// <summary>
    ///     Definition of the settings for the mod
    /// </summary>
    internal class PrisonersDontHaveKeysModSettings : ModSettings
    {
        public bool OwnDoor;
        public bool VerboseLogging;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref VerboseLogging, "VerboseLogging");
            Scribe_Values.Look(ref OwnDoor, "OwnDoor");
        }
    }
}