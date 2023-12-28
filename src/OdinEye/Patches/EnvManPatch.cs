namespace OdinEye.Patches
{
    using HarmonyLib;
    using Models.Proto;

    [HarmonyPatch(typeof(EnvMan))]
    public class EnvManPatch
    {   
        // This is executed when the server boots
        // Might add a redundant message - not a critical issue
        [HarmonyPatch(nameof(EnvMan.UpdateTriggers))]
        [HarmonyPrefix]
        protected static void UpdateTriggers(float oldDayFraction, float newDayFraction, Heightmap.Biome biome, float dt)
        {
            if (oldDayFraction > 0.20000000298023224 && oldDayFraction < 0.25 && newDayFraction > 0.25 && newDayFraction < 0.30000001192092896)
            {
                var day = EnvMan.instance.GetCurrentDay();
                OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.EnvironmentMorningStart, $"MORNING STARTED, day: {day}"));
            }

            if (oldDayFraction <= 0.699999988079071 || oldDayFraction >= 0.75 || newDayFraction <= 0.75 || newDayFraction >= 0.800000011920929)
            {
                return;
            }
            
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.EnvironmentEveningStart, "EVENING STARTED"));
        }
    }
}