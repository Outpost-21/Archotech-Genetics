using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ArchoGenes
{
    public class ArchoGenesMod : Mod
    {
        public static ArchoGenesMod mod;
        public static ArchoGenesSettings settings;

        public Vector2 optionsScrollPosition;
        public float optionsViewRectHeight;

        internal static string VersionDir => Path.Combine(mod.Content.ModMetaData.RootDir.FullName, "Version.txt");
        public static string CurrentVersion { get; private set; }

        public ArchoGenesMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<ArchoGenesSettings>();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            LogUtil.LogMessage($"{CurrentVersion} ::");

            File.WriteAllText(VersionDir, CurrentVersion);

            Harmony harmony = new Harmony("Neronix17.ArchoGenes.RimWorld");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public override string SettingsCategory() => "Archotech Genetics";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            bool flag = optionsViewRectHeight > inRect.height;
            Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width - (flag ? 26f : 0f), optionsViewRectHeight);
            Widgets.BeginScrollView(inRect, ref optionsScrollPosition, viewRect);
            Listing_Standard listing = new Listing_Standard();
            Rect rect = new Rect(viewRect.x, viewRect.y, viewRect.width, 999999f);
            listing.Begin(rect);
            // ============================ CONTENTS ================================
            DoOptionsCategoryContents(listing);
            // ======================================================================
            optionsViewRectHeight = listing.CurHeight;
            listing.End();
            Widgets.EndScrollView();
        }

        public void DoOptionsCategoryContents(Listing_Standard listing)
        {
            listing.Note("You will need to restart the game for some of these settings to take effect.", GameFont.Tiny);
            listing.GapLine();
            listing.CheckboxEnhanced("Less Overpowered Stats", "Drops the stats for many of the genes to be much lower, while still being stronger than anything vanilla.", ref settings.lessOPStats);
            //listing.CheckboxEnhanced("Xenotype is Progenitor", "Controls if the xenotype included has the Archotech Progenitor gene, allowing it to pass down archite and xenogenes as inheritable. This is not retroactive, existing pawns will not be affected!", ref settings.xenotypeProgenitor);
            //listing.CheckboxEnhanced("Archotech Progenitor Extreme", "Changes the behaviour of the Archotech Progenitor to enforce the passing down of the xenotype, vanilla has a 50% chance per endogene usually unless both parents have it, this makes it 100% regardless.", ref settings.extremeProgenitor);
            listing.CheckboxEnhanced("Archotech Bio-Unit", "If enabled, an extremely rare incident can happen where an Archotech Bio-Unit is dropped in a drop pod, a device which can turn any colonist into the Archinite xenotype.", ref settings.archotechBioUnit);
        }
    }
}
