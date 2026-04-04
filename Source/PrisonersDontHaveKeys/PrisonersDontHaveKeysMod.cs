using Mlie;
using UnityEngine;
using Verse;

namespace PrisonersDontHaveKeys;

[StaticConstructorOnStartup]
internal class PrisonersDontHaveKeysMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static PrisonersDontHaveKeysMod Instance;

    private static string currentVersion;


    /// <summary>
    ///     The private settings
    /// </summary>
    private PrisonersDontHaveKeysModSettings settings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public PrisonersDontHaveKeysMod(ModContentPack content)
        : base(content)
    {
        Instance = this;
        settings = GetSettings<PrisonersDontHaveKeysModSettings>();

        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal PrisonersDontHaveKeysModSettings Settings
    {
        get
        {
            return settings;
        }
    }

    public override string SettingsCategory()
    {
        return "Prisoners Dont Have Keys";
    }

    /// <summary>
    ///     The settings-window
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        base.DoSettingsWindowContents(rect);

        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.CheckboxLabeled("PDHK.logging.label".Translate(), ref Settings.VerboseLogging,
            "PDHK.logging.tooltip".Translate());
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("PDHK.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.Gap();
        if (ModLister.IdeologyInstalled || ModLister.AnomalyInstalled)
        {
            listingStandard.CheckboxLabeled("PDHK.forprisoners.label".Translate(), ref Settings.AppliesForPrisoners);
            if (ModLister.IdeologyInstalled)
            {
                listingStandard.CheckboxLabeled("PDHK.forslaves.label".Translate(), ref Settings.AppliesForSlaves);
            }

            if (ModLister.AnomalyInstalled)
            {
                listingStandard.CheckboxLabeled("PDHK.foranomalies.label".Translate(),
                    ref Settings.AppliesForAnomalies);
            }

            if (!Settings.AppliesForSlaves && !Settings.AppliesForPrisoners && !Settings.AppliesForAnomalies)
            {
                listingStandard.Label("PDHK.nothing.label".Translate());
            }
        }

        listingStandard.Gap();
        listingStandard.CheckboxLabeled("PDHK.owndoor.label".Translate(), ref Settings.OwnDoor,
            "PDHK.owndoor.description".Translate());
        listingStandard.End();
    }
}