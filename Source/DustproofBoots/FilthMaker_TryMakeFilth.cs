using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots;

[HarmonyPatch(typeof(FilthMaker), "TryMakeFilth", typeof(IntVec3), typeof(Map), typeof(ThingDef), typeof(string),
    typeof(int), typeof(FilthSourceFlags))]
public static class FilthMaker_TryMakeFilth
{
    public static bool Prefix(IntVec3 c, Map map, ThingDef filthDef)
    {
        if (filthDef == null || filthDef != ThingDefOf.Filth_Trash)
        {
            return true;
        }

        if (map is not { IsPlayerHome: true })
        {
            return true;
        }

        foreach (var thing in map.thingGrid.ThingsAt(c))
        {
            if (thing is not Pawn pawn || !pawn.RaceProps.Humanlike)
            {
                continue;
            }

            foreach (var apparel in pawn.apparel.WornApparel)
            {
                if (apparel.def.defName == "Apparel_DustproofBoots")
                {
                    return false;
                }
            }
        }

        return true;
    }
}