using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots;

[HarmonyPatch(typeof(Pawn_FilthTracker), nameof(Pawn_FilthTracker.Notify_EnteredNewCell), [])]
public static class Pawn_FilthTracker_Notify_EnteredNewCell
{
    public static bool Prefix(Pawn_FilthTracker __instance, Pawn ___pawn)
    {
        if (!___pawn.Spawned || !___pawn.RaceProps.Humanlike)
        {
            return true;
        }

        foreach (var apparel in ___pawn.apparel.WornApparel)
        {
            if (apparel.def.defName == "Apparel_DustproofBoots")
            {
                return false;
            }
        }

        return true;
    }
}