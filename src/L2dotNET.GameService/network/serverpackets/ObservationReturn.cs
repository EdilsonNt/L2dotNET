namespace L2dotNET.GameService.Network.Serverpackets
{
    class ObservationReturn
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public ObservationReturn(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xe0);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
        }
    }
}