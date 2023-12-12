namespace OdinEye.Patches
{
    using HarmonyLib;
    using Models.Proto;

    [HarmonyPatch(typeof(Talker))]
    public class TalkerPatch
    {
        [HarmonyPatch(nameof(Talker.RPC_Say))]
        [HarmonyPrefix]
        protected static void Say(long sender, int ctype, UserInfo user, string text, string senderNetworkUserId)
        {
            // work the same as ChatOnNewMessage
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayerChat, $"Talker.Say: {user.Name} - {text}"));
        }
    }
}