namespace OdinEye.Patches
{
    using HarmonyLib;
    using System;

    [HarmonyPatch(typeof(Talker))]
    public class TalkerPatch
    {
        [HarmonyPatch(nameof(Talker.RPC_Say))]
        [HarmonyPrefix]
        protected static void Say(long sender, int ctype, UserInfo user, string text, string senderNetworkUserId)
        {
            // work the same as ChatOnNewMessage
            OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, $"Talker.Say: {user.Name} - {text}"));
        }
    }
}