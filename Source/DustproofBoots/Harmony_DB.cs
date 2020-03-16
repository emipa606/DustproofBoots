using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots
{
	// Token: 0x02000003 RID: 3
	[HarmonyPatch(typeof(Pawn_FilthTracker), "Notify_EnteredNewCell", new Type[]
	{

	})]
	public static class Harmony_DB
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
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
						return false;
					}
				}
			}
			return true;
		}
	}
}
