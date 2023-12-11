namespace OdinEye.Patches
{
    using HarmonyLib;
    using System;
    using UnityEngine;

    [HarmonyPatch(typeof(RandEventSystem))]
    public class RandomEventSystemPatch
    {
        [HarmonyPatch(nameof(RandEventSystem.SetRandomEvent))]
        [HarmonyPostfix]
        protected static void OnSetRandomEvent(RandomEvent ev, Vector3 pos)
        {
            if (ev == null)
            {
                return;
            }

            OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, $"SetRandomEvent: {ev.m_name} - {ev.m_startMessage}"));
        }
    }
}