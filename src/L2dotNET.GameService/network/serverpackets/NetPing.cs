namespace L2dotNET.GameService.Network.Serverpackets
{
    class NetPing
    {
        private readonly int _request;

        public NetPing(int request)
        {
            _request = request;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xd9);
            p.WriteInt(_request);
        }
    }
}