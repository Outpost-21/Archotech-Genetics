using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ArchoGenes
{
    public class ArchoGenesSettings : ModSettings
    {
        public bool verboseLogging = false;

        public bool lessOPStats = false;
        //public bool xenotypeProgenitor = true;
        //public bool extremeProgenitor = false;
        public bool archotechBioUnit = true;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref lessOPStats, "lessOPStats");
            //Scribe_Values.Look(ref xenotypeProgenitor, "xenotypeProgenitor");
            //Scribe_Values.Look(ref extremeProgenitor, "extremeProgenitor");
            Scribe_Values.Look(ref archotechBioUnit, "archotechBioUnit");
        }

        public bool IsValidSetting(string input)
        {
            if (GetType().GetFields().Where(p => p.FieldType == typeof(bool)).Any(i => i.Name == input))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<string> GetEnabledSettings
        {
            get
            {
                return GetType().GetFields().Where(p => p.FieldType == typeof(bool) && (bool)p.GetValue(this)).Select(p => p.Name);
            }
        }
    }
}
