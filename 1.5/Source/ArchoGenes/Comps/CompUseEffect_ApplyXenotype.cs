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
    public class CompUseEffect_ApplyXenotype : CompUseEffect
    {
        public override void DoEffect(Pawn usedBy)
        {
            base.DoEffect(usedBy);
            ApplyXenotype(usedBy);
            if (PawnUtility.ShouldSendNotificationAbout(usedBy))
            {
                Messages.Message("ArchoGenes.UsedBioUnit".Translate(usedBy.LabelShort, usedBy.Named("USER")), usedBy, MessageTypeDefOf.PositiveEvent);
            }
        }

        public void ApplyXenotype(Pawn pawn)
        {
            if (pawn.genes != null)
            {
                pawn.genes.SetXenotype(ArchoGenesDefOf.ArchoGenes_Archinite);
            }
        }

        public override bool CanBeUsedBy(Pawn p, out string failReason)
        {
            if (p.genes == null)
            {
                failReason = null;
                return false;
            }
            if(p.genes.Xenotype == ArchoGenesDefOf.ArchoGenes_Archinite)
            {
                failReason = "ArchoGenes.AlreadyArchinite".Translate();
                return false;
            }
            if(p.def != ThingDefOf.Human)
            {
                failReason = "ArchoGenes.NonHumanIncompatible".Translate();
                return false;
            }
            return base.CanBeUsedBy(p, out failReason);
        }
    }
}
