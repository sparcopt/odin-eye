namespace OdinEye.Patches
{
    using HarmonyLib;
    using System;

    [HarmonyPatch(typeof(EnvMan))]
    public class EnvManPatch
    {
        [HarmonyPatch(nameof(EnvMan.OnMorning))]
        [HarmonyPrefix]
        protected static void OnMorning()
        {
            // not working
            OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, "A new day has started!"));
        }
        
        [HarmonyPatch(nameof(EnvMan.OnEvening))]
        [HarmonyPrefix]
        protected static void OnEvening()
        {
            // not working
            OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, "Evening has started!"));
        }
        
        // [HarmonyPatch(nameof(EnvMan.SkipToMorning))]
        // [HarmonyPrefix]
        // protected static void SkipToMorning()
        // {
        //     EventHandler.Handle("A new day has started!");
        // }
    }
}