using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots
{
    // Token: 0x02000004 RID: 4
    [HarmonyPatch(typeof(Pawn_FilthTracker), "GainFilth", typeof(ThingDef), typeof(IEnumerable<string>))]
    public static class Harmony_DBB
    {
        // Token: 0x06000003 RID: 3 RVA: 0x0000211C File Offset: 0x0000031C
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
                if (apparel.def.defName != "Apparel_DustproofBoots")
                {
                    continue;
                }

                var value2 = traverse.Field("carriedFilth").GetValue<List<Filth>>();
                value2.Clear();
                traverse.Field("carriedFilth").SetValue(value2);
                return false;
            }

            return true;
        }
    }
}