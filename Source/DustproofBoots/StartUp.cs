using System.Reflection;
using HarmonyLib;
using Verse;

namespace DustproofBoots
{
    // Token: 0x02000002 RID: 2
    [StaticConstructorOnStartup]
    public static class StartUp
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        static StartUp()
        {
            new Harmony("DustproofBoots.AKreedz").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}