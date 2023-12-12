namespace OdinEye.Patches
{
    using HarmonyLib;
    using Models.Proto;
    using UnityEngine;
    using EventType = Models.Proto.EventType;

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

            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.RandomEventSet , $"SetRandomEvent: {ev.m_name} - {ev.m_startMessage}"));
        }
    }
}