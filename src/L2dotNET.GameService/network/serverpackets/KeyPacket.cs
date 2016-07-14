namespace L2dotNET.GameService.Network.Serverpackets
{
    class KeyPacket
    {
        private readonly byte[] _key;
        private byte _next;

        public KeyPacket(GameClient client, byte n)
        {
            _key = client.EnableCrypt();
            _next = n;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x00);
            p.WriteInt(0x01);
            WriteB(_key);
            p.WriteInt(0x01);
            p.WriteInt(0x01);
        }
    }
}