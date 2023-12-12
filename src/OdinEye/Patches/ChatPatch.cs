namespace OdinEye.Patches
{
    using HarmonyLib;
    using Models.Proto;
    using UnityEngine;
    using EventType = Models.Proto.EventType;

    [HarmonyPatch(typeof(Chat))]
    public class ChatPatch
    {
        [HarmonyPatch(nameof(Chat.OnNewChatMessage))]
        [HarmonyPrefix]
        protected static void OnNewChatMessage(
            GameObject go, 
            long senderID, 
            Vector3 pos, 
            Talker.Type type, 
            UserInfo user, 
            string text, 
            string senderNetworkUserId)
        {
            var logText = $"user {user.Name} said: {text}";
            
            switch (type)
            {
                case Talker.Type.Whisper: // didnt work
                    OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayerChat, "CHAT WHISPER " + logText));
                    break;
                case Talker.Type.Normal: // didnt work
                    OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayerChat, "CHAT NORMAL " + logText));
                    break;
                case Talker.Type.Shout:
                    OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayerChat, "CHAT SHOUT " + logText));
                    break;
                case Talker.Type.Ping:
                    OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayerChat, "PING " + logText));
                    break;
                default:
                    OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayerChat, $"Unknown chat type {type}"));
                    break;
            }
        }
    }
}