using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots;

[HarmonyPatch(typeof(Pawn_FilthTracker), "GainFilth", typeof(ThingDef), typeof(IEnumerable<string>))]
public static class Pawn_FilthTracker_GainFilth
{
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