namespace L2dotNET.GameService.Network.Serverpackets
{
    class TradeDone
    {
        private readonly bool _done;

        public TradeDone(bool done = true)
        {
            _done = done;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x1c);
            p.WriteInt(_done ? 1 : 0);
        }
    }
}