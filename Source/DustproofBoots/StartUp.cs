using System.Reflection;
using HarmonyLib;
using Verse;

namespace DustproofBoots;

[StaticConstructorOnStartup]
public static class StartUp
{
    static StartUp()
    {
        new Harmony("DustproofBoots.AKreedz").PatchAll(Assembly.GetExecutingAssembly());
    }
}