namespace OdinEye.Extensions
{
    using NGuid;
    using System;

    public static class NameBasedGuid
    {
        private static readonly Guid NamespaceId = new Guid("4b01a09a-9b18-493c-9877-4786611eeea2");

        public static Guid NewPlayerGuid(string steamId, string playerName) => GuidHelpers.CreateFromName(NamespaceId, steamId + playerName);
    }
}