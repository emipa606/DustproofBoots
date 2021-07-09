using HarmonyLib;
using RimWorld;
using Verse;

namespace DustproofBoots
{
    // Token: 0x02000005 RID: 5
    [HarmonyPatch(typeof(FilthMaker), "TryMakeFilth", typeof(IntVec3), typeof(Map), typeof(ThingDef), typeof(int),
        typeof(FilthSourceFlags))]
    public static class Harmony_DropTrashNotify
    {
        // Token: 0x06000004 RID: 4 RVA: 0x00002200 File Offset: 0x00000400
        public static bool Prefix(IntVec3 c, Map map, ThingDef filthDef, int count = 1,
            FilthSourceFlags additionalFlags = FilthSourceFlags.None)
        {
            if (filthDef == null || filthDef != ThingDefOf.Filth_Trash)
            {
                return true;
            }

            if (map == null || !map.IsPlayerHome)
            {
                return true;
            }

            foreach (var thing in map.thingGrid.ThingsAt(c))
            {
                if (thing is not Pawn pawn || !pawn.RaceProps.Humanlike)
                {
                    continue;
                }

                foreach (var apparel in (thing as Pawn).apparel.WornApparel)
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
}