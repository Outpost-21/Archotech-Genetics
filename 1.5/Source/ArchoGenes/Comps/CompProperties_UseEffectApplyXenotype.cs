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
    public class CompProperties_UseEffectApplyXenotype : CompProperties_UseEffect
	{
		public CompProperties_UseEffectApplyXenotype()
		{
			compClass = typeof(CompUseEffect_ApplyXenotype);
		}
	}
}
