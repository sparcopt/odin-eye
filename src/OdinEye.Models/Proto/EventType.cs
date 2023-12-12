namespace OdinEye.Models.Proto
{
    public enum EventType
    {
        Unknown = 0,
        PlayerJoin = 1,
        PlayerSpawn = 2,
        PlayerDeath = 3,
        PlayerDisconnect = 4,
        PlayerChat = 5,
        
        GameAwake = 50,
        GameQuit = 51,
        GameSleepStop = 52,
        WorldLoad = 53,
        WorldSave = 54,
        ServerShutdown = 55,
        GlobalKeyAdd = 56,
        GlobalKeyRemove = 57,
        
        RandomEventActivate = 100,
        RandomEventDeactivate = 101,
        RandomEventSet = 102
    }
}