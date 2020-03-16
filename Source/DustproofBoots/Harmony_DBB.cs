using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(Pawn_FilthTracker), "GainFilth", new Type[]
	{
		typeof(ThingDef),
		typeof(IEnumerable<string>)
	})]
	public static class Harmony_DBB
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000211C File Offset: 0x0000031C
		public static bool Prefix(Pawn_FilthTracker __instance)
		{
			Traverse traverse = Traverse.Create(__instance);
			Pawn value = traverse.Field("pawn").GetValue<Pawn>();
			bool flag = value.Spawned && value.RaceProps.Humanlike;
			if (flag)
			{
				foreach (Apparel apparel in value.apparel.WornApparel)
				{
					bool flag2 = apparel.def.defName == "Apparel_DustproofBoots";
					if (flag2)
					{
						List<Filth> value2 = traverse.Field("carriedFilth").GetValue<List<Filth>>();
						value2.Clear();
						traverse.Field("carriedFilth").SetValue(value2);
						return false;
					}
				}
			}
			return true;
		}
	}
}
