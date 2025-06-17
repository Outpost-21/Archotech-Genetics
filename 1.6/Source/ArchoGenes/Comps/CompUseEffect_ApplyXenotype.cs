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
        public override AcceptanceReport CanBeUsedBy(Pawn p)
        {
            if (p.genes == null)
            {
                return null;
            }
            if(p.genes.Xenotype == ArchoGenesDefOf.ArchoGenes_Archinite)
            {
                return "ArchoGenes.AlreadyArchinite".Translate();
            }
            if(p.def != ThingDefOf.Human)
            {
                return "ArchoGenes.NonHumanIncompatible".Translate();
            }
            return base.CanBeUsedBy(p);
        }
    }
}
