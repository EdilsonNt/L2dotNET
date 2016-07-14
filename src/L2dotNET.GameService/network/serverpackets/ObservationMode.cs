namespace L2dotNET.GameService.Network.Serverpackets
{
    class ObservationMode
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public ObservationMode(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xdf);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
            p.WriteInt(0x00);
            p.WriteInt(0xc0);
            p.WriteInt(0x00);
        }
    }
}