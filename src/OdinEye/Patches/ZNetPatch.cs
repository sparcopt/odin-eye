namespace OdinEye.Patches
{
    using Extensions;
    using HarmonyLib;
    using Models.Proto;
    using System.Collections.Generic;
    using System.Linq;

    [HarmonyPatch(typeof(ZNet))]
    public class ZNetPatch
    {
        private static HashSet<ZDOID> deadPlayers = new HashSet<ZDOID>();
        
        [HarmonyPatch(nameof(ZNet.RPC_PeerInfo))]
        [HarmonyPostfix]
        protected static void RPC_PeerInfo(ZNet __instance, ZRpc rpc, ZPackage pkg)
        {
            var peer = __instance.GetPeer(rpc);
            
            // If the server join succeeds, the peer is added to m_zdoman
            if (__instance.m_zdoMan.m_peers.Any(zdoPeer => zdoPeer.m_peer == peer))
            {
                OdinEyePlugin.Instance.EventHandler.Handle(
                    GameEvent.New(EventType.PlayerJoin, $"Player has joined: {peer.m_playerName}", peer.ToPlayer()));
            }
        }
        
        [HarmonyPatch(nameof(ZNet.RPC_CharacterID))]
        [HarmonyPostfix]
        protected static void OnRPCCharId(ZNet __instance, ZRpc rpc)
        {
            // worked
            // but when a player dies, this is executed two times
            var peer = __instance.GetPeer(rpc);
            // If ZDOID.None means that player has previously died
            // Ignore it, since a new call will be made with a valid ZDOID
            if (peer.m_characterID != ZDOID.None)
            {
                OdinEyePlugin.Instance.EventHandler.Handle(
                    GameEvent.New(EventType.PlayerSpawn, $"Player has spawned: {peer.m_playerName}", peer.ToPlayer()));
            }
            //EventHandler.Handle($"Player details: ZDOID: {peer.m_characterID} UID: {peer.m_uid} SocketHostName: {peer.m_socket.GetHostName()}");

            // foreach (var data in peer.m_serverSyncedPlayerData)
            // {
            //     // this looks empty when the player joins
            //     // after death, this is populated with server events and a base value (?)
            //     // possibleEvents - army_eikthyr,boss_eikthyr,boss_bonemass,boss_moder,boss_gdking,boss_goblinking,boss_queen
            //     EventHandler.Handle($"Synced data: {data.Key} - {data.Value}");
            // }
        }
        
        [HarmonyPatch(nameof(ZNet.RPC_Disconnect))]
        [HarmonyPrefix]
        protected static void Disco(ZNet __instance, ZRpc rpc)
        {
            var peer = __instance.GetPeer(rpc);
            OdinEyePlugin.Instance.EventHandler.Handle(
                GameEvent.New(EventType.PlayerDisconnect, $"Player disconnected: {peer.m_playerName}", peer.ToPlayer()));
        }
        
        [HarmonyPatch(nameof(ZNet.LoadWorld))]
        [HarmonyPostfix]
        protected static void OnLoadWorld(ZNet __instance)
        {
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.WorldLoad, "World loaded!"));

            __instance.StartCoroutine(OdinEyePlugin.Instance.StatsSnapshotCoroutine.SendGameStatsSnapshotCoroutine());
            //OdinEyePlugin.Instance.StartSendGameStatsSnapshotCoroutine();
        }
        
        [HarmonyPatch(nameof(ZNet.SaveWorld))]
        [HarmonyPostfix]
        protected static void SaveWorld()
        {
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.WorldSave, "World was saved!"));
        }
        
        [HarmonyPatch(nameof(ZNet.Shutdown))]
        [HarmonyPrefix]
        protected static void OnShutdown()
        {
            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.ServerShutdown, "Shutdown triggered!"));
        }
        
        [HarmonyPatch(nameof(ZNet.SendPeriodicData))]
        [HarmonyPrefix]
        protected static void SendPeriodicData(ZNet __instance)
        {
            foreach (var peer in __instance.m_peers)
            {
                if (peer.IsReady() && !peer.m_characterID.IsNone())
                {
                    var zdo = ZDOMan.instance.GetZDO(peer.m_characterID);
                    if (zdo == null)
                    {
                        return;
                    }
                    
                    if (zdo.GetBool(ZDOVars.s_dead))
                    {
                        if (deadPlayers.Add(zdo.m_uid))
                        {
                            OdinEyePlugin.Instance.EventHandler.Handle(GameEvent.New(EventType.PlayerDeath, $"Player died: {peer.m_playerName}"));
                        }
                    }
                    else
                    {
                        deadPlayers.Remove(zdo.m_uid);
                    }
                }
            }
        }
    }
}