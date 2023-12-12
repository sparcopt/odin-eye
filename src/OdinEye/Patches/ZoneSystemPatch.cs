namespace OdinEye.Patches
{
    using HarmonyLib;
    using Models.Proto;

    [HarmonyPatch(typeof(ZoneSystem))]
    public class ZoneSystemPatch
    {
        [HarmonyPatch(nameof(ZoneSystem.RPC_SetGlobalKey))]
        [HarmonyPrefix]
        protected static void RPC_SetGlobalKey(string name)
        {
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.GlobalKeyAdd, $"GlobalKey added: {name}"));
        }
        
        [HarmonyPatch(nameof(ZoneSystem.RPC_RemoveGlobalKey))]
        [HarmonyPrefix]
        protected static void RPC_RemoveGlobalKey(string name)
        {
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.GlobalKeyRemove, $"GlobalKey removed: {name}"));
        }
    }
}