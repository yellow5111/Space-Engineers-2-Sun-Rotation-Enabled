using HarmonyLib;
using Keen.Game2.Simulation.GameSystems.Sun;
using System.Reflection;

namespace SpaceEngineers2EnableSunRotation
{
    [HarmonyPatch(typeof(SunSessionComponent), "Init")]
    public class SunSessionComponent_EnableSunRotation
    {
        public static void Postfix(SunSessionComponent __instance)
        {
            var sunRotationField = typeof(SunSessionComponent).GetField("_sunRotation", BindingFlags.NonPublic | BindingFlags.Instance);

            if (sunRotationField != null)
            {
                
                sunRotationField.SetValue(__instance, true);
            }

            MethodInfo sunDataChangedMethod = typeof(SunSessionComponent).GetMethod("SunDataChanged", BindingFlags.NonPublic | BindingFlags.Instance);
            sunDataChangedMethod?.Invoke(__instance, null);
        }
    }
}
