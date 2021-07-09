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
            var traverse = Traverse.Create(__instance);
            var value = traverse.Field("pawn").GetValue<Pawn>();
            if (!value.Spawned || !value.RaceProps.Humanlike)
            {
                return true;
            }

            foreach (var apparel in value.apparel.WornApparel)
            {
                if (apparel.def.defName == "Apparel_DustproofBoots")
                {
                    return false;
                }
            }

            return true;
        }
    }
}