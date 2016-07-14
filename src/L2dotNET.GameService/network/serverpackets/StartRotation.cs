namespace L2dotNET.GameService.Network.Serverpackets
{
    class StartRotation
    {
        private readonly int _sId;
        private readonly int _degree;
        private readonly int _side;
        private readonly int _speed;

        public StartRotation(int sId, int degree, int side, int speed)
        {
            _sId = sId;
            _degree = degree;
            _side = side;
            _speed = speed;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x62);
            p.WriteInt(_sId);
            p.WriteInt(_degree);
            p.WriteInt(_side);
            p.WriteInt(_speed);
        }
    }
}