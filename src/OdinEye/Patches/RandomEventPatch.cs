namespace OdinEye.Patches
{
    using HarmonyLib;
    using System;

    [HarmonyPatch(typeof(RandomEvent))]
    public class RandomEventPatch
    {
        [HarmonyPatch(nameof(RandomEvent.OnActivate))]
        [HarmonyPrefix]
        protected static void OnActivate(RandomEvent __instance)
        {
            OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, $"RandomEvent.OnActivate: {__instance.m_name} active for {__instance.m_duration}"));
        }
        
        [HarmonyPatch(nameof(RandomEvent.OnDeactivate))]
        [HarmonyPrefix]
        protected static void OnDeactivate(RandomEvent __instance)
        {
            OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, $"RandomEvent.OnDeactivate: {__instance.m_name} was active for {__instance.m_duration}"));
        }
    }
}