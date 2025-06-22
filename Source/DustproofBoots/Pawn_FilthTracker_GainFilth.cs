using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots;

[HarmonyPatch(typeof(Pawn_FilthTracker), nameof(Pawn_FilthTracker.GainFilth), typeof(ThingDef),
    typeof(IEnumerable<string>))]
public static class Pawn_FilthTracker_GainFilth
{
    public static bool Prefix(Pawn ___pawn, ref List<Filth> ___carriedFilth)
    {
        if (!___pawn.Spawned || !___pawn.RaceProps.Humanlike)
        {
            return true;
        }

        foreach (var apparel in ___pawn.apparel.WornApparel)
        {
            if (apparel.def.defName != "Apparel_DustproofBoots")
            {
                continue;
            }

            ___carriedFilth.Clear();
            return false;
        }

        return true;
    }
}