namespace L2dotNET.GameService.Network.Serverpackets
{
    class RadarControl
    {
        private readonly int _showRadar;
        private readonly int _type;
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public RadarControl(int showRadar, int type, int x, int y, int z)
        {
            _showRadar = showRadar; // 0 = showradar; 1 = delete radar;
            _type = type;
            _x = x;
            _y = y;
            _z = z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xEB);
            p.WriteInt(_showRadar);
            p.WriteInt(_type);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
        }
    }
}