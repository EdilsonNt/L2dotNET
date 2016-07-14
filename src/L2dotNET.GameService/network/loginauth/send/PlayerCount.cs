namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class PlayerCount
    {
        private readonly short _cnt;

        public PlayerCount(short cnt)
        {
            _cnt = cnt;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xA3);
            p.WriteShort(_cnt);
        }
    }
}