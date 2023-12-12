namespace OdinEye.Patches
{
    using HarmonyLib;
    using Models.Proto;

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
        
        [HarmonyPatch(nameof(Game.SleepStop))]
        [HarmonyPostfix]
        protected static void SleepStop(long sender)
        {
            var day = EnvMan.instance.GetCurrentDay();
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.GameSleepStop, $"A new day has started! Day {day}"));
        }
    }
}