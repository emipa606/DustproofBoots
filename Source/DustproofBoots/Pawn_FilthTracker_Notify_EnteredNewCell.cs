using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots;

[HarmonyPatch(typeof(Pawn_FilthTracker), "Notify_EnteredNewCell", [])]
public static class Pawn_FilthTracker_Notify_EnteredNewCell
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
            if (apparel.def.defName == "Apparel_DustproofBoots")
            {
                return false;
            }
        }

        return true;
    }
}