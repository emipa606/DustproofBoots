using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(FilthMaker), "TryMakeFilth", new Type[]
	{
		typeof(IntVec3),
		typeof(Map),
		typeof(ThingDef),
        typeof(int),
        typeof(FilthSourceFlags)
    })]
	public static class Harmony_DropTrashNotify
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002200 File Offset: 0x00000400
		public static bool Prefix(IntVec3 c, Map map, ThingDef filthDef, int count = 1, FilthSourceFlags additionalFlags = FilthSourceFlags.None)
		{
			bool flag = filthDef != null && filthDef == ThingDefOf.Filth_Trash;
			if (flag)
			{
				bool flag2 = map != null && map.IsPlayerHome;
				if (flag2)
				{
					foreach (Thing thing in map.thingGrid.ThingsAt(c))
					{
						bool flag3 = thing is Pawn && (thing as Pawn).RaceProps.Humanlike;
						if (flag3)
						{
							foreach (Apparel apparel in (thing as Pawn).apparel.WornApparel)
							{
								bool flag4 = apparel.def.defName == "Apparel_DustproofBoots";
								if (flag4)
                                {
                                    return false;
								}
							}
						}
					}
				}
			}
			return true;
		}
	}
}
