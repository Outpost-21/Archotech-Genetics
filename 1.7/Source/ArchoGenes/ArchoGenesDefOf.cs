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
    [DefOf]
    public static class ArchoGenesDefOf
    {
        static ArchoGenesDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ArchoGenesDefOf));
        }

        public static XenotypeDef ArchoGenes_Archinite;

        public static GeneDef ArchoGenes_ArchotechSight;
        //public static GeneDef ArchoGenes_ArchotechProgenitor;

        public static ThingDef ArchoGenes_BioUnit;
    }
}
