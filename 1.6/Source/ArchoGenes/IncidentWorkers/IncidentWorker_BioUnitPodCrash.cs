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
    public class IncidentWorker_BioUnitPodCrash : IncidentWorker
    {
        public override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            List<Thing> things = new List<Thing>();
            things.Add(ThingMaker.MakeThing(ArchoGenesDefOf.ArchoGenes_BioUnit));
            IntVec3 intVec = DropCellFinder.RandomDropSpot(map);
            DropPodUtility.DropThingsNear(intVec, map, things, 110, canInstaDropDuringInit: false, leaveSlag: true);
            SendStandardLetter("ArchoGenes.LetterLabelCargoPodCrash".Translate(), "ArchoGenes.CargoPodCrash".Translate(), LetterDefOf.PositiveEvent, parms, new TargetInfo(intVec, map));
            return true;
        }
    }
}
