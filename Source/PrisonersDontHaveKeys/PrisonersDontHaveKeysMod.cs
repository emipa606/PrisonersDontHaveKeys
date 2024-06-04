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
    public static PrisonersDontHaveKeysMod instance;

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
        instance = this;

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
            if (settings == null)
            {
                settings = GetSettings<PrisonersDontHaveKeysModSettings>();
            }

            return settings;
        }

        set => settings = value;
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

        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.CheckboxLabeled("PDHK.logging.label".Translate(), ref Settings.VerboseLogging,
            "PDHK.logging.tooltip".Translate());
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("PDHK.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.Gap();
        if (ModLister.IdeologyInstalled || ModLister.AnomalyInstalled)
        {
            listing_Standard.CheckboxLabeled("PDHK.forprisoners.label".Translate(), ref Settings.AppliesForPrisoners);
            if (ModLister.IdeologyInstalled)
            {
                listing_Standard.CheckboxLabeled("PDHK.forslaves.label".Translate(), ref Settings.AppliesForSlaves);
            }

            if (ModLister.AnomalyInstalled)
            {
                listing_Standard.CheckboxLabeled("PDHK.foranomalies.label".Translate(),
                    ref Settings.AppliesForAnomalies);
            }

            if (!Settings.AppliesForSlaves && !Settings.AppliesForPrisoners && !Settings.AppliesForAnomalies)
            {
                listing_Standard.Label("PDHK.nothing.label".Translate());
            }
        }

        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("PDHK.owndoor.label".Translate(), ref Settings.OwnDoor,
            "PDHK.owndoor.description".Translate());
        listing_Standard.End();
    }
}