namespace OdinEye.Patches
{
    using HarmonyLib;
    using Models.Proto;
    using System.Linq;

    [HarmonyPatch(typeof(Game))]
    public class GamePatch
    {
        [HarmonyPatch(nameof(Game.Awake))]
        [HarmonyPrefix]
        protected static void Awake()
        {
            // worked
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.GameAwake, "Game.Awake (server launch?)"));
        }
        
        [HarmonyPatch(nameof(Game.OnApplicationQuit))]
        [HarmonyPrefix]
        protected static void OnApplicationQuit()
        {
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.GameQuit, "Game.OnApplicationQuit (server stop?)"));
        }
        
        [HarmonyPatch(nameof(Game.SleepStart))]
        [HarmonyPrefix]
        protected static void SleepStart(long sender)
        {
            var playerNames = string.Join(", ", ZNet.instance.m_peers.Select(p => p.m_playerName));
            var message = $"Players {playerNames} went to sleep";
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayersSleepStart, message));
        }
        
        [HarmonyPatch(nameof(Game.SleepStop))]
        [HarmonyPrefix]
        protected static void SleepStop(long sender)
        {
            var playerNames = string.Join(", ", ZNet.instance.m_peers.Select(p => p.m_playerName));
            var message = $"Players {playerNames} woke up";
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayerSleepStop, message));
        }
    }
}