namespace OdinEye.Patches
{
    using HarmonyLib;
    using System;
    using UnityEngine;

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
                    OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, "CHAT WHISPER " + logText));
                    break;
                case Talker.Type.Normal: // didnt work
                    OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, "CHAT NORMAL " + logText));
                    break;
                case Talker.Type.Shout:
                    OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, "CHAT SHOUT " + logText));
                    break;
                case Talker.Type.Ping:
                    OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, "PING " + logText));
                    break;
                default:
                    OdinEyePlugin.Instance.EventHandler.Handle(new GameEvent(DateTime.UtcNow, $"Unknown chat type {type}"));
                    break;
            }
        }
    }
}